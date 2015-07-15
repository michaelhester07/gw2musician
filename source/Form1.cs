using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace midiKeyboarder
{
    public partial class Form1 : Form
    {
       

        public static List<section> sections;
        public static List<instrument> instruments;

       public int selectedInstrument = -1;
       public int renderRange = 2;
        MidiKeyboardInputDriver inputDriver;
        MultiBoxDriver mbDriver;

        Midi.OutputDevice monitor;


       public static KeyboardDriver standardDriver = new KeyboardDriver();
       public static KeyboardDriver bassDriver = new KeyboardDriver();
       public static KeyboardDriver fluteDriver = new KeyboardDriver();
       public static KeyboardDriver drumDriver = new KeyboardDriver();


        public Form1()
        {
            InitializeComponent();
            instruments = new List<instrument>();
            sections = new List<section>();
            
        }
        public List<section.note> selectedNotes = new List<section.note>();
        public List<section.note> noteClipboard = new List<section.note>();

        public void copy()
        {
            noteClipboard.Clear();
            foreach (var n in selectedNotes)
            {
                section.note xn = new section.note();
                xn.pitch = n.pitch;
                xn.time = n.time;
                xn.duration = n.duration;
                noteClipboard.Add(xn);
            }
        }
        public void delete()
        {
            foreach(var n in selectedNotes)
            {
                if (selectedInstrument >= 0)
                    sections[selectedInstrument].notes.Remove(n);
            }
            selectedNotes.Clear();
            renderSections();
        }
        public void cut()
        {
            copy();
            delete();
        }
        public void paste()
        {
            if (noteClipboard.Count == 0)
                return;
            float timeoffset = time - noteClipboard[0].time;
            foreach (var n in noteClipboard)
            {
                if (selectedInstrument >= 0)
                {
                    section.note xn = new section.note();
                    xn.pitch = n.pitch;
                    xn.time = n.time + timeoffset;
                    xn.duration = n.duration;
                   // n.time += timeoffset;
                    sections[selectedInstrument].notes.Add(xn);
                }
            }
            renderSections();
        }

        void inputDriver_NoteOff(Midi.NoteOffMessage msg)
        {
            //throw new NotImplementedException();
        }

        void inputDriver_NoteOn(Midi.NoteOnMessage msg)
        {
            //throw new NotImplementedException();
        }
        int getNoteOctave(string note)
        {
            return int.Parse("" + note[note.Length - 1]);

        }
        int findBass()
        {
            foreach (instrument i in instruments)
                if (i.mytype == instrument.instrumentType.bass)
                    return instruments.IndexOf(i);
            return -1;
        }
        List<section.note> notesOn = new List<section.note>();
        void inputDriver_NoteOnString(string note)
        {

            if(recording)
            {
                if (selectedInstrument >= 0)
                {

                  var n =   sections[selectedInstrument].addNote(note, time, 1/16.0f);
                  notesOn.Add(n);

                }

            }

            if (!recording )
            {
                int oct = getNoteOctave(note);
                if (selectedInstrument >= 0 && oct >= 3)
                {
                    instruments[selectedInstrument].play(note);
                }
                if (oct <= 2)
                {
                    int bass = findBass();
                    if (bass >= 0)
                        instruments[bass].play(note);
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var inputdevices = Midi.InputDevice.InstalledDevices;
            var outputdevices = Midi.OutputDevice.InstalledDevices;

            foreach(var id in inputdevices)
            {
                cbxInputDevices.Items.Add(id.Name);

            }
            foreach(var od in outputdevices)
            {
                cbxOutputDevices.Items.Add(od.Name);
            }
            if (cbxInputDevices.Items.Count == 0)
                cbConnectInput.Enabled = false;
            if (cbxOutputDevices.Items.Count == 0)
                cbConnectOutput.Enabled = false;
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void cbRunServer_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void cbFlat_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void cbConnectInput_CheckedChanged(object sender, EventArgs e)
        {
            if(cbConnectInput.Checked)
            {
                inputDriver = new MidiKeyboardInputDriver();
                inputDriver.NoteOn += inputDriver_NoteOn;
                inputDriver.NoteOff += inputDriver_NoteOff;
                inputDriver.NoteOnString += inputDriver_NoteOnString;
                inputDriver.NoteOffString += inputDriver_NoteOffString;
                if (monitor != null)
                    inputDriver.setMonitor(monitor);
                inputDriver.start(Midi.InputDevice.InstalledDevices[cbxInputDevices.SelectedIndex]);   
            }
            else
            {
                inputDriver.stop();
            }
        }

        void inputDriver_NoteOffString(string note)
        {
            List<section.note> removeme = new List<section.note>();
            if (selectedInstrument >= 0)
                {


                    foreach (var n in notesOn)
                        if (n.pitch == note)
                            removeme.Add(n);
                    foreach (var n in removeme)
                        notesOn.Remove(n);
            }
        }

        private void cbConnectOutput_CheckedChanged_1(object sender, EventArgs e)
        {
            if (cbConnectOutput.Checked)
            {
                monitor = Midi.OutputDevice.InstalledDevices[cbxOutputDevices.SelectedIndex];
                monitor.Open();
                monitor.SendProgramChange(Midi.Channel.Channel1, Midi.Instrument.AcousticGrandPiano);
                if (monitor.Name.Contains("Microsoft"))
                    monitor.SendControlChange(Midi.Channel.Channel1, Midi.Control.Volume, 127);
                    
            }
            else
            {
                monitor.SilenceAllNotes();
                monitor.Close();
                monitor = null;
            }
            if (inputDriver != null && cbConnectInput.Checked)
                inputDriver.setMonitor(monitor);
        }
        instrumentPanel addInstrumentPanel(int id)
        {
            instrumentPanel ip = new instrumentPanel();
            ip.instrumentID = id;
            ip.MouseUp += ip_MouseUp;
            instrumentList.Controls.Add(ip);
            ip.setInstrument(ip.instrumentID);
            return ip;
        }
        void addSection(instrumentPanel ip, int sectionid)
        {
            sectionPanel sp = new sectionPanel();
            sp.mysectionid = sectionid;
            instrumentSectionList.Controls.Add(sp);
            sp.myform = this;
            sp.drawSection(time, scrollTime, 4);
        }
        public void selectUIInstrument(int id)
        {
            var ip = selectInstrument(id);
            highlightInstrument(ip);
        }
        private void btnAddInstrument_Click(object sender, EventArgs e)
        {
            instruments.Add(new instrument());
            var ip = addInstrumentPanel(instruments.Count - 1);
            var section = new section();
            sections.Add(section);
            section.instrumentid = ip.instrumentID;
            addSection(ip, ip.instrumentID);
            highlightInstrument(ip);
            

        }
        instrumentPanel selectInstrument(int id)
        {
            foreach (Control c in instrumentList.Controls)
            {
                instrumentPanel cp = c as instrumentPanel;
                if (cp != null)
                    if (cp.instrumentID == id)
                        return cp;
            }
            return null;

        }
        sectionPanel selectSection(int id)
        {
            foreach (Control c in instrumentSectionList.Controls)
            {
                sectionPanel cp = c as sectionPanel;
                if (cp != null)
                    if (cp.mysectionid == id)
                        return cp;
            }
            return null;

        }
        void ip_MouseUp(object sender, MouseEventArgs e)
        {
            foreach(Control c in instrumentList.Controls)
            {
                instrumentPanel cp = c as instrumentPanel;
                if (cp != null)
                    cp.BackColor = Color.Silver;
            }

            instrumentPanel ip = (instrumentPanel)sender;
            selectedInstrument = ip.instrumentID;
            ip.BackColor = Color.LawnGreen;
        }
        void highlightInstrument( instrumentPanel ip)
        {
            foreach (Control c in instrumentList.Controls)
            {
                instrumentPanel cp = c as instrumentPanel;
                if (cp != null)
                    cp.BackColor = Color.Silver;
            }

            //instrumentPanel ip = (instrumentPanel)sender;
            selectedInstrument = ip.instrumentID;
            ip.BackColor = Color.LawnGreen;
        }
        private void btnRemoveInstrument_Click(object sender, EventArgs e)
        {
            var ip = selectInstrument(selectedInstrument);
            instruments.RemoveAt(selectedInstrument);
            sections.RemoveAt(selectedInstrument);
            instrumentSectionList.Controls.RemoveAt(selectedInstrument);
            instrumentList.Controls.Remove(ip);
            ip.Dispose();
            var ip2 = selectInstrument(0);
            if(ip2 != null)
                highlightInstrument(ip2);
        }

        bool recording = false;
        bool playing = false;
        public float time = 0;
        public float scrollTime = 0;

        float lastmidiRead = 0;
        Midi.Clock recordingClock;
       public  int timesig = 4;
        public void renderSections()
        {
            foreach(Control c in instrumentSectionList.Controls)
            {
                sectionPanel sp = c as sectionPanel;
                if (sp != null)
                    sp.drawSection(time, scrollTime, timesig);

            }
            tickLabel.Text = string.Format("{0}.{1}.{2}", (int)(time / 4)+1, (int)(time % 4)+1, Math.Round(time - (int)time, 2)*100);

        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            if (!recording)
            {
                btnSeekStart.Image = Properties.Resources.stop;
                playing = true;
                recording = true;
                recordingClock = new Midi.Clock(float.Parse(tbBPM.Text));
                time -= 4;
                recordingClock.Start();
                playTimer.Start();
            }
            else
                recording = false;
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd); 

        private void btnPlay_Click(object sender, EventArgs e)
        {

            var procs = System.Diagnostics.Process.GetProcesses();
            //find the guildwars window and focus it
            var Guildwars2 = System.Diagnostics.Process.GetProcessesByName("Gw2");
            if (Guildwars2.Length != 0)
                SetForegroundWindow(Guildwars2[0].MainWindowHandle);


            btnSeekStart.Image = Properties.Resources.stop;
            playing = true;
            recordingClock = new Midi.Clock(float.Parse(tbBPM.Text));
            recordingClock.Start();
            playTimer.Start();
            monitorNotesOn.Clear();
        }

        protected override void OnClosed(EventArgs e)
        {
            standardDriver.stop();
            bassDriver.stop();
            fluteDriver.stop();
            drumDriver.stop();
            Program.killAllThreads = true;

            base.OnClosed(e);
            Application.Exit();
        }

        private void btnSeekStart_Click(object sender, EventArgs e)
        {
            if (!playing && !recording)
            {
                time = 0; scrollTime = 0; lastmidiRead = 0;
                
                renderSections();
            }
            if (playing)
            {
                playing = false;
                playTimer.Stop();
                if(monitor != null)
                    monitor.SilenceAllNotes();
            }
            if (recording)
            {
                recording = false;
            }
            btnSeekStart.Image = Properties.Resources.seek;
           
        }
        List<section.note> monitorNotesOn = new List<section.note>();
        void monitorNoteOn(Object o)
        {
            section.note n = (section.note)o;
            int pos = 0;
            Midi.Note xn = Midi.Note.ParseNote(n.pitch, ref pos);
            pos = int.Parse("" + n.pitch[n.pitch.Length - 1]);
            System.Diagnostics.Trace.WriteLine("noteon " + n.pitch);
            if (monitor != null)
            {

                monitor.SendNoteOn(Midi.Channel.Channel1, xn.PitchInOctave(pos), 64);
               // System.Threading.Thread.Sleep((int)(1000 * n.duration));
               // monitor.SendNoteOff(Midi.Channel.Channel1, xn.PitchInOctave(pos), 64);
            }
        }
        void monitorNoteOff(Object o)
        {
            section.note n = (section.note)o;
            int pos = 0;
            Midi.Note xn = Midi.Note.ParseNote(n.pitch, ref pos);
            pos = int.Parse("" + n.pitch[n.pitch.Length - 1]);
            System.Diagnostics.Trace.WriteLine("noteoff " + n.pitch);
            if (monitor != null)
            {

               // monitor.SendNoteOn(Midi.Channel.Channel1, xn.PitchInOctave(pos), 64);
                //System.Threading.Thread.Sleep((int)(1000 * n.duration));
                
                monitor.SendNoteOff(Midi.Channel.Channel1, xn.PitchInOctave(pos), 0);
            }
        }
        public void quickPlay(section.note n)
        {
            if (monitor == null)
                return;
            System.Threading.Thread playthread = new System.Threading.Thread(monitorPlay);
            playthread.Start(n);
        }
        void monitorPlay(object o)
        {
            section.note n = (section.note)o;
            int pos = 0;
            Midi.Note xn = Midi.Note.ParseNote(n.pitch, ref pos);
            pos = int.Parse("" + n.pitch[n.pitch.Length - 1]);
            System.Diagnostics.Trace.WriteLine("noteoff " + n.pitch);
             monitor.SendNoteOn(Midi.Channel.Channel1, xn.PitchInOctave(pos), 64);
            System.Threading.Thread.Sleep((int)(1000));

            monitor.SendNoteOff(Midi.Channel.Channel1, xn.PitchInOctave(pos), 0);
        }

        //metronome stuff
        int lastMetro = 0;
        System.Media.SoundPlayer metronomeLow;
        System.Media.SoundPlayer metronomeHigh;
        void playMetro()
        {
            if (cbMetronome.Checked == false)
                return;
            if(metronomeLow == null)
            {
                metronomeLow = new System.Media.SoundPlayer("resources\\metronomeLow.wav");
                metronomeHigh = new System.Media.SoundPlayer("resources\\metronomeHigh.wav");
                

            }
            int currentMetro = (int)time;
            if(currentMetro != lastMetro)
            {
                bool high = (currentMetro % timesig) == 0;
                if (high)
                    metronomeHigh.Play();
                else
                    metronomeLow.Play();
                lastMetro = currentMetro;
            }


        }

        private void playTimer_Tick(object sender, EventArgs e)
        {
            if(playing)
            {
                float currentmidiread = recordingClock.Time;
                float deltaTime = currentmidiread - lastmidiRead;
                lastmidiRead = currentmidiread;

                time += deltaTime;
                //sections[selectedInstrument]
                //tickLabel.Text = string.Format("{0}.{1}.{2}", (int)(time / 4), (int)(time %4), time - (time%4));
                if (time > renderRange *2)
                    scrollTime = time - renderRange * 2;

                renderSections();
                if(recording)
                {
                    foreach (var note in notesOn)
                        note.duration = time - note.time;



                }
                playMetro();
                if (!recording)
                {
                    List<section.note> monitorNotesOff = new List<section.note>();
                    for (int i = 0; i < monitorNotesOn.Count; i++)
                    {
                        double mo = monitorNotesOn[i].monitorOn -= deltaTime;
                        if (mo < 0)
                            monitorNotesOff.Add(monitorNotesOn[i]);
                        
                    }
                    for (int i = 0; i < monitorNotesOff.Count;i++)
                    {
                        monitorNoteOff(monitorNotesOff[i]);
                        monitorNotesOn.Remove(monitorNotesOff[i]);
                    }

                        foreach (section s in sections)
                        {
                            var notes = s.notes;
                            foreach (var n in notes)
                            {
                                if(!n.playing && n.time < time && n.time + n.duration > time)
                                {
                                    n.playing = true;
                                    monitorNoteOn(n);
                                    //n.monitorOn = n.duration;
                                    //monitorNotesOn.Add(n);
                                    int oct = getNoteOctave(n.pitch);
                                    if (instruments[s.instrumentid].mytype == instrument.instrumentType.standard && oct >= 3)
                                    {
                                        instruments[s.instrumentid].play(n.pitch);
                                    }
                                    else if (instruments[s.instrumentid].mytype == instrument.instrumentType.standard && oct <= 2)
                                    {
                                        int bass = findBass();
                                        if (bass >= 0)
                                            instruments[bass].play(n.pitch);
                                    }
                                    else
                                    { instruments[s.instrumentid].play(n.pitch); }


                                    
                                }
                                if (n.playing && n.time + n.duration < time)
                                {
                                    monitorNoteOff(n);
                                    n.playing = false;
                                }
                               

                            }
                            //play the note in the monitor


                        }
                    
                }


            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.xml|*.xml";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return;

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            var ele =doc.CreateElement("song");
            doc.AppendChild(ele);
            var ix = instrument.save(doc, instruments);
            var sx = section.save(doc, sections);
            ele.AppendChild(ix);
            ele.AppendChild(sx);
            doc.Save(sfd.FileName);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.xml|*.xml";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return;
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(ofd.FileName);
            var ix = doc.GetElementsByTagName("instruments")[0];
            instruments = instrument.Load((System.Xml.XmlElement)ix);
            var sx = doc.GetElementsByTagName("Sections")[0];
            sections = section.Load((System.Xml.XmlElement)sx);
            instrumentList.Controls.Clear();
            instrumentSectionList.Controls.Clear();
            for(int i = 0; i < instruments.Count; i++)
            {
                var ip = addInstrumentPanel(i);
                addSection(ip, ip.instrumentID);
            }

        }

        private void btnDeleteSection_Click(object sender, EventArgs e)
        {
            if (selectedInstrument >= 0)
            {
                sections[selectedInstrument].notes.Clear();
                renderSections();
            }
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
                copy();
            if (e.Control && e.KeyCode == Keys.X)
                cut();
            if (e.Control && e.KeyCode == Keys.V)
                paste();
            if (e.KeyCode == Keys.Delete)
                delete();
        }

        private void tbTimeSig_Click(object sender, EventArgs e)
        {
            int outint;
            if (int.TryParse(tbTimeSig.Text, out outint))
                timesig = outint;
            renderSections();
        }
        public int addlength = 8;
        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }
        public int addOctave = 3;
        public float autoAdvance = 1 / 8.0f;
        private void tbAutoAdvance_Click(object sender, EventArgs e)
        {
            int outint;
            if (int.TryParse(tbAutoAdvance.Text, out outint))
            {
                if (outint == 0)
                    autoAdvance = 0;
                else
                    autoAdvance =1 / (float)outint;
            }
            renderSections();
        }
        
    }
}

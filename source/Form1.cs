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

        int selectedInstrument = -1;
        
        MidiKeyboardInputDriver inputDriver;
        MultiBoxDriver mbDriver;

        Midi.OutputDevice monitor;

        public Form1()
        {
            InitializeComponent();
            instruments = new List<instrument>();
            sections = new List<section>();
            
        }

        private void cbConnect_CheckedChanged(object sender, EventArgs e)
        {
           

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

            if (!recording && !playing)
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

        private void cbConnectOutput_CheckedChanged(object sender, EventArgs e)
        {
            
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
        private void btnAddInstrument_Click(object sender, EventArgs e)
        {
            instruments.Add(new instrument());
            var ip = addInstrumentPanel(instruments.Count - 1);

            sections.Add(new section());
            addSection(ip, ip.instrumentID);
            
            

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

        public void renderSections()
        {
            foreach(Control c in instrumentSectionList.Controls)
            {
                sectionPanel sp = c as sectionPanel;
                if (sp != null)
                    sp.drawSection(time, scrollTime, 4);

            }
            tickLabel.Text = time.ToString();

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

        private void btnPlay_Click(object sender, EventArgs e)
        {
            btnSeekStart.Image = Properties.Resources.stop;
            playing = true;
            recordingClock = new Midi.Clock(float.Parse(tbBPM.Text));
            recordingClock.Start();
            playTimer.Start();
            monitorNotesOn.Clear();
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
                monitor.SendNoteOff(Midi.Channel.Channel1, xn.PitchInOctave(pos), 64);
            }
        }

        void monitorPlay(object o)
        {
           
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
                tickLabel.Text = time.ToString();
                if (time > 4)
                    scrollTime = time - 4;

                renderSections();
                if(recording)
                {
                    foreach (var note in notesOn)
                        note.duration = time - note.time;



                }
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
                            var notes = s.play(time - 1/64.0f, time + 1/64.0f);
                            foreach (var n in notes)
                            {
                                if (!monitorNotesOn.Contains(n))
                                {
                                    monitorNoteOn(n);
                                    n.monitorOn = n.duration;
                                    monitorNotesOn.Add(n);
                                }
                                //instruments[s.instrumentid].play(n.pitch);

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
       
        
    }
}

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

       


        KeyboardDriver gw2KeyDriver;
        MidiKeyboardInputDriver inputDriver;
        MultiBoxDriver mbDriver;

        Midi.OutputDevice monitor;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Midi.Pitch outpitch;
           

            

            foreach (Midi.InputDevice dev in Midi.InputDevice.InstalledDevices)
                cbInputDevice.Items.Add(dev.Name);

            foreach (Midi.OutputDevice dev in Midi.OutputDevice.InstalledDevices)
                cbOutputDevice.Items.Add(dev.Name);

            if (cbInputDevice.Items.Count != 0)
                cbInputDevice.SelectedIndex = 0;
            if (cbOutputDevice.Items.Count != 0)
                cbOutputDevice.SelectedIndex = 0;

            if (cbInputDevice.Items.Count == 0)
            {
                cbConnect.Enabled = false;
                
            }
            if (cbOutputDevice.Items.Count == 0)
                cbConnectOutput.Enabled = false;

            mbDriver = new MultiBoxDriver();
            
        }

        private void cbConnect_CheckedChanged(object sender, EventArgs e)
        {
            if(cbConnect.Checked)
            {
                
                inputDriver = new MidiKeyboardInputDriver();
                inputDriver.NoteOnString += inputDriver_NoteOnString;
                inputDriver.NoteOn += inputDriver_NoteOn;
                inputDriver.NoteOff += inputDriver_NoteOff;
                inputDriver.start(Midi.InputDevice.InstalledDevices[cbInputDevice.SelectedIndex]);
              
                

            }
            else
            {
                inputDriver.stop();

            }
        }

        void inputDriver_NoteOff(Midi.NoteOffMessage msg)
        {
            //throw new NotImplementedException();
        }

        void inputDriver_NoteOn(Midi.NoteOnMessage msg)
        {
            //throw new NotImplementedException();
        }

        void inputDriver_NoteOnString(string note)
        {
           // throw new NotImplementedException();
            //note:  "ASharp4"
            // "G3"
            //bass notes:  C1 through B2
            //Treble notes:  C3 through C6
            int octave = int.Parse(""+note[note.Length - 1]);
            if (octave < 3)
                mbDriver.sendMsg(note);
            else
                gw2KeyDriver.play(note);

        }

        private void cbConnectOutput_CheckedChanged(object sender, EventArgs e)
        {
            if(cbConnectOutput.Checked)
            {
                monitor = Midi.OutputDevice.InstalledDevices[cbOutputDevice.SelectedIndex];
                monitor.Open();
                if (inputDriver != null)
                    inputDriver.setMonitor(monitor);

            }
            else
            {
                if (monitor != null)
                    monitor.Close();
                monitor = null;
                if (inputDriver != null)
                    inputDriver.setMonitor(monitor);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gw2KeyDriver = new KeyboardDriver();
            gw2KeyDriver.targetKey = "C";
            gw2KeyDriver.bass = false;
            gw2KeyDriver.flute = false;
            gw2KeyDriver.flat = false;
            gw2KeyDriver.transposeDirection = 0;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gw2KeyDriver.targetKey = (string)comboBox1.SelectedItem;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                mbDriver.connectClient(tbIpAddress.Text, (int)nudPort.Value);
            else
                mbDriver.closeConnection();
        }

        private void cbRunServer_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRunServer.Checked)
            {
                mbDriver.start((int)nudPort.Value);
                mbDriver.keybddriver = gw2KeyDriver;

            }
            else
                mbDriver.stop();
        }

        private void cbFlat_CheckedChanged(object sender, EventArgs e)
        {
            gw2KeyDriver.flat = cbFlat.Checked;
        }
       
        
    }
}

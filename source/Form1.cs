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

       
        
       


      

        Midi.OutputDevice od;
      


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
                label1.Text = "No midi input device found! app will not work!";
            }
            if (cbOutputDevice.Items.Count == 0)
                cbConnectOutput.Enabled = false;
           
           
            
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

        }
       
        
    }
}

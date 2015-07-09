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


        
        MidiKeyboardInputDriver inputDriver;
        MultiBoxDriver mbDriver;

        Midi.OutputDevice monitor;

        public Form1()
        {
            InitializeComponent();
            
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

        void inputDriver_NoteOnString(string note)
        {
           

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
                if (monitor != null)
                    inputDriver.setMonitor(monitor);
                inputDriver.start(Midi.InputDevice.InstalledDevices[cbxInputDevices.SelectedIndex]);   
            }
            else
            {
                inputDriver.stop();
            }
        }

        private void cbConnectOutput_CheckedChanged_1(object sender, EventArgs e)
        {
            if (cbConnectOutput.Checked)
            {
                monitor = Midi.OutputDevice.InstalledDevices[cbxOutputDevices.SelectedIndex];
            }
            else
            {
                monitor = null;
            }
            if (inputDriver != null && cbConnectInput.Checked)
                inputDriver.setMonitor(monitor);
        }
       
        
    }
}

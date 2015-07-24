using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Midi;
namespace midiKeyboarder
{
    public class MidiKeyboardInputDriver
    {
        Midi.InputDevice keybd;

        Midi.OutputDevice monitor;

        List<Midi.Pitch> keysDown;

        Midi.Clock clock;

        public event Midi.InputDevice.ControlChangeHandler ControlChange;
        public event Midi.InputDevice.NoteOnHandler NoteOn;
        public event Midi.InputDevice.NoteOffHandler NoteOff;
        public event Midi.InputDevice.ProgramChangeHandler ProgramChange;
        public event Midi.InputDevice.PitchBendHandler PitchBend;
        public delegate void NoteOnStringHandler(string note);
        public event NoteOnStringHandler NoteOnString;
        public event NoteOnStringHandler NoteOffString;
        public void start(Midi.InputDevice indev)
        {

            keybd = indev;
            keybd.NoteOn += keybd_NoteOn;
            keybd.NoteOff += keybd_NoteOff;
            keybd.ControlChange += keybd_ControlChange;
            keybd.Open();
            clock = new Midi.Clock(999);
          
            keybd.StartReceiving(clock);
            keysDown = new List<Midi.Pitch>();

        }

        public void setMonitor(Midi.OutputDevice device)
        {
            monitor = device;
        }

        private void keybd_ControlChange(ControlChangeMessage msg)
        {
            //throw new NotImplementedException();
        }
        public void stop()
        {
            keybd.RemoveAllEventHandlers();
            keybd.StopReceiving();
            keybd.Close();
        }

        void keybd_NoteOff(NoteOffMessage msg)
        {
            System.Diagnostics.Trace.WriteLine("off" + msg.Pitch.ToString());
            if (keysDown.Contains(msg.Pitch))
            {
                //InputManager.Keyboard.KeyUp(lastCode);
                if (NoteOff != null)
                    NoteOff(msg);
                string pitchIn = msg.Pitch.ToString();
                //send to the main form
                if (NoteOffString != null)
                    NoteOffString(pitchIn);
                keysDown.Remove(msg.Pitch);
                if (monitor != null)
                    monitor.SendNoteOff(Midi.Channel.Channel1, msg.Pitch, 127);
            }
        }

        void keybd_NoteOn(NoteOnMessage msg)
        {
            if (keysDown.Contains(msg.Pitch))
            {
                //InputManager.Keyboard.KeyUp(lastCode);
                string pitchIn = msg.Pitch.ToString();
                if (NoteOffString != null)
                    NoteOffString(pitchIn);
               
                keysDown.Remove(msg.Pitch);
               // if (monitor != null)
                  //  monitor.SendNoteOff(Midi.Channel.Channel1, msg.Pitch, msg.Velocity);
            }
            else
            {

               
                string pitchIn = msg.Pitch.ToString();
                //send to the main form
                if (NoteOnString != null)
                    NoteOnString(pitchIn);
               //play in the monitor if its available
               // if (monitor != null)
                 //   monitor.SendNoteOn(Midi.Channel.Channel1, msg.Pitch, msg.Velocity/*msg.Velocity*/);
                //these are passed out for the sequencer
                if (NoteOn != null)
                    NoteOn(msg);

                //for some midi devices they do the NoteOn message when you release instead of NoteOff
                keysDown.Add(msg.Pitch);
            }
        }

        


    }
}

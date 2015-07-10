using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InputManager;
using Midi;
using System.Windows.Forms;
namespace midiKeyboarder
{
   public  class KeyboardDriver
    {
       object locker = new object();
        Queue<midikey> keyQueue;
        bool kill = false;
       InputManager.VirtualKeyboard keybdx;

        string key = "CDEFGABC";
        int octave = 4;

       public int transposeDirection {get; set;}
       public bool flat {get; set;}
       public bool bass {get;set;}
       public bool flute {get; set;}
       public string targetKey{get;set;}

       public void start()
       {

           keybdx = new VirtualKeyboard();
            keybdx = new InputManager.VirtualKeyboard();
            keyQueue = new Queue<midikey>();
            System.Threading.Thread keythreadx = new System.Threading.Thread(keythread);
            keythreadx.Start();
           

       }


        public void play(string note)
        {
            //note looks like this
            //"ASharp4"
            //"G4"
            Pitch outpitch;
            string outnote = transpose(note,targetKey, transposeDirection,flat, out outpitch);
            
            int o;
            Keys code;
            keyToCode(outnote, out code, out o);
             int doctave = setOctave(o, flute,bass);

                    queueKeyPress(code, doctave);



        }



        int setOctave(int o, bool flute, bool bass)
        {

            if (flute)
            {
                if((o == 4 && octave == 5) || (o == 5 && octave == 4))
                    queueKeyPress(Keys.D9, 30);
                octave = o;
                return 0;
            }
            if (bass)
            {
                int doctave = 0;
                if ((o == 1 && octave == 2))
                    doctave = -1;
                if ((o == 2 && octave == 1))
                    doctave = 1;
                octave = o;
                return doctave;
            }
            //start in octave 3
            //max octave is 4, min octave is 2
            if (o > 5) o = 5;
            if (o < 3) o = 3;
            System.Diagnostics.Trace.WriteLine("octave change " + o.ToString() + " " + octave.ToString());
            int deltaO = o - octave;
            octave += deltaO;
            return deltaO;
            int i = Math.Sign(deltaO);
           
            while (o != octave)
            {
                if (i < 0)
                    queueKeyPress(Keys.D9, 30);
                else
                    queueKeyPress(Keys.D0, (int)30);
                octave += i;
                //System.Threading.Thread.Sleep(20);
            }    
           // System.Threading.Thread.Sleep(100);
        }

       public  void queueKeyPress(Keys xmidikey,  int deltaOctave)
        {
            midikey k = new midikey();
            k.k = xmidikey;
            k.deltaOctave = deltaOctave;
            lock(locker)
            {
                keyQueue.Enqueue(k);

            }

        }

       string transpose(string musicKey, string targetKey, int direction, bool flat,out Midi.Pitch outpitch)
        {
            //convert the key to a number:
            //"G8" = 8 * "8" + 7
            bool black = musicKey.Contains("Sharp");
             musicKey = musicKey.Replace("Sharp", "");
            string scale = "CDEFGABC";
            int y = int.Parse(""+musicKey[1]);
            int x = scale.IndexOf(musicKey[0]);

            if (flat && black) //add1 to x
                x = (x + 1);
            if (x == 7)
            {
                x %= 7;
                y++;
            }
            

            int keyID = y * 7 + x;
            switch(targetKey)
            {
                case "G":
                    direction = 3;
                    break;
                case "A": direction = 2;
                    break;

                case "B":
                    direction =1;
                    break;
                    
                    

            }

            keyID += direction;
            
            ;

            y = keyID / 7;
            x = keyID % 7;
           string preout = "" + scale[x] +  ((black)?("Sharp"):("")) +y.ToString();

           string cnote = "" + preout[0];
          // bool sharp = musicKey.Contains("Sharp");
           
          if (black)
               cnote += "#";
            Midi.Note outnote = new Midi.Note(cnote);
            outpitch = outnote.PitchInOctave(y);
           return preout;

        }


       
        void keyToCode(string musicKey, out Keys code, out int octave)
        {
            //C3
            musicKey = musicKey.Replace("Sharp", "");
            octave = int.Parse("" + musicKey[1]);
            int codekey = key.IndexOf(musicKey[0]);
          
            switch (codekey)
            {
                case 0:
                    code =  Keys.D1;
                    if (octave == 6)
                        code = Keys.D8;
                    break;
                case 1:
                    code =  Keys.D2; break;
                case 2:
                    code =  Keys.D3; break;
                case 3:
                    code =  Keys.D4; break;
                case 4:
                    code =  Keys.D5; break;
                case 5:
                    code =  Keys.D6; break;
                case 6:
                    code =  Keys.D7; break;
                case 7:
                    code =  Keys.D8; break;
                default:
                    code =  0;
                    break;
            }

        }

        public struct midikey
        {
            public int deltaOctave;
            public Keys k;
            public static midikey None
            { 
                get
                {
                    midikey ret = new midikey();
                    ret.deltaOctave=0;
                    ret.k = Keys.None;
                    return ret;
                }
            }

        }

        void keythread(object o)
        {

            while (!kill)
            {
                midikey k = midikey.None;
                lock (locker)
                {
                    if (keyQueue.Count > 0)
                        k = keyQueue.Dequeue();
                    else
                        k = midikey.None;


                }
                if (k.k != Keys.None)
                {
                    //add a pre-delay if octave changing since the last key
                    System.Diagnostics.Trace.WriteLine("doctave " + k.deltaOctave.ToString());
                    if (k.deltaOctave != 0)
                        System.Threading.Thread.Sleep(75);
                    while (k.deltaOctave < 0)
                    {
                        InputManager.Keyboard.KeyPress(Keys.D9, 25);
                        System.Threading.Thread.Sleep(80);
                        k.deltaOctave++;
                    }
                    while (k.deltaOctave > 0)
                    {
                        InputManager.Keyboard.KeyPress(Keys.D0, 25);
                        System.Threading.Thread.Sleep(80);
                        k.deltaOctave--;
                    }
                    //InputManager.Keyboard.KeyPress(k, 50);



                    InputManager.Keyboard.KeyPress(k.k, 25);

                }
                // if (k == Keys.D9 || k == Keys.D0)
                //   System.Threading.Thread.Sleep(60);
                //else
                //    System.Threading.Thread.Sleep(60); //roughly 35ms pulse.  At 120bpm this is faster than 16th notes  Longer than the keypress interval as well

            }
        }


    }
}

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
       bool started = false;
       System.Threading.Thread keythreadx;
       System.Diagnostics.Stopwatch smartWatch = new System.Diagnostics.Stopwatch();
       public void start()
       {
           if (!started)
           {
               keybdx = new VirtualKeyboard();
               keybdx = new InputManager.VirtualKeyboard();
               keyQueue = new Queue<midikey>();
               kill = false;
                keythreadx = new System.Threading.Thread(keythread);
                keythreadx.Name = "pc keyboard output thread";
               keythreadx.Start();
               started = true;
               smartWatch.Start();
               //InputManager.MouseHook.InstallHook();
               //InputManager.MouseHook.MouseMove += MouseHook_MouseMove;
           }

       }

       void MouseHook_MouseMove(MouseHook.POINT ptLocat)
       {
           System.Diagnostics.Trace.WriteLine("mousemove " + ptLocat.x.ToString() + "," + ptLocat.y);
       }
       public void stop()
       {
           kill = true;
           if(keythreadx != null)
             keythreadx.Abort();
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
            bool sharp = outnote.Contains("Sharp");
            keyToCode(outnote, out code, out o);
             int doctave = setOctave(o, flute,bass);
            if(!sharp)
                    queueKeyPress(code, doctave);
            else
            {
                string sharpnote = outnote.TrimEnd('1', '2', '3', '4', '5', '6');
                switch(sharpnote)
                {
                    case "CSharp":
                        queueKeyPress(Keys.D1, doctave);
                        queueKeyPress(Keys.D1, 0);
                        queueKeyPress(Keys.D2, 0);
                        break;
                    case "DSharp":
                        queueKeyPress(Keys.D2, doctave);
                        queueKeyPress(Keys.D2, 0);
                        queueKeyPress(Keys.D3, 0);
                        break;
                    case "FSharp":
                        queueKeyPress(Keys.D3, doctave);
                        queueKeyPress(Keys.D3, 0);
                        queueKeyPress(Keys.D4, 0);
                        break;
                    case "GSharp":
                        queueKeyPress(Keys.D4, doctave);
                        queueKeyPress(Keys.D4, 0);
                        queueKeyPress(Keys.D5, 0);
                        break;
                    case "ASharp":
                        queueKeyPress(Keys.D5, doctave);
                        queueKeyPress(Keys.D5, 0);
                        queueKeyPress(Keys.D6, 0);
                        break;

                }

            }

            

        }



        int setOctave(int o, bool flute, bool bass)
        {
            
            if (flute)
            {
                if ((o == 4 && octave == 5) || (o == 5 && octave == 4))
                {
                    octave = o;
                    return -1;
                }
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


       
        void keyToCode(string musicKey, out Keys code, out int coctave)
        {
            //C3
            musicKey = musicKey.Replace("Sharp", "");
            coctave = int.Parse("" + musicKey[1]);
            int codekey = key.IndexOf(musicKey[0]);
          
            switch (codekey)
            {
                case 0:
                    code =  Keys.D1;
                    if (coctave == octave + 1)
                    {
                        code = Keys.D8;
                        coctave = octave;
                    }
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
            public int noteOctave;
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
       void d9()
        {
             InputManager.Keyboard.KeyPress(Keys.D9, 15);
            //InputManager.Mouse.Move(1180, 1040);
            //InputManager.Mouse.PressButton(Mouse.MouseKeys.Left, 15);
        }
       void d0()
       {
            InputManager.Keyboard.KeyPress(Keys.D0, 15);
           //InputManager.Mouse.Move(1240, 1040);
          // InputManager.Mouse.PressButton(Mouse.MouseKeys.Left, 15);
       }
       void delay()
       {
           System.Diagnostics.Trace.WriteLine("d");
           System.Threading.Thread.Sleep(80);
       }
        void keythread2(object o)
        {
            System.Diagnostics.Trace.WriteLine("Keythread started with id " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());

            Stack<midikey> low = new Stack<midikey>();
            Stack<midikey> med = new Stack<midikey>();
            Stack<midikey> high = new Stack<midikey>();
            Stack<Stack<midikey>> playOrder = new Stack<Stack<midikey>>(); //yo dog i heard you like stacks
            while (!kill && !Program.killAllThreads)
            {
                if (Program.killAllThreads)
                    return;
                midikey k = midikey.None;

                low.Clear();
                med.Clear();
                high.Clear();
                playOrder.Clear();
                lock (locker)
                {   //sort the notes in this frame into their octaves
                    while (keyQueue.Count > 0)
                    {
                        k = keyQueue.Dequeue();
                        if (k.deltaOctave == 1 || k.deltaOctave == 3)
                            low.Push(k);
                        if (k.deltaOctave == 2 || k.deltaOctave == 4)
                            med.Push(k);
                        if (k.deltaOctave == 5 || k.deltaOctave == 6)
                        {
                            if (k.deltaOctave == 6) k.deltaOctave = 5;
                            high.Push(k);
                        }
                    }
                   // else
                     //   k = midikey.None;


                }
                if (low.Count !=0 || med.Count != 0 || high.Count != 0)
                {
                    if (low.Count != 0 && med.Count != 0 && high.Count != 0)
                    {
                        //this frame has notes from all 3 octaves.  The play order depends on the current octave
                        if (octave == 4 || octave == 3)
                        {
                            playOrder.Push(high);

                            playOrder.Push(med);
                            playOrder.Push(low);

                        }
                        if (octave == 5)
                        {
                            playOrder.Push(low);
                            playOrder.Push(med);

                            playOrder.Push(high);
                        }
                    }
                    else if (low.Count != 0 && med.Count != 0)
                    {
                        if (octave == 5 || octave == 4 || octave == 2)
                        {
                            playOrder.Push(low);
                            playOrder.Push(med); //closer octave first

                        }
                        if (octave == 1 || octave == 3)
                        {
                            playOrder.Push(low);
                            playOrder.Push(med); //closer octave first

                        }
                    }
                    else if (low.Count != 0 && high.Count != 0)
                    {
                        if (octave == 1 || octave == 3 || octave == 4)
                        {
                            playOrder.Push(high);
                            playOrder.Push(low);
                            //closer octave first

                        }
                        if (octave == 5 || octave == 2)
                        {
                            playOrder.Push(low);
                            playOrder.Push(high); //closer octave first

                        }
                    }
                    else if (med.Count != 0 && high.Count != 0)
                    {
                        if (octave == 1 || octave == 3 || octave == 4)
                        {
                            playOrder.Push(high);
                            playOrder.Push(med);
                            //closer octave first

                        }
                        if (octave == 5 || octave == 2)
                        {
                            playOrder.Push(med);
                            playOrder.Push(high); //closer octave first

                        }
                    }
                    else if (low.Count != 0)
                        playOrder.Push(low);
                    else if (med.Count != 0)
                        playOrder.Push(med);
                    else if (high.Count != 0)
                        playOrder.Push(high);



                    while (playOrder.Count > 0)
                    {
                        var notelist = playOrder.Pop();
                        foreach (var kx in notelist)
                        {
                            int deltaOctave = kx.deltaOctave - octave;
                            //add a pre-delay if octave changing since the last key
                            System.Diagnostics.Trace.WriteLine("doctave " + deltaOctave.ToString());
                            if (deltaOctave != 0)
                                delay();
                            while (deltaOctave < 0)
                            {
                                //InputManager.Keyboard.KeyPress(Keys.D9, 25);
                                d9();
                                octave--;
                                deltaOctave++;
                                if (deltaOctave != 0)
                                    delay();
                            }
                            while (deltaOctave > 0)
                            {
                                if (flute)
                                    // InputManager.Keyboard.KeyPress(Keys.D9, 25);
                                    d9();
                                else
                                    // InputManager.Keyboard.KeyPress(Keys.D0, 25);
                                    d0();
                                
                                octave++;
                                deltaOctave--;
                                if (deltaOctave != 0)
                                    delay();
                            }
                            //InputManager.Keyboard.KeyPress(k, 50);


                            System.Diagnostics.Trace.WriteLine("p");
                            InputManager.Keyboard.KeyPress(kx.k, 10);
                        }
                    }
                }
                // if (k == Keys.D9 || k == Keys.D0)
                //   System.Threading.Thread.Sleep(60);
                //else
                   System.Threading.Thread.Sleep(15); //roughly 35ms pulse.  At 120bpm this is faster than 16th notes  Longer than the keypress interval as well

            }
        }
        double lastTick = 0;
       void smartSleep()
        {
            if (Form1.dedicatedOctaveModeActive)
                return; //zero delays!
            System.Diagnostics.Trace.WriteLine("lasttick - ticks " + (lastTick - smartWatch.Elapsed.TotalSeconds).ToString());
            while (lastTick - smartWatch.Elapsed.TotalSeconds > 0) System.Threading.Thread.Sleep(0);
            System.Diagnostics.Trace.WriteLine("lasttick - ticks " + (lastTick - smartWatch.Elapsed.TotalSeconds).ToString());
        }

        void keythread(object o)
        {
            System.Diagnostics.Trace.WriteLine("Keythread started with id " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
            while (!kill && ! Program.killAllThreads)
            {
                if (Program.killAllThreads)
                    return;
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
                    bool octaveChange = false;
                    if (k.deltaOctave != 0)
                    {
                     //   System.Threading.Thread.Sleep(75);
                        octaveChange = true;
                        smartSleep();
                        lastTick = smartWatch.Elapsed.TotalSeconds +.080;
                    }
                    while (k.deltaOctave < 0)
                    {
                        smartSleep();
                        InputManager.Keyboard.KeyPress(Keys.D9, 25);

                        lastTick = smartWatch.Elapsed.TotalSeconds + .080;
                        k.deltaOctave++;
                    }
                    while (k.deltaOctave > 0)
                    {
                        smartSleep();
                        InputManager.Keyboard.KeyPress(Keys.D0, 25);

                        lastTick = smartWatch.Elapsed.TotalSeconds + .080;
                        k.deltaOctave--;
                    }
                    //InputManager.Keyboard.KeyPress(k, 50);

                    if(octaveChange)
                        smartSleep();
                    InputManager.Keyboard.KeyPress(k.k, 25);
                    lastTick = smartWatch.Elapsed.TotalSeconds + .080;
                }
                // if (k == Keys.D9 || k == Keys.D0)
                //   System.Threading.Thread.Sleep(60);
                //else
                //    System.Threading.Thread.Sleep(60); //roughly 35ms pulse.  At 120bpm this is faster than 16th notes  Longer than the keypress interval as well

            }
        }


    }
}

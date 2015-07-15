using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace midiKeyboarder
{
    public partial class sectionPanel : UserControl
    {
        public sectionPanel()
        {
            InitializeComponent();
            renderPlane.MouseUp += renderPlane_MouseUp;
            this.KeyUp += sectionPanel_KeyUp;
            renderPlane.PreviewKeyDown += renderPlane_PreviewKeyDown;
            
            
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
        }
        void renderPlane_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            throw new NotImplementedException();
        }
        void addNote(string pitch)
        {
            section.note newnote = new section.note();
            newnote.duration = 1 / (float)myform.addlength;
            newnote.time = myform.time;
            newnote.pitch = pitch;
            mySection.notes.Add(newnote);
            myform.quickPlay(newnote);
            myform.time += myform.autoAdvance * 4;
            myform.renderSections();

        }
        void sectionPanel_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
                myform.copy();
            if (e.Control && e.KeyCode == Keys.X)
                myform.cut();
            if (e.Control && e.KeyCode == Keys.V)
                myform.paste();
            if (e.KeyCode == Keys.Delete)
                myform.delete();
            if(e.KeyCode == Keys.Add)
            {
                myform.renderRange--;
                if(myform.renderRange < 1)
                    myform.renderRange = 1;

                myform.renderSections();
            }
            if (e.KeyCode == Keys.Subtract)
            {
                myform.renderRange++;
                if (myform.renderRange > 16)
                    myform.renderRange = 16;

                myform.renderSections();
            }
            switch(e.KeyCode)
            {
                case Keys.D0:
                    myform.addOctave++;
                    if (myform.addOctave > 5)
                        myform.addOctave = 5;
                    myform.labOctave.Text = myform.addOctave.ToString();
                    break;
                case Keys.D9:
                    myform.addOctave--;
                    if (myform.addOctave < 1)
                        myform.addOctave = 1;
                    myform.labOctave.Text = myform.addOctave.ToString();
                    break;
                case Keys.D1:
                    {
                        string pitch = "C" + myform.addOctave.ToString();

                        addNote(pitch);
                    }
                    break;
                case Keys.D2:
                    {
                        string pitch = "D" + myform.addOctave.ToString();

                        addNote(pitch);
                    }
                    break;
                case Keys.D3:
                    {
                        string pitch = "E" + myform.addOctave.ToString();

                        addNote(pitch);
                    }
                    break;
                case Keys.D4:
                    {
                        string pitch = "F" + myform.addOctave.ToString();

                        addNote(pitch);
                    }
                    break;
                case Keys.D5:
                    {
                        string pitch = "G" + myform.addOctave.ToString();

                        addNote(pitch);
                    }
                    break;
                case Keys.D6:
                    {
                        string pitch = "A" + myform.addOctave.ToString();

                        addNote(pitch);
                    }
                    break;
                case Keys.D7:
                    {
                        string pitch = "B" + myform.addOctave.ToString();

                        addNote(pitch);
                    }
                    break;
                case Keys.D8:
                    {
                        string pitch = "C" + (myform.addOctave+1).ToString();

                        addNote(pitch);
                    }
                    break;

            }


        }
        public Form1 myform;
        void renderPlane_MouseUp(object sender, MouseEventArgs e)
        {
            int beats = myform.timesig;
            int nBars = myform.renderRange;
            int nBeats = nBars * beats;
            int nQuarterBeats = nBeats * 4;
            float t = lerp(0, renderPlane.Width, -nBeats / 2, nBeats/2, e.X);

            
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                
                var tryPickNote = pickNote(e);
                if (tryPickNote != null)
                {
                    if (myform.selectedInstrument != mySection.instrumentid)
                    {
                        myform.selectUIInstrument(mySection.instrumentid);
                        myform.selectedNotes.Clear();
                    }
                    myform.selectedNotes.Add(tryPickNote);
                    myform.quickPlay(tryPickNote);
                }
                else
                    myform.selectedNotes.Clear();

               
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                 myform.time = myform.scrollTime + myform.renderRange * 2 + t;
                if (myform.time < 0)
                    myform.time = 0;
              
            }
            if(e.Button == System.Windows.Forms.MouseButtons.Middle)
            {
                  myform.scrollTime = myform.scrollTime + t;
                if (myform.scrollTime < 0)
                    myform.scrollTime = 0;
            }
            myform.renderSections();
            this.Focus();
            
        }

        public int mysectionid;
        public section mySection { get { return Form1.sections[mysectionid]; } }
        public void drawSection( float time, float scrollTime, int beats)
        {
            //mysectionid = id;
            
            //the second width is 8 bars
            //notes draw from C to C, bottom to top
            Bitmap temp = new Bitmap(renderPlane.Width, renderPlane.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(temp);
            //g.TranslateTransform(-scrollTime, 0);
           
            float timeline =  time;
            g.Clear(Color.Silver);
            lock (mySection.sectionLock)
            {
                foreach (var note in mySection.notes)
                {
                    var notebar = calculateNote(note.pitch, note.time - scrollTime, note.duration);
                    if (myform.selectedNotes.Contains(note))
                        g.FillRectangle(Brushes.Orange, notebar);
                    else
                        g.FillRectangle(Brushes.Green, notebar);
                    g.DrawRectangle(Pens.Black, notebar.X, notebar.Y, notebar.Width, notebar.Height);
                }
            }
            var font = new System.Drawing.Font("Arial", 10);

            int nBars = myform.renderRange;
            int nBeats = nBars * beats;
            int nQuarterBeats = nBeats * 4;



            for (int i = 0; i <= nQuarterBeats; i++)
            {
                float t = lerp(0, nQuarterBeats, ((int)scrollTime), ((int)scrollTime) + (nBeats) , i);
                int it = ((int)(t));
                bool largeTick = (i % 4) == 0;
                float tx = lerp(0, myform.renderRange * 4+1, 0, renderPlane.Width, t - scrollTime);
                int iheight = 10;
                if (largeTick) iheight = 20;
                g.DrawLine(((largeTick)?(Pens.DarkGray):(Pens.LightGray)),tx,0,tx, iheight);
                if (largeTick)
                {
                    int rt = it / beats + 1;
                    int bt = it % beats + 1;
                    if(myform.renderRange < 6 || bt == 1)
                    g.DrawString(rt.ToString() + "." + bt.ToString(), font, Brushes.Black, new PointF(tx + 5, 10));
                }

            }


            float timelinex = lerp(0, nBeats, 0, renderPlane.Width, timeline - scrollTime);

            g.DrawLine(Pens.Red, timelinex, 0, timelinex, renderPlane.Height);
            g.Dispose();
            renderPlane.Image = (Bitmap)temp.Clone();


        }

        public section.note pickNote(MouseEventArgs e)
        {
            List<RectangleF> notes = new List<RectangleF>();
            foreach (var note in mySection.notes)
            {
                var notebar = calculateNote(note.pitch, note.time - myform.scrollTime, note.duration);
                notes.Add(notebar);

             }
            int found = -1;
            for (int i = 0; i < notes.Count; i++)
                if (notes[i].Contains(e.X, e.Y))
                    found = i;
            if (found >= 0)
                return mySection.notes[found];
            return null;
                    

        }

        float lerp(float a1, float a2, float b1, float b2, float a)
        {
            return b1 + (b2 - b1) / (a2 - a1) * (a - a1);
        }
        RectangleF calculateNote(string pitch, float time, float duration)
        {
            //ASharp5
            //G3
           
            int icp = ("CDEFGAB").IndexOf(pitch[0]);
            int row = int.Parse("" + pitch[pitch.Length - 1]);
            if (row >= 3)
                row -= 3;
            else
                row--;

            icp += row * 7;

            float y = lerp(0, 44, renderPlane.Height, 0, 2 * icp + 1); //1 through 15
            float x = lerp(0, myform.renderRange * 4, 0, renderPlane.Width, time);
            float xd = lerp(0, myform.renderRange * 4, 0, renderPlane.Width, time + duration);

            return new RectangleF(x, y - 4, xd - x, 8);

        }

        private void renderPlane_Click(object sender, EventArgs e)
        {

        }

    }
}

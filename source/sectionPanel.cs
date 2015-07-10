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
        }
        public Form1 myform;
        void renderPlane_MouseUp(object sender, MouseEventArgs e)
        {
            float t = lerp(0, renderPlane.Width, -4, 4, e.X);

            
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                myform.time = myform.scrollTime + 4 + t;
                if (myform.time < 0)
                    myform.time = 0;
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                myform.scrollTime = myform.scrollTime + t;
                if (myform.scrollTime < 0)
                    myform.scrollTime = 0;
            }
            myform.renderSections();
            
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
            foreach(var note in mySection.notes )
            {
                var notebar = calculateNote(note.pitch, note.time - scrollTime, note.duration);
                g.FillRectangle(Brushes.Green, notebar);
                g.DrawRectangle(Pens.Black, notebar.X, notebar.Y, notebar.Width, notebar.Height);
            }
            var font = new System.Drawing.Font("Arial", 10);
            for(int i = 0; i < 36; i++)
            {
                float t = lerp(0, 36, ((int)scrollTime) - 1, ((int)scrollTime)+ 8, i);
                int it = ((int)t);
                bool largeTick = (i % beats) == 0;
                float tx = lerp(0, 8, 0, renderPlane.Width, t - scrollTime);
                int iheight = 10;
                if (largeTick) iheight = 20;
                g.DrawLine(((largeTick)?(Pens.DarkGray):(Pens.LightGray)),tx,0,tx, iheight);
                if (largeTick)
                {
                    int rt = it / beats + 1;
                    int bt = it % beats + 1;
                    g.DrawString(rt.ToString() + "." + bt.ToString(), font, Brushes.Black, new PointF(tx + 5, 10));
                }

            }


            float timelinex = lerp(0, 8, 0, renderPlane.Width, timeline - scrollTime);

            g.DrawLine(Pens.Red, timelinex, 0, timelinex, renderPlane.Height);
            g.Dispose();
            renderPlane.Image = (Bitmap)temp.Clone();


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
            float y = lerp(0, 16, renderPlane.Height, 0, 2 * icp + 1); //1 through 15
            float x = lerp(0, 8, 0, renderPlane.Width, time);
            float xd = lerp(0, 8, 0, renderPlane.Width, time + duration);

            return new RectangleF(x, y - 5, xd - x, 10);

        }

        private void renderPlane_Click(object sender, EventArgs e)
        {

        }

    }
}

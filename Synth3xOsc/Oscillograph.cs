using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Synth3xOsc
{
    class Oscillograph : PictureBox
    {

        const int historyLength = 940;
        float[] history;
        int nextWrite = 0;
        Graphics bmg;
        Bitmap bm;
        int i = 0;

        private System.Windows.Forms.Timer timer1;

        public Oscillograph()
        {
            history = new float[historyLength];

            InitializeComponent();

            for (int w = 0; w < historyLength; w++)
            {
                history[w] = 0;
            }

            this.DoubleBuffered = true;

            this.timer1 = new System.Windows.Forms.Timer();
            
            this.TabIndex = 0;
            this.TabStop = false;
            this.Paint += new PaintEventHandler(Oscillograph_Paint);

            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new EventHandler(timer1_Tick);
            this.ResumeLayout(false);
        }

        //*************************************************************************************

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
            //this.BorderStyle = BorderStyle.FixedSingle;
            this.BorderStyle = BorderStyle.Fixed3D;
        }

        //*************************************************************************************

        private void AddValue(float y)
        {
            history[nextWrite] = y;
            nextWrite = (nextWrite + 1) % historyLength;
        }

        //*************************************************************************************

        private void Oscillograph_Paint(object sender, PaintEventArgs e)
        {
            if (bm == null)
            {
                bm = new Bitmap(this.Width, this.Height);
                bmg = Graphics.FromImage(bm);
                bmg.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                bmg.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.GammaCorrected;
                bmg.Clear(Color.BlueViolet);
            }
            Render();

            e.Graphics.DrawImage(bm, 0, 0);
        }

        //*************************************************************************************

        void Render()
        {
            Pen pen = new Pen(Brushes.Chocolate);

            // Set the pen's width.
            pen.Width = 4.0F;

            // Set the LineJoin property.
            pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;

            bmg.Clear(Color.BurlyWood);
            float y0 = 0;
            int x0 = 0;
            for (int p = 0; p < historyLength; p++)
            {
                float y = (this.Height / 2) - 4 + 70.0f * history[(nextWrite + p) % historyLength];
                int x = p;
                if (p != 0)
                {
                    // draw a line
                    bmg.DrawLine(pen, x0, y0, x, y);
                }
                y0 = y;
                x0 = x;
            }
        }

        //*************************************************************************************

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int w = 0; w < 100; w++)
            {
                if (i == Program.wave.Length)
                    i = 0;
                
                else AddValue((float)(Program.wave[i++] / (float)short.MaxValue));
             
                this.Invalidate();
            }
            
        }

        //*************************************************************************************
    

    }
}

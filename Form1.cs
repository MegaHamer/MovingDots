using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovingDots
{
    public partial class Form1 : Form
    {
        List<Dot> dots = new List<Dot> { };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateNewDots();
        }
        private void GenerateNewDots()
        {
            Random r = new Random();
            dots.Clear();
            for (int i = 0; i < 100; i++)
            {
                dots.Add(new Dot(r, 0,0,this.Width,this.Height,true,true,100));
            }
        }
        private void draw_points()
        {
            Bitmap Image = new Bitmap(this.Width, this.Height);
            Graphics gr = Graphics.FromImage(Image);
            gr.FillRectangle(Brushes.White, 0, 0, Width, Height);
            Pen pn = new Pen(Color.Red, 1);


            foreach (Dot d in dots)
            {
                gr.DrawEllipse(pn, (float) d.Position.x,(float) d.Position.y, 10, 10);
            }
            var FormG = CreateGraphics();
            FormG.DrawImageUnscaled(Image, 0, 0);
        }
        private void clear_scr()
        {
            Graphics gr = this.CreateGraphics();
            //gr.Clear(SystemColors.Control);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            draw_points();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear_scr();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (Dot d in dots)
            {
                d.Step();
            }
            clear_scr();
            draw_points();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button3_Click(new object(), new EventArgs());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GenerateNewDots();
        }
    }
}

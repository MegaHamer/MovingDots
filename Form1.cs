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
        Canvas c;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Settings.Hide();
            c = new Canvas((Form)sender,0, 0, Width, Height);
            c.GenerateNewDots();
            dotsCountNUD.Value = c.dotCount;
            lengthBetweenNUD.Value = (int) c.legthBetween;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.draw_points();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            c.Step();
            c.draw_points();
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
            c.legthBetween = (int) lengthBetweenNUD.Value;
            c.dotCount = (int) dotsCountNUD.Value;
            c.GenerateNewDots();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            c.SecondDot.x = Width;
            c.SecondDot.y = Height;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (Settings.Visible)
            {
                Settings.Hide();
            }
            else
            {
                Settings.Show();
            }
        }
    }
}

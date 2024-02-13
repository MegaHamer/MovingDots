using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovingDots
{
    internal class Canvas
    {
        public class Point
        {
            public double x = 0;
            public double y = 0;
            public Point(int x, int y)
            {
                this.x = (double)x;
                this.y = (double)y;
            }
            public Point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }
            public Point()
            {
                this.x = 0;
                this.y = 0;
            }
        }
        public Point FirstDot;
        public Point SecondDot;
        List<Dot> dots = new List<Dot> { };
        public Form canv;
        public Canvas(Form graph,int x1,int y1,int x2,int y2)
        {
            canv = graph;
            FirstDot = new Point(Math.Min(x1, x2), Math.Min(y1, y2));
            SecondDot = new Point(Math.Max(x1, x2), Math.Max(y1, y2));
        }
        public void Step()
        {
            foreach (Dot d in dots)
            {
                d.Position.x += d.Vector.x;
                d.Position.y += d.Vector.y;

                var newPosx = d.Position.x + d.Vector.x;
                var newPosy = d.Position.y + d.Vector.y;

                if (newPosx <= FirstDot.x)
                {
                    d.Vector.x = Math.Abs(d.Vector.x);
                    d.Position.x += d.Vector.x;
                }
                if (SecondDot.x-d.diam <= newPosx)
                {
                    d.Vector.x = -Math.Abs(d.Vector.x);
                    d.Position.x += d.Vector.x;
                }
                
                if (newPosy <= FirstDot.y)
                {
                    d.Vector.y = Math.Abs(d.Vector.y);
                    d.Position.y += d.Vector.y;
                }
                if (SecondDot.y-d.diam <= newPosy)
                {
                    d.Vector.y = -Math.Abs(d.Vector.y);
                    d.Position.y += d.Vector.y;
                }
                
            }
            
        }
        public void GenerateNewDots()
        {
            Random r = new Random();
            dots.Clear();
            for (int i = 0; i < 100; i++)
            {
                dots.Add(new Dot(r, (int) FirstDot.x, (int)FirstDot.y, (int)SecondDot.x, (int)SecondDot.y,10, true, true));
            }
        }
        public void draw_points()
        {
            int width = (int)(SecondDot.x - FirstDot.x);
            int height = (int)(SecondDot.y - FirstDot.y);

            Bitmap Image = new Bitmap(width,height);
            Graphics gr = Graphics.FromImage(Image);

            gr.FillRectangle(Brushes.White, (int)FirstDot.x, (int)FirstDot.y, width, height);
            Pen pn = new Pen(Color.Red, 1);


            foreach (Dot d in dots)
            {
                gr.DrawEllipse(pn, (float)d.Position.x, (float)d.Position.y, d.diam, d.diam);
                gr.FillRectangle(Brushes.Green, (float)d.Position.x, (float)d.Position.y, d.diam, d.diam);
            }
            var FormG = canv.CreateGraphics();
            FormG.DrawImageUnscaled(Image, (int) FirstDot.x, (int) FirstDot.y);
        }

    }
}

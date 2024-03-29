﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovingDots
{
    
    internal class Dot
    {
        public class Point
        {
            public double x = 0;
            public double y = 0;
            public Point(int x,int y)
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
            public void RandPos(Random r,int diam,int x1,int y1,int x2,int y2)
            {
                //Random r = new Random();
                x= r.Next(x1,x2-diam);
                y= r.Next(y1,y2-diam);
            }
            public void RandVec(Random r,double spead = 1 )
            {
                //Random r =new Random();

                int x1 = r.Next(-10,10);
                int y1 = r.Next(-10,10);

                double len = Math.Sqrt(x1*x1+y1*y1);

                double x2 = x1/len;
                double y2 = y1/len;
                
                this.x = spead* x2;
                this.y = spead* y2;
            }
        }
        public Point Position;
        public Point Vector;
        public Point FirstDot;
        public Point SecondDot;
        public int diam = 1;
        public double spead = 100;
        public Dot(Random r,int x1,int y1,int x2,int y2,int diam, bool pos = false, bool vec = false,double spead = 100)
        {
            FirstDot = new Point(Math.Min(x1, x2), Math.Min(y1, y2));
            SecondDot = new Point(Math.Max(x1, x2), Math.Max(y1, y2));

            this.spead = spead;
            this.diam = diam;

            Position = new Point();
            Vector = new Point();

            if (pos)
            {
                Position = new Point();
                Position.RandPos(r,diam,((int)FirstDot.x),((int)FirstDot.y), ((int)SecondDot.x), ((int)SecondDot.y));
            }
            if (vec)
            {
                Vector= new Point();
                Vector.RandVec(r,spead/100);
            }
        }
    }
}

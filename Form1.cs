using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigBrainPixel2
{
    public partial class Form1 : Form
    {
        bool startDraw = false;
        Point a, b, c, d;
        Pen p = new Pen(Color.Red);
        SolidBrush brush = new SolidBrush(Color.Green);
        int spacing = 25;
        Point r1 = new Point(0, 25);
        Point r2 = new Point(500, 25);

        Point c1 = new Point(25, 0);
        Point c2 = new Point(25, 400);

        private void Columns_Tick(object sender, EventArgs e)
        {

            Graphics g = CreateGraphics();
            g.DrawLine(p, c1, c2);
            c1.X += spacing;
            c2.X += spacing;
            if (c1.X == 500)
            {
                Columns.Stop();
            }



        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            startDraw = true;

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            
            if(startDraw==true)
            {
                int quointx = e.X / 25;
                int quointy = e.Y / 25;
                a.X = quointx * 25;
                b.X = quointx * 25 + 25;
                c.X = quointx * 25 + 25;
                d.X = quointx * 25 + 25;


                a.Y = quointy * 25;
                b.Y = quointy * 25;
                c.Y = quointy * 25 + 25;
                d.Y = quointy * 25 + 25;
                Graphics g = CreateGraphics();
                Rectangle rect = new Rectangle(a.X, b.Y, 25, 25);
                g.DrawRectangle(p, rect);
                g.FillRectangle(brush, rect);

                

            }
            else
            {
                

            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            startDraw = false;
        }

        //private void Form1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    this.Refresh();
           
        //}

        private void Rows_Tick(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            g.DrawLine(p, r1, r2);
            r1.Y += spacing;
            r2.Y += spacing;
        
            if (r2.Y == 400)
            {
                Rows.Stop();
            }
           

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Rows.Start();
            Columns.Start();


        }
    }
}

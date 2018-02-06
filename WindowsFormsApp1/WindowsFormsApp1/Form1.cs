using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Pen pen = new Pen(Color.Red);
        int width = 10;
        int height = 10;
        bool is_moving = false;
        Point start;
        Rectangle circle = new Rectangle(0,0,0,0);

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            //Graphics g = panel1.CreateGraphics();
            int Mouse_Pos_x = e.X;
            int Mouse_Pos_y = e.Y;
            Control control = (Control)sender;
            /*  Mouse_Pos_x -= (int)width / 2;    //Dont delete these friends
              Mouse_Pos_y -= (int)height / 2;*/

            start = new Point(Mouse_Pos_x, Mouse_Pos_y);

            if (e.Button == MouseButtons.Left)
            {
                is_moving = true;
            }

            
            //circle = new Rectangle(start.X, start.Y, width, height);
            //g.DrawEllipse(pen, circle); 
            
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
           //Graphics g = panel1.CreateGraphics();
            if (is_moving)
            {
                Point end = new Point(e.X, e.Y);
                width = end.X - start.X;
                height = end.Y - start.Y;
                circle = new Rectangle(start.X, start.Y, width, height);
                //g.DrawEllipse(pen, circle);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Invalidate();
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            is_moving = false;
            g.DrawEllipse(pen, circle);
            //circle = new Rectangle(0, 0, 0, 0);
        }
    }
}

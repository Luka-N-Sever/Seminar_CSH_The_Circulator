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
        float width = 10;
        float height = 10;
        bool is_moving = false;
        Point start;
        RectangleF circle = new RectangleF(0,0,0,0);

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            int Mouse_Pos_x = e.X;
            int Mouse_Pos_y = e.Y;

            Mouse_Pos_x -= (int)width / 2;
            Mouse_Pos_y -= (int)height / 2;

            start = new Point(Mouse_Pos_x, Mouse_Pos_y);

            if (e.Button == MouseButtons.Left)
            {
                is_moving = true;
            }

            circle = new RectangleF(start.X, start.Y, width, height);
            g.DrawEllipse(pen, circle);
            
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            if (is_moving)
            {
                width = e.X - start.X;
                height = e.Y - start.Y;
                circle = new RectangleF(start.X, start.Y, width, height);
                g.DrawEllipse(pen, circle);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }
    }
}

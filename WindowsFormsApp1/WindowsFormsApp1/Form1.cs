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
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            float Mouse_Pos_x = e.X;
            float Mouse_Pos_y = e.Y;
            float width = 20;
            float height = 20;
            Pen pen = new Pen(Color.Red);
            RectangleF circle = new RectangleF(Mouse_Pos_x-width/2, Mouse_Pos_y-height/2, width, height);
            Graphics g = panel1.CreateGraphics();
            g.DrawEllipse(pen, circle);
        }
    }
}

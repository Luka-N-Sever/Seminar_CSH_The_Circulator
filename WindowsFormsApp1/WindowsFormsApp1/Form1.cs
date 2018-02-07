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
        private Rectangle circle;
        private Point start;
        private Point end;
        private double area;
        private double circumference;

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            start.X = e.X;
            start.Y = e.Y;
            circle = new Rectangle(0, 0, 0, 0);
            area = 0;
            circumference = 0;
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            end.X = e.X;
            end.Y = e.Y;
            circle = new Rectangle(start.X, start.Y, (end.X-start.X), (end.X-start.X));
            area = Math.Pow(circle.Width/2, 2) * Math.PI;
            circumference = 2 * circle.Width/2 * Math.PI;
            maskedTextBox1.AppendText(circumference.ToString());
            maskedTextBox2.AppendText(area.ToString());
            g.DrawEllipse(new Pen (Color.Red, 1), circle);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            panel1.Invalidate();
        }
    }
}

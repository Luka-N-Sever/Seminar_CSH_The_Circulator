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

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            start.X = e.X;
            start.Y = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            end.X = e.X;
            end.Y = e.Y;
            panel1.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            circle = new Rectangle(start.X, start.Y, end.X - start.X, end.X - start.X); 
            double diameter = Math.Sqrt((end.X - start.X)^2 + (end.Y - start.Y)^2);
            double radius = diameter / 2;
            double area = Math.Pow(radius, 2) * Math.PI;
            double circumference = 2 * radius * Math.PI;
            maskedTextBox1.AppendText(circumference.ToString());
            maskedTextBox2.AppendText(area.ToString());
            e.Graphics.DrawEllipse(new Pen(Color.Red, 1), circle);                     
        }
    }
}

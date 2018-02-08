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
        private RectangleF circle;
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
            RectangleF bounds = new RectangleF(0, 0, 0, 0);
            bounds = g.VisibleClipBounds; 
            end.X = e.X;
            end.Y = e.Y;
            float height_and_width = (float) Math.Sqrt(Math.Pow(end.X - start.X, 2) + Math.Pow(end.Y - start.Y, 2));

            circle = new RectangleF(start.X - height_and_width / 2, start.Y - height_and_width / 2, height_and_width, height_and_width);
            area = Math.Pow(circle.Width / 2, 2) * Math.PI;
            circumference = 2 * (circle.Width / 2) * Math.PI;
            maskedTextBox1.AppendText(circumference.ToString());
            maskedTextBox2.AppendText(area.ToString());
            g.DrawEllipse(new Pen(Color.Red, 1), circle);
            
            try
            {
                if (circle.Right > bounds.Right || 0 > circle.Left)
                 throw new ApplicationException();
                if (circle.Bottom > bounds.Bottom || 0 > circle.Top)
                 throw new ApplicationException(); 
            }
            catch (ApplicationException)
            {
                String exception = "Your Circle is out of Bounds!";
                String caption = "CIRCLE_EXCEPTION";
                MessageBox.Show(exception, caption);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            panel1.Invalidate();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpePaint;

namespace GDIPaint
{
    
    public partial class Form1 : Form
    {
        public MyPaint paint = null;
        Point firstPoint = Point.Empty;
        Point secondPoint = Point.Empty;



        public Form1()
        {
            InitializeComponent();
            paint = new MyPaint(pictureBox1.Size);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
            e.Graphics.DrawImage(paint.bitmap, Point.Empty);

            if (firstPoint != Point.Empty)
            {
                switch (paint.tool)
                {
                    case Tool.Line:
                        e.Graphics.DrawLine(paint.p, firstPoint, secondPoint);
                        break;
                    case Tool.Rectangle:
                        e.Graphics.DrawRectangle(paint.p, firstPoint.X, firstPoint.Y, secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
                        break;
                    case Tool.Circle:
                        break;
                    case Tool.Pen:
                        break;
                    default:
                        break;
                }
            }

        }


    

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            firstPoint = e.Location;

            if (paint.tool == Tool.Fill)
            {
                Color c = paint.bitmap.GetPixel(e.X, e.Y);

                MapFill mf = new MapFill();

                mf.Fill(paint.g, e.Location, paint.p.Color, ref paint.bitmap);

                pictureBox1.Refresh();

            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            secondPoint = e.Location;
            if (firstPoint != Point.Empty)
            {
                switch (paint.tool)
                {
                    case Tool.Line:
                        paint.g.DrawLine(paint.p, firstPoint, secondPoint);
                        break;
                    case Tool.Rectangle:
                        paint.g.DrawRectangle(paint.p, firstPoint.X, firstPoint.Y, secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
                        break;

                    case Tool.Circle:
                        break;
                    default:
                        break;
                }
            }

            this.Refresh();

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (firstPoint != Point.Empty)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    secondPoint = e.Location;

                    switch (paint.tool)
                    {
                        case Tool.Pen:
                            paint.g.DrawLine(paint.p, firstPoint, secondPoint);
                            firstPoint = secondPoint;
                            break;
                        case Tool.Brush:
                            GraphicsPath gp = new GraphicsPath();
                            gp.AddEllipse(secondPoint.X - 50, secondPoint.Y - 50, 100, 100);
                            paint.g.FillPath(paint.p.Brush, gp);
                            break;
                    }
                    this.Refresh();
                }
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            paint.p.Color = b.BackColor;
            HatchBrush myHatchBrush = new HatchBrush(HatchStyle.Vertical, paint.p.Color, Color.White);
            //paint.p.Brush = myHatchBrush;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            paint.tool = Tool.Rectangle;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            paint.tool = Tool.Line;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                paint.bitmap.Save(saveFileDialog1.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            paint.tool = Tool.Pen;
            paint.p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            paint.p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            paint.tool = Tool.Brush;

            BrushSelector bs = new BrushSelector();

            if (bs.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                if (bs.brushType == "1")
                {
                    MessageBox.Show("1111");
                }
                else if (bs.brushType == "2")
                {
                    MessageBox.Show("222222");
                }
            }
           
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = colorDialog1.ShowDialog();

            if (res == System.Windows.Forms.DialogResult.OK)
            {
                paint.p.Color = colorDialog1.Color;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
           
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            paint.p.Width = trackBar1.Value * 5 + 1;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK) 
            {
              Bitmap temp  = new Bitmap(openFileDialog1.FileName);
              paint.g.Clear(Color.White);
              paint.g.DrawImage(temp, Point.Empty);
                pictureBox1.Refresh();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            paint.tool = Tool.Fill;
        }
    }
}

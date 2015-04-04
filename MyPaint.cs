using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDIPaint
{
    public enum Tool
    {
        Pen,
        Brush,
        Eraser,
        Rectangle,
        Circle,
        Line
    }

    public class MyPaint
    {
        public MyPaint(Size size)
        {
            this.size = size;
            bitmap = new Bitmap(size.Width, size.Height);

            g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
        }
        public Size size = Size.Empty;
        public Pen p = new Pen(Color.Red, 5);
        public Tool tool = Tool.Pen;
        public Bitmap bitmap = null;
        public Graphics g = null;
    }
}

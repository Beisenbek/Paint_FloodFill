using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDIPaint
{
    public partial class BrushSelector : Form
    {
        public string brushType = "0";
        public BrushSelector()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            brushType = "1";
            Form1 x = this.Owner as Form1;
           x.paint.p.Brush = new SolidBrush(Color.Red);
         
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            brushType = "2";
            Form1 x = this.Owner as Form1;
           
            x.paint.p.Brush = new SolidBrush(Color.Green);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}

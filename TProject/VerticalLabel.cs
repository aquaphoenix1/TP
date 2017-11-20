using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TProject
{
    public partial class VerticalLabel : System.Windows.Forms.Label
    {
        public VerticalLabel()
        {
            InitializeComponent();
        }

        public int RotateAngle { get; set; }
        public string NewText { get; set; }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Brush b = new SolidBrush(this.ForeColor);
            e.Graphics.TranslateTransform(this.Width / 2, this.Height / 2);
            e.Graphics.RotateTransform(this.RotateAngle);
            e.Graphics.DrawString(this.NewText, new Font(Font.FontFamily, 10f, FontStyle.Italic, GraphicsUnit.Point, this.Font.GdiCharSet), b, -19f, 0f);
            base.OnPaint(e);
        }
    }
}

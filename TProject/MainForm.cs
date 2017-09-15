using System.Windows.Forms;

namespace TProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            mas.Add(rect = new Rectangle(20, 20, 50, 50));
            mas.Add(new Rectangle(40, 20, 50, 50));
        }
        Rectangle rect;
        List<Rectangle> mas = new List<System.Drawing.Rectangle>();
        private void pictureBoxMap_Paint(object sender, PaintEventArgs e)
        {

            Pen pen = new Pen(Color.Black);
            e.Graphics.DrawEllipse(pen, re);
            foreach (var r in mas)
                e.Graphics.DrawEllipse(pen, r);
        }

        int dX, dY;
        bool isClicked = false;

        private void pictureBoxMap_MouseUp(object sender, MouseEventArgs e)
        {
            isClicked = false;
            mas.Add(re);
        }

        private void pictureBoxMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (isClicked)
            {
                re.X = e.X - dX;
                re.Y = e.Y - dY;
                pictureBoxMap.Invalidate();
            }
        }
        Rectangle re;
        private void pictureBoxMap_MouseDown(object sender, MouseEventArgs e)
        {
            re = mas.Find(o => e.X < o.X + o.Width && e.X > o.X && e.Y < o.Y + o.Height && e.Y > o.Y);
            if (re  != null)
            {
                mas.Remove(re);
                isClicked = true;
                dX = e.X - re.X;
                dY = e.Y - re.Y;
            }
        }
    }
}

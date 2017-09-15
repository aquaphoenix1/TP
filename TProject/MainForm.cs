using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            vp = new VertexPoints(10, new Pen(Color.Black));
            vp.AddVertexPoint(new Rectangle(20, 15, 10, 10));
            vp.AddVertexPoint(new Rectangle(45, 20, 10, 10));
            vp.AddVertexPoint(new Rectangle(42, 25, 10, 10));
            vp.AddVertexPoint(new Rectangle(90, 30, 10, 10));
            vp.AddVertexPoint(new Rectangle(100, 40, 10, 10));
            vp.AddVertexPoint(new Rectangle(80, 80, 10, 10));
            vp.AddVertexPoint(new Rectangle(70, 65, 10, 10));
            vp.AddVertexPoint(new Rectangle(65, 15, 10, 10));
            vp.AddVertexPoint(new Rectangle(55, 30, 10, 10));
            vp.AddVertexPoint(new Rectangle(45, 40, 10, 10));
            vp.AddVertexPoint(new Rectangle(20, 24, 10, 10));
            vp.AddVertexPoint(new Rectangle(30, 25, 10, 10));
        }
        class VertexPoints
        {
            public Pen Brush { get; private set; }
            private List<Rectangle> vertexPointList;
            private int radius;
            public VertexPoints(int radius, Pen pen)
            {
                this.radius = radius;
                Brush = pen;
                vertexPointList = new List<Rectangle>();
            }
            public void AddVertexPoint(Rectangle rectangle)
            {
                vertexPointList.Add(rectangle);
            }
            public Rectangle SearhVertexPoint(int x, int y)
            {
                return vertexPointList.Find(o => x < o.X + o.Width && x > o.X && y < o.Y + o.Height && y > o.Y);
            }
            public void RemoveVertexPoint(Rectangle rectangle)
            {
                vertexPointList.Remove(rectangle);
            }
            public List<Rectangle> GetVertexPointList()
            {
                return vertexPointList;
            }
        }

        private int dX, dY;
        private bool isClicked = false;
        private VertexPoints vp;
        Rectangle re;



        private void pictureBoxMap_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(vp.Brush, re);
            foreach (var r in vp.GetVertexPointList())
                e.Graphics.DrawEllipse(vp.Brush, r);
        }

        private void pictureBoxMap_MouseUp(object sender, MouseEventArgs e)
        {
            isClicked = false;
            vp.AddVertexPoint(re);
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
        private void pictureBoxMap_MouseDown(object sender, MouseEventArgs e)
        {
            re = vp.SearhVertexPoint(e.X, e.Y);
            if (re != null)
            {
                vp.RemoveVertexPoint(re);
                isClicked = true;
                dX = e.X - re.X;
                dY = e.Y - re.Y;
            }
        }
    }
}

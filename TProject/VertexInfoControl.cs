using System.Drawing;
using System.Windows.Forms;

namespace TProject
{
    public partial class VertexInfoControl : UserControl
    {
        public VertexInfoControl()
        {
            InitializeComponent();
        }
        public void Init(int x, int y, bool isTrLight, Point p)
        {
            Location = p;
            labelName.Text = "Перекресток (X = " + x + "; Y= " + y + ")";
            checkBoxTrafficLight.Checked = isTrLight;
        }

    }
}

using System;
using System.Windows.Forms;
using TProject.Graph;
using TProject.Way;

namespace TProject
{
    public partial class EditVertex : Form
    {
        public Vertex Vertex { get; private set; }

        public EditVertex(Vertex _vertex)
        {
            InitializeComponent();
            Vertex = _vertex;
        }

        private void EditVertex_Load(object sender, EventArgs e)
        {
            linkLabelID.Text = Vertex.ID.ToString();
            bool isChecked = Vertex.IsRegular;
            if (isChecked)
            {
                checkBoxWay.Checked = Vertex.IsRegular;
                TrafficLight trafficLight = Vertex.TrafficLight;
                numericUpDownRed.Value = trafficLight.RedSeconds;
                numericUpDownGreen.Value = trafficLight.GreenSeconds;
            }
            else
            {
                numericUpDownRed.Enabled = false;
                numericUpDownGreen.Enabled = false;
            }
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            Vertex.TrafficLight = (checkBoxWay.Checked) ? new TrafficLight((int)numericUpDownGreen.Value, (int)numericUpDownRed.Value) : null;
            
            Close();
        }

        private void checkBoxWay_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxWay.Checked)
            {
                numericUpDownRed.Enabled = true;
                numericUpDownGreen.Enabled = true;
            }
            else
            {
                numericUpDownRed.Enabled = false;
                numericUpDownGreen.Enabled = false;
            }
        }
    }
}

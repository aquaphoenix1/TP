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
            bool isChecked = Vertex.IsRegular;
            if (isChecked)
            {
               trafficlightCheckBox.Checked = Vertex.IsRegular;
                TrafficLight trafficLight = Vertex.TrafficLight;
               timeRedLightComboBox.SelectedItem = trafficLight.RedSeconds;
                timeGreenLightComboBox.SelectedItem = trafficLight.GreenSeconds;
            }
            else
            {
               timeRedLightComboBox.Enabled = false;
                timeGreenLightComboBox.Enabled = false;
            }
        }

        private voidtrafficlightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxWay.Checked)
            {
               timeRedLightComboBox.Enabled = true;
                timeGreenLightComboBox.Enabled = true;
            }
            else
            {
               timeRedLightComboBox.Enabled = false;
                timeGreenLightComboBox.Enabled = false;
            }
        }

        private void okEditCrossroadButton_Click(object sender, EventArgs e)
        {

            Vertex.TrafficLight = (trafficlightCheckBox.Checked) ? new TrafficLight((int)timeGreenLightComboBox.SelectedItem, (int)timeGreenLightComboBox.SelectedItem) : null;
            Close();
        }
    }
}

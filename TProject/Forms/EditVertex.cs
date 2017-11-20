using System;
using System.Windows.Forms;
using TProject.Graph;
using TProject.Way;

namespace TProject
{
    public partial class EditVertex : Form
    {
        public Vertex Vertex { get; private set; }

        private TrafficLight SaveTF = null;

        public EditVertex(Vertex _vertex)
        {
            InitializeComponent();
            Vertex = _vertex;
            SaveTF = Vertex.TrafficLight;
        }

        private void EditVertex_Load(object sender, EventArgs e)
        {
            bool isChecked = Vertex.IsRegular;
            if (isChecked)
            {
                panelContainer.Enabled = true;
                trafficlightCheckBox.Checked = isChecked;
                TrafficLight trafficLight = Vertex.TrafficLight;
                timeRedLightComboBox.SelectedItem = trafficLight.RedSeconds;
                timeGreenLightComboBox.SelectedItem = trafficLight.GreenSeconds;
            }
            else
            {
                panelContainer.Enabled = false;
                timeRedLightComboBox.Enabled = false;
                timeGreenLightComboBox.Enabled = false;
            }
        }

        private void trafficlightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            panelContainer.Enabled = ((CheckBox)sender).Checked;
        }


        private void okEditCrossroadButton_Click(object sender, EventArgs e)
        {
            if (trafficlightCheckBox.Checked)
                Vertex.TrafficLight = null;
            else
                Vertex.TrafficLight = new TrafficLight(int.Parse(timeGreenLightComboBox.SelectedItem.ToString()),
                    int.Parse(timeRedLightComboBox.SelectedItem.ToString()));
            Close();
        }

        private void cancelEditCrossroadButton_Click(object sender, EventArgs e)
        {
            Vertex.TrafficLight = SaveTF;
            Close();
        }
    }
}

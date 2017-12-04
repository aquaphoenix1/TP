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
                timeRedLightComboBox.Text = trafficLight.RedSeconds.ToString();
                timeGreenLightComboBox.Text = trafficLight.GreenSeconds.ToString();
            }
            else
            {
                panelContainer.Enabled = false;
                timeRedLightComboBox.Enabled = false;
                timeGreenLightComboBox.Enabled = false;
            }
        }

        private void TrafficlightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            panelContainer.Enabled = ((CheckBox)sender).Checked;
            timeGreenLightComboBox.Enabled = panelContainer.Enabled;
            timeRedLightComboBox.Enabled = panelContainer.Enabled;

        }


        private void OkEditCrossroadButton_Click(object sender, EventArgs e)
        {
            int green;
            int red;
            if (!trafficlightCheckBox.Checked)
            {
                Vertex.TrafficLight = null;
            }
            else
            {
                if(timeGreenLightComboBox.Text=="")
                {
                    MessageBox.Show("Введите значение длительности зеленой фазы");
                    return;
                }
                int.TryParse(timeGreenLightComboBox.Text,out green);               
                if (green < 10 || green > 40)
                {
                     MessageBox.Show("Допустимый диапазон значений зеленой фазы от 10 до 40");
                     return;
                }                               

                if (timeRedLightComboBox.Text == "")
                {
                    MessageBox.Show("Введите значение длительности красной фазы");
                    return;
                }
                int.TryParse(timeRedLightComboBox.Text, out red);
                if (red < 20 || red > 70)
                {
                     MessageBox.Show("Допустимый диапазон значений красной фазы от 20 до 70");
                     return;
                }                         
                Vertex.TrafficLight = new TrafficLight(green, red);
            }
            Viewer.ViewPort.Invalidate();
            DialogResult = DialogResult.OK;
        }

        private void CancelEditCrossroadButton_Click(object sender, EventArgs e)
        {
            Vertex.TrafficLight = SaveTF;
        }
    }
}

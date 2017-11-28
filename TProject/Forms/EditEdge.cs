using System;
using System.Windows.Forms;
using TProject.Graph;
using TProject.Way;

namespace TProject
{
    public partial class EditEdge : Form
    {
        public Edge Edge { get; private set; }

        public EditEdge(Edge _edge)
        {
            InitializeComponent();
            Edge = _edge;
        }

        private void checkBoxWay_CheckedChanged(object sender, EventArgs e)
        {
            Edge.IsBilateral = signTwoWayCheckBox.Checked;
            Viewer.ViewPort.Invalidate();
        }

        private void buttonMirror_Click(object sender, EventArgs e)
        {
            Edge.Revers();
            Viewer.ViewPort.Invalidate();
        }
        private void EditEdge_Load(object sender, EventArgs e)
        {
            Edge.StreetList.ForEach(var => nameStreetComboBox.Items.Add(var[1]));

            nameStreetComboBox.SelectedItem = Edge.NameStreet;
            coatingComboBox.SelectedItem = Edge.Coat;
            policemanComboBox.SelectedItem = Edge.Policemen;

            signTwoWayCheckBox.Checked = Edge.IsBilateral;
            signMaxSpeedCheckBox.Checked = Edge.Signs != null;
            policemanCheckBox.Checked = Edge.Policemen != null;
        }

        private void okEditEgdeButton_Click(object sender, EventArgs e)
        {
            Edge.Coat = (Coating)coatingComboBox.SelectedItem;
            Edge.IsBilateral = signTwoWayCheckBox.Checked;
            Edge.NameStreet = nameStreetComboBox.SelectedItem.ToString();
            Edge.Policemen = policemanCheckBox.Checked ? (Police)policemanComboBox.SelectedItem : null;
            Edge.Signs = signMaxSpeedCheckBox.Checked ? (Sign)signMaxSpeedComboBox.SelectedItem : null;
            Close();
        }

        private void cancelEditEgdeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void policemanCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            policemanGroupBox.Enabled = ((CheckBox)sender).Checked;
        }

        private void signMaxSpeedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            signMaxSpeedComboBox.Enabled = ((CheckBox)sender).Checked;
        }
    }
}

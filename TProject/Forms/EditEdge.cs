using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TProject.Graph;
using TProject.Way;

namespace TProject
{
    public partial class EditEdge : Form
    {
        public Edge Edge { get; private set; }

        private Edge SaveEdge;

        public EditEdge(Edge _edge)
        {
            InitializeComponent();
            Edge = _edge;

            SaveEdge = new Edge(Edge.GetHead(), Edge.GetEnd());
            SaveEdge.Coat = Edge.Coat;
            SaveEdge.ID = Edge.ID;
            SaveEdge.IsBilateral = Edge.IsBilateral;
            SaveEdge.NameStreet = Edge.NameStreet;
            SaveEdge.Policemen = Edge.Policemen;
            SaveEdge.Signs = Edge.Signs;
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
            Edge.Coat = SaveEdge.Coat;
            Edge.ID = SaveEdge.ID;
            Edge.IsBilateral = SaveEdge.IsBilateral;
            Edge.NameStreet = SaveEdge.NameStreet;
            Edge.Policemen = SaveEdge.Policemen;
            Edge.Signs = SaveEdge.Signs;
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

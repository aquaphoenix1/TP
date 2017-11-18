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

        public EditEdge(Edge _edge)
        {
            InitializeComponent();
            Edge = _edge;
        }

        private void checkBoxWay_CheckedChanged(object sender, EventArgs e)
        {
            Edge.IsBilateral = checkBoxWay.Checked;
            ((MainForm)Owner).RePaint();
        }

        private void buttonMirror_Click(object sender, EventArgs e)
        {
            Edge.Revers();
            ((MainForm)Owner).RePaint();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            Edge.SetLength((int)numericUpDownLength.Value);
            Edge.NameStreet = textBoxName.Text;


            Edge.Signs = (Sign)comboBoxSign.SelectedItem;
            Edge.Coat = (Coating)coatingComboBox.SelectedItem;

            Close();
        }

        private void EditEdge_Load(object sender, EventArgs e)
        {
            linkLabelID.Text = Edge.ID.ToString();
            textBoxName.Text = Edge.NameStreet;
            numericUpDownLength.Value = Edge.GetLength();
            //comboBoxCoat.DataSource = Coating.collection;
            //comboBoxCoat.DataSource = Coating.ListSurface;
            //comboBoxSign.DataSource = Sign.collection;
            checkBoxWay.Checked = Edge.IsBilateral;
        }
    }
}

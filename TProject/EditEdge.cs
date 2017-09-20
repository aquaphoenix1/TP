using System;
using System.Windows.Forms;

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

            if (comboBoxCoat.SelectedValue == null)
                Edge.Coat = new Edge.Coating();
            if (comboBoxSign.SelectedValue == null)
                Edge.Signs = new Edge.Sign();
            
            Close();
        }

        private void EditEdge_Load(object sender, EventArgs e)
        {
            linkLabelID.Text = Edge.ID.ToString();
            textBoxName.Text = Edge.NameStreet;
            numericUpDownLength.Value = Edge.GetLength();
            //comboBoxCoat.DataSource = Edge.Coat;
            if(!(Edge.Signs == null))
                comboBoxSign.DataSource = Edge.Signs;
            checkBoxWay.Checked = Edge.IsBilateral;
        }
    }
}

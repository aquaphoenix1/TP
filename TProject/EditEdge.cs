using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TProject
{
    public partial class EditEdge : Form
    {
        public Edge Edge { get; private set; }

        public EditEdge(Edge _edge)
        {
            InitializeComponent();
            linkLabel1.Text = _edge.ID.ToString();
            Edge = _edge;
            checkBox1.Checked = _edge.IsBilateral;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Edge.IsBilateral = checkBox1.Checked;
            ((MainForm)Owner).RePaint();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Edge.Revers();
            ((MainForm)Owner).RePaint();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Edge.SetLength((int)numericUpDown1.Value);
            Edge.NameStreet = textBox1.Text;

            if (comboBox1.SelectedValue == null)
                Edge.Coat = new Edge.Coating();
            if (comboBox2.SelectedValue == null)
                Edge.Signs = new Edge.Sign();

            this.AcceptButton.DialogResult = DialogResult.OK;
            Close();
        }
    }
}

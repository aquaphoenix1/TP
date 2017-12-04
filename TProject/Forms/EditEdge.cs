using System;
using System.Collections.Generic;
using System.Linq;
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

            Edge.StreetList.ForEach(var => nameStreetComboBox.Items.Add(var[0]));
            Coating.ListSurface.ForEach(var => coatingComboBox.Items.Add(var[0]));
            Police.ListTypePolicemen.ForEach(var => policemanComboBox.Items.Add(var[0]));
            Sign.ListSigns.ForEach(var => signMaxSpeedComboBox.Items.Add(var[0]));

            if(_edge.Policemen != null)
            {
                policemanCheckBox.Checked = true;
                policemanComboBox.SelectedIndex = policemanComboBox.FindString(_edge.Policemen.TypeName);
            }

            signTwoWayCheckBox.Checked = _edge.SignTwoWay;

            if (_edge.SignMaxSpeed != null)
            {
                signMaxSpeedCheckBox.Checked = true;
                signMaxSpeedComboBox.SelectedIndex = signMaxSpeedComboBox.FindString(_edge.SignMaxSpeed.TypeName);
            }

            try
            {
                nameStreetComboBox.SelectedIndex = nameStreetComboBox.FindString(_edge.NameStreet);
                coatingComboBox.SelectedIndex = coatingComboBox.FindString(_edge.Coat.TypeName);
            }
            catch { }
            signMaxSpeedComboBox.Enabled = signMaxSpeedCheckBox.Checked;
            policemanComboBox.Enabled = policemanCheckBox.Checked;
        }

        private void CheckBoxWay_CheckedChanged(object sender, EventArgs e)
        {
            Edge.IsBilateral = signTwoWayCheckBox.Checked;
            Viewer.ViewPort.Invalidate();
        }

        private void OkEditEgdeButton_Click(object sender, EventArgs e)
        {
            if(nameStreetComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите название улицы");
                return;
            }
            else if(coatingComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите покрытие");
                return;
            }
            else
            {
                bool isPolice = policemanCheckBox.Checked;

                if (isPolice)
                {
                    if (policemanComboBox.SelectedItem == null)
                    {
                        MessageBox.Show("Выберите полицейского");
                        return;
                    }
                }

                bool isSignMaxSpeed = signMaxSpeedCheckBox.Checked;

                if (isSignMaxSpeed)
                {
                    if (signMaxSpeedComboBox.SelectedItem == null)
                    {
                        MessageBox.Show("Выберите знак");
                        return;
                    }
                }

                if (isPolice)
                {
                    Edge.Policemen = Police.CreatePolice(policemanComboBox.SelectedItem.ToString());
                }

                if (isSignMaxSpeed)
                {
                    List<object> sign = Sign.ListSigns.First(sg => sg[0].ToString().Equals(signMaxSpeedComboBox.SelectedItem.ToString()));
                    Edge.SignMaxSpeed = Sign.CreateSign(sign[0].ToString(), double.Parse(sign[1].ToString()));
                }

                Edge.NameStreet = nameStreetComboBox.SelectedItem.ToString();

                List<object> coat = Coating.ListSurface.First(coating => coating[0].ToString().Equals(coatingComboBox.SelectedItem.ToString()));
                Edge.Coat = Coating.CreateCoating(coat[0].ToString(), double.Parse(coat[1].ToString()));

                Edge.IsBilateral = signTwoWayCheckBox.Checked;

                Edge.SignTwoWay = signTwoWayCheckBox.Checked;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelEditEgdeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PolicemanCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            policemanComboBox.Enabled = ((CheckBox)sender).Checked;
        }

        private void SignMaxSpeedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            signMaxSpeedComboBox.Enabled = ((CheckBox)sender).Checked;
        }
    }
}

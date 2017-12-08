using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TProject.Forms
{
    public partial class SaveAs : Form
    {
        public string nameMap;
        private bool flag = false;
        public SaveAs()
        {
            InitializeComponent();

            comboBoxNames.Visible = false;
            comboBoxNames.Enabled = false;

            textBoxMapName.Visible = true;
            textBoxMapName.Enabled = true;
        }
        public SaveAs(bool fl):this()
        {
            label1.Text = "Выбрите имя карты, которую Вы хотите открыть:";
            Text = "Открыть";
            flag = fl;

            comboBoxNames.Visible = true;
            comboBoxNames.Enabled = true;

            textBoxMapName.Visible = false;
            textBoxMapName.Enabled = false;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            string name = textBoxMapName.Text;

            if (!flag)
            {
                if (name.Length == 0)
                {
                    MessageBox.Show("Введите название");
                }
                else
                {
                    if (DAO.GetAll("Maps", string.Format("Name = '{0}'", name)).Count == 0)
                    {
                        try
                        {
                            DAO.InsertMap(Map.vertexes, Map.edges, Viewer.ViewPort.View.Image, name);
                            Map.Name = name;
                            DialogResult = DialogResult.OK;
                            Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            else
            {
                if(comboBoxNames.SelectedItem != null)
                {
                    nameMap = comboBoxNames.SelectedItem.ToString();
                    Map.Name = nameMap;
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Выберите карту!");
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SaveAs_Load(object sender, EventArgs e)
        {
            List<List<object>> list = DAO.GetAll("Maps");

            list.ForEach(var => comboBoxNames.Items.Add(var[0].ToString()));
        }
    }
}

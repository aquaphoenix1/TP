using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TProject.Forms
{
    public partial class ConductingForm : Form
    {
        public string nameMap;
        private Act act;
        private Image img;
        public ConductingForm(Image img, Act act) : this()
        {
            this.img = img;
            this.act = act;

            AddOrRemoveAct();
        }

        private ConductingForm()
        {
            InitializeComponent();
        }

        public ConductingForm(Act act) : this()
        {
            this.act = act;

            switch (act)
            {
                case Act.Load:
                    {
                        labelNameMapSave.Text = "Выберите имя карты, которую Вы хотите открыть:";
                        Text = "Открыть";

                        LoadOrRemoveMapAct();

                        break;
                    }
                case Act.Add:
                    {
                        AddOrRemoveAct();

                        break;
                    }
                case Act.Delete:
                    {
                        labelNameMapSave.Text = "Выберите имя карты, которую Вы хотите удалить:";
                        Text = "Удалить";

                        LoadOrRemoveMapAct();

                        break;
                    }
            }
        }

        private void LoadOrRemoveMapAct()
        {
            comboBoxNames.Visible = true;
            comboBoxNames.Enabled = true;

            textBoxMapName.Visible = false;
            textBoxMapName.Enabled = false;

            pictureBoxMiniMap.Enabled = true;
            pictureBoxMiniMap.Visible = true;

            Width = 433;
            Height = 284;

            buttonCancel.Location = new Point(330, 217);
            buttonOk.Location = new Point(249, 217);

            pictureBoxMiniMap.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void AddOrRemoveAct()
        {
            comboBoxNames.Visible = false;
            comboBoxNames.Enabled = false;

            textBoxMapName.Visible = true;
            textBoxMapName.Enabled = true;

            pictureBoxMiniMap.Enabled = false;
            pictureBoxMiniMap.Visible = false;

            Width = 433;
            Height = 120;

            buttonCancel.Location = new Point(330, 48);
            buttonOk.Location = new Point(249, 48);
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            string name = textBoxMapName.Text;

            if (act == Act.Add)
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
                            if (MakeMap.ViewPort != null)
                            {
                                DAO.InsertMap(Map.vertexes, Map.edges, MakeMap.ViewPort.View.Image, name);
                            }
                            else
                            {
                                DAO.InsertMap(Map.vertexes, Map.edges, img, name);
                            }

                            Map.Name = name;
                            DialogResult = DialogResult.OK;
                            Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Карта с таким именем уже существует!");
                    }
                }
            }
            else if (act == Act.Load)
            {
                if (comboBoxNames.SelectedItem != null)
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
            else
            {
                if (comboBoxNames.SelectedItem != null)
                {
                    if (DAO.RemoveMap(comboBoxNames.SelectedItem.ToString()))
                    {
                        comboBoxNames.Items.RemoveAt(comboBoxNames.SelectedIndex);
                        pictureBoxMiniMap.Image = null;
                    }
                }
                else
                {
                    MessageBox.Show("Выберите карту!");
                }
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SaveAs_Load(object sender, EventArgs e)
        {
            List<List<object>> list = DAO.GetAll("Maps");

            list.ForEach(var => comboBoxNames.Items.Add(var[0].ToString()));
        }

        private void ComboBoxNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxNames.SelectedItem != null)
            {
                pictureBoxMiniMap.Image = DAO.LoadPicture(comboBoxNames.SelectedItem.ToString()) as Image;
            }
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;
using TProject.Graph;

namespace TProject
{
    public partial class FormStreet : Form
    {
        private bool addOrEdit;
        private long ID;

        public FormStreet()
        {
            InitializeComponent();
        }

        public FormStreet(bool addOrEdit) : this()
        {
            this.addOrEdit = addOrEdit;
        }

        public FormStreet(long id, string name) : this(false)
        {
            textBoxNameStreet.Text = name;
            this.ID = id;
        }

        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            string name = textBoxNameStreet.Text;
            textBoxNameStreet.BackColor = Color.White;

            if((string.IsNullOrWhiteSpace(name)) || (string.IsNullOrEmpty(name)))
            {
                MessageBox.Show("Не корректное название улицы!");
                textBoxNameStreet.BackColor = Color.Red;
            }
            else
            {
                if (addOrEdit)
                {
                    Add();
                }
                else
                {
                    Edit();
                }
            }
        }

        private void Add()
        {
            string[] array = new string[2];
            array[0] = (++Edge.CurrentMaxID).ToString();
            array[1] = textBoxNameStreet.Text;

            object value = array;

            if (new TypeDAO.StreetDAO().Insert(value))
            {
                Main.IsChanged = true;

                Close();
            }
            else
            {
                Edge.CurrentMaxID--;
                MessageBox.Show("Ошибка добавления");
            }
        }

        private void Edit()
        {
            Close();
        }
    }
}

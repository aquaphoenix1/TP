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

        private void Accept()
        {
            string name = textBoxNameStreet.Text;
            textBoxNameStreet.BackColor = Color.White;

            if ((string.IsNullOrWhiteSpace(name)) || (string.IsNullOrEmpty(name)))
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

        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            Accept();
        }

        private void Add()
        {
            string str = textBoxNameStreet.Text;

            object value = str;

            if (new TypeDAO.StreetDAO().Insert(value))
            {
                Main.IsChanged = true;

                Close();
            }
            else
            {
                MessageBox.Show("Ошибка добавления");
            }
        }

        private void Edit()
        {
            Close();
        }

        private void TextBoxNameStreet_TextChanged(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(textBoxNameStreet.Text)) || (string.IsNullOrEmpty(textBoxNameStreet.Text)))
            {
                textBoxNameStreet.BackColor = Color.Red;
            }
            else
            {
                textBoxNameStreet.BackColor = Color.White;
            }
        }

        private void TextBoxNameStreet_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Accept();
            }
        }

        private void ButtonAccept_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Accept();
            }
        }
    }
}

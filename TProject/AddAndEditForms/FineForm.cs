using System;
using System.Drawing;
using System.Windows.Forms;
using TProject.TypeDAO;
using TProject.Way;

namespace TProject
{
    public partial class FineForm : Form
    {
        private bool addOrEdit;
        private Fine fine;
        private string ID;

        private FineForm()
        {
            InitializeComponent();
        }

        public FineForm(bool addOrEdit) : this()
        {
            this.addOrEdit = addOrEdit;
        }

        public FineForm(string nFine, double cost) : this(false)
        {
            fine = Fine.CreateFine(nFine, cost);

            textBoxNameFine.Text = nFine;
            textBoxValueFine.Text = cost.ToString();

            ID = nFine;
        }

        private void Accept()
        {
            textBoxNameFine.BackColor = Color.White;

            string name = textBoxNameFine.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Название штрафа не задано!");
                textBoxNameFine.BackColor = Color.Red;
            }
            else
            {
                if (double.TryParse(textBoxValueFine.Value.ToString(), out double d))
                {
                    if (fine == null)
                    {
                        fine = new Fine(name, d);
                    }
                    else
                    {
                        fine.TypeName = name;
                        fine.Count = d;
                    }

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
        }

        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            Accept();
        }

        private void Add()
        {
            if (new FineDAO().Insert(fine))
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
            if (new FineDAO().Update(fine, ID))
            {
                Main.IsChanged = true;
                Close();
            }
            else
            {
                MessageBox.Show("Ошибка изменения");
            }
        }

        private void TextBoxNameFine_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNameFine.Text) || string.IsNullOrEmpty(textBoxNameFine.Text))
            {
                textBoxNameFine.BackColor = Color.Red;
            }
            else
            {
                textBoxNameFine.BackColor = Color.White;
            }
        }

        private void TextBoxNameFine_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Accept();
            }
        }

        private void TextBoxValueFine_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Accept();
            }
        }

        private void ButtonAccept_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Accept();
            }
        }
    }
}

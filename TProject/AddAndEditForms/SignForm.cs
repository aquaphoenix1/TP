using System;
using System.Drawing;
using System.Windows.Forms;
using TProject.TypeDAO;
using TProject.Way;

namespace TProject
{
    public partial class SignForm : Form
    {
        private bool addOrEdit;
        private Sign sign;

        private SignForm()
        {
            InitializeComponent();
        }

        public SignForm(bool addOrEdit) : this()
        {
            this.addOrEdit = addOrEdit;
        }

        public SignForm(long id, string tSign, double value) : this(false)
        {
            sign = Sign.CreateSign(id, tSign, value);

            textBoxTypeSign.Text = tSign;
            textBoxValueSign.Value =(decimal)value;
        }

        private void Accept()
        {
            textBoxTypeSign.BackColor = Color.White;

            string type = textBoxTypeSign.Text;

            if (string.IsNullOrWhiteSpace(type) || string.IsNullOrEmpty(type))
            {
                textBoxTypeSign.BackColor = Color.Red;
                MessageBox.Show("Тип дорожного знака не задан!");
            }
            else
            {
                if (double.TryParse(textBoxValueSign.Text, out double d))
                {
                    if (sign == null)
                    {
                        sign = new Sign(type, d);
                    }
                    else
                    {
                        sign.TypeName = type;
                        sign.Count = d;
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
            if (new SignDAO().Insert(sign))
            {
                Main.IsChanged = true;

                Close();
            }
            else
            {
                MessageBox.Show("Ошибка добавления");
                Sign.CurrentMaxID--;
            }
        }

        private void Edit()
        {
            if (new SignDAO().Update(sign))
            {
                Main.IsChanged = true;
                Close();
            }
            else
            {
                MessageBox.Show("Ошибка изменения");
            }
        }

        private void TextBoxTypeSign_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxTypeSign.Text) || string.IsNullOrEmpty(textBoxTypeSign.Text))
            {
                textBoxTypeSign.BackColor = Color.Red;
            }
            else
            {
                textBoxTypeSign.BackColor = Color.White;
            }
        }

        private void TextBoxTypeSign_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Accept();
            }
        }

        private void TextBoxValueSign_KeyUp(object sender, KeyEventArgs e)
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

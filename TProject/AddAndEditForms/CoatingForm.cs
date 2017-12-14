using System;
using System.Drawing;
using System.Windows.Forms;
using TProject.TypeDAO;
using TProject.Way;

namespace TProject
{
    public partial class CoatingForm : Form
    {
        private bool addOrEdit;
        private Coating coating;
        private string ID;

        private CoatingForm()
        {
            InitializeComponent();
        }

        public CoatingForm(bool addOrEdit) : this()
        {
            this.addOrEdit = addOrEdit;
        }

        public CoatingForm(string tCoating, double coeff) : this(false)
        {
            coating = Coating.CreateCoating(tCoating, coeff);

            textBoxTypeCoating.Text = tCoating;
            ID = tCoating;

            textBoxCoefficient.Text = coeff.ToString();
        }

        private void Accept()
        {
            textBoxTypeCoating.BackColor = Color.White;

            string type = textBoxTypeCoating.Text;
            double d;
            if (string.IsNullOrWhiteSpace(type) || string.IsNullOrEmpty(type))
            {
                MessageBox.Show("Тип покрытия не задан!");
                textBoxTypeCoating.BackColor = Color.Red;
            }
            else
            {
                if (double.TryParse(textBoxCoefficient.Text, out d))
                {
                    if (d > 1 || d == 0)
                    {
                        MessageBox.Show("Допустимый диапазон коэффициента: (0,1]!");
                    }
                    else
                    {
                        if (coating == null)
                        {
                            coating = new Coating(type, d);
                        }
                        else
                        {
                            coating.TypeName = type;
                            coating.Coeff = d;
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
        }

        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            Accept();
        }

        private void Add()
        {
            if (new CoatingDAO().Insert(coating))
            {
                Main.IsChanged = true;

                Close();
            }
            else
            {
                MessageBox.Show("Данная запись уже существует!");
            }
        }

        private void Edit()
        {
            if (new CoatingDAO().Update(coating, ID))
            {
                Main.IsChanged = true;
                Close();
            }
            else
            {
                MessageBox.Show("Данная запись уже существует!");
            }
        }

        private void TextBoxTypeCoating_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxTypeCoating.Text) || string.IsNullOrEmpty(textBoxTypeCoating.Text))
            {
                textBoxTypeCoating.BackColor = Color.Red;
            }
            else
            {
                textBoxTypeCoating.BackColor = Color.White;
            }
        }

        private void TextBoxTypeCoating_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Accept();
            }
        }

        private void TextBoxCoefficient_KeyUp(object sender, KeyEventArgs e)
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

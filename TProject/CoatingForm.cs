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

        private CoatingForm()
        {
            InitializeComponent();
        }
        
        public CoatingForm(bool addOrEdit) : this()
        {
            this.addOrEdit = addOrEdit;
        }

        public CoatingForm(long id, string tCoating, double coeff) : this(false)
        {
            coating = Coating.CreateCoating(id, tCoating, coeff);

            textBoxTypeCoating.Text = tCoating;
            textBoxCoefficient.Text = coeff.ToString();
        }
        
        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            textBoxCoefficient.BackColor = Color.White;
            textBoxTypeCoating.BackColor = Color.White;

            string type = textBoxTypeCoating.Text;

            if (string.IsNullOrWhiteSpace(type) || string.IsNullOrEmpty(type))
            {
                MessageBox.Show("Тип покрытия не задан!");
                textBoxTypeCoating.BackColor = Color.Red;
            }
            else
            {
                if (double.TryParse(textBoxCoefficient.Text, out double d))
                {
                    if (coating == null)
                    {
                        coating = new Coating(type, d);
                    }
                    else
                    {
                        coating.TypeName = textBoxTypeCoating.Text;
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
                else
                {
                    MessageBox.Show("Не корректно задан коэффициент!");
                    textBoxCoefficient.BackColor = Color.Red;
                }
            }

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
                MessageBox.Show("Ошибка добавления");
                Coating.CurrentMaxID--;
            }
        }

        private void Edit()
        {
            if (new CoatingDAO().Update(coating))
            {
                Main.IsChanged = true;
                Close();
            }
            else
            {
                MessageBox.Show("Ошибка изменения");
            }
        }
    }
}

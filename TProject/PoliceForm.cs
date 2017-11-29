using System;
using System.Drawing;
using System.Windows.Forms;
using TProject.Way;

namespace TProject
{
    public partial class PoliceForm : Form
    {
        private bool addOrEdit;
        private Police police;

        private PoliceForm()
        {
            InitializeComponent();
        }

        public PoliceForm(bool addOrEdit) : this()
        {
            this.addOrEdit = addOrEdit;
        }

        public PoliceForm(long id, string tPolice, double coeff) : this(false)
        {
            police = Police.CreatePolice(id, tPolice, coeff);
            textBoxTypePolice.Text = tPolice;
            textBoxCoefficient.Text = coeff.ToString();
        }

        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            textBoxTypePolice.BackColor = Color.White;
            textBoxCoefficient.BackColor = Color.White;
            string type = textBoxTypePolice.Text;

            if (string.IsNullOrWhiteSpace(type) || string.IsNullOrEmpty(type))
            {
                textBoxTypePolice.BackColor = Color.Red;
                MessageBox.Show("Поле тип полицейского не задан!");
            }
            else
            {
                if (double.TryParse(textBoxCoefficient.Text, out double d))
                {
                    if (police == null)
                    {
                        police = new Police(type, d);
                    }
                    else
                    {
                        police.TypeName = textBoxTypePolice.Text;
                        police.Coeff = d;
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
            if (new PoliceDAO().Insert(police))
            {
                Main.IsChanged = true;

                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка создания");
                Police.CurrentMaxID--;
            }
        }

        private void Edit()
        {
            if (new PoliceDAO().Update(police))
            {
                Main.IsChanged = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка обновления");
            }
        }

       
    }
}

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

        private FineForm()
        {
            InitializeComponent();
        }
        
        public FineForm(bool addOrEdit) : this()
        {
            this.addOrEdit = addOrEdit;
        }

        public FineForm(long id, string nFine, double cost) : this(false)
        {
            fine = Fine.CreateFine(id, nFine, cost);

            textBoxNameFine.Text = nFine;
            textBoxValueFine.Text = cost.ToString();
        }

        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            textBoxNameFine.BackColor = Color.White;
            textBoxValueFine.BackColor = Color.White;

            string name = textBoxNameFine.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Название штрафа не задано!");
                textBoxNameFine.BackColor = Color.Red;
            }
            else
            {
                if (double.TryParse(textBoxValueFine.Text, out double d) || d > 0)
                {
                    if (fine == null)
                    {
                        fine = new Fine(name, d);
                    }
                    else
                    {
                        fine.TypeName = textBoxNameFine.Text;
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
                else
                {
                    MessageBox.Show("Не корректно задан коэффициент!");
                    textBoxValueFine.BackColor = Color.Red;
                }
            }
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
                Fine.CurrentMaxID--;
            }
        }

        private void Edit()
        {
            if (new FineDAO().Update(fine))
            {
                Main.IsChanged = true;
                Close();
            }
            else
            {
                MessageBox.Show("ОШибка изменения");
            }
        }
    }
}

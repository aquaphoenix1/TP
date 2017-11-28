using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TProject.Way;

namespace TProject
{
    public partial class PoliceForm : Form
    {
        private bool addOrEdit; //Добавление или изменение
        private Police p;      

        private PoliceForm()
        {
            InitializeComponent();
        }

        public PoliceForm(bool addOrEdit) : this()
        {
            button1.Text = (addOrEdit) ? "Добавить" : "Изменить";
            this.addOrEdit = addOrEdit;
        }

        public PoliceForm(int id, string tPolice, double coeff) : this(false)
        {
            p = new Police(id, tPolice, coeff);
            tb_TypePolice.Text = tPolice;
            tb_Coefficient.Text = coeff.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_TypePolice.Text))
                MessageBox.Show("Поле тип полицейского не задан !");
            else
            {
                double d;
                if (double.TryParse(tb_Coefficient.Text, out d))
                {
                    if (p == null) p = new Police(tb_TypePolice.Text, d);
                    else
                    {
                        p.TypeName = tb_TypePolice.Text;
                        p.Coeff = d;
                    }
                    if (addOrEdit) Add();
                    else Edit();

                }
                else MessageBox.Show("Не корректно задан коэффициент !");
            }
        }




        private void Add()
        {
            if (new PoliceDAO().Insert(p))
            {
                this.Close();
            }
        }

        private void Edit()
        {
            if (new PoliceDAO().Update(p))
            {
                this.Close();
            }
        }

       
    }
}

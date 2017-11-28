using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TProject.TypeDAO;
using TProject.Way;

namespace TProject
{
    public partial class CoatingForm : Form
    {
        private bool addOrEdit; //Добавление или изменение
        private Coating c;

        private CoatingForm()
        {
            InitializeComponent();
        }

        //изменение кнопки
        public CoatingForm(bool addOrEdit) : this()
        {
            button1.Text = (addOrEdit) ? "Добавить" : "Изменить";
            this.addOrEdit = addOrEdit;
        }
        //Конструктор
        public CoatingForm(int id, string tCoating, double coeff) : this(false)
        {
            c = new Coating(id, tCoating, coeff);
            tb_TypeCoating.Text = tCoating;
            tb_Coefficient.Text = coeff.ToString();
        }

       
        //нажата кнопка добавить новое покрытие
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_TypeCoating.Text))
                MessageBox.Show("Тип покрытия не задано !");
            else
            {
                double d;
                if (double.TryParse(tb_Coefficient.Text, out d))
                {
                    if (c == null) c = new Coating(tb_TypeCoating.Text, d);
                    else
                    {
                        c.TypeName = tb_TypeCoating.Text;
                        c.Coeff = d;
                    }
                    if (addOrEdit) Add();
                    else Edit();

                }
                else MessageBox.Show("Не корректно задан коэффициент !");
            }

        }

        
        private void Add()
        {
            if (new CoatingDAO().Insert(c))
            {
                Close();
            }
        }
        
        private void Edit()
        {
            if (new CoatingDAO().Update(c))
            {
                Close();
            }
        }
    }
}

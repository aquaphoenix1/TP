using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TProject.Driver;
using TProject.TypeDAO;

namespace TProject
{
    public partial class FuelForm : Form
    {
        private bool addOrEdit; //Добавление или изменение
        private Fuel f;

        private FuelForm()
        {
            InitializeComponent();
        }

        //изменение кнопки
        public FuelForm(bool addOrEdit) : this()
        {
            button1.Text = (addOrEdit) ? "Добавить" : "Изменить";
            this.addOrEdit = addOrEdit;
        }
        //Конструктор
        public FuelForm(int id, string nFuel, double price) : this(false)
        {
            f = new Fuel(id, nFuel, price);
            tb_NameFuel.Text = nFuel;
            tb_Price.Text = price.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_NameFuel.Text))
                MessageBox.Show("Тип покрытия не задано !");
            else
            {
                double d;
                if (double.TryParse(tb_Price.Text, out d))
                {
                    if (f == null) f = new Fuel(tb_NameFuel.Text, d);
                    else
                    {
                        f.TypeName = tb_NameFuel.Text;
                        f.Price = d;
                    }
                    if (addOrEdit) Add();
                    else Edit();

                }
                else MessageBox.Show("Не корректно задан коэффициент !");
            }
        }
        private void Add()
        {
            if (new FuelDAO().Insert(f))
            {
                Close();
            }
        }

        private void Edit()
        {
            if (new FuelDAO().Update(f))
            {
                Close();
            }
        }
    }
}

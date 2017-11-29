using System;
using System.Drawing;
using System.Windows.Forms;
using TProject.Driver;
using TProject.TypeDAO;

namespace TProject
{
    public partial class FuelForm : Form
    {
        private bool addOrEdit;
        private Fuel fuel;

        private FuelForm()
        {
            InitializeComponent();
        }

        public FuelForm(bool addOrEdit) : this()
        {
            this.addOrEdit = addOrEdit;
        }

        public FuelForm(long id, string nFuel, double price) : this(false)
        {
            fuel = Fuel.CreateFuel(id, nFuel, price);

            textBoxNameFuel.Text = nFuel;
            textBoxPrice.Text = price.ToString();
        }

        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            textBoxNameFuel.BackColor = Color.White;
            textBoxPrice.BackColor = Color.White;

            string name = textBoxNameFuel.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Название топлива не задано!");
                textBoxNameFuel.BackColor = Color.Red;
            }
            else
            {
                if (double.TryParse(textBoxPrice.Text, out double d) || d > 0)
                {
                    if (fuel == null)
                    {
                        fuel = new Fuel(name, d);
                    }
                    else
                    {
                        fuel.TypeName = name;
                        fuel.Price = d;
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
                    MessageBox.Show("Не корректно задана цена!");
                    textBoxPrice.BackColor = Color.Red;
                }
            }
        }
        private void Add()
        {
            if (new FuelDAO().Insert(fuel))
            {
                Main.IsChanged = true;
                Close();
            }
            else
            {
                MessageBox.Show("Ошибка добавления");
                Fuel.CurrentMaxID--;
            }
        }

        private void Edit()
        {
            if (new FuelDAO().Update(fuel))
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

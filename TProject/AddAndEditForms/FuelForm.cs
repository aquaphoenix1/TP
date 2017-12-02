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
            
            textBoxPrice.Value = (decimal)price;
        }

        private void Accept()
        {
            textBoxNameFuel.BackColor = Color.White;

            string name = textBoxNameFuel.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Название топлива не задано!");
                textBoxNameFuel.BackColor = Color.Red;
            }
            else
            {
                if (double.TryParse(textBoxPrice.Value.ToString(), out double d))
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
            }
        }

        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            Accept();
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

        private void TextBoxNameFuel_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNameFuel.Text) || string.IsNullOrEmpty(textBoxNameFuel.Text))
            {
                textBoxNameFuel.BackColor = Color.Red;
            }
            else
            {
                textBoxNameFuel.BackColor = Color.White;
            }
        }

        private void TextBoxNameFuel_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Accept();
            }
        }

        private void TextBoxPrice_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
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

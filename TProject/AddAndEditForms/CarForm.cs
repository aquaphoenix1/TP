using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TProject.Driver;
using TProject.TypeDAO;

namespace TProject
{
    public partial class CarForm : Form
    {
        private bool addOrEdit;
        private Car car;

        private string ID;

        private CarForm()
        {
            InitializeComponent();
        }

        public CarForm(bool addOrEdit) : this()
        {
            Fuel.ListFuel.ForEach(var => comboBoxIDFuel.Items.Add(var[0]));
            this.addOrEdit = addOrEdit;
        }

        public CarForm(string model, Fuel fuel, double consumption, double speed) : this(false)
        {
            car = Car.CreateCar(model, fuel, consumption, speed);
            textBoxModel.Text = model;

            ID = model;

            comboBoxIDFuel.SelectedIndex = comboBoxIDFuel.FindString(fuel.TypeName);
            textBoxConsumption.Text = consumption.ToString();
            textBoxSpeed.Text = speed.ToString();
        }

        private void Accept()
        {
            string model = textBoxModel.Text;
            string consumption = textBoxConsumption.Value.ToString();
            string speed = textBoxSpeed.Value.ToString();
            string f = string.Empty;

            textBoxModel.BackColor = Color.White;

            if (string.IsNullOrWhiteSpace(model) || string.IsNullOrEmpty(model))
            {
                MessageBox.Show("Не корректное значение модели!");
                textBoxModel.BackColor = Color.Red;
            }
            else if (comboBoxIDFuel.SelectedItem == null)
            {
                MessageBox.Show("Не выбрано топливо!");
            }
            else
            {
                f = comboBoxIDFuel.SelectedItem.ToString();
                double spd = double.Parse(speed);
                double cons = double.Parse(consumption);

                var findfuel = Fuel.ListFuel.First(l => l.ElementAt(0).ToString().Equals(f));

                Fuel fuel = Fuel.CreateFuel(findfuel[0].ToString(), double.Parse(findfuel[1].ToString()));

                if (car == null)
                {
                    car = new Car(model, fuel, cons, spd);
                }
                else
                {
                    car.TypeName = model;
                    car.CarFuel = fuel;
                    car.FuelConsumption = cons;
                    car.Speed = spd;
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

    private void ButtonAccept_Click(object sender, EventArgs e)
    {
        Accept();
    }

    private void Add()
    {
        if (new CarDAO().Insert(car))
        {
            Main.IsChanged = true;

            Close();
        }
        else
        {
            MessageBox.Show("Ошибка добавления");
        }
    }

    private void Edit()
    {
        if (new CarDAO().Update(car, ID))
        {
            Main.IsChanged = true;

            Close();
        }
        else
        {
            MessageBox.Show("Ошибка изменения");
        }
    }

    private void TextBoxModel_TextChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(textBoxModel.Text) || string.IsNullOrEmpty(textBoxModel.Text))
        {
            textBoxModel.BackColor = Color.Red;
        }
        else
        {
            textBoxModel.BackColor = Color.White;
        }
    }

    private void TextBoxModel_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            Accept();
        }
    }

    private void ComboBoxIDFuel_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            Accept();
        }
    }

    private void TextBoxConsumption_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            Accept();
        }
    }

    private void TextBoxSpeed_KeyUp(object sender, KeyEventArgs e)
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

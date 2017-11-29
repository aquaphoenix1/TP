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

        private CarForm()
        {
            InitializeComponent();
        }

        public CarForm(bool addOrEdit) : this()
        {
            Fuel.ListFuel.ForEach(var => comboBoxIDFuel.Items.Add(var[0]));
            this.addOrEdit = addOrEdit;
        }

        public CarForm(long id, string model, Fuel fuel, double consumption) : this(false)
        {
            car = Car.CreateCar(id, model, fuel, consumption);
            textBoxModel.Text = model;
            comboBoxIDFuel.SelectedIndex = comboBoxIDFuel.FindString(fuel.ID.ToString());
            textBoxConsumption.Text = consumption.ToString();
        }

        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            string model = textBoxModel.Text;
            string consumption = textBoxConsumption.Text;

            textBoxModel.BackColor = Color.White;
            textBoxConsumption.BackColor = Color.White;

            if (string.IsNullOrWhiteSpace(model) || string.IsNullOrEmpty(model))
            {
                MessageBox.Show("Не корректное значение модели!");
                textBoxModel.BackColor = Color.Red;
            }
            else
            {
                if (double.TryParse(consumption, out double d))
                {
                    if (long.TryParse(comboBoxIDFuel.Text, out long idFuel))
                    {
                        var findfuel = Fuel.ListFuel.First(l => l.ElementAt(0).ToString() == comboBoxIDFuel.SelectedItem.ToString());

                        Fuel fuel = Fuel.CreateFuel(long.Parse(findfuel[0].ToString()), findfuel[1].ToString(), double.Parse(findfuel[2].ToString()));

                        if (car == null)
                        {
                            car = new Car(textBoxModel.Text, fuel, double.Parse(textBoxConsumption.Text));
                        }
                        else
                        {
                            car.TypeName = textBoxModel.Text;
                            car.CarFuel = fuel;
                            car.FuelConsumption = double.Parse(textBoxConsumption.Text);
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
                        MessageBox.Show("Не выбрано топливо!");
                    }
                }
                else
                {
                    MessageBox.Show("Не корректно задано потребление!");
                    textBoxConsumption.BackColor = Color.Red;
                }
            }
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
                Car.CurrentMaxID--;
            }
        }

        private void Edit()
        {
            if (new CarDAO().Update(car))
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

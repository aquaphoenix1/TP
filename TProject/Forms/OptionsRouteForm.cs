using System.Linq;
using System.Windows.Forms;

namespace TProject
{
    public partial class OptionsRouteForm : Form
    {
        public Main.Criterial Criterial { private set; get; }
        public Driver.Driver Drive { private set; get; }

        public OptionsRouteForm()
        {
            InitializeComponent();

            TProject.Driver.Driver.ListDriver.ForEach((System.Collections.Generic.List<object> drive) => driverComboBox.Items.Add(drive[0]));

            driverComboBox.SelectedIndex = 0;
            critSearchComboBox.SelectedIndex = 0;
        }

        private void OkRouteButton_Click(object sender, System.EventArgs e)
        {
            if(driverComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите водителя!");
            }
            else if (critSearchComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите критерий поиска!");
            }
            else
            {
                System.Collections.Generic.List<object> driver = Driver.Driver.ListDriver.First(dv => dv[0].ToString().Equals(driverComboBox.SelectedItem.ToString()));


                switch (critSearchComboBox.SelectedItem.ToString())
                {
                    case "Время":
                        {
                            Criterial = Main.Criterial.Time;

                            System.Collections.Generic.List<object> cars = Driver.Car.ListAuto.First(car => car[0].ToString().Equals(driver[2].ToString()));
                            System.Collections.Generic.List<object> fuels = Driver.Fuel.ListFuel.First(fuel => fuel[0].ToString().Equals(cars[1].ToString()));

                            Driver.Fuel curFuel = Driver.Fuel.CreateFuel(fuels[0].ToString(), double.Parse(fuels[1].ToString()));
                            Driver.Car curCar = Driver.Car.CreateCar(cars[0].ToString(), curFuel, double.Parse(cars[2].ToString()), double.Parse(cars[3].ToString()));

                            Drive = Driver.Driver.CreateDriver(driver[0].ToString(), bool.Parse(driver[1].ToString()), curCar);
                            break;
                        }
                    case "Длина":
                        {

                            System.Collections.Generic.List<object> cars = Driver.Car.ListAuto.First(car => car[0].ToString().Equals(driver[2].ToString()));
                            System.Collections.Generic.List<object> fuels = Driver.Fuel.ListFuel.First(fuel => fuel[0].ToString().Equals(cars[1].ToString()));
                            Criterial = Main.Criterial.Length;
                            Driver.Fuel curFuel = Driver.Fuel.CreateFuel(fuels[0].ToString(), double.Parse(fuels[1].ToString()));
                            Driver.Car curCar = Driver.Car.CreateCar(cars[0].ToString(), curFuel, double.Parse(cars[2].ToString()), double.Parse(cars[3].ToString()));
                            Drive = Driver.Driver.CreateDriver(driver[0].ToString(), bool.Parse(driver[1].ToString()), curCar);

                            break;
                        }
                    case "Стоимость":
                        {
                            Criterial = Main.Criterial.Price;

                            System.Collections.Generic.List<object> cars = Driver.Car.ListAuto.First(car => car[0].ToString().Equals(driver[2].ToString()));
                            System.Collections.Generic.List<object> fuels = Driver.Fuel.ListFuel.First(fuel => fuel[0].ToString().Equals(cars[1].ToString()));

                            Driver.Fuel curFuel = Driver.Fuel.CreateFuel(fuels[0].ToString(), double.Parse(fuels[1].ToString()));
                            Driver.Car curCar = Driver.Car.CreateCar(cars[0].ToString(), curFuel, double.Parse(cars[2].ToString()), double.Parse(cars[3].ToString()));
                            Drive = Driver.Driver.CreateDriver(driver[0].ToString(), bool.Parse(driver[1].ToString()), curCar);

                            break;
                        }
                }

                this.DialogResult = DialogResult.OK;

                Hide();
            }
        }

        private void CancelRouteButton_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            Close();
        }
    }
}

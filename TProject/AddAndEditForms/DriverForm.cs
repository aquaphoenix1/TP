using System;
using System.Linq;
using System.Windows.Forms;
using TProject.Driver;
using TProject.TypeDAO;

namespace TProject
{
    public partial class DriverForm : Form
    {
        private bool addOrEdit;
        private Driver.Driver driver;

        private DriverForm()
        {
            InitializeComponent();
        }

        public DriverForm(bool addOrEdit) : this()
        {
            Car.ListAuto.ForEach(var => comboBoxIDAuto.Items.Add(var[0]));
            this.addOrEdit = addOrEdit;
        }

        public DriverForm(long id, string typeDriver, Car car) : this(false)
        {
            driver = Driver.Driver.CreateDriver(id, typeDriver.Equals("Нарушитель"), car);
            checkBoxIsIntruder.Checked = typeDriver.Equals("Нарушитель");
            comboBoxIDAuto.SelectedIndex = comboBoxIDAuto.FindString(car.ID.ToString());
        }

        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            if (long.TryParse(comboBoxIDAuto.Text, out long d))
            {
                var findcar = Car.ListAuto.FirstOrDefault(l => l.ElementAt(0).ToString() == comboBoxIDAuto.SelectedItem.ToString());

                var findfuel = Fuel.ListFuel.FirstOrDefault(l => l.ElementAt(0).ToString() == findcar[2].ToString());

                Fuel fuel = Fuel.CreateFuel(long.Parse(findfuel[0].ToString()), findfuel[1].ToString(), double.Parse(findfuel[2].ToString()));

                Car fcar = Car.CreateCar(long.Parse(findcar[0].ToString()), findcar[1].ToString(), fuel, double.Parse(findcar[3].ToString()));

                if (driver == null)
                {
                    driver = new Driver.Driver(checkBoxIsIntruder.Checked, fcar);
                }
                else
                {
                    driver.IsViolateTL = checkBoxIsIntruder.Checked;
                    driver.Car = fcar;
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
                MessageBox.Show("Не корректно задан id машины!");
            }
        }

        private void Add()
        {
            if (new DriverDAO().Insert(driver))
            {
                Main.IsChanged = true;

                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка добавления");
                Driver.Driver.CurrentMaxID--;
            }
        }

        private void Edit()
        {
            if (new DriverDAO().Update(driver))
            {
                Main.IsChanged = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка изменения");
            }
        }
    }
}

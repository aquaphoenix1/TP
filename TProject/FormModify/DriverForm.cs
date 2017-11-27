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

namespace TProject
{
    public partial class DriverForm : Form
    {
        
        private bool addOrEdit; //Добавление или изменение
        private Driver.Driver driver;
        private string type;
        private bool typed;

        private DriverForm()
        {
            InitializeComponent();
        }

        public DriverForm(bool addOrEdit) : this()
        {
            Car.ListAuto.ForEach(var => cbIDAuto.Items.Add(var[0]));
            button1.Text = (addOrEdit) ? "Добавить" : "Изменить";
            this.addOrEdit = addOrEdit;
        }

        public DriverForm(int id, bool typeDriver, Car car) : this(false)
        {
            if (typeDriver == false) { type = "Нет"; } else { type = "Да"; }
            driver = new Driver.Driver(id, typeDriver, car);
            int index = cbIDAuto.FindString(car.ID.ToString());
            cbIDAuto.SelectedIndex = index;
            tbTypeDriver.Text = type;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbTypeDriver.Text))
                MessageBox.Show("Поле тип водителя не задан !");
            else
            {
                double d;
                if (double.TryParse(cbIDAuto.Text, out d))
                {
                    //нашел машину для водителя
                   var findcar = Car.ListAuto.FirstOrDefault(l => l.ElementAt(0).ToString() == cbIDAuto.SelectedItem.ToString());


                    var findfuel = Fuel.ListFuel.FirstOrDefault(l => l.ElementAt(0).ToString() == findcar[2].ToString());

                    Fuel ffuel = new Fuel(int.Parse(findfuel[0].ToString()), findfuel[1].ToString(), double.Parse(findfuel[2].ToString()));

                   Car fcar = new Car(int.Parse(findcar[0].ToString()), findcar[1].ToString(), ffuel, double.Parse(findcar[3].ToString()));

                    if (tbTypeDriver.Text == "Нет") { typed = false; } else { typed = true; }
                    if (driver == null) driver = new Driver.Driver(typed, fcar);
                    else
                    {
                        driver.IsViolateTL = typed;
                        driver.Car = fcar;
                    }
                    if (addOrEdit) Add();
                    else Edit();

                }
                else MessageBox.Show("Не корректно задан id машины !");
            }
        }

        private void Add()
        {
            if (new DriverDAO().Insert(driver))
            {
                this.Close();
            }
        }

        private void Edit()
        {
            if (new DriverDAO().Update(driver))
            {
                this.Close();
            }
        }
    }
}

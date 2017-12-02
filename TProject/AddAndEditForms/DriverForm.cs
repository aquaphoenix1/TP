using System;
using System.Drawing;
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

        public DriverForm(string FIO, string typeDriver, Car car) : this(false)
        {
            driver = Driver.Driver.CreateDriver(FIO, typeDriver.Equals("Нарушитель"), car);
            checkBoxIsIntruder.Checked = typeDriver.Equals("Нарушитель");
            comboBoxIDAuto.SelectedIndex = comboBoxIDAuto.FindString(car.TypeName);

            textBoxFIO.Text = FIO;
            textBoxFIO.Enabled = false;
        }

        private void Accept()
        {
            textBoxFIO.BackColor = Color.White;

            string name = textBoxFIO.Text;
            string model = comboBoxIDAuto.SelectedText;

            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Введите ФИО!");
                textBoxFIO.BackColor = Color.Red;
            }
            else if (string.IsNullOrEmpty(model) || string.IsNullOrWhiteSpace(model))
            {
                MessageBox.Show("Выберите модель!");
            }
            else
            {
                var findcar = Car.ListAuto.FirstOrDefault(l => l.ElementAt(0).ToString().Equals(model));

                var findfuel = Fuel.ListFuel.FirstOrDefault(l => l.ElementAt(0).Equals(findcar[2].ToString()));

                Fuel fuel = Fuel.CreateFuel(findfuel[0].ToString(), double.Parse(findfuel[2].ToString()));

                Car fcar = Car.CreateCar(findcar[1].ToString(), fuel, double.Parse(findcar[3].ToString()), double.Parse(findcar[4].ToString()));

                if (driver == null)
                {
                    driver = new Driver.Driver(name, checkBoxIsIntruder.Checked, fcar);
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
        }

        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            Accept();
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

        private void ComboBoxIDAuto_KeyUp(object sender, KeyEventArgs e)
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

        private void TextBoxFIO_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFIO.Text) || string.IsNullOrWhiteSpace(textBoxFIO.Text))
            {
                textBoxFIO.BackColor = Color.Red;
            }
            else
            {
                textBoxFIO.BackColor = Color.White;
            }
        }

        private void TextBoxFIO_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Accept();
            }
        }
    }
}

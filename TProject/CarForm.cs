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
    public partial class CarForm : Form
    {
        private bool addOrEdit; //Добавление или изменение
        private Car c;
        private Fuel fuel;

        private CarForm()
        {
            InitializeComponent();
        }

        //изменение кнопки
        public CarForm(bool addOrEdit) : this()
        {
            Fuel.ListFuel.ForEach(var => cbIDFuel.Items.Add(var[0]));
            button1.Text = (addOrEdit) ? "Добавить" : "Изменить";
            this.addOrEdit = addOrEdit;
        }
        //Конструктор для изменения
        public CarForm(int id, string Model, Fuel fuel, double consumption) : this(false)
        {
            c = new Car(id, Model, fuel, consumption);
            tbModel.Text = Model;
            int index = cbIDFuel.FindString(fuel.ID.ToString());
            cbIDFuel.SelectedIndex = index;
            tbconsumption.Text = consumption.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbModel.Text) || string.IsNullOrWhiteSpace(tbconsumption.Text) || cbIDFuel.SelectedItem.ToString() == "")
                MessageBox.Show("Поля не заданы  !");

            else
            {
                double consumption;
                if (double.TryParse(tbconsumption.Text, out consumption))
                {
                    var findfuel = Fuel.ListFuel.FirstOrDefault(l => l.ElementAt(0).ToString() == cbIDFuel.SelectedItem.ToString());

                    if (findfuel != null)
                    {
                  //     fuel = new Fuel(int.Parse(findfuel[0].ToString()), findfuel[1].ToString(), double.Parse(findfuel[2].ToString()));
                    }
                    if (c == null) c = new Car(tbModel.Text, fuel, double.Parse(tbconsumption.Text));
                    else
                    {
                        // var findfuel1 = Fuel.ListFuel.FirstOrDefault(l => l.ElementAt(0).ToString() == cbIDFuel.SelectedItem.ToString());
                        //Fuel fuel1 = new Fuel(int.Parse(findfuel[0].ToString()), findfuel[1].ToString(), double.Parse(findfuel[2].ToString()));
                        c.Model = tbModel.Text;
                        c.CarFuel = fuel;
                        c.FuelConsumption = double.Parse(tbconsumption.Text);
                    }
                    if (addOrEdit) Add();
                    else Edit();

                }
                else MessageBox.Show("Не корректно задана цена !");
            }
        }
        private void Add()
        {
            if (new CarDAO().Insert(c))
            {
                Close();
            }
        }

        private void Edit()
        {
            if (new CarDAO().Update(c))
            {
                Close();
            }
        }


    }
}

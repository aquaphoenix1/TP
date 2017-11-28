using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TProject.TypeDAO;
using TProject.Way;

namespace TProject
{
    public partial class SignForm : Form
    {
        private bool addOrEdit; //Добавление или изменение
        private Sign s;

        private SignForm()
        {
            InitializeComponent();
        }

        //изменение кнопки
        public SignForm(bool addOrEdit) : this()
        {
            button1.Text = (addOrEdit) ? "Добавить" : "Изменить";
            this.addOrEdit = addOrEdit;
        }
        //Конструктор
        public SignForm(int id, string tSign, double value) : this(false)
        {
            s = new Sign(id, tSign, value);
            tbTypeSign.Text = tSign;
            tbValueSign.Text = value.ToString();
        }


        //нажата кнопка добавить новое покрытие
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbTypeSign.Text))
                MessageBox.Show("Тип дорожного знака не задано !");
            else
            {
                double d;
                if (double.TryParse(tbValueSign.Text, out d))
                {
                    if (s == null) s = new Sign(tbTypeSign.Text, d);
                    else
                    {
                        s.TypeName = tbTypeSign.Text;
                        s.Count = d;
                    }
                    if (addOrEdit) Add();
                    else Edit();

                }
                else MessageBox.Show("Не корректно задан коэффициент !");
            }

        }


        private void Add()
        {
            if (new SignDAO().Insert(s))
            {
                Close();
            }
        }

        private void Edit()
        {
            if (new SignDAO().Update(s))
            {
                Close();
            }
        }
    }
}

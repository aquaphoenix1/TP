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
    public partial class FineForm : Form
    {
        private bool addOrEdit; //Добавление или изменение
        private Fine f;

        private FineForm()
        {
            InitializeComponent();
        }

        //изменение кнопки
        public FineForm(bool addOrEdit) : this()
        {
            button1.Text = (addOrEdit) ? "Добавить" : "Изменить";
            this.addOrEdit = addOrEdit;
        }
        //Конструктор
        public FineForm(int id, string nFine, double cost) : this(false)
        {
            f = new Fine(id, nFine, cost);
            tbNameFine.Text = nFine;
            tbSummaFine.Text = cost.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNameFine.Text))
                MessageBox.Show("Название штрафа не задано !");
            else
            {
                double d;
                if (double.TryParse(tbSummaFine.Text, out d))
                {
                    if (f == null) f = new Fine(tbNameFine.Text, d);

                    else
                    {
                        long index = f.ID;
                        f.TypeName = tbNameFine.Text;
                        f.Count = d;
                    }
                    if (addOrEdit) Add();
                    else Edit();

                }
                else MessageBox.Show("Не корректно задан коэффициент !");
            }
        }
        private void Add()
        {
            if (new FineDAO().Insert(f))
            {
                Close();
            }
        }

        private void Edit()
        {
            if (new FineDAO().Update(f))
            {
                Close();
            }
        }
    }
}

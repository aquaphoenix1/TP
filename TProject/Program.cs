using System;
using System.Windows.Forms;
using TProject.Forms;

namespace TProject
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                if (!DAO.IsExistDataBase())
                {
                    DAO.CreateDataBase();
                }

                //Application.Run(new FirstForm());

                Start();
            }
            catch (System.Data.SQLite.SQLiteException ex) { MessageBox.Show(ex.Message); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        static void Start()
        {
            FirstForm f = new FirstForm();
            Application.Run(f);

            if(!(f.DialogResult == DialogResult.None))
            {
                Start();
            }

            if (FirstForm.formMain != null)
            {
                if (FirstForm.formMain.DialogResult == DialogResult.Abort)
                {
                    FirstForm.formMain = null;
                    Start();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
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

                Application.Run(new FirstForm());
            }
            catch (System.Data.SQLite.SQLiteException ex) { MessageBox.Show(ex.Message); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}

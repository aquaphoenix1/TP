using System;
using System.Windows.Forms;

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

                Application.Run(new Main());
            }
            catch (System.Data.SQLite.SQLiteException ex) { MessageBox.Show(ex.Message); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}

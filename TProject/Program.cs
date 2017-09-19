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
            //if (!DAOLibrary.DAO.IsExistDataBase())
                DAO.CreateDataBase();
            Application.Run(new MainForm());
        }
    }
}

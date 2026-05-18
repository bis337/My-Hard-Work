using System;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Точка входа в приложение.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Главная функция приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();

            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new MainForm());
        }
    }
}
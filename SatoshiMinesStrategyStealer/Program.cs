using System;
using System.Windows.Forms;
using SatoshiMinesStrategyStealer.UI.Forms;

namespace SatoshiMinesStrategyStealer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
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
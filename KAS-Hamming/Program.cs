using System;
using System.Collections;
using System.Windows.Forms;

namespace KAS_Hamming
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
            Application.Run(new HammingForm());
        }
    }
}

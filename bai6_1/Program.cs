using System;
using System.Windows.Forms;

namespace RetailSalesSystem
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Application.SetDefaultFont(new System.Drawing.Font("Arial", 9.5f));

            Application.Run(new MainForm());
        }
    }
}
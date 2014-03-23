using System;
using System.Reflection;
using System.Windows.Forms;
using log4net;

[assembly: log4net.Config.XmlConfigurator]

namespace ReceiptScanSandbox
{
    static class Program
    {

        private static readonly ILog Log =
    LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Log.Info("Start up.");


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

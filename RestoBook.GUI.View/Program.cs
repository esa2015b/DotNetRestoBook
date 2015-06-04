using RestoBook.Common.Business.Managers;
using System;
using System.Windows.Forms;

namespace RestoBook.GUI.View
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException +=
              new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.ThreadException +=
              new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Views.MainForm());
        }

            static void CurrentDomain_UnhandledException
                (object sender, UnhandledExceptionEventArgs e)
            {
              try
              {
                var customEx = new ErrorManager();
                Exception ex =  customEx.GetExceptionDetail((Exception)e.ExceptionObject);

                MessageBox.Show(ex.Message, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
              }
              finally
              {
                Application.Exit();
              }
            }

            public static void Application_ThreadException
              (object sender, System.Threading.ThreadExceptionEventArgs e)
            {
              DialogResult result = DialogResult.Abort;
              try
              {
                  var customEx = new ErrorManager();
                  Exception ex = customEx.GetExceptionDetail(e.Exception);
                result = MessageBox.Show(ex.Message, "Application Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Stop);
              }
              finally
              {
                 Application.Exit();
              }
        }
    }
}

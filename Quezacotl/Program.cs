using System;
using System.Threading;
using System.Windows.Forms;

namespace Quezacotl
{
    static class Program
    {
        public static SplashForm splashForm = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Thread splashThread = new Thread(new ThreadStart(
            delegate
            {
                splashForm = new SplashForm();
                Application.Run(splashForm);
            }
            ));

            splashThread.SetApartmentState(ApartmentState.STA);
            splashThread.Start();

            Form1 form1 = new Form1();
            form1.Load += new EventHandler(form1_Load);
            Application.Run(form1);
        }

        static void form1_Load(object sender, EventArgs e)
        {
            //close splash
            if (splashForm == null)
            {
                return;
            }

            splashForm.Invoke(new Action(splashForm.Close));
            splashForm.Dispose();
            splashForm = null;
        }
    }
}

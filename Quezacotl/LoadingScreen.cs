using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Quezacotl
{
    public partial class LoadingScreen : Form
    {
        public LoadingScreen()
        {
            InitializeComponent();
        }

        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerAsync();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            for (int i = 0; i < 0; i++)
            {
                worker.ReportProgress(i);
                var form1 = new Form1();
                form1.LoadTabsObjects();
                //System.Threading.Thread.Sleep(1000);
            }
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarLoad.Value = e.ProgressPercentage;
        }    
    }
}

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Quezacotl
{
    public partial class SplashForm : Form
    {
        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode, ExactSpelling = true)] //used in Listview selection style method
        internal static extern int SetWindowTheme(IntPtr hWnd, string appName, string partList);

        public SplashForm()
        {
            InitializeComponent();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            SetWindowTheme(progressBar1.Handle, "explorer", null);
            SetWindowTheme(progressBar1.Handle, "explorer", null);
        }
    }
}

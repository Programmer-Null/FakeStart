using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Main
{
    public partial class FrmMain : Form
    {
        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_SHOWWINDOW = 0x0040;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmFakeStartMenu fakeSM = new FrmFakeStartMenu();
            fakeSM.Show();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Rectangle bounds = Screen.PrimaryScreen.Bounds;

            int StartButtonWidget = 48;
            int StartButtonHeight = 40;

            this.Width = StartButtonWidget;
            this.Height = StartButtonHeight;

            this.Location = new Point(bounds.Left, bounds.Bottom - this.Height);

            ForceTopMost();
        }

        public void ForceTopMost()
        {
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ForceTopMost();
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.Alt == true || e.Shift == true) // Alt-Shift
            {
                Application.Exit();
            }
        }
    }
}

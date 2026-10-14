using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    public partial class FrmFakeStartMenu : Form
    {
        public FrmFakeStartMenu()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox3.Visible = true;
            pictureBox3.Enabled = true;
        }

        private void FrmFakeStartMenu_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;

            int x = workingArea.Left;
            int y = workingArea.Bottom - this.Height;

            this.Location = new Point(x, y);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "我觉得隐藏关机按钮很不错，此处还有114514种关机方法(划掉)\r\n我都说了这里无法关机，你偏要在这里关机，十分奇怪。" +
                    "为什么你不按Ctrl-Alt-Del关机？为什么不用cmd /c \"shutdown /s /t 120\"关机？"
                , "陷阱");
        }

        private void FrmFakeStartMenu_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Alt == true && e.Shift == true) // Alt-Shift
            {
                this.Close();
            }
        }
    }
}

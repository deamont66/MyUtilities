using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingStatus
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            
            Rectangle r = Screen.PrimaryScreen.WorkingArea;
            this.Location = new Point(r.Width - this.Size.Width, r.Height - this.Size.Height);

            this.BackColor = Color.SlateGray; // SlateGray
            this.TransparencyKey = Color.SlateGray;

            notifyIcon2.ShowBalloonTip(3);

            PingThread.Start(this);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.SlateGray, e.ClipRectangle);
        }

        public void SetPingTime(int time)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int>(SetPingTime), new object[] { time });
                return;
            }
            if (time < 0)
            {
                label1.Text = "Lost";
                return;
            }
            label1.Text = String.Format("{0} ms", time);
            notifyIcon2.Text = String.Format("{0} ms - {1}", time, PingStatus.Properties.Settings.Default.adress);
        }

        private void notifyIcon2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon2_MouseDoubleClick(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.Show();
        }
    }
}

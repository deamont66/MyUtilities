using MetroFramework.Forms;
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
    public partial class SettingsForm : MetroForm
    {
        public SettingsForm()
        {
            InitializeComponent();

            adressTextField.Text = PingStatus.Properties.Settings.Default.adress;
            metroTrackBar1.Value = PingStatus.Properties.Settings.Default.interval;
        }

        private void metroTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            float time = (float) Math.Round(metroTrackBar1.Value / 1000f, 1);
            delayLabel.Text = String.Format("{0}s", time);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            PingStatus.Properties.Settings.Default.adress = adressTextField.Text;
            float time = (float) Math.Round(metroTrackBar1.Value / 1000f, 1);
            PingStatus.Properties.Settings.Default.interval = (int)(time * 1000);
            PingStatus.Properties.Settings.Default.Save();
            this.Dispose();
        }
    }
}

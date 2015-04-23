using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DNSChanger
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();

            metroComboBox1.Items.Add(new ComboItem(DNSHandler.Servers.DHCP, "Auto/DHCP"));
            metroComboBox1.Items.Add(new ComboItem(DNSHandler.Servers.GOOGLE, "Google DNS"));
            metroComboBox1.Items.Add(new ComboItem(DNSHandler.Servers.CZNIC, "CZ.NIC DNS"));

            metroComboBox1.SelectedIndex = (int) DNSHandler.getCurrentServer();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            DNSHandler.changeDNSServerTo((DNSHandler.Servers)metroComboBox1.SelectedIndex);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            DNSHandler.RenewDHCP();
        }
    }
}

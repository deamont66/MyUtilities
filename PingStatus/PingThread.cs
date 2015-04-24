using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingStatus
{
    class PingThread
    {
        private static MainForm mainForm;

        public static void Start(MainForm f)
        {
            mainForm = f;
            Thread t = new Thread(Run);
            t.IsBackground = true;
            t.Start();
        }

        private static void Run()
        {
            Ping p = new Ping();
            while (true) {
                PingReply reply = p.Send(PingStatus.Properties.Settings.Default.adress);
                if (reply.Status == IPStatus.Success)
                {
                    mainForm.SetPingTime((int)reply.RoundtripTime);
                }
                else
                {
                    mainForm.SetPingTime(-1);
                }
                Thread.Sleep(PingStatus.Properties.Settings.Default.interval);
            }
        }
    }
}

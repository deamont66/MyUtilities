using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DNSChanger
{
    class DNSHandler
    {
        public enum Servers {
            DHCP = 0, GOOGLE = 1, CZNIC = 2
        }

        static string googleIP = "8.8.8.8";
        static string cznicIP = "217.31.204.130";

        static Servers? currentServer = null;

        public static Servers getCurrentServer() {
            if (currentServer != null) 
            {
                return (Servers) currentServer;
            }

            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = false;
            p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/C echo | nslookup | findstr \"Address\"";
            p.Start();

            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            if (output.Contains(googleIP)) {
                currentServer = Servers.GOOGLE;
            }
            else if (output.Contains(cznicIP))
            {
                currentServer = Servers.CZNIC;
            }
            else 
            {
                currentServer = Servers.DHCP;
            }
            return (Servers) currentServer;
        }

        public static void changeDNSServerTo(Servers server)
        {
            if (currentServer.Equals(server))
            {
                return;
            }

            string serverName;
            switch (server)
            {
                case Servers.GOOGLE: serverName = "Google"; break;
                case Servers.CZNIC: serverName = "NIC"; break;
                default: serverName = "Dhcp"; break;
            }

            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), String.Format("dns{0}.bat", serverName));

            using (Stream input = Assembly.GetEntryAssembly().GetManifestResourceStream(String.Format("DNSChanger.Resources.dns{0}.bat", serverName)))
            using (Stream output = File.Create(path))
            {
                CopyStream(input, output);
            }

            Process myProg = new System.Diagnostics.Process();
            myProg.StartInfo.FileName = path;
            myProg.StartInfo.UseShellExecute = false;
            myProg.StartInfo.Arguments = "";
            myProg.StartInfo.RedirectStandardOutput = true;
            myProg.StartInfo.CreateNoWindow = true;
            myProg.Start();
            myProg.StandardOutput.Dispose();
            myProg.WaitForExit();

            File.Delete(path);

            currentServer = server;
        }

        public static void RenewDHCP()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "internet.bat");

            using (Stream input = Assembly.GetEntryAssembly().GetManifestResourceStream("DNSChanger.Resources.internet.bat"))
            using (Stream output = File.Create(path))
            {
                CopyStream(input, output);
            }

            Process myProg = new System.Diagnostics.Process();
            myProg.StartInfo.FileName = path;
            myProg.StartInfo.UseShellExecute = false;
            myProg.StartInfo.Arguments = "";
            myProg.StartInfo.RedirectStandardOutput = false;
            myProg.StartInfo.CreateNoWindow = false;
            myProg.Start();
            myProg.WaitForExit();

            File.Delete(path);
        }

        public static void CopyStream(Stream input, Stream output)
        {
            // Insert null checking here for production
            byte[] buffer = new byte[8192];

            int bytesRead;
            while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, bytesRead);
            }
        }
    }
}

using System;
using System.Management;
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

        static string[] googleIP = new string[] { "8.8.8.8", "8.8.4.4" };
        static string[] cznicIP = new string[] { "217.31.204.130", "193.29.206.206" };

        static Servers? currentServer = null;


        public static Servers getCurrentDNSServer()
        {
            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();

            foreach (ManagementObject objMO in objMOC)
            {
                if ((bool)objMO["IPEnabled"])
                {
                    string addres = ((string[]) objMO["DNSServerSearchOrder"])[0];
                    if (addres.Contains(googleIP[0]) || addres.Contains(googleIP[1])) 
                    {
                        return Servers.GOOGLE;
                    }
                    else if (addres.Contains(cznicIP[0]) || addres.Contains(cznicIP[1]))
                    {
                        return Servers.CZNIC;
                    }
                }
            }
            return Servers.DHCP;
        }

        public static void changeDNSServer(Servers server, string filter = null)
        {
            bool filtered = !(filter == null);
            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();

            foreach (ManagementObject objMO in objMOC)
            {
                if ((bool)objMO["IPEnabled"])
                {
                    if (filtered && !objMO["Index"].ToString().Contains(filter))
                    {
                        continue;
                    }

                    try
                    {
                        if (server == Servers.DHCP)
                        {
                            objMO.InvokeMethod("SetDNSServerSearchOrder", objMO.GetMethodParameters("SetDNSServerSearchOrder"), null);
                        }
                        else
                        {
                            ManagementBaseObject newDNS =
                                   objMO.GetMethodParameters("SetDNSServerSearchOrder");
                            if(server == Servers.CZNIC) 
                            {
                                newDNS["DNSServerSearchOrder"] = cznicIP;
                            }
                            else if (server == Servers.GOOGLE)
                            {
                                newDNS["DNSServerSearchOrder"] = googleIP;
                            }
                            ManagementBaseObject setDNS =
                                objMO.InvokeMethod("SetDNSServerSearchOrder", newDNS, null);
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
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

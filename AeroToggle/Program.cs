using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AeroToggle
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            toggleWindowsAero();

            Application.Exit();
        }

        private static void toggleWindowsAero()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "aerotoggle.bat");
            Console.WriteLine(path);
            using (Stream input = Assembly.GetEntryAssembly().GetManifestResourceStream("AeroToggle.Resources.aerotoggle.bat"))
            using (Stream output = File.Create(path))
            {
                CopyStream(input, output);
            }

            Process myProg = new System.Diagnostics.Process();
            myProg.StartInfo.FileName = path;
            myProg.StartInfo.UseShellExecute = false;
            myProg.StartInfo.Arguments = "";
            myProg.StartInfo.RedirectStandardOutput = false;
            myProg.StartInfo.CreateNoWindow = true;
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

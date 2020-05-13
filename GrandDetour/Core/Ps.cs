using System;
using System.Diagnostics;
using System.Globalization;

namespace GrandDetour.Core
{
    public static class Ps
    {
        public static int RunAndRead(string fileName, string arguments, string salt, string filter=null)
        {
            var process = new Process();

            var cmdStartInfo = new ProcessStartInfo
                                   {
                                       RedirectStandardError = true,
                                       RedirectStandardOutput = true,
                                       RedirectStandardInput = false,
                                       UseShellExecute = false,
                                       CreateNoWindow = true,
                                       FileName = fileName,
                                       Arguments = arguments,
                                   };

            process.StartInfo = cmdStartInfo;
            process.EnableRaisingEvents = true;
            process.OutputDataReceived += (o, args) => Global.ProcessOnOutputDataReceived(o, args, salt, filter);
            process.Start();
            process.BeginOutputReadLine();
            process.WaitForExit();
            return process.Id;
        }

        public static string GetPIDKey(int pid, string hash)
        {
            return String.Format("PIDKEY_{0}", pid.ToString(CultureInfo.InvariantCulture).Hash(hash));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Silicon_Library.Core.Helpers
{
    public class RunDeviceTest
    {
    public static List<ProgressItem> Invoke(string cliPath)
    {
            List<ProgressItem> runSummary = new List<ProgressItem>();
            var script = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + cliPath);
            //var script = @"$object = [pscustomobject]@{Name='My Name demo';}
            //                $object | select -property Name";
            //var powerShell = PowerShell.Create().AddScript(script);
            //    var res = powerShell.Invoke();
            //string basePath = "C:\\Users\\Sandeep V\\source\\repos\\Silicon-Library\\Silicon Library\\bin\\x64\\Debug\\net6.0-windows10.0.19041.0\\win10-x64\\AppX\\Assets\\CLIs\\";
            string basePath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string exe = "Powershell.exe -File '"+basePath+cliPath+"'";
            string path = AppDomain.CurrentDomain.BaseDirectory + cliPath;
            var powerShell = PowerShell.Create();
            var res = powerShell.AddScript(exe).Invoke();

            foreach (PSObject item in res)
            {
                //Console.WriteLine(item.Name);
                if (!string.IsNullOrEmpty(Convert.ToString(item.BaseObject))) 
                runSummary.Add(new ProgressItem() { CurrentItemName = item.BaseObject.ToString() });
            }
            return runSummary;
            //var start = new ProcessStartInfo { 
            // FileName="Powershell.exe",
            //    UseShellExecute = false,
            //    RedirectStandardOutput = true,
            //    Arguments= "-File 'C:\\Users\\Sandeep V\\source\\repos\\Silicon-Library\\Silicon Library\\bin\\x64\\Debug\\net6.0-windows10.0.19041.0\\win10-x64\\AppX\\Assets\\CLIs\\ExecuteForRPI4.ps1'",
            //    CreateNoWindow = true
            //};
            //var process = Process.Start(start);
            //var reader=process.StandardOutput.ReadToEnd();
            return null;
    }
    }
    public class ProgressItem
    {
        public string CurrentItemName { get; set; }
    }
}

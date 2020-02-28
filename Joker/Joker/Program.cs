using ElectronNET.API;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Joker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Queue<Process> queue = new Queue<Process>();
            Process[] processes = Process.GetProcessesByName("electron");
            foreach(string processName in new string[] { "Electron", ".NET Core Host", "Joker" })
            {
                Process[] processSet = Process.GetProcessesByName(processName);
                processes = processes.Concat(processSet).ToArray();
            }
            foreach (Process p in processes)
            {
                if (p.StartTime < DateTime.Now.AddMinutes(-1))
                {
                    queue.Enqueue(p);
                }
            }
            while (queue.Count > 0)
            {
                if(queue.Peek().HasExited)
                {
                    queue.Dequeue();
                }
                else
                {
                    queue.Dequeue().Kill();
                }                
            }
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseElectron(args)
                .UseStartup<Startup>();
    }
}

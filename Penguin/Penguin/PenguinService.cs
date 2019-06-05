using System;
using System.IO;
using System.IO.Pipes;
using System.Security.Permissions;
using System.ServiceProcess;
using System.Threading;
using System.Timers;
using System.Diagnostics;
using static Penguin.ToApp;
using System.Threading.Tasks;
using System.Security.AccessControl;
using System.Collections.Generic;
using System.Security.Principal;


namespace Penguin
{
    public partial class PenguinService : ServiceBase
    {
        private static int numThreads = 1;
        int i = 0;
        static NamedPipeServerStream pipeServer;
        Thread[] servers = new Thread[numThreads];
        static Dictionary<string, string> supers = new Dictionary<string, string>
        {
            { "Batman", "I'm Vengence! I'm the Night! I'm Batman!" },
            { "GreenLantern", "In brightest day, in blackest night, No evil shall escape my sight.Let those who worship evil's might Beware my power--Green Lantern's light!" },
            { "Spiderman", "With great power come Great Responsibility!" },
            { "Default", "Default Value"}
        };

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public PenguinService()
        {
            InitializeComponent();
            //System.Timers.Timer timer = new System.Timers.Timer();

            File.WriteAllText(@"C:\Test1.txt", "Creating Pipe!");

            for (i = 0; i < numThreads; i++)
            {
                servers[i] = new Thread(ServerThread);
                servers[i].Start();
            }
        }

        private static void ServerThread()
        {
            File.AppendAllText(@"C:\Test1.txt", $"Thread Started");
            try
            {
                pipeServer = new NamedPipeServerStream("Riddler", PipeDirection.InOut, numThreads, PipeTransmissionMode.Message, PipeOptions.None, 2048, 2048, SetupPipeSecurity());
                StreamString ss = new StreamString(pipeServer);
                string key = "Default";
                while (true)
                {
                    try
                    {
                        if (pipeServer.IsConnected)
                        {
                            key = ss.ReadString();
                            File.AppendAllText(@"C:\Test1.txt", $" { key } ");
                            File.AppendAllText(@"C:\Test1.txt", $" { supers[key] } ");
                            ss.WriteString(supers[key]);
                            pipeServer.WaitForPipeDrain();
                            //Thread.Sleep(2000);
                            pipeServer.Disconnect();
                        }
                        else
                        {
                            File.AppendAllText(@"C:\Test1.txt", "Waiting!");
                            pipeServer.WaitForConnection();
                            File.AppendAllText(@"C:\Test1.txt", "Got Connected!");
                        }
                    }
                    catch (Exception e)
                    {
                        pipeServer.Dispose();
                        pipeServer = new NamedPipeServerStream("Riddler", PipeDirection.InOut, numThreads, PipeTransmissionMode.Message, PipeOptions.None, 2048, 2048, SetupPipeSecurity());
                        File.AppendAllText(@"C:\Test1.txt", $" { e.Message + " | " + e.StackTrace } ");                        
                    }
                }

            }
            catch (Exception e)
            {
                File.AppendAllText(@"C:\Test1.txt", $" { e.Message + " OUT| " + e.StackTrace } ");
            }
        }

        private static  PipeSecurity SetupPipeSecurity()
        {
            PipeSecurity pipeSecurity = new PipeSecurity();
            System.Security.Principal.SecurityIdentifier sid = new System.Security.Principal.SecurityIdentifier(System.Security.Principal.WellKnownSidType.WorldSid, null);
            pipeSecurity.AddAccessRule(new PipeAccessRule(sid, PipeAccessRights.ReadWrite, AccessControlType.Allow));
            return pipeSecurity;
        }


        protected override void OnStart(string[] args)
        {
            if (!System.Diagnostics.EventLog.SourceExists("RiddlerLog"))
            {
                EventLog.CreateEventSource("Penguin", "RiddlerLog");
            }
            else
            {
            }

            //Task.Delay(1000).ContinueWith(t => ServerThread());

            eventLogger.Source = "Penguin";
            eventLogger.Log = "RiddlerLog";
            eventLogger.WriteEntry("In OnStart " + String.Join("-", args));
        }

        protected override void OnStop()
        {
            eventLogger.WriteEntry("In OnStop ");
            pipeServer.Close();
        }


    }
}

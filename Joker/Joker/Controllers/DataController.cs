using System;
using System.IO.Pipes;
using System.Linq;
using System.Security.Principal;
using System.ServiceProcess;
using Microsoft.AspNetCore.Mvc;

namespace Joker.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private string ret = "Initial";
        NamedPipeClientStream pipeClient;
        public DataController()
        {
            
        }

        [HttpGet("{key}", Name = "GetDate")]
        public string GetDate(string key)
        {
            pipeClient = new NamedPipeClientStream(".", "Riddler",
                   PipeDirection.InOut, PipeOptions.None,
                   TokenImpersonationLevel.Impersonation);
            System.IO.File.AppendAllText($@"C:\Pipes\{key}.txt", $"Before Connect! {this.ControllerContext}");
            pipeClient.Connect(2000);
            if (!pipeClient.IsConnected)
            {
                return "Not Connected!";
            }
            string t = getDataFromService(key);
            System.IO.File.AppendAllText($@"C:\Pipes\{key}.txt", $"Return ret - {ret}");
            return t;
        }

        private string getDataFromService(string key)
        {
            ret = "Two Face!";
            try
            {
                StreamString ss = new StreamString(pipeClient);                
                ss.WriteString(key);                
                string temp = ss.ReadString();
                ss.Dispose();
                pipeClient.Dispose();
                ret = temp;
            }
            catch (Exception e)
            {
                System.IO.File.AppendAllText(@"C:\Pipes\ClientError.txt", e.Message + " | " + e.StackTrace);
                ret = e.Message + " | " + e.StackTrace;
            }
            return ret;
        }

        ~DataController()
        {
            pipeClient.Dispose();
        }
    }
}
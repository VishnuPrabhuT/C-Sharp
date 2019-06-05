using System;
using System.IO.Pipes;
using System.Security.Principal;
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
            pipeClient.Connect(2000);

            if (!pipeClient.IsConnected)
            {
                return "Not Connected!";
            }
            string t = getDataFromService(key);
            //System.IO.File.AppendAllText(@"C:\Test2.txt", $"Return ret - {ret}");
            return t;
        }


        private string getDataFromService(string key)
        {
            ret = "Two Face!";
            try
            {
                System.IO.File.AppendAllText(@"C:\Test2.txt", "After Connect!");
                StreamString ss = new StreamString(pipeClient);
                System.IO.File.AppendAllText(@"C:\Test2.txt", "After SS!");
                ss.WriteString(key);
                System.IO.File.WriteAllText(@"C:\Test2.txt", $"Wrote {key}");
                string temp = ss.ReadString();
                System.IO.File.AppendAllText(@"C:\Test2.txt", temp);
                ret = temp;
            }
            catch (Exception e)
            {
                System.IO.File.AppendAllText(@"C:\Test2.txt", e.Message + " | " + e.StackTrace);
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
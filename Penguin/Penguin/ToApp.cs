using System;
using System.Data.SqlClient;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading;
using System.Timers;
using static Penguin.ToApp;

namespace Penguin
{
    public class ToApp
    {
        // Defines the data protocol for reading and writing strings on our stream
        public class StreamString : IDisposable
        {
            private MemoryStream memoryStream;
            private PipeStream ioStream;
            private UnicodeEncoding streamEncoding;

            public StreamString(PipeStream ioStream)
            {
                this.ioStream = ioStream;
                this.memoryStream = new MemoryStream();
                streamEncoding = new UnicodeEncoding();
            }

            public string ReadString()
            {
                byte[] inBuffer = new byte[512];
                do
                {
                    int readbytes = ioStream.Read(inBuffer, 0, 512);
                    memoryStream.Write(inBuffer, 0, readbytes);
                }
                while (!ioStream.IsMessageComplete);
                System.IO.File.AppendAllText($@"C:\Pipes\LenS.txt", $"{ memoryStream.Length.ToString() }\n");
                return streamEncoding.GetString(memoryStream.ToArray());
            }

            public int WriteString(string outString)
            {
                byte[] outBuffer = streamEncoding.GetBytes(outString);
                System.IO.File.AppendAllText($@"C:\Pipes\LenS.txt", outBuffer.Length.ToString());
                ioStream.Write(outBuffer, 0, outBuffer.Length);
                ioStream.Flush();
                return outBuffer.Length;
            }

            public void Dispose()
            {
                if (ioStream != null)
                {
                    ioStream = null;
                }
            }
        }        
    }
}


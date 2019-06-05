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
            private Stream ioStream;
            private UnicodeEncoding streamEncoding;

            public StreamString(Stream ioStream)
            {
                this.ioStream = ioStream;
                streamEncoding = new UnicodeEncoding();
            }

            public string ReadString()
            {
                int len = 0;

                len = ioStream.ReadByte() * 256;
                len += ioStream.ReadByte();
                byte[] inBuffer = new byte[len];
                ioStream.Read(inBuffer, 0, len);

                return streamEncoding.GetString(inBuffer);
            }

            public int WriteString(string outString)
            {
                byte[] outBuffer = streamEncoding.GetBytes(outString);
                int len = outBuffer.Length;
                if (len > UInt16.MaxValue)
                {
                    len = (int)UInt16.MaxValue;
                }
                ioStream.WriteByte((byte)(len / 256));
                ioStream.WriteByte((byte)(len & 255));
                ioStream.Write(outBuffer, 0, len);
                ioStream.Flush();

                return outBuffer.Length + 2;
            }

            public void Dispose()
            {
                if(ioStream != null)
                {
                    ioStream = null;
                }
            }
        }


        // Contains the method executed in the context of the impersonated user
        public class ReadFileToStream
        {
            private string fn;
            public StreamString ss;

            public ReadFileToStream(StreamString str, string filename)
            {
                fn = filename;
                ss = str;
            }

            public void Start()
            {
                string contents = File.ReadAllText(fn);
                ss.WriteString(contents);
            }
        }
    }
}


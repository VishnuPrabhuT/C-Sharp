using System;
using System.IO;
using System.IO.Pipes;
using System.Text;

namespace Joker
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
            this.ioStream.ReadMode = PipeTransmissionMode.Message;
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
            return streamEncoding.GetString(memoryStream.ToArray());
        }

        public int WriteString(string outString)
        {
            Span<byte> span = new Span<byte>(streamEncoding.GetBytes(outString));
            ioStream.Write(span.ToArray());
            ioStream.Flush();
            return span.Length;
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

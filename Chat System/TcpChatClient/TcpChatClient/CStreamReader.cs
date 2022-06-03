using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace TcpChatClient
{
    public class CStreamReader : StreamReader
    {
        private Stream baseStream;
        public CStreamReader(Stream stream) : base(stream)
        { 
            this.baseStream = stream;
        }


        public override string ReadLine()
        {
            MemoryStream memoryStream = new MemoryStream(100000);
            int currByte = this.baseStream.ReadByte();
            while (currByte != -1)
            {
                if (Convert.ToChar(currByte) == '\n')
                {
                    break;
                }
                memoryStream.WriteByte(Convert.ToByte(currByte));
                currByte = this.baseStream.ReadByte();
            }
            return Encoding.Default.GetString(memoryStream.ToArray());
        }
    }
}

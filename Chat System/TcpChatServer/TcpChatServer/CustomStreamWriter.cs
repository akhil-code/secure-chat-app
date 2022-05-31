using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace TcpChatServer
{
    public class CustomStreamWriter : CryptoStream
    {
        public CustomStreamWriter(Stream stream, ICryptoTransform transform, CryptoStreamMode mode) : base(stream, transform, mode)
        {
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            System.Console.WriteLine("akhil");
            base.Write(buffer, offset, count);

        }
    }
}

//----Please DO NOT remove this comment----  
//  This code is written by 
//
//  Abdelnasser Ouda
//
//  Computer Science and Engineering
//  College of Engineering
//  University of North Texas
//----Please DO NOT remove this comment----

using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace TcpChatServer
{
    /// <summary>
    /// Class to represend a chat client on the chat system
    /// </summary>
    class ChatClient
    {
        private Socket tcpSocket; //Client socket
        private String name;
        private String id;
        private StreamReader streamReader;
        private StreamWriter streamWriter;
        private NetworkStream networkStream;

        public ChatClient(Socket socket, String id)
        {
            this.tcpSocket = socket;
            this.id = id;
            this.networkStream = new NetworkStream(socket);
            this.streamReader = new StreamReader(this.networkStream);
            this.streamWriter = new StreamWriter(this.networkStream);
        }

        public String Name
        {
            set { this.name = value; }
            get { return name; }
        }

        public Socket getSocket()
        {
            return this.tcpSocket;
        }

        public StreamReader StreamReader
        {
            get { return this.streamReader; }
        }

        public StreamWriter StreamWriter
        {
            get { return this.streamWriter; }
        }

        public String ID
        {
            set { this.id = value; }
            get { return this.id; }
        }
    }
}

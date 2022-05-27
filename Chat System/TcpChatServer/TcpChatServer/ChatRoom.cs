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
using System.Net;

namespace TcpChatServer
{
    /// <summary>
    /// Represents a chat room which client's can join
    /// </summary>
    class ChatRoom
    {
        private String name; // name of room    
        private List<ChatClient> roomClients; // clients in the room

        public ChatRoom(String name)
        {
            this.name = name;
            roomClients = new List<ChatClient>();
        }

        public ChatRoom(String name,ChatClient firstClient)
        {
            this.name = name;
            roomClients = new List<ChatClient>();
            roomClients.Add(firstClient);
        }

        public String Name
        {
            get { return this.name; }
            set { this.name = value; }
        }


        public void addClient(ChatClient client) 
        {
            this.roomClients.Add(client);
        }
        

        public void removeClient(String clientID)
        {
            foreach (ChatClient c in roomClients)
            {
                if (c.ID.Equals(clientID))
                    roomClients.Remove(c);
            }
        }


        public void removeClient(ChatClient client)
        {
            this.roomClients.Remove(client);
        }

        public void sendMessageToAll(String message)
        {
            foreach (ChatClient c in roomClients)
            {
                c.StreamWriter.WriteLine(message);
                c.StreamWriter.Flush();
            }
        }

        public List<ChatClient> List
        {
            get { return this.roomClients; }
        }

        public String getAttendeeNames()
        {
            String names = "";
            foreach (ChatClient c in roomClients)
            {
                names = names+c.Name+", ";
            }
            return names.Substring(0,names.Length-2);
        }

        public override string ToString()
        {
            return name;
        }

        public ChatClient Find(String id)
        {
            foreach (ChatClient c in this.roomClients)
            {
                if (c.ID.Equals(id))
                    return c;
            }
            return null;
        }

        public ChatClient Find(ChatClient cl)
        {
            foreach (ChatClient c in this.roomClients)
            {
                if (c.Equals(cl))
                    return c;
            }
            return null;
        }
    }
}

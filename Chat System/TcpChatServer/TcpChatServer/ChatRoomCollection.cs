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
using System.Windows.Forms;

namespace TcpChatServer
{
    /// <summary>
    /// Represents the all chat rooms avaiable on the server
    /// </summary>
    class ChatRoomCollection
    {
        private List<ChatRoom> chatRooms;

        public ChatRoomCollection() {
            chatRooms = new List<ChatRoom>();
        }

        public void Add(ChatRoom cr)
        {
            foreach (ChatRoom c in chatRooms)
            {
                if (c.Name.Equals(cr.Name))
                    throw new InvalidOperationException("Chat rooms cannot have the same name");
            }
            
            this.chatRooms.Add(cr);

        }

        public bool Remove(ChatRoom cr)
        {
            return this.chatRooms.Remove(cr);
        }

        public List<ChatRoom> List
        {
            get { return this.chatRooms; }
        }

        public String getChatRoomNames()
        {
            String str = "";
            foreach (ChatRoom cr in this.chatRooms)
            {
                str = str + cr.Name + ",";
            }
            return str.Substring(0,str.Length-1);
        }

        public void sendToAllChatRooms(String message)
        {
            foreach (ChatRoom r in chatRooms)
            {
                foreach (ChatClient c in r.List)
                {
                    c.StreamWriter.WriteLine(message);
                    c.StreamWriter.Flush();
                }
            }
        }

        public ChatRoom Find(String roomName)
        { 
            foreach (ChatRoom c in chatRooms)
            {
                if (c.Name.Equals(roomName))
                {
                    return c;
                }
            }
            return null;        
        }

        public ChatRoom Find(ChatClient client)
        {
            foreach (ChatRoom c in chatRooms)
            {
                ChatClient result = c.Find(client);
                if (result != null)
                {
                    return c;
                }
            }
            return null;
        }

    }
}

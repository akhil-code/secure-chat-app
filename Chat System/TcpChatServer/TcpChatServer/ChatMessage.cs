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

namespace TcpChatServer
{
    /// <summary>
    /// Defines the type of message which the client sends to server
    /// </summary>
    public enum MessageType
    {
        MESSAGE, CREATE_ROOM, JOIN, WHO, DISCONNECT
    }

    class ChatMessage
    {
        private MessageType messageType; // type of message
        private String parameter; // message content

        private ChatMessage(MessageType messageType, String parameter)
        {
            this.messageType = messageType;
            this.parameter = parameter;
        }

        /// <summary>
        /// Converts the message received from client to a message type object 
        /// </summary>
        public static ChatMessage parseMessage(String message) {
            int coLoc = message.IndexOf(":"); // location of opening bracket
            String type = message.Substring(0, coLoc);
            MessageType messageType = (MessageType)Enum.Parse(typeof(MessageType),type);
            String parameter = message.Substring(coLoc + 1);
            return new ChatMessage(messageType, parameter);
        }

        /// <summary>
        /// Returns the message type
        /// </summary>
        public MessageType MessageType
        {
            get { return this.messageType; }
        }

        /// <summary>
        /// Returns the message parameter
        /// </summary>
        public String Parameter
        {
            get { return this.parameter; }
        }
    }
}

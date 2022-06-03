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
using System.ComponentModel; 
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;


namespace TcpChatServer
{
    public partial class Form1 : Form
    {
        Socket tcpServer;   //Socket for server
        //ChatClient chatClient;
        List<ChatClient> clients; // List of client sockets
        // Delegate to point the ReceiveMessage function and accept function
        delegate void MethodDelegate(ChatClient c);
        delegate void MethodDelegate2();
        MethodDelegate dlgt;
        MethodDelegate2 serverAcceptDlgt;
        // Variable used to assign client id's
        int client_id = 0; 
        // ChatRoom collection and the default chat room (general)
        ChatRoomCollection chatRooms;
        ChatRoom defaultRoom;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Called when the listen button is clicked 
        /// </summary>
        private void btn_listen_Click(object sender, EventArgs e)
        {
            try
            {
                chatRooms = new ChatRoomCollection();
                // Create default chat room
                defaultRoom = new ChatRoom("General");
                chatRooms.Add(defaultRoom);
                // Creating server socket
                tcpServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint listenEndPoint = new IPEndPoint(IPAddress.Any, Int32.Parse(txt_portNum.Text));
                // Creating TCP server socket
                tcpServer.Bind(listenEndPoint);
                tcpServer.Listen(int.MaxValue);
                clients = new List<ChatClient>();
                // Update status information
                this.lbl_status.Text = "Server created successfully";
                btn_listen.Enabled = false;
                serverAcceptDlgt = new MethodDelegate2(this.acceptClient);
                serverAcceptDlgt.BeginInvoke(new AsyncCallback(DoneReading), null);
            }

            catch (Exception)
            {
                lbl_status.Text="Failed to create server";
            }
        }

        public void acceptClient()
        {
            while (true)
            {
                // Socket for the connected client
                Socket tcpClient = tcpServer.Accept();
                // Create a new ChatClient object and assign id to it
                ChatClient chatClient = new ChatClient(tcpClient, Convert.ToString(client_id));
                this.clients.Add(chatClient);
                // increments id 
                client_id++;
                try
                {
                    // Assign delage to point to ReceiveMessage fucntion
                    dlgt = new MethodDelegate(this.ReceiveMessage);

                    // Send a greeting message to client name to other computer
                    chatClient.StreamWriter.Write("***Welcome to the chat server***");
                    chatClient.StreamWriter.Flush();

                    // Get the client name
                    chatClient.Name = chatClient.StreamReader.ReadLine();
                    
                    // Send the client's id
                    chatClient.StreamWriter.WriteLine(chatClient.ID);
                    chatClient.StreamWriter.Flush();

                    // Send the available chat rooms
                    chatClient.StreamWriter.WriteLine(chatRooms.getChatRoomNames());
                    chatClient.StreamWriter.Flush();

                    // Adds client to default chat room and send messages to all clients on the system
                    defaultRoom.addClient(chatClient);
                    lst_messageList.Items.Add("Client <" + chatClient.Name + "> has registered in the room <" + defaultRoom.Name + ">");
                    chatRooms.sendToAllChatRooms("Client <" + chatClient.Name + "> has registered in the room <" + defaultRoom.Name + ">");
                    chatClient.StreamWriter.WriteLine("STATUS:Success - registeration to chat server was successful");
                    chatClient.StreamWriter.Flush();
                    // Begin a thread which will read the client's sent message
                    dlgt.BeginInvoke(chatClient,new AsyncCallback(DoneReading),chatClient);
                }
                catch (Exception)
                {
                    chatClient.StreamWriter.WriteLine("STATUS:Failure - Could not register client to server");
                    chatClient.StreamWriter.Flush();
                }
            }
        }

        /// <summary>
        /// The method that runs asychronously to receive messages from the socket
        /// </summary>
         void ReceiveMessage(ChatClient c)
        {
            while (true) // run infinitely in a thread seperate from the calling thread
            {
                String str = c.StreamReader.ReadLine(); // ReadLine is blocking, waits until there is something to read
                ChatMessage message = ChatMessage.parseMessage(str);
                ChatClient sendingClient=null;
  
                //Conversation message directed to other members in chat room
                if (message.MessageType.Equals(MessageType.MESSAGE))
                {
                    foreach (ChatRoom cr in chatRooms.List)
                    {
                        sendingClient = cr.Find(c);
                        if (sendingClient != null)
                        {
                            // Message to add to server 
                            lst_messageList.Items.Add("Client <" + sendingClient.Name + ">" + " is speaking at <" + cr.Name + ">");
                            // Send message to chat room participants
                            cr.sendMessageToAll(sendingClient.Name + ">>" + message.Parameter);
                            break;
                        }
                    }
                }

                /* CREATE ROOM command requested
                Create room for sending client and add it to the room */
                else if (message.MessageType.Equals(MessageType.CREATE_ROOM))
                {
                    try
                    {
                        foreach (ChatRoom cr in chatRooms.List)
                        {
                            sendingClient = cr.Find(c);
                            if (sendingClient != null)
                            {
                                // Create new room
                                ChatRoom newRoom = new ChatRoom(message.Parameter);
                                chatRooms.Add(newRoom); // add the new room to the chat room collection
                                // Remove client from room
                                cr.removeClient(sendingClient);
                                newRoom.addClient(sendingClient); // Add client to room
                                // Add information message to server
                                lst_messageList.Items.Add("Client <" + sendingClient.Name + "> has created and joined room <" + newRoom.Name + ">");
                                // Send information message to all clients in the left chat room
                                cr.sendMessageToAll("Client <" + sendingClient.Name + "> has left room <" + cr.Name + ">");
                                // Send information message to all clients in the joined chat room
                                newRoom.sendMessageToAll("Client <" + sendingClient.Name + "> has joined room <" + newRoom.Name + ">");
                                // Send message to clients to update their chat room list
                                chatRooms.sendToAllChatRooms("UPDATE CHAT ROOM:" + chatRooms.getChatRoomNames());
                                sendingClient.StreamWriter.WriteLine("STATUS:Success - Chat room was created successfully");
                                sendingClient.StreamWriter.Flush();
                                break;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        // Send error message to client
                        sendingClient.StreamWriter.WriteLine("STATUS:Failure - Chat room was not created!");
                        sendingClient.StreamWriter.Flush();
                    }
                }

                /* JOIN Command Requested
                 * Move the sending client to a another chat room */
                else if (message.MessageType.Equals(MessageType.JOIN))
                {
                    try
                    {
                        foreach (ChatRoom cr in chatRooms.List)
                        {
                            sendingClient = cr.Find(c);
                            if (sendingClient != null)
                            {
                                // Remove client from room
                                cr.removeClient(sendingClient);
                                // Create new room
                                ChatRoom roomToJoin = chatRooms.Find(message.Parameter);
                                roomToJoin.addClient(sendingClient); // Add client to room
                                // Add information message to server
                                lst_messageList.Items.Add("Client <" + sendingClient.Name + "> has left room <" + cr.Name + ">");
                                lst_messageList.Items.Add("Client <" + sendingClient.Name + "> has joined room <" + roomToJoin.Name + ">");
                                // Send information message to all clients in the left chat room
                                cr.sendMessageToAll("Client <" + sendingClient.Name + "> has left room <" + cr.Name + ">");
                                // Send information message to all clients in the joined chat room
                                roomToJoin.sendMessageToAll("Client <" + sendingClient.Name + "> has joined room <" + roomToJoin.Name + ">");
                                sendingClient.StreamWriter.WriteLine("STATUS:Success - Join command executed successfully");
                                sendingClient.StreamWriter.Flush();
                                break;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        // Send error message to client
                        sendingClient.StreamWriter.WriteLine("STATUS:Failure - Could not join chat room");
                        sendingClient.StreamWriter.Flush();
                    }
                }

                /* WHO command requested
                 * Sends the names of all clients in the room */
                else if (message.MessageType.Equals(MessageType.WHO))
                {
                    try
                    {
                        foreach (ChatRoom cr in chatRooms.List)
                        {
                            sendingClient = cr.Find(c);
                            if (sendingClient != null)
                            {
                                // Send the name to clients in the room
                                sendingClient.StreamWriter.WriteLine("Server >> The clients in room are " + cr.getAttendeeNames());
                                sendingClient.StreamWriter.Flush();
                                // Send command successful message to sending client
                                sendingClient.StreamWriter.WriteLine("STATUS:Success - Who command executed sucessfully");
                                sendingClient.StreamWriter.Flush();
                                break;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        // Send error message to  the sending client
                        sendingClient.StreamWriter.WriteLine("STATUS:Failure - Could not execute the who command");
                        sendingClient.StreamWriter.Flush();
                    }
                }

                /* DISCONNECT command requested
                * Disconnect the client from server and informs clients in chat room */
                else if (message.MessageType.Equals(MessageType.DISCONNECT))
                {
                    try
                    {
                        // End the thread and call the callback method DoneReading
                        return; 
                    }
                    catch (Exception) 
                    {
                        // Send error message
                        sendingClient.StreamWriter.WriteLine("STATUS:Failure - Could not disconnect from server");
                        sendingClient.StreamWriter.Flush();
                    }
                }
            }
        }

        /// <summary>
        /// Method that executes when the server stops reading (ie. connection closed)
        /// </summary>
        public void DoneReading(IAsyncResult iar)
        {
            // Get the client whom the thread is responsible for and close its socket
            ChatClient cc = (ChatClient)iar.AsyncState;
            ChatRoom room = chatRooms.Find(cc);
            room.removeClient(cc);
            cc.getSocket().Close();
            cc.StreamReader.Close();
            cc.StreamWriter.Close();
            // Send message to clients in the same room
            lst_messageList.Items.Add("Client <"+cc.Name+"> disconnected from server");
            room.sendMessageToAll("Client <" + cc.Name + "> has left room <" + room.Name + ">");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            this.lst_messageList.Items.Clear(); // Clears the message list box
        }
    }


}
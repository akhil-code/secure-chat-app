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
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;
using System.Security.Cryptography;


namespace TcpChatClient
{
    public partial class Form1 : Form
    {
        Socket tcpSocket;
        String name;
        String id;
        StreamReader streamReader;
        StreamWriter streamWriter;
        NetworkStream networkStream;
        private CryptoStream cryptoStreamWriter;
        private CryptoStream cryptoStreamReader;
        delegate void MethodDelegate();
        MethodDelegate dlgt;

        public Form1()
        {
            InitializeComponent();
            setGUIBeforeRegister();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            // Get the client's name
            this.name = txt_clientName.Text;

            //Create the client's tcp socket
            tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
            // Parse IP address
            IPAddress remoteHostAddress;
            if (this.txt_serverName.Text.Equals("localhost", StringComparison.OrdinalIgnoreCase))
            {
                remoteHostAddress = IPAddress.Loopback;
            }
            else
            {
                remoteHostAddress = IPAddress.Parse(txt_serverName.Text); //try catch here
            }

            // Create a remote endpoint for server
            IPEndPoint remoteHostEndPoint = new IPEndPoint(remoteHostAddress, Int32.Parse(txt_connectPort.Text));

            // Connect to server
            tcpSocket.BeginConnect(remoteHostEndPoint, new AsyncCallback(Connected), tcpSocket);
        }

        /// <summary>
        /// Method called when the client connects to server 
        /// </summary>
        public void Connected(IAsyncResult iar)
        {
            Socket sock = (Socket)iar.AsyncState;
            try
            {
                sock.EndConnect(iar);

                lbl_status.Text = "Success - Connected to chat server";
                setGUIAfterRegister();
                
                // Create streamreader and streamwriter
                this.networkStream = new NetworkStream(tcpSocket);

                // Crypto stream
                Rijndael rijAlg = Rijndael.Create();
                rijAlg.Mode = CipherMode.CBC;

                rijAlg.Key = Convert.FromBase64String("3j6ctQUbkYfVJrdkkzROAApUcguxtP6fQ+UbhEhQmsY=");
                rijAlg.IV = Convert.FromBase64String("vH3Az9+iXRv+9P67xBQXpw==");
                rijAlg.Padding = PaddingMode.ISO10126;


                // Writer
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);
                this.cryptoStreamWriter = new CryptoStream(this.networkStream, encryptor, CryptoStreamMode.Write);

                // Reader
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
                this.cryptoStreamReader = new CryptoStream(this.networkStream, decryptor, CryptoStreamMode.Read);

                this.streamReader = new StreamReader(this.cryptoStreamReader);
                this.streamWriter = new StreamWriter(this.networkStream);

                // Send computer name (NOTE: alternatively you can send the IP address)
                streamWriter.WriteLine(txt_clientName.Text);
                streamWriter.Flush();

                //participantName = streamReader.ReadLine(); // Get other computer's name

                Console.WriteLine("Started reading the line");
                MemoryStream memoryStream = new MemoryStream(1000);
                int currByte = this.cryptoStreamReader.ReadByte();
                while (currByte > 0) {
                    memoryStream.WriteByte(Convert.ToByte(currByte));
                    if (Convert.ToChar(currByte) == '\n') {
                        break;
                    }
                    currByte = this.cryptoStreamReader.ReadByte();
                }
                Console.WriteLine(Encoding.Default.GetString(memoryStream.ToArray()));


                lst_messageList.Items.Add(streamReader.ReadLine());
                // Get the ID assigned by the server
                id = streamReader.ReadLine();


                // MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(id));



                this.Text = txt_clientName.Text + "(ID:" + id + ") Chat Client";
                // Get the avaiable room lists
                UpdateChatRoomList(streamReader.ReadLine());

                // Assign delage to point to ReceiveMessage fucntion
                dlgt = new MethodDelegate(this.ReceiveMessage);

                // Begin a thread which will read the server's sent message
                dlgt.BeginInvoke(new AsyncCallback(DoneReading), null);
            }
            catch (Exception e)
            {
                lbl_status.Text="Failure - Could not connect to chat server";
                System.Console.WriteLine(e.Message);
            }
        }

        public void ReceiveMessage()
        {
            while (true) // run infinitely in a thread seperate from the calling thread
            {
                String str = streamReader.ReadLine(); // ReadLine is blocking, waits until there is something to read
                if (!IsStatusMessage(str) && !IsUpdateRoomsMessage(str))
                    lst_messageList.Items.Add(str+"\n");
            }
        }

        /// <summary>
        /// Method that executes when the server stops reading (ie. connection closed)
        /// </summary>
        public void DoneReading(IAsyncResult iar)
        {
            lbl_status.Text = "Success - Disconnected from server";
            setGUIBeforeRegister();
            streamReader.Close();
            streamWriter.Close();
            networkStream.Close();
            tcpSocket.Close();
            // Close sockets and streams
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            try
            {
                // Write message to stream
                streamWriter.WriteLine("MESSAGE:" + txt_message.Text);
                streamWriter.Flush();
                // Clear message textbox
                txt_message.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not send message because of the following exception:\n" + ex, "Send Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void UpdateChatRoomList(String str)
        {
            List<String> lst = new List<string>();
            lst.AddRange(str.Split(','));
            cmbx_chatRoom.DataSource = lst;
        }

        private bool IsStatusMessage(String str){
            if (str.StartsWith("STATUS:", StringComparison.Ordinal))
            {
                lbl_status.Text = str.Substring(str.IndexOf(":") + 1);
                return true;
            }
            return false;
        }

        private bool IsUpdateRoomsMessage(String str)
        {
            if (str.StartsWith("UPDATE CHAT ROOM:", StringComparison.Ordinal))
            {
                this.UpdateChatRoomList(str.Substring(str.IndexOf(":") + 1));
                return true;
            }
            return false;
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            // Write message to stream
            streamWriter.WriteLine("CREATE_ROOM:" + txt_roomName.Text);
            streamWriter.Flush();
            // Clear message textbox
            txt_roomName.Text = "";
        }

        private void btn_join_Click(object sender, EventArgs e)
        {
            streamWriter.WriteLine("JOIN:" + cmbx_chatRoom.SelectedValue.ToString());
            streamWriter.Flush();
        }

        private void btn_who_Click(object sender, EventArgs e)
        {
            streamWriter.WriteLine("WHO:");
            streamWriter.Flush();
        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            streamWriter.WriteLine("DISCONNECT:");
            streamWriter.Flush();
        }

        public void setGUIBeforeRegister()
        {
            foreach (Control c in grpbx_registration.Controls)
                c.Enabled = true;

            foreach (Control c in grpbx_join.Controls)
                c.Enabled = false;

            foreach (Control c in grpbx_create.Controls)
                c.Enabled = false;

            lst_messageList.Enabled = false;
            btn_disconnect.Enabled = false;
            btn_send.Enabled = false;
            btn_who.Enabled = false;
            btn_clear.Enabled = false;
            txt_message.Enabled = false;
        }

        public void setGUIAfterRegister()
        {
            foreach (Control c in grpbx_registration.Controls)
                c.Enabled = false;

            foreach (Control c in grpbx_join.Controls)
                c.Enabled = true;

            foreach (Control c in grpbx_create.Controls)
                c.Enabled = true;

            lst_messageList.Enabled = true;
            btn_disconnect.Enabled = true;
            btn_send.Enabled = true;
            btn_who.Enabled = true;
            btn_clear.Enabled = true;
            txt_message.Enabled = true;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            this.lst_messageList.Items.Clear();
        }



    }
}
//-//----Please DO NOT remove this comment----  
//  This code is written by 
//
//  Abdelnasser Ouda
//
//  Computer Science and Engineering
//  College of Engineering
//  University of North Texas
//----Please DO NOT remove this comment----

namespace TcpChatClient
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbx_chatRoom = new System.Windows.Forms.ComboBox();
            this.btn_join = new System.Windows.Forms.Button();
            this.grpbx_join = new System.Windows.Forms.GroupBox();
            this.txt_connectPort = new System.Windows.Forms.TextBox();
            this.txt_serverName = new System.Windows.Forms.TextBox();
            this.btn_register = new System.Windows.Forms.Button();
            this.lbl_connectToPort = new System.Windows.Forms.Label();
            this.lbl_serverName = new System.Windows.Forms.Label();
            this.grpbx_registration = new System.Windows.Forms.GroupBox();
            this.txt_clientName = new System.Windows.Forms.TextBox();
            this.lbl_clientName = new System.Windows.Forms.Label();
            this.txt_roomName = new System.Windows.Forms.TextBox();
            this.lbl_roomName = new System.Windows.Forms.Label();
            this.btn_create = new System.Windows.Forms.Button();
            this.grpbx_create = new System.Windows.Forms.GroupBox();
            this.lbl_status = new System.Windows.Forms.Label();
            this.btn_send = new System.Windows.Forms.Button();
            this.txt_message = new System.Windows.Forms.TextBox();
            this.btn_disconnect = new System.Windows.Forms.Button();
            this.btn_who = new System.Windows.Forms.Button();
            this.lst_messageList = new System.Windows.Forms.ListBox();
            this.lbl_messages = new System.Windows.Forms.Label();
            this.btn_clear = new System.Windows.Forms.Button();
            this.grpbx_join.SuspendLayout();
            this.grpbx_registration.SuspendLayout();
            this.grpbx_create.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbx_chatRoom
            // 
            this.cmbx_chatRoom.FormattingEnabled = true;
            this.cmbx_chatRoom.Location = new System.Drawing.Point(6, 21);
            this.cmbx_chatRoom.MaxDropDownItems = 100;
            this.cmbx_chatRoom.Name = "cmbx_chatRoom";
            this.cmbx_chatRoom.Size = new System.Drawing.Size(128, 21);
            this.cmbx_chatRoom.TabIndex = 14;
            // 
            // btn_join
            // 
            this.btn_join.Location = new System.Drawing.Point(5, 48);
            this.btn_join.Name = "btn_join";
            this.btn_join.Size = new System.Drawing.Size(125, 23);
            this.btn_join.TabIndex = 15;
            this.btn_join.Text = "Join";
            this.btn_join.UseVisualStyleBackColor = true;
            this.btn_join.Click += new System.EventHandler(this.btn_join_Click);
            // 
            // grpbx_join
            // 
            this.grpbx_join.Controls.Add(this.btn_join);
            this.grpbx_join.Controls.Add(this.cmbx_chatRoom);
            this.grpbx_join.Location = new System.Drawing.Point(383, 158);
            this.grpbx_join.Name = "grpbx_join";
            this.grpbx_join.Size = new System.Drawing.Size(169, 77);
            this.grpbx_join.TabIndex = 16;
            this.grpbx_join.TabStop = false;
            this.grpbx_join.Text = "Join another chat room";
            // 
            // txt_connectPort
            // 
            this.txt_connectPort.Location = new System.Drawing.Point(99, 56);
            this.txt_connectPort.Name = "txt_connectPort";
            this.txt_connectPort.Size = new System.Drawing.Size(46, 20);
            this.txt_connectPort.TabIndex = 21;
            this.txt_connectPort.Text = "998";
            // 
            // txt_serverName
            // 
            this.txt_serverName.Location = new System.Drawing.Point(6, 30);
            this.txt_serverName.Name = "txt_serverName";
            this.txt_serverName.Size = new System.Drawing.Size(139, 20);
            this.txt_serverName.TabIndex = 20;
            this.txt_serverName.Text = "localhost";
            // 
            // btn_register
            // 
            this.btn_register.Location = new System.Drawing.Point(12, 108);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(81, 24);
            this.btn_register.TabIndex = 19;
            this.btn_register.Text = "Register";
            this.btn_register.UseVisualStyleBackColor = true;
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            // 
            // lbl_connectToPort
            // 
            this.lbl_connectToPort.AutoSize = true;
            this.lbl_connectToPort.Location = new System.Drawing.Point(12, 59);
            this.lbl_connectToPort.Name = "lbl_connectToPort";
            this.lbl_connectToPort.Size = new System.Drawing.Size(81, 13);
            this.lbl_connectToPort.TabIndex = 18;
            this.lbl_connectToPort.Text = "Connect to Port";
            // 
            // lbl_serverName
            // 
            this.lbl_serverName.AutoSize = true;
            this.lbl_serverName.Location = new System.Drawing.Point(4, 16);
            this.lbl_serverName.Name = "lbl_serverName";
            this.lbl_serverName.Size = new System.Drawing.Size(157, 13);
            this.lbl_serverName.TabIndex = 17;
            this.lbl_serverName.Text = "Server name/Server IP Address";
            // 
            // grpbx_registration
            // 
            this.grpbx_registration.Controls.Add(this.txt_clientName);
            this.grpbx_registration.Controls.Add(this.txt_connectPort);
            this.grpbx_registration.Controls.Add(this.lbl_clientName);
            this.grpbx_registration.Controls.Add(this.txt_serverName);
            this.grpbx_registration.Controls.Add(this.btn_register);
            this.grpbx_registration.Controls.Add(this.lbl_connectToPort);
            this.grpbx_registration.Controls.Add(this.lbl_serverName);
            this.grpbx_registration.Location = new System.Drawing.Point(383, 12);
            this.grpbx_registration.Name = "grpbx_registration";
            this.grpbx_registration.Size = new System.Drawing.Size(169, 139);
            this.grpbx_registration.TabIndex = 22;
            this.grpbx_registration.TabStop = false;
            this.grpbx_registration.Text = "Registration";
            // 
            // txt_clientName
            // 
            this.txt_clientName.Location = new System.Drawing.Point(82, 82);
            this.txt_clientName.Name = "txt_clientName";
            this.txt_clientName.Size = new System.Drawing.Size(75, 20);
            this.txt_clientName.TabIndex = 30;
            this.txt_clientName.Text = "Client";
            // 
            // lbl_clientName
            // 
            this.lbl_clientName.AutoSize = true;
            this.lbl_clientName.Location = new System.Drawing.Point(12, 85);
            this.lbl_clientName.Name = "lbl_clientName";
            this.lbl_clientName.Size = new System.Drawing.Size(64, 13);
            this.lbl_clientName.TabIndex = 29;
            this.lbl_clientName.Text = "Client Name";
            // 
            // txt_roomName
            // 
            this.txt_roomName.Location = new System.Drawing.Point(8, 30);
            this.txt_roomName.Name = "txt_roomName";
            this.txt_roomName.Size = new System.Drawing.Size(126, 20);
            this.txt_roomName.TabIndex = 23;
            // 
            // lbl_roomName
            // 
            this.lbl_roomName.AutoSize = true;
            this.lbl_roomName.Location = new System.Drawing.Point(6, 15);
            this.lbl_roomName.Name = "lbl_roomName";
            this.lbl_roomName.Size = new System.Drawing.Size(69, 13);
            this.lbl_roomName.TabIndex = 24;
            this.lbl_roomName.Text = " Room Name";
            // 
            // btn_create
            // 
            this.btn_create.Location = new System.Drawing.Point(8, 55);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(81, 24);
            this.btn_create.TabIndex = 25;
            this.btn_create.Text = "Create";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // grpbx_create
            // 
            this.grpbx_create.Controls.Add(this.btn_create);
            this.grpbx_create.Controls.Add(this.lbl_roomName);
            this.grpbx_create.Controls.Add(this.txt_roomName);
            this.grpbx_create.Location = new System.Drawing.Point(381, 248);
            this.grpbx_create.Name = "grpbx_create";
            this.grpbx_create.Size = new System.Drawing.Size(171, 84);
            this.grpbx_create.TabIndex = 26;
            this.grpbx_create.TabStop = false;
            this.grpbx_create.Text = "Create Chat Room";
            // 
            // lbl_status
            // 
            this.lbl_status.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_status.ForeColor = System.Drawing.Color.Red;
            this.lbl_status.Location = new System.Drawing.Point(9, 350);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(546, 36);
            this.lbl_status.TabIndex = 31;
            this.lbl_status.Text = "Ready";
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(12, 319);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(56, 24);
            this.btn_send.TabIndex = 12;
            this.btn_send.Text = "Send";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // txt_message
            // 
            this.txt_message.Location = new System.Drawing.Point(12, 293);
            this.txt_message.Name = "txt_message";
            this.txt_message.Size = new System.Drawing.Size(363, 20);
            this.txt_message.TabIndex = 13;
            // 
            // btn_disconnect
            // 
            this.btn_disconnect.Location = new System.Drawing.Point(133, 319);
            this.btn_disconnect.Name = "btn_disconnect";
            this.btn_disconnect.Size = new System.Drawing.Size(69, 24);
            this.btn_disconnect.TabIndex = 27;
            this.btn_disconnect.Text = "Disconnect";
            this.btn_disconnect.UseVisualStyleBackColor = true;
            this.btn_disconnect.Click += new System.EventHandler(this.btn_disconnect_Click);
            // 
            // btn_who
            // 
            this.btn_who.Location = new System.Drawing.Point(74, 319);
            this.btn_who.Name = "btn_who";
            this.btn_who.Size = new System.Drawing.Size(53, 24);
            this.btn_who.TabIndex = 29;
            this.btn_who.Text = "Who";
            this.btn_who.UseVisualStyleBackColor = true;
            this.btn_who.Click += new System.EventHandler(this.btn_who_Click);
            // 
            // lst_messageList
            // 
            this.lst_messageList.FormattingEnabled = true;
            this.lst_messageList.HorizontalScrollbar = true;
            this.lst_messageList.Location = new System.Drawing.Point(12, 20);
            this.lst_messageList.Name = "lst_messageList";
            this.lst_messageList.Size = new System.Drawing.Size(362, 264);
            this.lst_messageList.TabIndex = 30;
            // 
            // lbl_messages
            // 
            this.lbl_messages.AutoSize = true;
            this.lbl_messages.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_messages.Location = new System.Drawing.Point(12, 5);
            this.lbl_messages.Name = "lbl_messages";
            this.lbl_messages.Size = new System.Drawing.Size(55, 13);
            this.lbl_messages.TabIndex = 32;
            this.lbl_messages.Text = "Messages";
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(206, 319);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(96, 24);
            this.btn_clear.TabIndex = 33;
            this.btn_clear.Text = "Clear Messages";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btn_send;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 395);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.lbl_messages);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.lst_messageList);
            this.Controls.Add(this.btn_who);
            this.Controls.Add(this.btn_disconnect);
            this.Controls.Add(this.grpbx_create);
            this.Controls.Add(this.grpbx_registration);
            this.Controls.Add(this.grpbx_join);
            this.Controls.Add(this.txt_message);
            this.Controls.Add(this.btn_send);
            this.Name = "Form1";
            this.Text = "Chat Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpbx_join.ResumeLayout(false);
            this.grpbx_registration.ResumeLayout(false);
            this.grpbx_registration.PerformLayout();
            this.grpbx_create.ResumeLayout(false);
            this.grpbx_create.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbx_chatRoom;
        private System.Windows.Forms.Button btn_join;
        private System.Windows.Forms.GroupBox grpbx_join;
        private System.Windows.Forms.TextBox txt_connectPort;
        private System.Windows.Forms.TextBox txt_serverName;
        private System.Windows.Forms.Button btn_register;
        private System.Windows.Forms.Label lbl_connectToPort;
        private System.Windows.Forms.Label lbl_serverName;
        private System.Windows.Forms.GroupBox grpbx_registration;
        private System.Windows.Forms.TextBox txt_roomName;
        private System.Windows.Forms.Label lbl_roomName;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.GroupBox grpbx_create;
        private System.Windows.Forms.TextBox txt_clientName;
        private System.Windows.Forms.Label lbl_clientName;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.TextBox txt_message;
        private System.Windows.Forms.Button btn_disconnect;
        private System.Windows.Forms.Button btn_who;
        private System.Windows.Forms.ListBox lst_messageList;
        private System.Windows.Forms.Label lbl_messages;
        private System.Windows.Forms.Button btn_clear;
    }
}


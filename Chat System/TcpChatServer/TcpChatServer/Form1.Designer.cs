//----Please DO NOT remove this comment----  
//  This code is written by 
//
//  Abdelnasser Ouda
//
//  Computer Science and Engineering
//  College of Engineering
//  University of North Texas
//----Please DO NOT remove this comment----
namespace TcpChatServer
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
            this.lst_messageList = new System.Windows.Forms.ListBox();
            this.txt_portNum = new System.Windows.Forms.TextBox();
            this.btn_listen = new System.Windows.Forms.Button();
            this.listenOnPort_lbl = new System.Windows.Forms.Label();
            this.lbl_status = new System.Windows.Forms.Label();
            this.btn_clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lst_messageList
            // 
            this.lst_messageList.FormattingEnabled = true;
            this.lst_messageList.Location = new System.Drawing.Point(12, 26);
            this.lst_messageList.Name = "lst_messageList";
            this.lst_messageList.Size = new System.Drawing.Size(311, 251);
            this.lst_messageList.TabIndex = 0;
            // 
            // txt_portNum
            // 
            this.txt_portNum.Location = new System.Drawing.Point(16, 296);
            this.txt_portNum.Name = "txt_portNum";
            this.txt_portNum.Size = new System.Drawing.Size(75, 20);
            this.txt_portNum.TabIndex = 1;
            this.txt_portNum.Text = "998";
            // 
            // btn_listen
            // 
            this.btn_listen.Location = new System.Drawing.Point(97, 294);
            this.btn_listen.Name = "btn_listen";
            this.btn_listen.Size = new System.Drawing.Size(85, 22);
            this.btn_listen.TabIndex = 2;
            this.btn_listen.Text = "Listen";
            this.btn_listen.UseVisualStyleBackColor = true;
            this.btn_listen.Click += new System.EventHandler(this.btn_listen_Click);
            // 
            // listenOnPort_lbl
            // 
            this.listenOnPort_lbl.AutoSize = true;
            this.listenOnPort_lbl.Location = new System.Drawing.Point(13, 280);
            this.listenOnPort_lbl.Name = "listenOnPort_lbl";
            this.listenOnPort_lbl.Size = new System.Drawing.Size(72, 13);
            this.listenOnPort_lbl.TabIndex = 4;
            this.listenOnPort_lbl.Text = "Listen on Port";
            // 
            // lbl_status
            // 
            this.lbl_status.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_status.ForeColor = System.Drawing.Color.Red;
            this.lbl_status.Location = new System.Drawing.Point(12, 360);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(310, 39);
            this.lbl_status.TabIndex = 12;
            this.lbl_status.Text = "Ready";
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(188, 294);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(96, 24);
            this.btn_clear.TabIndex = 34;
            this.btn_clear.Text = "Clear Messages";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 408);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.listenOnPort_lbl);
            this.Controls.Add(this.btn_listen);
            this.Controls.Add(this.txt_portNum);
            this.Controls.Add(this.lst_messageList);
            this.Name = "Form1";
            this.Text = "Chat Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lst_messageList;
        private System.Windows.Forms.TextBox txt_portNum;
        private System.Windows.Forms.Button btn_listen;
        private System.Windows.Forms.Label listenOnPort_lbl;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.Button btn_clear;
    }
}


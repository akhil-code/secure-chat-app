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
using System.Windows.Forms;

namespace TcpChatClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
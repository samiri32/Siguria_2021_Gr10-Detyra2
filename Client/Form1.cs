﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        Socket clientSocket;
        RSACryptoServiceProvider objRsa = new RSACryptoServiceProvider();
        DESCryptoServiceProvider objDes = new DESCryptoServiceProvider();
        //X509Certificate2 certifikata = new X509Certificate2();
        string key;
        string IV;


        Socket socket()
        {
            return new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        }

        public Form1()
        {
            InitializeComponent();
            clientSocket = socket();
            connect();

        }

        private void connect()
        {
            string ipaddress = "127.0.0.1";
            int portNumber = 12000;

            try
            {
                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ipaddress), portNumber);
                clientSocket.Connect(ep);

            }
            catch
            {
                MessageBox.Show("Connection Failed");
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            /*if (textBox1.Text != "" && textBox2.Text != "")
            {
              
                send();
                

            }
            else
            {*/
                this.label3.Text = "Të gjitha fushat duhet të plotësohen!";
           /* }*/
        }

        private void send()
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string login = "1";

            string msg =  username + "." + password + "." + login;

            //msg = encrypt(msg);
            
            byte[] data = Encoding.Default.GetBytes(msg);
            clientSocket.Send(data, 0, data.Length, 0);
       
        }

        

        private void label3_Click(object sender, EventArgs e)
        {
           
            Register reg = new Register();
            reg.Show();
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Socket ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private void button1_Click(object sender, EventArgs e)
        {
            
            try {
                int port = 8080;
                
                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(textBox3.Text), port);
                ClientSocket.Connect(ep);

            }
 
            catch (Exception ex) {
                MessageBox.Show("Error: " + ex);
            }
            Thread t = new Thread(() =>
            {   
                //while (true)
                {
                    Thread UserThread = new Thread(User);
                    UserThread.Start(ClientSocket);
                }
            });
            t.Start();
            
        }

        public void User(object Client)
        {
            while (true)
            {
                Socket ClientSocket = Client as Socket;
                byte[] rev = new byte[4096];
                int size = ClientSocket.Receive(rev);
                //add(Encoding.ASCII.GetString(rev, 0, size));
                //rev = new byte[1024];
                //size = ClientSocket.Receive(rev);
                add(Encoding.ASCII.GetString(rev, 0, size));
            }
        }

        void add(string s)
        {
            textBox2.Invoke(new MethodInvoker(delegate()
            {
                textBox2.Text=s;
                textBox2.AppendText("\r\n");
            }));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string msg = textBox1.Text;
            ClientSocket.Send(Encoding.ASCII.GetBytes(msg), 0, msg.Length, SocketFlags.None);
        }
    }
}

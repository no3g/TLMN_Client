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
        private Socket ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private void bt_Connect_Click(object sender, EventArgs e)
        {
            bt_Connect.Hide();
            
            try
            {
                int port = 8080;

                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(tbIP.Text), port);
                ClientSocket.Connect(ep);

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
            List_Bet.Visible = true;
            lb_Bet.Visible = true;
            label1.Visible = true;
        }

        private void bt_TaoPhong_Click(object sender, EventArgs e)
        {
            if (List_Bet.SelectedItem == null) return;
            string s=List_Bet.SelectedItem.ToString();
            ClientSocket.Send(Encoding.ASCII.GetBytes("1 "+s), 0, ("1 "+s).Length, SocketFlags.None);
            Form2 f2 = new Form2(ClientSocket,s);
            this.Hide();
            f2.Show();
        }

        private void bt_TimPhong_Click(object sender, EventArgs e)
        {
            if (List_Bet.SelectedItem == null) return;
            string s = List_Bet.SelectedItem.ToString();
            ClientSocket.Send(Encoding.ASCII.GetBytes("0 " + s), 0, ("0 " + s).Length, SocketFlags.None);
            byte[] rev = new byte[4096];
            int size = ClientSocket.Receive(rev);
            string str = (Encoding.ASCII.GetString(rev, 0, size));
            if (str=="1")
            {
                Form2 f2 = new Form2(ClientSocket,s);
                this.Hide();
                f2.Show();
            }
            else MessageBox.Show("Khong co phong phu hop");
        }

        
    }
}

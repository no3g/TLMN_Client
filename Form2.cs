using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Client
{
    public partial class Form2 : Form
    {
        public Form2(string s)
        {
            ip = IPAddress.Parse(s);
            InitializeComponent();
        }
        IPAddress ip;
        List<Image> images = new List<Image>();
        List<Rectangle> rects = new List<Rectangle>();
        bool[] clicked = new bool[13];
        private Socket ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private string str = "";
        /*void add(string s)
        {
            textBox2.Invoke(new MethodInvoker(delegate()
            {
                textBox2.Text = s;
                textBox2.AppendText("\r\n");
            }));
        }*/

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                int port = 8080;

                IPEndPoint ep = new IPEndPoint(ip, port);
                ClientSocket.Connect(ep);

            }

            catch (Exception ex)
            {
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
                str=(Encoding.ASCII.GetString(rev, 0, size));
                draw();
            }
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen selPen = new Pen(Color.White);
            Brush red = new SolidBrush(Color.Blue);
            g.DrawRectangle(selPen, 0, 0, 1200, 650);
            if (str.Contains("Rank"))
            {
                Image labai = Image.FromFile("..\\..\\image\\BG.gif");
                for (int i = 0; i < 5; i++)
                    g.DrawImage(labai, 520 + i * 20, 20, 80, 115);
                for (int i = 0; i < 5; i++)
                    g.DrawImage(labai, 30 + i * 20, 210, 80, 115);
                for (int i = 0; i < 5; i++)
                    g.DrawImage(labai, 990 + i * 20, 210, 80, 115);
                string drawString = str;
                Font drawFont = new Font("Arial", 16);
                SolidBrush drawBrush = new SolidBrush(Color.Black);
                float x = 550;
                float y = 170;
                StringFormat drawFormat = new StringFormat();
                g.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);
                //g.DrawImage(Image.FromFile("..\\..\\image\\wait.gif"), 500, 170, 200, 200);
            }
            else if (str != "")
            {
                Image labai = Image.FromFile("..\\..\\image\\BG.gif");
                for (int i = 0; i < 5; i++)
                    g.DrawImage(labai, 520 + i * 20, 20, 80, 115);
                for (int i = 0; i < 5; i++)
                    g.DrawImage(labai, 30 + i * 20, 210, 80, 115);
                for (int i = 0; i < 5; i++)
                    g.DrawImage(labai, 990 + i * 20, 210, 80, 115);
                string[] card = str.Split(' ');
                int k = int.Parse(card[0]);
                images.Clear();
                rects.Clear();
                for (int i = 0; i < k; i++)
                {
                    labai = Image.FromFile("..\\..\\image\\" + card[i + 1].Replace(',', ' ') + ".png");
                    images.Add(labai);
                    rects.Add(new Rectangle((1140 - k * 20) / 2 + i * 20, 475, 80, 115));
                    if (clicked[i]) g.DrawImage(labai, (1140 - k * 20) / 2 + i * 20, 455, 80, 115);
                    else g.DrawImage(labai, (1140 - k * 20) / 2 + i * 20, 475, 80, 115);
                }
                int k1 = int.Parse(card[k + 1]);
                for (int i = k + 1; i < k + k1 + 1; i++)
                {
                    labai = Image.FromFile("..\\..\\image\\" + card[i + 1].Replace(',', ' ') + ".png");
                    g.DrawImage(labai, (1140 - k1 * 20) / 2 + (i - k - 1) * 20, 210, 80, 115);
                }
            }
            else
            {
                Image labai = Image.FromFile("..\\..\\image\\BG.gif");
                for (int i = 0; i < 5; i++)
                    g.DrawImage(labai, 520 + i * 20, 20, 80, 115);
                for (int i = 0; i < 5; i++)
                    g.DrawImage(labai, 30 + i * 20, 210, 80, 115);
                for (int i = 0; i < 5; i++)
                    g.DrawImage(labai, 990 + i * 20, 210, 80, 115);
                g.DrawImage(Image.FromFile("..\\..\\image\\wait.gif"), 500, 170, 200, 200);
            }
            g.Dispose(); 
        }
        private void draw()
        {
            //Form1_Paint(new object(), new PaintEventArgs());
            //var r = new Rectangle(0, 0, this.Width, this.Height);

            this.Invalidate();
            //this.Update();
        }

        private void bt_Danh_Click(object sender, EventArgs e)
        {
            string msg="1";
            string[] card = str.Split(' ');
            int k = int.Parse(card[0]);
            for (int i = 0; i < k; i++) if (clicked[i]) msg = msg + " " + card[i+1];
            ClientSocket.Send(Encoding.ASCII.GetBytes(msg), 0, msg.Length, SocketFlags.None);
            clicked = new bool[13];
        }

        private void bt_BoLuot_Click(object sender, EventArgs e)
        {
            ClientSocket.Send(Encoding.ASCII.GetBytes("0"), 0, "0".Length, SocketFlags.None);
            clicked = new bool[13];
        }

        private void Form2_MouseClick(object sender, MouseEventArgs e)
        {
            Point mousePt = new Point(e.X, e.Y);
            for (int j = rects.Count - 1; j >= 0; j--)
            {
                if (rects[j].Contains(mousePt))
                {
                    clicked[j] = !clicked[j];
                    break;
                }
            }
            draw();
        }
    }
}

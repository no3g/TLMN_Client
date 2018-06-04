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
        public Form2(Socket client, string s)
        {
            bet = s;
            ClientSocket = client;
            InitializeComponent();
        }
        List<Image> images = new List<Image>();
        List<Rectangle> rects = new List<Rectangle>();
        int ID = -1;
        int money = 10000;
        string bet;
        int numofPlayer = 0;
        bool ksort = false;
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


        private void Form2_Load(object sender, EventArgs e)
        {
            lb_Player1.BackColor = System.Drawing.Color.Transparent;
            lb_Player2.BackColor = System.Drawing.Color.Transparent;
            lb_Player3.BackColor = System.Drawing.Color.Transparent;
            lb_Ready1.BackColor = System.Drawing.Color.Transparent;
            lb_Ready2.BackColor = System.Drawing.Color.Transparent;
            lb_Ready3.BackColor = System.Drawing.Color.Transparent;
            lb_BoLuot1.BackColor = System.Drawing.Color.Transparent;
            lb_BoLuot2.BackColor = System.Drawing.Color.Transparent;
            lb_BoLuot3.BackColor = System.Drawing.Color.Transparent;
            lb_BoLuot4.BackColor = System.Drawing.Color.Transparent;
            lb_Wait1.BackColor = System.Drawing.Color.Transparent;
            lb_Wait2.BackColor = System.Drawing.Color.Transparent;
            lb_Wait3.BackColor = System.Drawing.Color.Transparent;
            lb_Bet.BackColor = System.Drawing.Color.Transparent;
            lb_Money.BackColor = System.Drawing.Color.Transparent;
            lb_Bet.Text = "Tien cuoc: " + bet;
            lb_Money.Text = "Tien: " + money.ToString();
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
                try
                {
                    Socket ClientSocket = Client as Socket;
                    byte[] rev = new byte[4096];
                    int size = ClientSocket.Receive(rev);
                    //add(Encoding.ASCII.GetString(rev, 0, size));
                    //rev = new byte[1024];
                    //size = ClientSocket.Receive(rev);
                    str = (Encoding.ASCII.GetString(rev, 0, size));
                    if (ksort) sort();
                    string[] s = str.Split(' ');
                    if (s[0] == "ID") ID = int.Parse(s[1]);
                    else if (s[0] == "Status")
                    {
                        if (s[1] == "2")
                        {
                            PlayerShow(lb_Player1);
                            if (s[3] == "1") PlayerShow(lb_Ready1);
                        }
                        if (s[1] == "3")
                        {
                            PlayerShow(lb_Player1);
                            PlayerShow(lb_Player2);
                            if (s[3] == "1") PlayerShow(lb_Ready1);
                            if (s[4] == "1") PlayerShow(lb_Ready2);
                        }
                        if (s[1] == "4")
                        {
                            PlayerShow(lb_Player1);
                            PlayerShow(lb_Player2);
                            PlayerShow(lb_Player3);
                            if (s[3] == "1") PlayerShow(lb_Ready1);
                            if (s[4] == "1") PlayerShow(lb_Ready2);
                            if (s[5] == "1") PlayerShow(lb_Ready3);
                        }
                        numofPlayer = int.Parse(s[1]);
                    }
                    else if (s[0] == "Rank:")
                    {
                        ShowRank(s[1]);
                        bt_Danh.Enabled = false;
                        bt_BoLuot.Enabled = false;
                        bt_Show(bt_Ready);
                    }
                    else draw();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        public void ShowRank(string s)
        {
            lb_Rank.Invoke(new MethodInvoker(delegate()
            {
                lb_Rank.Text = "Rank " + s;
            }));
            int d = int.Parse(s);
            int k = 0;
            if (numofPlayer == 2) k = - 2 * ((d - 1) * 2 - 1);
            if (numofPlayer == 3) k = -2 * (d - 2);
            if (numofPlayer == 4)
                if (d >= 2) k = (-1 * (d - 3));
                else k = (-1 * (d - 2));
            money=(money + k * int.Parse(bet) / 2);
            lb_Money.Invoke(new MethodInvoker(delegate()
            {
                lb_Money.Text = "Tien: " + money;
            }));
            LB(lb_Rank, 1);
        }
        public void PlayerShow(Label lb)
        {
            lb.Invoke(new MethodInvoker(delegate()
            {
                lb.Visible = true;
            }));
        }
        public void bt_Show(Button bt)
        {
            bt.Invoke(new MethodInvoker(delegate()
            {
                bt.Visible = true;
            }));
        }
        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            /*Graphics g = e.Graphics;
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
            g.Dispose(); */
        }
        public void LB(Label lb,int k)
        {
            if (k==1)
            {
                lb.Invoke(new MethodInvoker(delegate()
                {
                    lb.Visible = true;
                }));
            }
            else
            {
                lb.Invoke(new MethodInvoker(delegate()
                {
                    lb.Visible = false;
                }));
            }
        }
        private void draw()
        {
            LB(lb_Ready1, 0);
            LB(lb_Ready2, 0);
            LB(lb_Ready3, 0);
            string[] s = str.Split(' ');
            int d = s.Length - numofPlayer;
            if (numofPlayer >= 2)
                if (s[d + 1] == "0") LB(lb_BoLuot1, 1);
                else LB(lb_BoLuot1, 0);
            if (numofPlayer >= 3)
                if (s[d + 2] == "0") LB(lb_BoLuot2, 1);
                else LB(lb_BoLuot2, 0);
            if (numofPlayer >= 4)
                if (s[d + 3] == "0") LB(lb_BoLuot3, 1);
                else LB(lb_BoLuot3, 0);
            if (s[d] == "0") LB(lb_BoLuot4, 1);
            else LB(lb_BoLuot4, 0);
            if (s[s.Length-numofPlayer -1]=="0")
            {
                bt_Danh.Invoke(new MethodInvoker(delegate()
                {
                    bt_Danh.Enabled = true;
                }));
                int k = int.Parse(str.Split(' ')[0]);
                if (str.Split(' ')[k + 1] != "0")
                {
                    bt_BoLuot.Invoke(new MethodInvoker(delegate()
                    {
                        bt_BoLuot.Enabled = true;
                    }));
                }
            }
            panel2.Invalidate();
            panel1.Invalidate();
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
            bt_Danh.Enabled = false;
            bt_BoLuot.Enabled = false;
        }

        private void bt_BoLuot_Click(object sender, EventArgs e)
        {
            ClientSocket.Send(Encoding.ASCII.GetBytes("0"), 0, "0".Length, SocketFlags.None);
            clicked = new bool[13];
            bt_Danh.Enabled = false;
            bt_BoLuot.Enabled = false;
        }

        private void Form2_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
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
            panel2.Invalidate();
        }

        private void bt_Ready_Click(object sender, EventArgs e)
        {
            ClientSocket.Send(Encoding.ASCII.GetBytes("1"), 0, "1".Length, SocketFlags.None);
            bt_Ready.Visible = false;
            lb_Rank.Visible = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (!str.Contains("Status") && !str.Contains("ID") && str != "" && !str.Contains("Rank"))
            {
                Image labai;
                string[] card = str.Split(' ');
                int k = int.Parse(card[0]);
                images.Clear();
                rects.Clear();
                for (int i = 0; i < k; i++)
                {
                    labai = Image.FromFile("..\\..\\image\\" + card[i + 1].Replace(',', ' ') + ".png");
                    images.Add(labai);
                    rects.Add(new Rectangle((570 - k * 20) / 2 + i * 20, 5, 85, 115));
                    if (clicked[i]) g.DrawImage(labai, (570 - k * 20) / 2 + i * 20, 5, 85, 115);
                    else g.DrawImage(labai, (570 - k * 20) / 2 + i * 20, 15, 85, 115);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (!str.Contains("Status") && !str.Contains("ID") && str != "" && !str.Contains("Rank"))
            {
                Image labai;
                string[] card = str.Split(' ');
                int k = int.Parse(card[0]);
                int k1 = int.Parse(card[k + 1]);
                for (int i = k + 1; i < k + k1 + 1; i++)
                {
                    labai = Image.FromFile("..\\..\\image\\" + card[i + 1].Replace(',', ' ') + ".png");
                    g.DrawImage(labai, (570 - k1 * 20) / 2 + (i - k - 1) * 20, 15, 85, 115);
                }
            }
        }

        private void bt_Sort_Click(object sender, EventArgs e)
        {
            sort();
            ksort = true;
            panel2.Invalidate();
        }
        public void sort()
        {
            if (!(!str.Contains("Status") && !str.Contains("ID") && str != "" && !str.Contains("Rank"))) return;
            string[] s = str.Split(' ');
            int n = int.Parse(s[0]);
            for (int i = 0; i < n - 1; i++)
                for (int j = i + 1; j < n; j++)
                    if (int.Parse(s[i + 1].Split(',')[0]) > int.Parse(s[j + 1].Split(',')[0]) || (int.Parse(s[i + 1].Split(',')[0]) == int.Parse(s[j + 1].Split(',')[0]) && int.Parse(s[i + 1].Split(',')[1]) > int.Parse(s[j + 1].Split(',')[1])))
                    {
                        string s1 = s[i + 1];
                        s[i + 1] = s[j + 1];
                        s[j + 1] = s1;
                    }
            str = s[0];
            for (int i = 1; i < s.Length; i++)
            {
                str = str + " " + s[i];
            }
        }
    }
}

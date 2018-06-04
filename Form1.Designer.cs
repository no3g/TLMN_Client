namespace Client
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
            this.tbIP = new System.Windows.Forms.TextBox();
            this.bt_Connect = new System.Windows.Forms.Button();
            this.IP = new System.Windows.Forms.Label();
            this.bt_TaoPhong = new System.Windows.Forms.Button();
            this.bt_TimPhong = new System.Windows.Forms.Button();
            this.List_Bet = new System.Windows.Forms.ListBox();
            this.lb_Bet = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(485, 223);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(181, 20);
            this.tbIP.TabIndex = 0;
            // 
            // bt_Connect
            // 
            this.bt_Connect.Location = new System.Drawing.Point(538, 249);
            this.bt_Connect.Name = "bt_Connect";
            this.bt_Connect.Size = new System.Drawing.Size(75, 23);
            this.bt_Connect.TabIndex = 1;
            this.bt_Connect.Text = "Ket Noi";
            this.bt_Connect.UseVisualStyleBackColor = true;
            this.bt_Connect.Click += new System.EventHandler(this.bt_Connect_Click);
            // 
            // IP
            // 
            this.IP.AutoSize = true;
            this.IP.Location = new System.Drawing.Point(452, 226);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(17, 13);
            this.IP.TabIndex = 2;
            this.IP.Text = "IP";
            // 
            // bt_TaoPhong
            // 
            this.bt_TaoPhong.Location = new System.Drawing.Point(408, 360);
            this.bt_TaoPhong.Name = "bt_TaoPhong";
            this.bt_TaoPhong.Size = new System.Drawing.Size(75, 23);
            this.bt_TaoPhong.TabIndex = 3;
            this.bt_TaoPhong.Text = "Tao Phong";
            this.bt_TaoPhong.UseVisualStyleBackColor = true;
            this.bt_TaoPhong.Click += new System.EventHandler(this.bt_TaoPhong_Click);
            // 
            // bt_TimPhong
            // 
            this.bt_TimPhong.Location = new System.Drawing.Point(671, 360);
            this.bt_TimPhong.Name = "bt_TimPhong";
            this.bt_TimPhong.Size = new System.Drawing.Size(75, 23);
            this.bt_TimPhong.TabIndex = 4;
            this.bt_TimPhong.Text = "Tim Phong";
            this.bt_TimPhong.UseVisualStyleBackColor = true;
            this.bt_TimPhong.Click += new System.EventHandler(this.bt_TimPhong_Click);
            // 
            // List_Bet
            // 
            this.List_Bet.FormattingEnabled = true;
            this.List_Bet.Items.AddRange(new object[] {
            "100",
            "200",
            "500"});
            this.List_Bet.Location = new System.Drawing.Point(537, 295);
            this.List_Bet.Name = "List_Bet";
            this.List_Bet.Size = new System.Drawing.Size(76, 43);
            this.List_Bet.TabIndex = 5;
            this.List_Bet.Visible = false;
            // 
            // lb_Bet
            // 
            this.lb_Bet.AutoSize = true;
            this.lb_Bet.Location = new System.Drawing.Point(535, 279);
            this.lb_Bet.Name = "lb_Bet";
            this.lb_Bet.Size = new System.Drawing.Size(82, 13);
            this.lb_Bet.TabIndex = 6;
            this.lb_Bet.Text = "Chon muc cuoc";
            this.lb_Bet.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(537, 341);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "So tien: 10000";
            this.label1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 611);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_Bet);
            this.Controls.Add(this.List_Bet);
            this.Controls.Add(this.bt_TimPhong);
            this.Controls.Add(this.bt_TaoPhong);
            this.Controls.Add(this.IP);
            this.Controls.Add(this.bt_Connect);
            this.Controls.Add(this.tbIP);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_Connect;
        private System.Windows.Forms.Label IP;
        public System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.Button bt_TaoPhong;
        private System.Windows.Forms.Button bt_TimPhong;
        private System.Windows.Forms.ListBox List_Bet;
        private System.Windows.Forms.Label lb_Bet;
        private System.Windows.Forms.Label label1;

    }
}


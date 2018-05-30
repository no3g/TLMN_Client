namespace Client
{
    partial class Form2
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
            this.bt_Danh = new System.Windows.Forms.Button();
            this.bt_BoLuot = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_Danh
            // 
            this.bt_Danh.Location = new System.Drawing.Point(944, 518);
            this.bt_Danh.Name = "bt_Danh";
            this.bt_Danh.Size = new System.Drawing.Size(75, 23);
            this.bt_Danh.TabIndex = 0;
            this.bt_Danh.Text = "Danh";
            this.bt_Danh.UseVisualStyleBackColor = true;
            this.bt_Danh.Click += new System.EventHandler(this.bt_Danh_Click);
            // 
            // bt_BoLuot
            // 
            this.bt_BoLuot.Location = new System.Drawing.Point(944, 547);
            this.bt_BoLuot.Name = "bt_BoLuot";
            this.bt_BoLuot.Size = new System.Drawing.Size(75, 23);
            this.bt_BoLuot.TabIndex = 1;
            this.bt_BoLuot.Text = "Bo Luot";
            this.bt_BoLuot.UseVisualStyleBackColor = true;
            this.bt_BoLuot.Click += new System.EventHandler(this.bt_BoLuot_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 611);
            this.Controls.Add(this.bt_BoLuot);
            this.Controls.Add(this.bt_Danh);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form2_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_Danh;
        private System.Windows.Forms.Button bt_BoLuot;
    }
}
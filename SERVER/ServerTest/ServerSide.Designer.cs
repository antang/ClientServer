namespace ServerTest
{
    partial class ServerSide
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
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblScreen = new System.Windows.Forms.Label();
            this.txtChatScreen = new System.Windows.Forms.TextBox();
            this.lbl_IP = new System.Windows.Forms.Label();
            this.txt_IPServer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblMessage.Location = new System.Drawing.Point(30, 59);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(103, 20);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Message :";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(139, 62);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(262, 100);
            this.txtMessage.TabIndex = 1;
            this.txtMessage.AcceptsTabChanged += new System.EventHandler(this.btnSend_Click);
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSend_KeyDown);
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(407, 62);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(95, 100);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblScreen
            // 
            this.lblScreen.AutoSize = true;
            this.lblScreen.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScreen.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblScreen.Location = new System.Drawing.Point(12, 187);
            this.lblScreen.Name = "lblScreen";
            this.lblScreen.Size = new System.Drawing.Size(133, 20);
            this.lblScreen.TabIndex = 0;
            this.lblScreen.Text = "Chat screen :";
            // 
            // txtChatScreen
            // 
            this.txtChatScreen.Location = new System.Drawing.Point(139, 187);
            this.txtChatScreen.Multiline = true;
            this.txtChatScreen.Name = "txtChatScreen";
            this.txtChatScreen.ReadOnly = true;
            this.txtChatScreen.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtChatScreen.Size = new System.Drawing.Size(363, 161);
            this.txtChatScreen.TabIndex = 5;
            // 
            // lbl_IP
            // 
            this.lbl_IP.AutoSize = true;
            this.lbl_IP.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_IP.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_IP.Location = new System.Drawing.Point(30, 23);
            this.lbl_IP.Name = "lbl_IP";
            this.lbl_IP.Size = new System.Drawing.Size(97, 20);
            this.lbl_IP.TabIndex = 7;
            this.lbl_IP.Text = "IP Server";
            // 
            // txt_IPServer
            // 
            this.txt_IPServer.Enabled = false;
            this.txt_IPServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_IPServer.Location = new System.Drawing.Point(139, 22);
            this.txt_IPServer.Name = "txt_IPServer";
            this.txt_IPServer.Size = new System.Drawing.Size(262, 26);
            this.txt_IPServer.TabIndex = 8;
            // 
            // ServerSide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(510, 356);
            this.Controls.Add(this.txt_IPServer);
            this.Controls.Add(this.lbl_IP);
            this.Controls.Add(this.txtChatScreen);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lblScreen);
            this.Controls.Add(this.lblMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServerSide";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SERVER Side - [Send Message Demo]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MyChatForm_FormClosing);
            this.Load += new System.EventHandler(this.MyChatForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblScreen;
        private System.Windows.Forms.TextBox txtChatScreen;
        private System.Windows.Forms.Label lbl_IP;
        private System.Windows.Forms.TextBox txt_IPServer;
    }
}


﻿namespace Client
{
    partial class Client
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lsvMessage = new ListView();
            txbMessage = new TextBox();
            btnSend = new Button();
            SuspendLayout();
            // 
            // lsvMessage
            // 
            lsvMessage.BackColor = SystemColors.HighlightText;
            lsvMessage.Location = new Point(12, 12);
            lsvMessage.Name = "lsvMessage";
            lsvMessage.Size = new Size(776, 352);
            lsvMessage.TabIndex = 0;
            lsvMessage.UseCompatibleStateImageBehavior = false;
            lsvMessage.View = View.List;
            lsvMessage.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // txbMessage
            // 
            txbMessage.Location = new Point(12, 378);
            txbMessage.Multiline = true;
            txbMessage.Name = "txbMessage";
            txbMessage.Size = new Size(672, 60);
            txbMessage.TabIndex = 1;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(690, 378);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(94, 60);
            btnSend.TabIndex = 2;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // Client
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSend);
            Controls.Add(txbMessage);
            Controls.Add(lsvMessage);
            Name = "Client";
            Text = "Client";
            FormClosed += Client_FormClosed;
            Load += Client_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lsvMessage;
        private TextBox txbMessage;
        private Button btnSend;
    }
}
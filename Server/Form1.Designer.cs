namespace Server
{
    partial class Server
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
            btnSend = new Button();
            txbMessage = new TextBox();
            lsvMessage = new ListView();
            checkBox1 = new CheckBox();
            SuspendLayout();
            // 
            // btnSend
            // 
            btnSend.Location = new Point(690, 399);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(94, 39);
            btnSend.TabIndex = 5;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // txbMessage
            // 
            txbMessage.Location = new Point(12, 349);
            txbMessage.Multiline = true;
            txbMessage.Name = "txbMessage";
            txbMessage.Size = new Size(672, 89);
            txbMessage.TabIndex = 4;
            txbMessage.TextChanged += txbMessage_TextChanged;
            // 
            // lsvMessage
            // 
            lsvMessage.BackColor = SystemColors.HighlightText;
            lsvMessage.Location = new Point(12, 12);
            lsvMessage.Name = "lsvMessage";
            lsvMessage.Size = new Size(776, 331);
            lsvMessage.TabIndex = 3;
            lsvMessage.UseCompatibleStateImageBehavior = false;
            lsvMessage.View = View.List;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(688, 351);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(100, 24);
            checkBox1.TabIndex = 6;
            checkBox1.Text = "Auto Send";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // Server
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            ClientSize = new Size(800, 450);
            Controls.Add(checkBox1);
            Controls.Add(btnSend);
            Controls.Add(txbMessage);
            Controls.Add(lsvMessage);
            Name = "Server";
            Text = "Server";
            FormClosed += Server_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSend;
        private TextBox txbMessage;
        private ListView lsvMessage;
        private CheckBox checkBox1;
    }
}
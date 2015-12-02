namespace Grupperum_Dedikeret_Klient
{
    partial class EditGroupRoomPOPUP
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
            this.lbl_name = new System.Windows.Forms.Label();
            this.txtBx_roomName = new System.Windows.Forms.TextBox();
            this.chkBx_monitor = new System.Windows.Forms.CheckBox();
            this.chkBx_whiteboard = new System.Windows.Forms.CheckBox();
            this.btn_accept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(12, 9);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(89, 13);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.Text = "Grupperum navn:";
            // 
            // txtBx_roomName
            // 
            this.txtBx_roomName.Location = new System.Drawing.Point(12, 25);
            this.txtBx_roomName.Name = "txtBx_roomName";
            this.txtBx_roomName.ReadOnly = true;
            this.txtBx_roomName.Size = new System.Drawing.Size(141, 20);
            this.txtBx_roomName.TabIndex = 1;
            // 
            // chkBx_monitor
            // 
            this.chkBx_monitor.AutoSize = true;
            this.chkBx_monitor.Location = new System.Drawing.Point(15, 51);
            this.chkBx_monitor.Name = "chkBx_monitor";
            this.chkBx_monitor.Size = new System.Drawing.Size(61, 17);
            this.chkBx_monitor.TabIndex = 2;
            this.chkBx_monitor.Text = "Monitor";
            this.chkBx_monitor.UseVisualStyleBackColor = true;
            // 
            // chkBx_whiteboard
            // 
            this.chkBx_whiteboard.AutoSize = true;
            this.chkBx_whiteboard.Location = new System.Drawing.Point(15, 74);
            this.chkBx_whiteboard.Name = "chkBx_whiteboard";
            this.chkBx_whiteboard.Size = new System.Drawing.Size(81, 17);
            this.chkBx_whiteboard.TabIndex = 3;
            this.chkBx_whiteboard.Text = "Whiteboard";
            this.chkBx_whiteboard.UseVisualStyleBackColor = true;
            // 
            // btn_accept
            // 
            this.btn_accept.Location = new System.Drawing.Point(15, 97);
            this.btn_accept.Name = "btn_accept";
            this.btn_accept.Size = new System.Drawing.Size(138, 41);
            this.btn_accept.TabIndex = 4;
            this.btn_accept.Text = "Godkend";
            this.btn_accept.UseVisualStyleBackColor = true;
            this.btn_accept.Click += new System.EventHandler(this.btn_accept_Click);
            // 
            // EditGroupRoomPOPUP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(169, 170);
            this.Controls.Add(this.btn_accept);
            this.Controls.Add(this.chkBx_whiteboard);
            this.Controls.Add(this.chkBx_monitor);
            this.Controls.Add(this.txtBx_roomName);
            this.Controls.Add(this.lbl_name);
            this.Name = "EditGroupRoomPOPUP";
            this.Text = "EditGroupRoomPOPUP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.TextBox txtBx_roomName;
        private System.Windows.Forms.CheckBox chkBx_monitor;
        private System.Windows.Forms.CheckBox chkBx_whiteboard;
        private System.Windows.Forms.Button btn_accept;
    }
}
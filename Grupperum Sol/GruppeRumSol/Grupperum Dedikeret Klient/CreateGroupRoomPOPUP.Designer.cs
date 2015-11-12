namespace Grupperum_Dedikeret_Klient
{
    partial class CreateGroupRoomPOPUP
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
            this.Check_Monitor = new System.Windows.Forms.CheckBox();
            this.check_whiteboard = new System.Windows.Forms.CheckBox();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.btn_godkend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Check_Monitor
            // 
            this.Check_Monitor.AutoSize = true;
            this.Check_Monitor.Location = new System.Drawing.Point(15, 51);
            this.Check_Monitor.Name = "Check_Monitor";
            this.Check_Monitor.Size = new System.Drawing.Size(61, 17);
            this.Check_Monitor.TabIndex = 0;
            this.Check_Monitor.Text = "Monitor";
            this.Check_Monitor.UseVisualStyleBackColor = true;
            // 
            // check_whiteboard
            // 
            this.check_whiteboard.AutoSize = true;
            this.check_whiteboard.Location = new System.Drawing.Point(15, 74);
            this.check_whiteboard.Name = "check_whiteboard";
            this.check_whiteboard.Size = new System.Drawing.Size(81, 17);
            this.check_whiteboard.TabIndex = 1;
            this.check_whiteboard.Text = "Whiteboard";
            this.check_whiteboard.UseVisualStyleBackColor = true;
            // 
            // txt_Name
            // 
            this.txt_Name.ForeColor = System.Drawing.Color.Black;
            this.txt_Name.Location = new System.Drawing.Point(12, 25);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(141, 20);
            this.txt_Name.TabIndex = 2;
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Location = new System.Drawing.Point(12, 9);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(100, 13);
            this.lbl_Name.TabIndex = 3;
            this.lbl_Name.Text = "Navngiv grupperum";
            this.lbl_Name.Click += new System.EventHandler(this.lbl_Name_Click);
            // 
            // btn_godkend
            // 
            this.btn_godkend.Location = new System.Drawing.Point(15, 97);
            this.btn_godkend.Name = "btn_godkend";
            this.btn_godkend.Size = new System.Drawing.Size(138, 41);
            this.btn_godkend.TabIndex = 4;
            this.btn_godkend.Text = "Godkend";
            this.btn_godkend.UseVisualStyleBackColor = true;
            this.btn_godkend.Click += new System.EventHandler(this.btn_godkend_Click);
            // 
            // CreateGroupRoomPOPUP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(169, 170);
            this.Controls.Add(this.btn_godkend);
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.check_whiteboard);
            this.Controls.Add(this.Check_Monitor);
            this.Name = "CreateGroupRoomPOPUP";
            this.Text = "CreateGroupRoomPOPUP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox Check_Monitor;
        private System.Windows.Forms.CheckBox check_whiteboard;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Button btn_godkend;
    }
}
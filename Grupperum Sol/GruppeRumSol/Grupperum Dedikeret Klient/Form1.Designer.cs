namespace Grupperum_Dedikeret_Klient
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
            this.btn_CreateRoom = new System.Windows.Forms.Button();
            this.btn_editRoom = new System.Windows.Forms.Button();
            this.comBx_groupRooms = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btn_CreateRoom
            // 
            this.btn_CreateRoom.Location = new System.Drawing.Point(32, 43);
            this.btn_CreateRoom.Name = "btn_CreateRoom";
            this.btn_CreateRoom.Size = new System.Drawing.Size(75, 23);
            this.btn_CreateRoom.TabIndex = 0;
            this.btn_CreateRoom.Text = "Opret lokale";
            this.btn_CreateRoom.UseVisualStyleBackColor = true;
            this.btn_CreateRoom.Click += new System.EventHandler(this.btn_CreateRoom_Click);
            // 
            // btn_editRoom
            // 
            this.btn_editRoom.Location = new System.Drawing.Point(150, 43);
            this.btn_editRoom.Name = "btn_editRoom";
            this.btn_editRoom.Size = new System.Drawing.Size(88, 23);
            this.btn_editRoom.TabIndex = 1;
            this.btn_editRoom.Text = "Rediger lokale";
            this.btn_editRoom.UseVisualStyleBackColor = true;
            this.btn_editRoom.Click += new System.EventHandler(this.btn_editRoom_Click);
            // 
            // comBx_groupRooms
            // 
            this.comBx_groupRooms.FormattingEnabled = true;
            this.comBx_groupRooms.Location = new System.Drawing.Point(150, 16);
            this.comBx_groupRooms.Name = "comBx_groupRooms";
            this.comBx_groupRooms.Size = new System.Drawing.Size(121, 21);
            this.comBx_groupRooms.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.comBx_groupRooms);
            this.Controls.Add(this.btn_editRoom);
            this.Controls.Add(this.btn_CreateRoom);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_CreateRoom;
        private System.Windows.Forms.Button btn_editRoom;
        private System.Windows.Forms.ComboBox comBx_groupRooms;
    }
}


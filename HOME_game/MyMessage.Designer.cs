namespace HOME_game
{
    partial class MyMessage
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
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.tbMessage = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pbIcon
            // 
            this.pbIcon.Location = new System.Drawing.Point(30, 21);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(135, 134);
            this.pbIcon.TabIndex = 0;
            this.pbIcon.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnOK.Location = new System.Drawing.Point(258, 131);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(89, 32);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tbMessage
            // 
            this.tbMessage.BackColor = System.Drawing.SystemColors.Control;
            this.tbMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbMessage.Enabled = false;
            this.tbMessage.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMessage.ForeColor = System.Drawing.SystemColors.MenuText;
            this.tbMessage.Location = new System.Drawing.Point(187, 44);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.ReadOnly = true;
            this.tbMessage.Size = new System.Drawing.Size(228, 81);
            this.tbMessage.TabIndex = 3;
            this.tbMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MyMessage
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 175);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.pbIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MyMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox tbMessage;
    }
}
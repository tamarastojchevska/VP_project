namespace HOME_game
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
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pbLogo
            // 
            this.pbLogo.BackgroundImage = global::HOME_game.Resource1.logo;
            this.pbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbLogo.Location = new System.Drawing.Point(51, 22);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(444, 155);
            this.pbLogo.TabIndex = 3;
            this.pbLogo.TabStop = false;
            // 
            // btnInfo
            // 
            this.btnInfo.BackgroundImage = global::HOME_game.Resource1.info;
            this.btnInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfo.ForeColor = System.Drawing.SystemColors.Control;
            this.btnInfo.Location = new System.Drawing.Point(225, 328);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(70, 55);
            this.btnInfo.TabIndex = 2;
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.BackgroundImage = global::HOME_game.Resource1.quit;
            this.btnQuit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuit.ForeColor = System.Drawing.SystemColors.Control;
            this.btnQuit.Location = new System.Drawing.Point(159, 267);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(200, 55);
            this.btnQuit.TabIndex = 1;
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackgroundImage = global::HOME_game.Resource1.start;
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.ForeColor = System.Drawing.SystemColors.Control;
            this.btnStart.Location = new System.Drawing.Point(159, 206);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(200, 55);
            this.btnStart.TabIndex = 0;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = global::HOME_game.Resource1.delete;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.SystemColors.Control;
            this.btnDelete.Location = new System.Drawing.Point(225, 380);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(70, 55);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 458);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnDelete;
    }
}


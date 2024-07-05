namespace HOME_game
{
    partial class GameOver
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
            this.btnRetry = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnQuit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRetry
            // 
            this.btnRetry.BackgroundImage = global::HOME_game.Resource1.retry;
            this.btnRetry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRetry.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRetry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetry.ForeColor = System.Drawing.SystemColors.Control;
            this.btnRetry.Location = new System.Drawing.Point(51, 341);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.Size = new System.Drawing.Size(171, 51);
            this.btnRetry.TabIndex = 1;
            this.btnRetry.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::HOME_game.Resource1.game_over;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(51, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(432, 240);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnQuit
            // 
            this.btnQuit.BackgroundImage = global::HOME_game.Resource1.quit;
            this.btnQuit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuit.ForeColor = System.Drawing.SystemColors.Control;
            this.btnQuit.Location = new System.Drawing.Point(312, 341);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(171, 51);
            this.btnQuit.TabIndex = 3;
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // GameOver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 458);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnRetry);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GameOver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnRetry;
        private System.Windows.Forms.Button btnQuit;
    }
}
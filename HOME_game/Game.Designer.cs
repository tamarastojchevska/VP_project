namespace HOME_game
{
    partial class Game
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
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pbHealth = new System.Windows.Forms.ProgressBar();
            this.timerHealth = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbResume = new System.Windows.Forms.PictureBox();
            this.pbPause = new System.Windows.Forms.PictureBox();
            this.lblBestScore = new System.Windows.Forms.Label();
            this.lblCurrentScore = new System.Windows.Forms.Label();
            this.pbPlayer = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbResume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 30;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // pbHealth
            // 
            this.pbHealth.BackColor = System.Drawing.SystemColors.Control;
            this.pbHealth.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.pbHealth.Location = new System.Drawing.Point(10, 88);
            this.pbHealth.Maximum = 150;
            this.pbHealth.Name = "pbHealth";
            this.pbHealth.Size = new System.Drawing.Size(372, 23);
            this.pbHealth.Step = 1;
            this.pbHealth.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbHealth.TabIndex = 1;
            this.pbHealth.Value = 150;
            // 
            // timerHealth
            // 
            this.timerHealth.Enabled = true;
            this.timerHealth.Interval = 1000;
            this.timerHealth.Tick += new System.EventHandler(this.timerHealth_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.panel1.Controls.Add(this.pbResume);
            this.panel1.Controls.Add(this.pbPause);
            this.panel1.Controls.Add(this.lblBestScore);
            this.panel1.Controls.Add(this.lblCurrentScore);
            this.panel1.Controls.Add(this.pbHealth);
            this.panel1.Location = new System.Drawing.Point(665, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 114);
            this.panel1.TabIndex = 2;
            // 
            // pbResume
            // 
            this.pbResume.BackgroundImage = global::HOME_game.Resource1.play;
            this.pbResume.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbResume.Location = new System.Drawing.Point(312, 21);
            this.pbResume.Name = "pbResume";
            this.pbResume.Size = new System.Drawing.Size(70, 60);
            this.pbResume.TabIndex = 5;
            this.pbResume.TabStop = false;
            this.pbResume.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbResume_MouseClick);
            // 
            // pbPause
            // 
            this.pbPause.BackgroundImage = global::HOME_game.Resource1.pause;
            this.pbPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbPause.Location = new System.Drawing.Point(236, 21);
            this.pbPause.Name = "pbPause";
            this.pbPause.Size = new System.Drawing.Size(70, 60);
            this.pbPause.TabIndex = 4;
            this.pbPause.TabStop = false;
            this.pbPause.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbPause_MouseClick);
            // 
            // lblBestScore
            // 
            this.lblBestScore.AutoSize = true;
            this.lblBestScore.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBestScore.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblBestScore.Location = new System.Drawing.Point(6, 21);
            this.lblBestScore.Name = "lblBestScore";
            this.lblBestScore.Size = new System.Drawing.Size(124, 22);
            this.lblBestScore.TabIndex = 3;
            this.lblBestScore.Text = "Best score: 0";
            // 
            // lblCurrentScore
            // 
            this.lblCurrentScore.AutoSize = true;
            this.lblCurrentScore.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentScore.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCurrentScore.Location = new System.Drawing.Point(6, 53);
            this.lblCurrentScore.Name = "lblCurrentScore";
            this.lblCurrentScore.Size = new System.Drawing.Size(156, 22);
            this.lblCurrentScore.TabIndex = 2;
            this.lblCurrentScore.Text = "Current score: 0";
            // 
            // pbPlayer
            // 
            this.pbPlayer.BackColor = System.Drawing.Color.Transparent;
            this.pbPlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbPlayer.Location = new System.Drawing.Point(5, 5);
            this.pbPlayer.Name = "pbPlayer";
            this.pbPlayer.Size = new System.Drawing.Size(114, 73);
            this.pbPlayer.TabIndex = 0;
            this.pbPlayer.TabStop = false;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.ClientSize = new System.Drawing.Size(1062, 673);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbPlayer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1080, 720);
            this.MinimumSize = new System.Drawing.Size(1080, 720);
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HOME";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Game_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Game_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbResume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPlayer;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ProgressBar pbHealth;
        private System.Windows.Forms.Timer timerHealth;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCurrentScore;
        private System.Windows.Forms.Label lblBestScore;
        private System.Windows.Forms.PictureBox pbResume;
        private System.Windows.Forms.PictureBox pbPause;
    }
}
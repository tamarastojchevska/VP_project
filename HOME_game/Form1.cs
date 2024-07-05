using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOME_game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Game game = new Game();
            this.Hide();
            game.ShowDialog();
            if(game.DialogResult == DialogResult.OK)
            {
                this.Show();
            }
            else
            {
                this.Close();
            }
            
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            Information info = new Information();
            info.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the previous scores?", "", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                System.IO.File.WriteAllText(@"Resources\Scores.txt", "");
            }
        }
    }
}

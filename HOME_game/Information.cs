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
    public partial class Information : Form
    {
        public Information()
        {
            InitializeComponent();
            PictureBox picture = new PictureBox();
            picture.Image = Image.FromFile(@"Resources\information.png");
            picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            Panel panel = new Panel();
            panel.Size = new Size(450, 450);
            panel.Location = new Point(0, 0);
            panel.AutoScroll = true;
            panel.Controls.Add(picture);
            this.Controls.Add(panel);
        }

        private void Information_Load(object sender, EventArgs e)
        {

        }
    }
}

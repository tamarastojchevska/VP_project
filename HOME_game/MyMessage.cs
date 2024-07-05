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
    public partial class MyMessage : Form
    {
        public MyMessage(string image, string text)
        {
            InitializeComponent();

            pbIcon.BackgroundImage = Image.FromFile(@"Resources\" + image);
            pbIcon.BackgroundImageLayout = ImageLayout.Center;
            tbMessage.Text = text;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoviePlayerApp
{
    public partial class FrmPlayer : Form
    {
        public FrmPlayer()
        {
            InitializeComponent();
        }

        private void BtnSelectFile_Click(object sender, EventArgs e)
        {
            if(DlgSelectFiles.ShowDialog() == DialogResult.OK)
            {
                MoviePlayer.URL = DlgSelectFiles.FileName;
            }
        }

        private void FrmPlayer_Load(object sender, EventArgs e)
        {
            MoviePlayer.stretchToFit = true;
        }

        private void FrmPlayer_Resize(object sender, EventArgs e)
        {
            MoviePlayer.Size = this.ClientSize;

            BtnSelectFile.Location = new Point(
                ClientSize.Width - BtnSelectFile.Size.Width - 5,
                ClientSize.Height - BtnSelectFile.Size.Height - 5);
        }
    }
}

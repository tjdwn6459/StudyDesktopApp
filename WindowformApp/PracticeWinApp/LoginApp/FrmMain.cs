using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (TxtUserId.Text.ToLower() == "admin" && TxtPassWord.Text == "12345")
                TxtResult.Text = "로그인 성공";
            else
                TxtResult.Text = "로그인 실패";
        }
    }
}

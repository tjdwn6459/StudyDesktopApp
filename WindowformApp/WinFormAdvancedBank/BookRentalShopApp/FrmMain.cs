using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookRentalShopApp
{
    public partial class FrmMain : MetroForm

    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
           
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            frm.ShowDialog();
        }

        private void MnuExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void InitChildForm(Form frm, string strtitle)
        {
            frm.Text = strtitle;
            frm.Dock = DockStyle.Fill;
            frm.MdiParent = this; //FrmDivCode 가 frmMain 의 자식임을 말해준다 이렇게 설정 안하면 따로 뜬다
            frm.Show();
            frm.Width = this.ClientSize.Width - 10; //추가
            frm.Height = this.Height - menuStrip1.Height; //추가
            frm.WindowState = FormWindowState.Maximized;
        }

        private void MnuDiv_Click(object sender, EventArgs e)
        {
            FrmDivCode frm = new FrmDivCode();
            InitChildForm(frm, "구분코드 관리");

        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MetroMessageBox.Show(this, "종료하시겠습니까?", "종료",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                e.Cancel = false; //창을 닫는 이벤트를 취소하는걸 취소하니까 프로그램의 창이 종료된다
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true; //프로그램 종료 안함
            }
        }

        private void MnuMember_Click(object sender, EventArgs e)
        {
            FrmRental frm = new FrmRental();
            InitChildForm(frm, "회원관리");
        }

        private void MnuBooks_Click(object sender, EventArgs e)
        {
            FrmBooks frm = new FrmBooks();
            InitChildForm(frm, "책 관리");
        }

        private void MnuRental_Click(object sender, EventArgs e)
        {
            FrmRental frm = new FrmRental();
            InitChildForm(frm, "대여 관리");
        }
    }
}

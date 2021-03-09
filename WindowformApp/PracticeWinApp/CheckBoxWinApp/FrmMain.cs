using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckBoxWinApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnResult_Click(object sender, EventArgs e)
        {
            string checkState = string.Empty;

            List<CheckBox> boxes = new List<CheckBox> {
                ChkApple, ChkPear, ChkStrawberry, ChkBanana, ChkOrange, ChkDurian
            };

            foreach (var item in boxes)
            {
                checkState += $"{item.Text} : {item.Checked}\n";
            }

            MessageBox.Show(checkState, "체크상태");

            string Summary = $"좋아하는 과일은 : ";

            foreach (var item in boxes)
            {
                if (item.Checked /*== true*/) //if문에서는 이미 결과가 참이라서 true를 쓰지않아도 댄다
                    Summary += item.Text + " "; //true인값만 따로 빼서 결과를 나타냄
            }

            MessageBox.Show(Summary, "좋아하는 과일 리스트");
        }
    }
}

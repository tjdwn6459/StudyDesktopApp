using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorChangerApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void TrackBar_Scroll(object sender, EventArgs e)
        {
            TxtRed.Text = TrbRed.Value.ToString(); //Trb는 숫자만 인식하는데 Txt에 값을 표시하기 위해서는 문자열을 인식하는 박스에 맞추기
            TxtGreen.Text = TrbGreen.Value.ToString();
            Txtblue.Text = TrbBlue.Value.ToString();

            PnlResult.BackColor = Color.FromArgb(TrbRed.Value, TrbGreen.Value, TrbBlue.Value);
        }

        private void TextChanged(object sender, EventArgs e)
        {
            TrbRed.Value = int.Parse(TxtRed.Text); //위에서 받은 값을 int로 
            TrbGreen.Value = int.Parse(TxtGreen.Text);
            TrbBlue.Value = int.Parse(Txtblue.Text);
            PnlResult.BackColor = Color.FromArgb(TrbRed.Value, TrbGreen.Value, TrbBlue.Value);
        }
        

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void BtnColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }

        
    }
}

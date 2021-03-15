using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WinChartApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnRegen_Click(object sender, EventArgs e)
        {
            GenNewChart(); //그려진 데이터 위에 계속 그린다
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Text = "중간고사 성적";
            ChtScore.Titles.Add("중간고사 성적"); //차트의 제목을 만듬
            GenNewChart();
        }

        private void GenNewChart()
        {
           
            Random rand = new Random(); //rand라는 메소드를 하나 새로 만듬
            ChtScore.Series[0].Points.Clear();
            for (int i = 0; i < 10; i++)
            {
                ChtScore.Series[0].Points.Add(rand.Next(10, 100));

            }
            ChtScore.Series[0].LegendText = "수학";
            ChtScore.Series[0].ChartType = SeriesChartType.Pie;
        }
    }
}

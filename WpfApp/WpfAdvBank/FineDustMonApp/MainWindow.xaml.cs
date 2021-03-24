using MahApps.Metro.Controls;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace FineDustMonApp
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private string excelPath = $@"{AppDomain.CurrentDomain.BaseDirectory}busan_station_list.xls";


        private string openApiUri = "http://apis.data.go.kr/B552584/ArpltnInforInqireSvc/getMsrstnAcctoRltmMesureDnsty?" +
            "serviceKey=5xl5tTXSMaQ7TK43LWE8MlKChK3rt9cMPtxR%2BagjzxVdyrzil2psuFg2JyhCSPgLy2wdtoJz%2BD6Ebss%2FyWA%2F2A%3D%3D&" +
            "returnType=xml&" +
            "numOfRows=100&" +
            "pageNo=1&" +
            "dataTerm=DAILY&" +
            "ver=1.0&" +
            "stationName=";


        public MainWindow()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //엑셀파일에서 측정소를 가져오기
            IWorkbook wb = null;
            ISheet sh = null;


            using (FileStream fs = new FileStream(excelPath, FileMode.Open, FileAccess.Read))
            {
                wb = new HSSFWorkbook(fs);
            }

             List<string> lstLabs = new List<string>();


            sh = wb.GetSheetAt(0);
            int rowCount = sh.LastRowNum;

            try
            {
                for (int r = 0; r < rowCount; r++)
                {
                    if (r == 0) continue;

                    lstLabs.Add(sh.GetRow(r).Cells[1].ToString());

                }
            }
            catch (Exception ex)
            {

                throw;
            }

            Debug.WriteLine(lstLabs.Count);
            CboStations.ItemsSource = lstLabs;

        }

        private void CboStations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstResult = new List<FineDustInfo>();
            if (CboStations.SelectedItem != null)
            {
                openApiUri = openApiUri.Substring(0, openApiUri.LastIndexOf("=") + 1) + CboStations.SelectedItem.ToString();
                XmlDocument xml = new XmlDocument();
                xml.Load(openApiUri);
                XmlNodeList xnList = xml.SelectNodes("/response/body/items/item");

                foreach (XmlNode item in xnList)
                {
                    //Debug.WriteLine($"datetime: {item[dataTime].InnerText}");
                    lstResult.Add(new FineDustInfo()
                    {
                        DataTime = item["dataTime"].InnerText,
                        Khai = item["khaiValue"].InnerText,
                        SO2 = item["so2Value"].InnerText,

                    });
                }
            }
            DgrFineDustInfos.ItemsSource = lstResult;
        }

        private List<FineDustInfo> lstResult;
    }

    public class FineDustInfo
    {
        public string DataTime { get; set; }
        public string Khai { get; set; }
        public string SO2 { get; set; }
    }
}

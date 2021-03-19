using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookRentalShopApp
{
    public partial class FrmBooksPopup : MetroForm
    {
        #region 전역변수 영역
        public int SelIdx { get; set; }
        public string SelName { get; set; }

        #endregion

        #region 이벤트영역

        public FrmBooksPopup()
        {
            InitializeComponent();
        }

        private void FrmDivCode_Load(object sender, EventArgs e)
        {

            RefreshData(); //테이블 조회


        }



        private void FrmDivCode_Resize(object sender, EventArgs e)
        {

        }

        private void DgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        #region 커스텀 메서드 영역
        private void RefreshData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    var query = @"SELECT b.Idx
                                      ,b.Author
                                      ,b.Division
	                                  ,d.Names as DivName
                                      ,b.Names
                                      ,b.ReleaseDate
                                  FROM dbo.bookstbl as b
                                 INNER JOIN dbo.divtbl as d
                                    ON b.Division = d.Division "; // 210318 Descriptions 컬럼추가
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "bookstbl");

                    DgvData.DataSource = ds;
                    DgvData.DataMember = "bookstbl";
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"예외발생 : {ex.Message}", "오류", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            // 데이터그리드뷰 컬럼 화면에서 안보이게
            var column = DgvData.Columns[2]; // Division 컬럼
            column.Visible = false;

            column = DgvData.Columns[4];
            column.Width = 250;
            column.HeaderText = "도서명";

            column = DgvData.Columns[0]; // Idx
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        #endregion


        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (DgvData.SelectedRows.Count == 0)
            {
                MetroMessageBox.Show(this, "데이터를 선택하세요", "경고",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SelIdx = (int)DgvData.SelectedRows[0].Cells[0].Value;
            SelName = DgvData.SelectedRows[0].Cells[4].Value.ToString();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}











/// <summary>
/// 삭제처리 프로세스
/// </summary>

/* private void DgvData_CellClick(object sender, DataGridViewCellEventArgs e)
  {
      if (e.RowIndex > -1) //선택된 값이 존재하면
      {
          var selData = DgvData.Rows[e.RowIndex];
          //AsignToControls(selData);
          //isNew = false; //수정


      }
  }*/


/// <summary>
/// 입력(수정)처리 프로세스
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>

#endregion
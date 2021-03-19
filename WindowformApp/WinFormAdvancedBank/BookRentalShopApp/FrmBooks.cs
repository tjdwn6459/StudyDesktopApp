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
    public partial class FrmBooks : MetroForm
    {
        #region 전역변수 영역
        private bool isNew = false; //false (수정) true(신규)

        #endregion

        #region 이벤트영역

        public FrmBooks()
        {
            InitializeComponent();
        }

        private void FrmDivCode_Load(object sender, EventArgs e)
        {
            isNew = true; // 신규  초기화
            InitCboData();// 콤보박스 들어가는 데이터 초기화
            RefreshData(); //테이블 조회

            DtpReleaseDate.CustomFormat = "yyy-MM-dd";
            DtpReleaseDate.Format = DateTimePickerFormat.Custom;
        }

       

        private void FrmDivCode_Resize(object sender, EventArgs e)
        {
            DgvData.Height = this.ClientRectangle.Height - 90;
            groupBox1.Height = this.ClientRectangle.Height - 90;
        }

        private void DgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1) //선택된 값이 존재하면
            {
                var selData = DgvData.Rows[e.RowIndex];
                AsignToControls(selData);
                isNew = false; //수정

               
            }
        }

       

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            //  Validation
            if (CheckValidation() == false) return;

            if (MetroMessageBox.Show(this, "삭제하시겠습니까?", "삭제",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            DeleData();
            RefreshData();
            ClearInput();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Vaildation 체크
            if (CheckValidation() == false) return;


            SaveData();
            RefreshData();
            ClearInput();
        }

        #endregion


        #region 커스텀 메서드 영역

        private void InitCboData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    var query = "SELECT Division, Names FROM dbo.divtbl";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    var temp = new Dictionary<string, string>();
                    while (reader.Read())
                    {
                        temp.Add(reader[0].ToString(), reader[1].ToString());// (Key)B001, (Value)공포/ 스릴러
                    }
                    CboDivision.DataSource = new BindingSource(temp, null);
                    CboDivision.DisplayMember = "Value";
                    CboDivision.ValueMember = "Key";
                    CboDivision.SelectedIndex = -1;


                }
            }
            catch { }
            {

                
            }
        }

        private void AsignToControls(DataGridViewRow selData)
        {
            TxtIdx.Text = selData.Cells[0].Value.ToString(); //selData.Cells[0].Values는 object인데 TxtIdx.Text 문자열이라  tostring으로 문자열을 바꿈
            TxtAuthor.Text = selData.Cells[1].Value.ToString();
            CboDivision.SelectedValue = selData.Cells[2].Value; //B001 = B001 selectedindex 가 숫자로 매겨지는데 문자열 넣는곳에 넣어서 인식이 안댐
            // selData.Cells[3] X
            TxtNames.Text = selData.Cells[4].Value.ToString();
            //ReleaseDate
            DtpReleaseDate.Value = (DateTime)selData.Cells[5].Value;
            TxtISBN.Text = selData.Cells[6].Value.ToString();
            TxtPrice.Text = selData.Cells[7].Value.ToString();
            TxtDescriptions.Text = selData.Cells[8].Value.ToString();



            TxtIdx.ReadOnly = true;
        }


        /// <summary>
        /// 삭제처리 프로세스
        /// </summary>
        private void DeleData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    var query = "";

                    query = "DELETE FROM [dbo].[bookstbl] " +
                                        " WHERE[Idx] = @Idx ";
                    cmd.CommandText = query;

                    var pIdx = new SqlParameter("@Idx", SqlDbType.Int);
                    pIdx.Value = TxtIdx.Text;
                    cmd.Parameters.Add(pIdx);




                    var result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MetroMessageBox.Show(this, "삭제 성공", "삭제",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "삭제 실패", "삭제",
                           MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }


            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"예외발생 : {ex.Message}", "오류", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
        }
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
                                      ,b.ISBN
                                      ,b.Price
                                      ,b.Descriptions
                                  FROM dbo.bookstbl as b
                                  INNER JOIN dbo.divtbl as d
                                  on b.Division = d.Division
                                "; // 210318 descriptions 컬럼 추가

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataSet ds = new DataSet(); //adapter 데이터를 가져오기 위한것
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


            //데이터그리드뷰 컬럼(division) 화면에서 안보이게
            var column = DgvData.Columns[2];
            column.Visible = false;
            column = DgvData.Columns[8];
            column.Visible = false;

            column = DgvData.Columns[4];
            column.Width = 250;
            column.HeaderText = "도서명";


            column = DgvData.Columns[0];
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }


        /// <summary>
        /// 입력(수정)처리 프로세스
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void SaveData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    var query = "";

                    if (isNew == true) // ISNERT
                    {
                        query = @"INSERT INTO [dbo].[bookstbl]
                                       ([Author]
                                       ,[Division]
                                       ,[Names]
                                       ,[ReleaseDate]
                                       ,[ISBN]
                                       ,[Price]
                                       ,[Descriptions])
                                 VALUES
                                       (@Author
                                       ,@Division
                                       ,@Names
                                       ,@ReleaseDate
                                       ,@ISBN
                                       ,@Price
                                       ,@Descriptions) ";
                    }
                    else // UPDATE
                    {
                        query = @"UPDATE [dbo].[bookstbl]
                                       SET [Author] = @Author
                                          ,[Division] = @Division
                                          ,[Names] = @Names
                                          ,[ReleaseDate] = @ReleaseDate
                                          ,[ISBN] = @ISBN
                                          ,[Price] = @Price
                                          ,[Descriptions] = @Descriptions
                                     WHERE Idx = @Idx ";
                    }
                    cmd.CommandText = query;

                    var pAuthor = new SqlParameter("@Author", SqlDbType.NVarChar, 50);
                    pAuthor.Value = TxtAuthor.Text;
                    cmd.Parameters.Add(pAuthor);

                    var pDivision = new SqlParameter("@Division", SqlDbType.VarChar, 8);
                    pDivision.Value = CboDivision.SelectedValue; // B001
                    cmd.Parameters.Add(pDivision);

                    var pNames = new SqlParameter("@Names", SqlDbType.NVarChar, 100);
                    pNames.Value = TxtNames.Text;
                    cmd.Parameters.Add(pNames);

                    var pReleaseDate = new SqlParameter("@ReleaseDate", SqlDbType.Date);
                    pReleaseDate.Value = DtpReleaseDate.Value;
                    cmd.Parameters.Add(pReleaseDate);

                    var pISBN = new SqlParameter("@ISBN", SqlDbType.VarChar, 200);
                    pISBN.Value = TxtISBN.Text;
                    cmd.Parameters.Add(pISBN);

                    var pPrice = new SqlParameter("@Price", SqlDbType.Decimal);
                    pPrice.Value = TxtPrice.Text;
                    cmd.Parameters.Add(pPrice);

                    var pDescriptions = new SqlParameter("@Descriptions", SqlDbType.NVarChar);
                    pDescriptions.Value = Helper.Common.ReplaceCmdText(TxtDescriptions.Text);
                    cmd.Parameters.Add(pDescriptions);

                    if (isNew == false) // Update 일때만 처리
                    {
                        var pIdx = new SqlParameter("@Idx", SqlDbType.Int);
                        pIdx.Value = TxtIdx.Text;
                        cmd.Parameters.Add(pIdx);
                    }

                    var result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MetroMessageBox.Show(this, "저장 성공", "저장",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "저장 실패", "저장",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"예외발생 : {ex.Message}", "오류", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }




        /// <summary>
        /// 입력값 유효성 체크 메서드
        /// </summary>
        /// <returns></returns>
        private bool CheckValidation()
        {
            if (String.IsNullOrEmpty(TxtAuthor.Text) ||
                string.IsNullOrEmpty(TxtNames.Text) ||
                 CboDivision.SelectedIndex == -1 ||
                DtpReleaseDate.Value == null) //값이 없으면 null
            {
                MetroMessageBox.Show(this, "빈값은 처리할 수 없습니다.", "경고",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ClearInput()
        {
            TxtIdx.Text = TxtAuthor.Text = ""; //두개의 값을 없애준다
            TxtNames.Text = TxtISBN.Text = "";
            TxtDescriptions.Text = TxtPrice.Text = "";
            CboDivision.SelectedIndex = -1;
            DtpReleaseDate.Value = DateTime.Now; //오늘 날짜로 초기화
            TxtIdx.ReadOnly = true;
            isNew = true;
        }

        #endregion

        private void CboDivision_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

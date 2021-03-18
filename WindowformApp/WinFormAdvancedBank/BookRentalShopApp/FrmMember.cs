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
    public partial class FrmMember : MetroForm
    {
        #region 전역변수 영역

        private bool isNew = false; //false (수정) true(신규)


        #endregion

        #region 이벤트영역

        public FrmMember()
        {
            InitializeComponent();
        }

        private void FrmDivCode_Load(object sender, EventArgs e)
        {
            isNew = false; // 신규  초기화
            RefreshData();
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
                TxtIdx.Text = selData.Cells[0].Value.ToString();
                TxtNames.Text = selData.Cells[1].Value.ToString();
                CboLevels.SelectedItem = selData.Cells[2].Value;


                TxtAddr.Text = selData.Cells[3].Value.ToString();
                TxtMobile.Text = selData.Cells[4].Value.ToString();
                TxtEmail.Text = selData.Cells[5].Value.ToString();
                TxtUserId.Text = selData.Cells[6].Value.ToString();



                TxtIdx.ReadOnly = true;
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

            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    var query = "";
                    if (isNew == true) //INSERT
                    {
                        query = @"INSERT INTO [dbo].[membertbl]
                                  ([Names] 
                                   ,[Levels]
                                   ,[Addr] 
                                   ,[Mobile]
                                   ,[Email]
                                   ,[userID]
                                   ,[passwords])
                                   VALUES
                                     (@Names
                                     ,@Levels
                                     ,@Addr
                                     ,@Mobile
                                     ,@Email
                                     ,@userID
                                     ,@passwords) ";
                    }
                    else
                    {
                        query = @"UPDATE [dbo].[membertbl] 
                                   SET[Names] = @Names 
                                   ,[Levels] = @Levels
                                   ,[Addr] = @Addr
                                   ,[Mobile] = @Mobile
                                    ,[Email] = @Email
                                  ,[userID] = @userID
                                ,[passwords] = @passwords
                                 WHERE Idx = @Idx";

                    }
                    cmd.CommandText = query;

                    var pNames = new SqlParameter("@Names", SqlDbType.NVarChar, 50);
                    pNames.Value = TxtNames.Text;
                    cmd.Parameters.Add(pNames);

                    var pLevels = new SqlParameter("@Levels", SqlDbType.Char, 1);
                    pLevels.Value = CboLevels.SelectedItem.ToString();
                    cmd.Parameters.Add(pLevels);

                    var PAddr = new SqlParameter("@Addr", SqlDbType.NVarChar, 100);
                    PAddr.Value = TxtAddr.Text;
                    cmd.Parameters.Add(PAddr);

                    var PMobile = new SqlParameter("@Mobile", SqlDbType.VarChar, 50);
                    PMobile.Value = TxtMobile.Text;
                    cmd.Parameters.Add(PMobile);


                    var PEmail = new SqlParameter("@Email", SqlDbType.VarChar, 50);
                    PEmail.Value = TxtAddr.Text;
                    cmd.Parameters.Add(PEmail);

                    var PUserId = new SqlParameter("@UserId", SqlDbType.VarChar, 20);
                    PUserId.Value = TxtAddr.Text;
                    cmd.Parameters.Add(PUserId);


                    var PPasswords = new SqlParameter("@Passwords", SqlDbType.VarChar, 100);
                    PPasswords.Value = TxtAddr.Text;
                    cmd.Parameters.Add(PPasswords);

                    var pIdx = new SqlParameter("@Idx", SqlDbType.Int);
                    pIdx.Value = TxtIdx.Text;
                    cmd.Parameters.Add(pIdx);

                    if (isNew == false)
                    {

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

            RefreshData();
            ClearInput();
        }

        #endregion


        #region 커스텀 메서드 영역
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

                    query = "DELETE FROM [dbo].[membertbl] " +
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



        /// <summary>
        /// 입력(수정)처리 프로세스
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    var query = @"SELECT [Idx]
                                    ,[Names]
                                    ,[Levels]
                                    ,[Addr]
                                    ,[Mobile]
                                    ,[Email]
                                    ,[userID]
                                   ,[lastLoginDt]
                                   ,[loginIpAddr]
                                    FROM [dbo].[membertbl]";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "membertbl");

                    DgvData.DataSource = ds;
                    DgvData.DataMember = "membertbl";

                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"예외발생 : {ex.Message}", "오류", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                isNew = false;
            }
        }

        /// <summary>
        /// 입력값 유효성 체크 메서드
        /// </summary>
        /// <returns></returns>
        private bool CheckValidation()
        {
            if (String.IsNullOrEmpty(TxtIdx.Text) || string.IsNullOrEmpty(TxtNames.Text) ||
                string.IsNullOrEmpty(TxtAddr.Text) || string.IsNullOrEmpty(TxtMobile.Text) ||
                string.IsNullOrEmpty(TxtEmail.Text) || CboLevels.SelectedIndex == -1 ||
                string.IsNullOrEmpty(TxtUserId.Text))
            {
                MetroMessageBox.Show(this, "빈값은 처리할 수 없습니다.", "경고",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ClearInput()
        {
            TxtIdx.Text = TxtNames.Text = ""; //두개의 값을 없애준다
            TxtMobile.Text = TxtAddr.Text = TxtEmail.Text = "";
            TxtPasswords.Text = TxtUserId.Text = "";
            CboLevels.SelectedIndex = -1;
            TxtIdx.ReadOnly = true;
            isNew = true;
        }

        #endregion

    }
}

namespace RestaurentSelApp
{
    partial class FrmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.Lblresult = new System.Windows.Forms.Label();
            this.CboRestaurent = new System.Windows.Forms.ComboBox();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "좋아하는 식당 리스트";
            // 
            // Lblresult
            // 
            this.Lblresult.AutoSize = true;
            this.Lblresult.Location = new System.Drawing.Point(25, 141);
            this.Lblresult.Name = "Lblresult";
            this.Lblresult.Size = new System.Drawing.Size(105, 12);
            this.Lblresult.TabIndex = 1;
            this.Lblresult.Text = "이번 주 모임장소 :";
            this.Lblresult.Click += new System.EventHandler(this.LblResult_Click);
            // 
            // CboRestaurent
            // 
            this.CboRestaurent.FormattingEnabled = true;
            this.CboRestaurent.Location = new System.Drawing.Point(27, 38);
            this.CboRestaurent.Name = "CboRestaurent";
            this.CboRestaurent.Size = new System.Drawing.Size(237, 20);
            this.CboRestaurent.TabIndex = 2;
            this.CboRestaurent.SelectedIndexChanged += new System.EventHandler(this.CboRestaurent_SelectedIndexChanged);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(299, 18);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(77, 21);
            this.BtnAdd.TabIndex = 3;
            this.BtnAdd.Text = "추가";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnRemove
            // 
            this.BtnRemove.Location = new System.Drawing.Point(299, 45);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(77, 21);
            this.BtnRemove.TabIndex = 4;
            this.BtnRemove.Text = "삭제";
            this.BtnRemove.UseVisualStyleBackColor = true;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 176);
            this.Controls.Add(this.BtnRemove);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.CboRestaurent);
            this.Controls.Add(this.Lblresult);
            this.Controls.Add(this.label1);
            this.Name = "FrmMain";
            this.Text = "좋아하는 레스토랑";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Lblresult;
        private System.Windows.Forms.ComboBox CboRestaurent;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnRemove;
    }
}


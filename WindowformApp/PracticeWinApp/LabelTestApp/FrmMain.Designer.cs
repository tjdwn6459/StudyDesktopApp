
namespace LabelTestApp
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
            this.button1 = new System.Windows.Forms.Button();
            this.LblAutoSize = new System.Windows.Forms.Label();
            this.LblMannualSize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "텍스트입력";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // LblAutoSize
            // 
            this.LblAutoSize.AutoSize = true;
            this.LblAutoSize.Location = new System.Drawing.Point(32, 91);
            this.LblAutoSize.Name = "LblAutoSize";
            this.LblAutoSize.Size = new System.Drawing.Size(72, 12);
            this.LblAutoSize.TabIndex = 1;
            this.LblAutoSize.Text = "LblAutoSize";
            this.LblAutoSize.Click += new System.EventHandler(this.LblAutoSize_Click);
            // 
            // LblMannualSize
            // 
            this.LblMannualSize.Location = new System.Drawing.Point(32, 126);
            this.LblMannualSize.Name = "LblMannualSize";
            this.LblMannualSize.Size = new System.Drawing.Size(232, 48);
            this.LblMannualSize.TabIndex = 2;
            this.LblMannualSize.Text = "LblMannualSize";
            this.LblMannualSize.Click += new System.EventHandler(this.LblMannualSize_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 183);
            this.Controls.Add(this.LblMannualSize);
            this.Controls.Add(this.LblAutoSize);
            this.Controls.Add(this.button1);
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label LblAutoSize;
        private System.Windows.Forms.Label LblMannualSize;
    }
}


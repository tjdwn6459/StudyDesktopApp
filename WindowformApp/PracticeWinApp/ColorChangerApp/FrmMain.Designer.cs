﻿
namespace ColorChangerApp
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
            this.PnlResult = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtRed = new System.Windows.Forms.TextBox();
            this.TxtGreen = new System.Windows.Forms.TextBox();
            this.Txtblue = new System.Windows.Forms.TextBox();
            this.BtnColor = new System.Windows.Forms.Button();
            this.TrbRed = new System.Windows.Forms.TrackBar();
            this.TrbGreen = new System.Windows.Forms.TrackBar();
            this.TrbBlue = new System.Windows.Forms.TrackBar();
            this.BtnOpen = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.TrbRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrbGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrbBlue)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlResult
            // 
            this.PnlResult.BackColor = System.Drawing.Color.Black;
            this.PnlResult.Location = new System.Drawing.Point(99, 12);
            this.PnlResult.Name = "PnlResult";
            this.PnlResult.Size = new System.Drawing.Size(459, 162);
            this.PnlResult.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "RED";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "GREEN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 301);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "BLUE";
            // 
            // TxtRed
            // 
            this.TxtRed.Location = new System.Drawing.Point(479, 202);
            this.TxtRed.Name = "TxtRed";
            this.TxtRed.Size = new System.Drawing.Size(79, 21);
            this.TxtRed.TabIndex = 7;
            this.TxtRed.Text = "0";
            this.TxtRed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtRed.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // TxtGreen
            // 
            this.TxtGreen.Location = new System.Drawing.Point(479, 251);
            this.TxtGreen.Name = "TxtGreen";
            this.TxtGreen.Size = new System.Drawing.Size(79, 21);
            this.TxtGreen.TabIndex = 8;
            this.TxtGreen.Text = "0";
            this.TxtGreen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtGreen.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // Txtblue
            // 
            this.Txtblue.Location = new System.Drawing.Point(479, 298);
            this.Txtblue.Name = "Txtblue";
            this.Txtblue.Size = new System.Drawing.Size(79, 21);
            this.Txtblue.TabIndex = 9;
            this.Txtblue.Text = "0";
            this.Txtblue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txtblue.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // BtnColor
            // 
            this.BtnColor.Location = new System.Drawing.Point(586, 12);
            this.BtnColor.Name = "BtnColor";
            this.BtnColor.Size = new System.Drawing.Size(36, 31);
            this.BtnColor.TabIndex = 10;
            this.BtnColor.Text = "...";
            this.BtnColor.UseVisualStyleBackColor = true;
            this.BtnColor.Click += new System.EventHandler(this.BtnColor_Click);
            // 
            // TrbRed
            // 
            this.TrbRed.Location = new System.Drawing.Point(150, 196);
            this.TrbRed.Maximum = 255;
            this.TrbRed.Name = "TrbRed";
            this.TrbRed.Size = new System.Drawing.Size(305, 45);
            this.TrbRed.TabIndex = 11;
            this.TrbRed.TickFrequency = 5;
            this.TrbRed.Scroll += new System.EventHandler(this.TrackBar_Scroll);
            // 
            // TrbGreen
            // 
            this.TrbGreen.Location = new System.Drawing.Point(150, 246);
            this.TrbGreen.Maximum = 255;
            this.TrbGreen.Name = "TrbGreen";
            this.TrbGreen.Size = new System.Drawing.Size(305, 45);
            this.TrbGreen.TabIndex = 11;
            this.TrbGreen.TickFrequency = 5;
            this.TrbGreen.Scroll += new System.EventHandler(this.TrackBar_Scroll);
            // 
            // TrbBlue
            // 
            this.TrbBlue.Location = new System.Drawing.Point(150, 292);
            this.TrbBlue.Maximum = 255;
            this.TrbBlue.Name = "TrbBlue";
            this.TrbBlue.Size = new System.Drawing.Size(305, 45);
            this.TrbBlue.TabIndex = 11;
            this.TrbBlue.TickFrequency = 5;
            this.TrbBlue.Scroll += new System.EventHandler(this.TrackBar_Scroll);
            // 
            // BtnOpen
            // 
            this.BtnOpen.Location = new System.Drawing.Point(586, 49);
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Size = new System.Drawing.Size(36, 31);
            this.BtnOpen.TabIndex = 10;
            this.BtnOpen.Text = "...";
            this.BtnOpen.UseVisualStyleBackColor = true;
            this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(586, 86);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(36, 31);
            this.BtnSave.TabIndex = 10;
            this.BtnSave.Text = "...";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(634, 355);
            this.Controls.Add(this.TrbBlue);
            this.Controls.Add(this.TrbGreen);
            this.Controls.Add(this.TrbRed);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnOpen);
            this.Controls.Add(this.BtnColor);
            this.Controls.Add(this.Txtblue);
            this.Controls.Add(this.TxtGreen);
            this.Controls.Add(this.TxtRed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PnlResult);
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RGB Color Scroller";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TrbRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrbGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrbBlue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PnlResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtRed;
        private System.Windows.Forms.TextBox TxtGreen;
        private System.Windows.Forms.TextBox Txtblue;
        private System.Windows.Forms.Button BtnColor;
        private System.Windows.Forms.TrackBar TrbRed;
        private System.Windows.Forms.TrackBar TrbGreen;
        private System.Windows.Forms.TrackBar TrbBlue;
        private System.Windows.Forms.Button BtnOpen;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}


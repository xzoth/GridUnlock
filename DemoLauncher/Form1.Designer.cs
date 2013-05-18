namespace DemoLauncher
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.gridUnlock1 = new GridUnlock.GridUnlock();
            this.SuspendLayout();
            // 
            // gridUnlock1
            // 
            this.gridUnlock1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridUnlock1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gridUnlock1.GridUnlockStyle = GridUnlock.GridUnlockStyle.SixteenKeyPoint;
            this.gridUnlock1.Location = new System.Drawing.Point(204, 80);
            this.gridUnlock1.Name = "gridUnlock1";
            this.gridUnlock1.Size = new System.Drawing.Size(150, 150);
            this.gridUnlock1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 371);
            this.Controls.Add(this.gridUnlock1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private GridUnlock.GridUnlock gridUnlock1;
    }
}


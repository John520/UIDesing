namespace UIDesing
{
    partial class DFileOpt
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pcbPage = new System.Windows.Forms.TabPage();
            this.classifyPage = new System.Windows.Forms.TabPage();
            this.materPage = new System.Windows.Forms.TabPage();
            this.mountingPage = new System.Windows.Forms.TabPage();
            this.markPage = new System.Windows.Forms.TabPage();
            this.grop2 = new System.Windows.Forms.GroupBox();
            this.tabControl1.SuspendLayout();
            this.grop2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.pcbPage);
            this.tabControl1.Controls.Add(this.classifyPage);
            this.tabControl1.Controls.Add(this.materPage);
            this.tabControl1.Controls.Add(this.mountingPage);
            this.tabControl1.Controls.Add(this.markPage);
            this.tabControl1.Location = new System.Drawing.Point(17, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1164, 827);
            this.tabControl1.TabIndex = 0;
            // 
            // pcbPage
            // 
            this.pcbPage.Location = new System.Drawing.Point(4, 26);
            this.pcbPage.Name = "pcbPage";
            this.pcbPage.Padding = new System.Windows.Forms.Padding(3);
            this.pcbPage.Size = new System.Drawing.Size(1164, 840);
            this.pcbPage.TabIndex = 0;
            this.pcbPage.Text = "PCB数据";
            this.pcbPage.UseVisualStyleBackColor = true;
            // 
            // classifyPage
            // 
            this.classifyPage.Location = new System.Drawing.Point(4, 26);
            this.classifyPage.Name = "classifyPage";
            this.classifyPage.Padding = new System.Windows.Forms.Padding(3);
            this.classifyPage.Size = new System.Drawing.Size(1164, 840);
            this.classifyPage.TabIndex = 1;
            this.classifyPage.Text = "元件分类数据";
            this.classifyPage.UseVisualStyleBackColor = true;
            // 
            // materPage
            // 
            this.materPage.Location = new System.Drawing.Point(4, 26);
            this.materPage.Name = "materPage";
            this.materPage.Size = new System.Drawing.Size(1164, 840);
            this.materPage.TabIndex = 2;
            this.materPage.Text = "元件上料数据";
            this.materPage.UseVisualStyleBackColor = true;
            // 
            // mountingPage
            // 
            this.mountingPage.Location = new System.Drawing.Point(4, 26);
            this.mountingPage.Name = "mountingPage";
            this.mountingPage.Size = new System.Drawing.Size(1164, 840);
            this.mountingPage.TabIndex = 3;
            this.mountingPage.Text = "元件插装数据";
            this.mountingPage.UseVisualStyleBackColor = true;
            // 
            // markPage
            // 
            this.markPage.Location = new System.Drawing.Point(4, 26);
            this.markPage.Name = "markPage";
            this.markPage.Size = new System.Drawing.Size(1156, 797);
            this.markPage.TabIndex = 4;
            this.markPage.Text = "Mark点数据";
            this.markPage.UseVisualStyleBackColor = true;
            // 
            // grop2
            // 
            this.grop2.Controls.Add(this.tabControl1);
            this.grop2.Location = new System.Drawing.Point(4, 4);
            this.grop2.Name = "grop2";
            this.grop2.Size = new System.Drawing.Size(1187, 901);
            this.grop2.TabIndex = 1;
            this.grop2.TabStop = false;
            this.grop2.Text = "功能切换";
            // 
            // DFileOpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grop2);
            this.Name = "DFileOpt";
            this.Size = new System.Drawing.Size(1207, 868);
            this.Load += new System.EventHandler(this.DFileOpt_Load);
            this.tabControl1.ResumeLayout(false);
            this.grop2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage pcbPage;
        private System.Windows.Forms.TabPage classifyPage;
        private System.Windows.Forms.TabPage materPage;
        private System.Windows.Forms.TabPage mountingPage;
        private System.Windows.Forms.TabPage markPage;
        private System.Windows.Forms.GroupBox grop2;
    }
}

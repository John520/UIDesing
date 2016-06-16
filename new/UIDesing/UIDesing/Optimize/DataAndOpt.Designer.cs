namespace UIDesing.Optimize
{
    partial class DataAndOpt
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
            this.label1 = new System.Windows.Forms.Label();
            this.fileName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.exit_button = new System.Windows.Forms.Button();
            this.edit_button = new System.Windows.Forms.Button();
            this.stop_button = new System.Windows.Forms.Button();
            this.start_button = new System.Windows.Forms.Button();
            this.Param_button = new System.Windows.Forms.Button();
            this.check_button = new System.Windows.Forms.Button();
            this.form_Switch = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12.18462F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(30, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "PCB文件名:";
            // 
            // fileName
            // 
            this.fileName.AutoSize = true;
            this.fileName.BackColor = System.Drawing.Color.Aqua;
            this.fileName.Font = new System.Drawing.Font("宋体", 12.18462F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fileName.Location = new System.Drawing.Point(177, 44);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(82, 23);
            this.fileName.TabIndex = 1;
            this.fileName.Text = "noFile";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Yellow;
            this.label3.Font = new System.Drawing.Font("宋体", 12.18462F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(707, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "未优化";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.fileName);
            this.groupBox1.Location = new System.Drawing.Point(31, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(940, 135);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基础信息";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(181, 93);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(340, 24);
            this.comboBox1.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12.18462F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(34, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "优化方式:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.exit_button);
            this.groupBox2.Controls.Add(this.edit_button);
            this.groupBox2.Controls.Add(this.stop_button);
            this.groupBox2.Controls.Add(this.start_button);
            this.groupBox2.Controls.Add(this.Param_button);
            this.groupBox2.Controls.Add(this.check_button);
            this.groupBox2.Location = new System.Drawing.Point(999, 171);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 672);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "控制按钮";
            // 
            // exit_button
            // 
            this.exit_button.Location = new System.Drawing.Point(22, 567);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(157, 55);
            this.exit_button.TabIndex = 5;
            this.exit_button.Text = "退出窗口";
            this.exit_button.UseVisualStyleBackColor = true;
            // 
            // edit_button
            // 
            this.edit_button.Location = new System.Drawing.Point(22, 468);
            this.edit_button.Name = "edit_button";
            this.edit_button.Size = new System.Drawing.Size(157, 55);
            this.edit_button.TabIndex = 4;
            this.edit_button.Text = "编辑数据";
            this.edit_button.UseVisualStyleBackColor = true;
            // 
            // stop_button
            // 
            this.stop_button.Location = new System.Drawing.Point(22, 368);
            this.stop_button.Name = "stop_button";
            this.stop_button.Size = new System.Drawing.Size(157, 55);
            this.stop_button.TabIndex = 3;
            this.stop_button.Text = "停止优化";
            this.stop_button.UseVisualStyleBackColor = true;
            // 
            // start_button
            // 
            this.start_button.Location = new System.Drawing.Point(22, 263);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(157, 55);
            this.start_button.TabIndex = 2;
            this.start_button.Text = "开始优化";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // Param_button
            // 
            this.Param_button.Location = new System.Drawing.Point(22, 167);
            this.Param_button.Name = "Param_button";
            this.Param_button.Size = new System.Drawing.Size(157, 55);
            this.Param_button.TabIndex = 1;
            this.Param_button.Text = "优化参数设置";
            this.Param_button.UseVisualStyleBackColor = true;
            this.Param_button.Click += new System.EventHandler(this.Param_button_Click);
            // 
            // check_button
            // 
            this.check_button.Location = new System.Drawing.Point(22, 64);
            this.check_button.Name = "check_button";
            this.check_button.Size = new System.Drawing.Size(157, 55);
            this.check_button.TabIndex = 0;
            this.check_button.Text = "检查PCB数据";
            this.check_button.UseVisualStyleBackColor = true;
            this.check_button.Click += new System.EventHandler(this.check_button_Click);
            // 
            // form_Switch
            // 
            this.form_Switch.Location = new System.Drawing.Point(31, 171);
            this.form_Switch.Name = "form_Switch";
            this.form_Switch.Size = new System.Drawing.Size(940, 672);
            this.form_Switch.TabIndex = 5;
            this.form_Switch.TabStop = false;
            // 
            // DataAndOpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.form_Switch);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "DataAndOpt";
            this.Size = new System.Drawing.Size(1207, 868);
            this.Load += new System.EventHandler(this.DataAndOpt_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label fileName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.Button edit_button;
        private System.Windows.Forms.Button stop_button;
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.Button Param_button;
        private System.Windows.Forms.Button check_button;
        private System.Windows.Forms.GroupBox form_Switch;
    }
}

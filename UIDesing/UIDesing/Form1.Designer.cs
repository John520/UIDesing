namespace UIDesing
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
            this.fileWindow = new System.Windows.Forms.Button();
            this.funSwitch = new System.Windows.Forms.GroupBox();
            this.Manual = new System.Windows.Forms.Button();
            this.Autobutton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.icImagingControl1 = new TIS.Imaging.ICImagingControl();
            this.down_button = new System.Windows.Forms.Button();
            this.up_button = new System.Windows.Forms.Button();
            this.save_button = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icImagingControl1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileWindow
            // 
            this.fileWindow.Location = new System.Drawing.Point(28, 45);
            this.fileWindow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.fileWindow.Name = "fileWindow";
            this.fileWindow.Size = new System.Drawing.Size(70, 34);
            this.fileWindow.TabIndex = 0;
            this.fileWindow.Text = "数据编辑";
            this.fileWindow.UseVisualStyleBackColor = true;
            this.fileWindow.Click += new System.EventHandler(this.fileWindow_Click);
            // 
            // funSwitch
            // 
            this.funSwitch.Location = new System.Drawing.Point(4, 12);
            this.funSwitch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.funSwitch.Name = "funSwitch";
            this.funSwitch.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.funSwitch.Size = new System.Drawing.Size(905, 651);
            this.funSwitch.TabIndex = 4;
            this.funSwitch.TabStop = false;
            // 
            // Manual
            // 
            this.Manual.Location = new System.Drawing.Point(28, 129);
            this.Manual.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Manual.Name = "Manual";
            this.Manual.Size = new System.Drawing.Size(70, 34);
            this.Manual.TabIndex = 5;
            this.Manual.Text = "手动控制";
            this.Manual.UseVisualStyleBackColor = true;
            this.Manual.Click += new System.EventHandler(this.Manual_Click);
            // 
            // Autobutton
            // 
            this.Autobutton.Location = new System.Drawing.Point(28, 235);
            this.Autobutton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Autobutton.Name = "Autobutton";
            this.Autobutton.Size = new System.Drawing.Size(70, 34);
            this.Autobutton.TabIndex = 6;
            this.Autobutton.Text = "自动生产";
            this.Autobutton.UseVisualStyleBackColor = true;
            this.Autobutton.Click += new System.EventHandler(this.Autobutton_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(28, 343);
            this.button4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(70, 34);
            this.button4.TabIndex = 7;
            this.button4.Text = "辅助功能";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.fileWindow);
            this.groupBox2.Controls.Add(this.Autobutton);
            this.groupBox2.Controls.Add(this.Manual);
            this.groupBox2.Location = new System.Drawing.Point(928, 9);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(122, 675);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "功能选择";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.icImagingControl1);
            this.groupBox1.Controls.Add(this.down_button);
            this.groupBox1.Controls.Add(this.up_button);
            this.groupBox1.Controls.Add(this.save_button);
            this.groupBox1.Location = new System.Drawing.Point(1070, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(314, 388);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "图像显示";
            // 
            // icImagingControl1
            // 
            this.icImagingControl1.BackColor = System.Drawing.Color.White;
            this.icImagingControl1.DeviceListChangedExecutionMode = TIS.Imaging.EventExecutionMode.Invoke;
            this.icImagingControl1.DeviceLostExecutionMode = TIS.Imaging.EventExecutionMode.AsyncInvoke;
            this.icImagingControl1.ImageAvailableExecutionMode = TIS.Imaging.EventExecutionMode.MultiThreaded;
            this.icImagingControl1.LiveDisplayPosition = new System.Drawing.Point(0, 0);
            this.icImagingControl1.Location = new System.Drawing.Point(5, 20);
            this.icImagingControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.icImagingControl1.Name = "icImagingControl1";
            this.icImagingControl1.Size = new System.Drawing.Size(304, 315);
            this.icImagingControl1.TabIndex = 3;
            // 
            // down_button
            // 
            this.down_button.Location = new System.Drawing.Point(118, 351);
            this.down_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.down_button.Name = "down_button";
            this.down_button.Size = new System.Drawing.Size(67, 17);
            this.down_button.TabIndex = 2;
            this.down_button.Text = "切换下面";
            this.down_button.UseVisualStyleBackColor = true;
            this.down_button.Click += new System.EventHandler(this.down_button_Click);
            // 
            // up_button
            // 
            this.up_button.Location = new System.Drawing.Point(30, 351);
            this.up_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.up_button.Name = "up_button";
            this.up_button.Size = new System.Drawing.Size(67, 17);
            this.up_button.TabIndex = 1;
            this.up_button.Text = "切换上面";
            this.up_button.UseVisualStyleBackColor = true;
            this.up_button.Click += new System.EventHandler(this.up_button_Click);
            // 
            // save_button
            // 
            this.save_button.Location = new System.Drawing.Point(214, 351);
            this.save_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(56, 17);
            this.save_button.TabIndex = 0;
            this.save_button.Text = "存图";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(1070, 414);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(314, 270);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "示教按钮";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.funSwitch);
            this.groupBox4.Location = new System.Drawing.Point(9, 16);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Size = new System.Drawing.Size(914, 668);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "功能区";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 562);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.icImagingControl1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button fileWindow;
        private System.Windows.Forms.GroupBox funSwitch;
        private System.Windows.Forms.Button Manual;
        private System.Windows.Forms.Button Autobutton;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button save_button;
        private TIS.Imaging.ICImagingControl icImagingControl1;
        private System.Windows.Forms.Button down_button;
        private System.Windows.Forms.Button up_button;
    }
}


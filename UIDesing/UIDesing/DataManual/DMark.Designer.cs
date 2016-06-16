namespace UIDesing
{
    partial class DMark
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.remarks = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.zone = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.error = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.threshold = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ySize = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.xSize = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.reflectType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.shape = new System.Windows.Forms.ComboBox();
            this.templateFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.minMatch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.brightness = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.delete_button = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.save_button = new System.Windows.Forms.Button();
            this.new_button = new System.Windows.Forms.Button();
            this.exit_button = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(26, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(627, 706);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mark列表";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(621, 681);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Id";
            this.Column8.Name = "Column8";
            this.Column8.Visible = false;
            this.Column8.Width = 50;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "id";
            this.Column1.HeaderText = "编号";
            this.Column1.Name = "Column1";
            this.Column1.Width = 70;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Name";
            this.Column2.HeaderText = "名称";
            this.Column2.Name = "Column2";
            this.Column2.Width = 80;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Type";
            this.Column3.HeaderText = "Mark类型";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "X1";
            this.Column4.HeaderText = "X1";
            this.Column4.Name = "Column4";
            this.Column4.Width = 80;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Y1";
            this.Column5.HeaderText = "Y1";
            this.Column5.Name = "Column5";
            this.Column5.Width = 80;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "X2";
            this.Column6.HeaderText = "X2";
            this.Column6.Name = "Column6";
            this.Column6.Width = 80;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Y2";
            this.Column7.HeaderText = "Y2";
            this.Column7.Name = "Column7";
            this.Column7.Width = 80;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.remarks);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.zone);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.error);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.threshold);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.ySize);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.xSize);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.reflectType);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.shape);
            this.groupBox2.Controls.Add(this.templateFile);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.minMatch);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.brightness);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(676, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(269, 719);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "识别信息";
            // 
            // remarks
            // 
            this.remarks.Location = new System.Drawing.Point(25, 425);
            this.remarks.Multiline = true;
            this.remarks.Name = "remarks";
            this.remarks.Size = new System.Drawing.Size(206, 129);
            this.remarks.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(30, 406);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 16);
            this.label11.TabIndex = 20;
            this.label11.Text = "备注：";
            // 
            // zone
            // 
            this.zone.Location = new System.Drawing.Point(115, 358);
            this.zone.Name = "zone";
            this.zone.Size = new System.Drawing.Size(116, 26);
            this.zone.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 361);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 16);
            this.label10.TabIndex = 18;
            this.label10.Text = "搜索区域";
            // 
            // error
            // 
            this.error.Location = new System.Drawing.Point(115, 328);
            this.error.Name = "error";
            this.error.Size = new System.Drawing.Size(116, 26);
            this.error.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 331);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 16);
            this.label9.TabIndex = 16;
            this.label9.Text = "容许误差";
            // 
            // threshold
            // 
            this.threshold.Location = new System.Drawing.Point(115, 289);
            this.threshold.Name = "threshold";
            this.threshold.Size = new System.Drawing.Size(116, 26);
            this.threshold.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 292);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "二值化阀值";
            // 
            // ySize
            // 
            this.ySize.Location = new System.Drawing.Point(115, 255);
            this.ySize.Name = "ySize";
            this.ySize.Size = new System.Drawing.Size(116, 26);
            this.ySize.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 258);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Y方向尺寸";
            // 
            // xSize
            // 
            this.xSize.Location = new System.Drawing.Point(115, 221);
            this.xSize.Name = "xSize";
            this.xSize.Size = new System.Drawing.Size(116, 26);
            this.xSize.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "X方向尺寸";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "反光类型";
            // 
            // reflectType
            // 
            this.reflectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.reflectType.FormattingEnabled = true;
            this.reflectType.Items.AddRange(new object[] {
            "A",
            "B"});
            this.reflectType.Location = new System.Drawing.Point(115, 185);
            this.reflectType.Name = "reflectType";
            this.reflectType.Size = new System.Drawing.Size(116, 24);
            this.reflectType.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "轮廓形状";
            // 
            // shape
            // 
            this.shape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shape.FormattingEnabled = true;
            this.shape.Items.AddRange(new object[] {
            "a",
            "b",
            "c"});
            this.shape.Location = new System.Drawing.Point(115, 138);
            this.shape.Name = "shape";
            this.shape.Size = new System.Drawing.Size(116, 24);
            this.shape.TabIndex = 6;
            // 
            // templateFile
            // 
            this.templateFile.Location = new System.Drawing.Point(115, 106);
            this.templateFile.Name = "templateFile";
            this.templateFile.Size = new System.Drawing.Size(116, 26);
            this.templateFile.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "模板文件";
            // 
            // minMatch
            // 
            this.minMatch.Location = new System.Drawing.Point(115, 69);
            this.minMatch.Name = "minMatch";
            this.minMatch.Size = new System.Drawing.Size(116, 26);
            this.minMatch.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "最低匹配度";
            // 
            // brightness
            // 
            this.brightness.Location = new System.Drawing.Point(115, 30);
            this.brightness.Name = "brightness";
            this.brightness.Size = new System.Drawing.Size(116, 26);
            this.brightness.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "光源亮度";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.delete_button);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.save_button);
            this.groupBox3.Controls.Add(this.new_button);
            this.groupBox3.Controls.Add(this.exit_button);
            this.groupBox3.Location = new System.Drawing.Point(970, 45);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(160, 575);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "控制按钮";
            // 
            // delete_button
            // 
            this.delete_button.Location = new System.Drawing.Point(28, 408);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(108, 57);
            this.delete_button.TabIndex = 4;
            this.delete_button.Text = "删除";
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(28, 285);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(108, 64);
            this.button4.TabIndex = 3;
            this.button4.Text = "跟踪/示教";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // save_button
            // 
            this.save_button.Location = new System.Drawing.Point(28, 182);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(108, 64);
            this.save_button.TabIndex = 2;
            this.save_button.Text = "保存";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // new_button
            // 
            this.new_button.Location = new System.Drawing.Point(28, 58);
            this.new_button.Name = "new_button";
            this.new_button.Size = new System.Drawing.Size(108, 63);
            this.new_button.TabIndex = 1;
            this.new_button.Text = "新建";
            this.new_button.UseVisualStyleBackColor = true;
            this.new_button.Click += new System.EventHandler(this.new_button_Click);
            // 
            // exit_button
            // 
            this.exit_button.Location = new System.Drawing.Point(28, 501);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(108, 53);
            this.exit_button.TabIndex = 0;
            this.exit_button.Text = "退出";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // DMark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "DMark";
            this.Size = new System.Drawing.Size(1156, 797);
            this.Load += new System.EventHandler(this.DMark_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox brightness;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox zone;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox error;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox threshold;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ySize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox xSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox reflectType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox shape;
        private System.Windows.Forms.TextBox templateFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox minMatch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button new_button;
        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox remarks;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}

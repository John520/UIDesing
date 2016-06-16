using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIDesing.Optimize
{
    public partial class DataAndOpt : UserControl
    {
        public DataAndOpt()
        {
            InitializeComponent();
        }
        private void DataAndOpt_Load(object sender, EventArgs e)
        {
            this.fileName.Text = Program.fileNmae;
        }
        //显示数据编辑窗口函数，方便调用
        public void form_show(UserControl control)
        {
            //测试用于弹出数据文件管理窗口
            control.Show();
            form_Switch.Controls.Clear();
            form_Switch.Controls.Add(control);

        }

        private void check_button_Click(object sender, EventArgs e)
        {
            CheckData checkForm = new CheckData();
            form_show(checkForm);
        }

        private void Param_button_Click(object sender, EventArgs e)
        {
            ParamDesinger param = new ParamDesinger();
            form_show(param);
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            AfterOpt afterOpt = new AfterOpt();
            form_show(afterOpt);
        }

     
    }
}

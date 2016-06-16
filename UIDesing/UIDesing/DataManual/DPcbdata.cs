using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIDesing.dataSql;
using UIDesing.DataManual;
using UIDesing.util;
using UIDesing.dataSql.data;
namespace UIDesing
{
    public partial class DPcbdata : UserControl
    {
        private PCB_data pcb_data=new PCB_data();
        public DPcbdata()
        {
            InitializeComponent();
        }

        private void DPcbdata_Load(object sender, EventArgs e)
        {
            List<Object> pcb_list;
             //初始化显示
           if (Program.fileId != 0)
            {
                using (MyContext context = new MyContext())
                {
                    pcb_data=new PCB_data();
                    pcb_data.pcbId=-1;
                    pcb_list = context.get(Program.fileId, pcb_data);
                }    
              if (pcb_list.Count!=0)
                {
                  PCB_data temp = (PCB_data)pcb_list[0];       
                  //加载显示
                  data_load(temp);
                  pcb_data.pcbId = temp.pcbId;
              }
            }
            
        }
        //保存
        private void save_button_Click(object sender, EventArgs e)
        {
            try
            {
            data_upload(pcb_data);
            using (MyContext context = new MyContext())
            {
                context.save(Program.fileId, pcb_data);
            }
            }
            catch (TypeErrorException exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        //退出
        private void exit_button_Click(object sender, EventArgs e)
        {
            Is_save is_saveForm = new Is_save();
            DialogResult reslut = is_saveForm.ShowDialog();
            if (reslut == DialogResult.OK)
            {
                //保存操作
                save_button_Click(sender, e);
            }
            //测试用于弹出数据文件管理窗口
            FileAdmin fileAdmin = new FileAdmin();
            Program.form1.form_show(fileAdmin);
        }
        /*
         * 输入:pcb_data对象
         * 将数据加载到ui显示，对pcb_data对象进行显示
         * 
         */
        private void data_load(PCB_data pcb_data)
        {
            //长度信息的封装
            this.length.Text = Convert.ToString(pcb_data.Length);
            this.width.Text = Convert.ToString(pcb_data.Width);
            this.high.Text = Convert.ToString(pcb_data.Thickness);
            //位置信息
            this.X.Text = Convert.ToString(pcb_data.X);
            this.Y.Text = Convert.ToString(pcb_data.Y);
            //信息显示
            this.fulfll_num.Text = Convert.ToString(pcb_data.FinishedNum);
            this.remark.Text = pcb_data.Describe;
            //操作信息
            this.method.SelectedIndex=pcb_data.Clamp;
            this.speend.SelectedIndex = pcb_data.Speed;
            this.MaxNum.Text = Convert.ToString(pcb_data.MaxNum);
        }
        /*
         * 输入:pcb_data对象
         * 将UI数据加载到数据库中
         * 
         */
        private void data_upload(PCB_data pcb_data)
        {
            string exText = "长度";
            try
            {         
            //长度信息的封装
            pcb_data.Length = (float)TypeChange.stringToFloat(this.length.Text);
            exText = "宽度";
            pcb_data.Width = (float)TypeChange.stringToFloat(this.width.Text);
            exText = "高度";
            pcb_data.Thickness = (float)TypeChange.stringToFloat(this.high.Text);
            //位置信息
            pcb_data.X = (float)TypeChange.stringToFloat(this.X.Text);
            pcb_data.Y = (float)TypeChange.stringToFloat(this.Y.Text);
            //信息显示
            pcb_data.FinishedNum = (int)TypeChange.stringToInt(this.fulfll_num.Text);
            pcb_data.Describe = TypeChange.stringToString((String)this.remark.Text);
            //操作信息           
             pcb_data.Clamp=TypeChange.combSelected(this.method.SelectedIndex);
             pcb_data.Speed=TypeChange.combSelected(this.speend.SelectedIndex);
             exText = "最大补料次数";
             pcb_data.MaxNum = TypeChange.stringToInt(this.MaxNum.Text);
            }
            catch (TypeErrorException exp)
            {
                throw new TypeErrorException(exText + "为" + exp.Message);
            }
        }

        
    }
}

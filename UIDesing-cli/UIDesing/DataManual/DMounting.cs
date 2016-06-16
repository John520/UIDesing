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
using UIDesing.dataSql.data;
using UIDesing.util;
namespace UIDesing
{
   
    public partial class DMounting : UserControl
    {
        private Plug_data plug_data = new Plug_data();
        private Cate_data cate = new Cate_data();
        public DMounting()
        {
            InitializeComponent();
        }
        private void DMounting_Load(object sender, EventArgs e)
        { 
            List<Object> plugs;
            List<Object> cates;

             using (MyContext context = new MyContext())
            {
                plug_data.id = -1;
                plugs = context.get(Program.fileId, plug_data);
                 cate.id=-1;
                cates = context.get(Program.fileId,cate);
            }
             if (cates != null)
             {
                                 
                this.Column3.DataSource =cates;//必须在设置dataGridView1的DataSource的属性前设置
                this.Column3.DisplayMember = "CateName";
                 
             }
            foreach (Plug_data plug_data in plugs)
            {
                //调用显示函数
                toDataView(plug_data);
            }
  
        }
        //实时更新数据库
        private void dataGridView1_cellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            save_button_Click(sender,null);
        }
        //新建
        private void new_button_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Add();
            //调用数据库增加一行空数据
        }
        //保存
        private void save_button_Click(object sender, EventArgs e)
        {
             try
            {
            if (this.dataGridView1.CurrentRow.Cells[0].Value == null)
            {                
                data_upload(plug_data);
                plug_data.id = -1;
                using (MyContext context = new MyContext())
                {  
                   plug_data.id = context.save(Program.fileId, plug_data);                 
                }

            }
            else
            {
                plug_data.id = (int)this.dataGridView1.CurrentRow.Cells[0].Value;
                data_upload(plug_data);
                using (MyContext context = new MyContext())
                {
                    context.save(Program.fileId, plug_data);
                }
            }
            this.dataGridView1.CurrentRow.Cells[0].Value = plug_data.id;
            }
           catch (MyException exc)
             {
                 MessageBox.Show("请写出存在的分类名");
             }
             catch (TypeErrorException exp)
             {
                 MessageBox.Show(exp.Message);
             }
        }
       
        //删除
        private void delete_button_Click(object sender, EventArgs e)
        {
            try
            {
            if (this.dataGridView1.CurrentRow != null)
            {
                //删除对应数据库中的数据
                if (this.dataGridView1.CurrentRow.Cells[0].Value != null)
                {
                    plug_data.id = (int)this.dataGridView1.CurrentRow.Cells[0].Value;
                    data_upload(plug_data);
                    using (MyContext context = new MyContext())
                    {
                        context.delete(Program.fileId, plug_data);
                    }
                }
                this.dataGridView1.Rows.Remove(this.dataGridView1.CurrentRow);
            }
            }
             catch (MyException exc)
             {
                 MessageBox.Show("请写出存在的分类名");
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
       * 输入:plug对象
       * 将UI数据加载到数据库中
       * 
       */
        private void data_upload(Plug_data plug_data)
        {
            int index = 1;
            try
            {
            //上料信息保存
            plug_data.id = TypeChange.stringToId(Convert.ToString(this.dataGridView1.CurrentRow.Cells[0].Value));
            plug_data.PlugId = TypeChange.stringToInt(Convert.ToString(this.dataGridView1.CurrentRow.Cells[1].Value));
            index = 2;
            plug_data.Name = TypeChange.stringToStrignAndThrow((String)this.dataGridView1.CurrentRow.Cells[2].Value);
            index = 3;
            plug_data.CateName = TypeChange.stringToStrignAndThrow((String)this.dataGridView1.CurrentRow.Cells[3].Value);
            index = 4;
            plug_data.X= TypeChange.stringToFloat(Convert.ToString(this.dataGridView1.CurrentRow.Cells[4].Value));
            index = 5;
            plug_data.Y = TypeChange.stringToFloat(Convert.ToString(this.dataGridView1.CurrentRow.Cells[5].Value));
            index = 6;
            plug_data.Z = TypeChange.stringToFloat(Convert.ToString(this.dataGridView1.CurrentRow.Cells[6].Value));
            index = 7;
            plug_data.U = TypeChange.stringToFloat(Convert.ToString(this.dataGridView1.CurrentRow.Cells[7].Value));
           
            //是否插件的判断，使用的是下拉框
            string isplug= TypeChange.stringToStrignAndThrow((String)this.dataGridView1.CurrentRow.Cells[9].Value);
            index = 9;
            if ("true".Equals(isplug))
                plug_data.IsPlug = true;
            else
                plug_data.IsPlug = false;         
            }
            catch (TypeErrorException exp)
            {
                throw new TypeErrorException(this.dataGridView1.Columns[index].HeaderText + "为" + exp.Message);
            }     
        }
        //将数据转化为行显示
        private void toDataView(Plug_data plug_data)
        {
            Object[] row = new Object[12];
            row[0] = plug_data.id;
            row[1] = plug_data.PlugId;
            row[2] = plug_data.Name;
            row[3] = plug_data.CateName;
            row[4] = plug_data.X;
            row[5] =plug_data.Y;
            row[6] = plug_data.Z;
            row[7] = plug_data.U;
            row[8] = plug_data.FeedId;
            if (plug_data.IsPlug)
                row[9] = "true";
            else
                row[9] = "false";

            row[10] = plug_data.PlugHeadId;
            row[11] = plug_data.CartridgeNum;
            this.dataGridView1.Rows.Add(row);
        }
       
    }
}

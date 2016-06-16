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
    public partial class DMark : UserControl
    {
        private Mark_data mark_data = new Mark_data();
        public DMark()
        {
            InitializeComponent();
        }
        
        private void DMark_Load(object sender, EventArgs e)
        {
            List<Object> marks;
            using (MyContext context = new MyContext())
            {
                mark_data.id = -1;
                marks = context.get(Program.fileId,mark_data);
            }
            foreach (Mark_data mark_data in marks)
            {
                //调用显示函数
                toDataView(mark_data);
            }  
            //右边显示
            if (this.dataGridView1.CurrentRow!=null&&this.dataGridView1.CurrentRow.Cells[0].Value != null)
           {
               mark_data.id = (int)this.dataGridView1.CurrentRow.Cells[0].Value;
               using (MyContext context = new MyContext())
               {         
                   marks = context.get(Program.fileId, mark_data);
               }
             
               if (marks != null)
               {
                   data_load((Mark_data)marks[0]);
               }
           }
      
        }
        //实时更新数据库
        private void dataGridView1_cellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            save_button_Click(sender, null);
        }
        //右边保存事件
        private void groupBox_Leave(object sender, EventArgs e){
            if (this.dataGridView1.CurrentRow.Cells[0].Value != null)
            {

                mark_data.id = (int)this.dataGridView1.CurrentRow.Cells[0].Value;
                data_upload(mark_data);
                using (MyContext context = new MyContext())
                {
                    context.save(Program.fileId, mark_data);
                }

            }
        }
        //每当单击一行时，右边显示变换：
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            List<Object> marks;
            //右边显示
            if (this.dataGridView1.CurrentRow.Cells[0].Value != null)
            {
                mark_data.id = (int)this.dataGridView1.CurrentRow.Cells[0].Value;
                using (MyContext context = new MyContext())
                {
                    marks = context.get(Program.fileId, mark_data);
                }

                if (marks != null)
                {
                    data_load((Mark_data)marks[0]);
                }
            }
        }
        //新建
        private void new_button_Click(object sender, EventArgs e)
        {
            //左边新增加一行
            this.dataGridView1.Rows.Add();
            //右边显示空白
            Mark_data mark_data = new Mark_data();
            mark_data.ReflectType = -1;
            mark_data.Shape = -1;
            data_load(mark_data);
           
        }
        //保存  怎样设计
        private void save_button_Click(object sender, EventArgs e)
        {
             try
            {
            if (this.dataGridView1.CurrentRow.Cells[0].Value == null)
            {
               
                data_upload(mark_data);
                mark_data.id = -1;
                using (MyContext context = new MyContext())
                {
                   mark_data.id = context.save(Program.fileId, mark_data);

                }

            }
            else
            {
                mark_data.id = (int)this.dataGridView1.CurrentRow.Cells[0].Value;
                data_upload(mark_data);
                using (MyContext context = new MyContext())
                {
                    context.save(Program.fileId, mark_data);
                }
            }
            this.dataGridView1.CurrentRow.Cells[0].Value = mark_data.id;
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
                   
                    data_upload(mark_data);
                    using (MyContext context = new MyContext())
                    {
                        context.delete(Program.fileId, mark_data);

                    }

                }
                this.dataGridView1.Rows.Remove(this.dataGridView1.CurrentRow);

            }
            }
             catch (TypeErrorException exp)
             {
                 MessageBox.Show(exp.Message);
             }
        }
        //退出按钮
        private void exit_button_Click(object sender, EventArgs e)
        {
            Is_save is_saveForm = new Is_save();
            DialogResult reslut = is_saveForm.ShowDialog();
            if (reslut == DialogResult.OK)
            {
                //保存操作
                save_button_Click(sender,e);
            }
            //测试用于弹出数据文件管理窗口
            FileAdmin fileAdmin = new FileAdmin();
            Program.form1.form_show(fileAdmin);
        }
         /*
          * 输入:list[i]  mark对象
          * 将数据加载到ui显示，通过从list中获得指定的Mark对象进行显示
          * 
          */
        private void data_load(Mark_data mark_data)
        {
            //识别信息
            this.brightness.Text = Convert.ToString(mark_data.Brightness);
            this.minMatch.Text = Convert.ToString(mark_data.MinMatch);
            this.templateFile.Text = mark_data.TemplateFile;
            this.shape.SelectedIndex =mark_data.Shape;
            this.reflectType.SelectedIndex = mark_data.ReflectType;
            this.xSize.Text = Convert.ToString(mark_data.XSize);
            this.ySize.Text = Convert.ToString(mark_data.YSize);
            this.threshold.Text =Convert.ToString( mark_data.Threshold);
            this.error.Text = Convert.ToString(mark_data.Error);
            this.zone.Text = Convert.ToString(mark_data.Zone);
            this.remarks.Text = mark_data.Remarks;
        }
        /*
          * 输入:list[i]  mark对象
          * 将UI数据加载到数据库中
          * 
          */
        private void data_upload(Mark_data mark_data)
        {
            string exText = "光源亮度";
            try
            {   
            //识别信息
            mark_data.Brightness = TypeChange.stringToInt(this.brightness.Text);
            exText = "最低匹配度";
            mark_data.MinMatch = TypeChange.stringToInt(this.minMatch.Text);
            mark_data.TemplateFile = TypeChange.stringToString((String)this.templateFile.Text);
            mark_data.Shape = TypeChange.combSelected(this.shape.SelectedIndex);
            mark_data.ReflectType = TypeChange.combSelected(this.reflectType.SelectedIndex);
            exText = "X方向尺寸";
            mark_data.XSize =  TypeChange.stringToFloat(this.xSize.Text);
            exText = "Y方向尺寸";
            mark_data.YSize = TypeChange.stringToFloat(this.ySize.Text);
            exText = "二值化阀值";
            mark_data.Threshold = TypeChange.stringToInt(this.threshold.Text );
            exText = "容许错误";
            mark_data.Error = TypeChange.stringToInt(this.error.Text );
            exText = "搜索区域";
            mark_data.Zone = TypeChange.stringToFloat(this.zone.Text );
            mark_data.Remarks = TypeChange.stringToString((String)this.remarks.Text);
            }
            catch (TypeErrorException exp)
            {
                throw new TypeErrorException(exText + "为" + exp.Message);
            }
           int index = 1;
            try
            {
            //mark列表信息
            mark_data.id = TypeChange.stringToId(Convert.ToString(this.dataGridView1.CurrentRow.Cells[0].Value));
            mark_data.MarkId = TypeChange.stringToInt(Convert.ToString(this.dataGridView1.CurrentRow.Cells[1].Value));
            index = 2;
            mark_data.Name = TypeChange.stringToStrignAndThrow((String)this.dataGridView1.CurrentRow.Cells[2].Value);
            index = 3;
            mark_data.Type = TypeChange.stringToInt(Convert.ToString(this.dataGridView1.CurrentRow.Cells[3].Value));
            index = 4;
            mark_data.X1 = TypeChange.stringToFloat(Convert.ToString(this.dataGridView1.CurrentRow.Cells[4].Value));
            index = 5;
            mark_data.Y1 = TypeChange.stringToFloat(Convert.ToString(this.dataGridView1.CurrentRow.Cells[5].Value));
            index = 6;
            mark_data.X2 = TypeChange.stringToFloat(Convert.ToString(this.dataGridView1.CurrentRow.Cells[6].Value));
            index = 7;
            mark_data.Y2 = TypeChange.stringToFloat(Convert.ToString(this.dataGridView1.CurrentRow.Cells[7].Value));
            }
            catch (TypeErrorException exp)
            {
                throw new TypeErrorException(this.dataGridView1.Columns[index].HeaderText + "为" + exp.Message);
            }     
        }
        //将数据转化为行显示
        private void toDataView(Mark_data mark_data)
        {
            Object[] row = new Object[8];
            row[0] = mark_data.id;
            row[1] = mark_data.MarkId;
            row[2] = mark_data.Name;
            row[3] = mark_data.Type;
            row[4] = mark_data.X1;
            row[5] = mark_data.Y1;
            row[6] = mark_data.X2;
            row[7] = mark_data.Y2;
            this.dataGridView1.Rows.Add(row);
        }     
    }
}

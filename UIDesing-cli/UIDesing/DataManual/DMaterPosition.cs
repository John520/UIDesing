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
    public partial class DMaterPosition : UserControl
    {
        private Feed_data feed_data = new Feed_data();
        private Cate_data cate = new Cate_data();
        public DMaterPosition()
        {
            InitializeComponent();
        }
        private void DMaterPosition_Load(object sender, EventArgs e)
        {
            List<Object> feeds;
            List<Object> cates;
            using (MyContext context = new MyContext())
            {
                feed_data.id = -1;
                feeds = context.get(Program.fileId, feed_data);
                cate.id = -1;
                cates = context.get(Program.fileId, cate);
            }
            if (cates != null)
            {

                this.Column2.DataSource = cates;//必须在设置dataGridView1的DataSource的属性前设置
                this.Column2.DisplayMember = "CateName";

            }
            foreach (Feed_data feed_data in feeds)
            {
                //调用显示函数
                toDataView(feed_data);
            }  
        }
        //实时更新数据库
        private void dataGridView1_cellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            save_button_Click(sender, null);
        }
        //新建
        private void new_button_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Add();
            //调用数据库增加一行空数据
        }
        //保存按钮  待设计
        private void save_button_Click(object sender, EventArgs e)
        {
              try
            {
            if (this.dataGridView1.CurrentRow.Cells[0].Value == null)
            {

                data_upload(feed_data);
                feed_data.id = -1;
                using (MyContext context = new MyContext())
                {
                    feed_data.id = context.save(Program.fileId, feed_data);

                }

            }
            else
            {
                feed_data.id = (int)this.dataGridView1.CurrentRow.Cells[0].Value;
                data_upload(feed_data);
                using (MyContext context = new MyContext())
                {
                    context.save(Program.fileId, feed_data);
                }
            }
            this.dataGridView1.CurrentRow.Cells[0].Value = feed_data.id;
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
                    feed_data.id = (int)this.dataGridView1.CurrentRow.Cells[0].Value;
                    data_upload(feed_data);
                    using (MyContext context = new MyContext())
                    {
                        context.delete(Program.fileId, feed_data);
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
        * 输入:feed对象
        * 将UI数据加载到数据库中
        * 
        */
        private void data_upload(Feed_data feed_data)
        {
            int index = 1;
            try
            {
            //上料信息保存
            feed_data.id = TypeChange.stringToId(Convert.ToString(this.dataGridView1.CurrentRow.Cells[0].Value));
            feed_data.FeedId = TypeChange.stringToInt(Convert.ToString(this.dataGridView1.CurrentRow.Cells[1].Value));
            index = 2;
            feed_data.FeedComp = TypeChange.stringToStrignAndThrow((String)this.dataGridView1.CurrentRow.Cells[2].Value);
            /*index = 3;
            feed_data.PickPointX = TypeChange.stringToFloat(Convert.ToString(this.dataGridView1.CurrentRow.Cells[3].Value));
            index = 4;
            feed_data.PickPointY = TypeChange.stringToFloat(Convert.ToString(this.dataGridView1.CurrentRow.Cells[4].Value));
            index = 5;
            feed_data.PickPointZ = TypeChange.stringToFloat(Convert.ToString(this.dataGridView1.CurrentRow.Cells[5].Value));*/
            feed_data.PickPointX = 1.1f;
            feed_data.PickPointY = 1.1f;
            feed_data.PickPointZ = 1.1f;
            index = 6;
            feed_data.UDegree = TypeChange.stringToFloat(Convert.ToString(this.dataGridView1.CurrentRow.Cells[6].Value));

            index = 7;
             string isUsed = TypeChange.stringToStrignAndThrow((String)this.dataGridView1.CurrentRow.Cells[7].Value);
             if ("true".Equals(isUsed))
                feed_data .IsUsed = true;
            else
               feed_data .IsUsed = false;   
        
            }
            catch (TypeErrorException exp)
            {
                throw new TypeErrorException(this.dataGridView1.Columns[index].HeaderText + "为" + exp.Message);
            }     
        }
        //将数据转化为行显示
        private void toDataView(Feed_data feed_data)
        {
            Object[] row = new Object[8];
            row[0] = feed_data.id;
            row[1] = feed_data.FeedId.ToString();
            row[2] = feed_data.FeedComp;
            row[3] = feed_data.PickPointX;
            row[4] = feed_data.PickPointY;
            row[5] = feed_data.PickPointZ;
            row[6] = feed_data.UDegree;
            row[7] = feed_data.IsUsed;
            if (feed_data.IsUsed)
                row[7] = "true";
            else
                row[7] = "false";
            this.dataGridView1.Rows.Add(row);
        }

       
    }
}

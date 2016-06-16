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
using UIDesing.dataSql.data;
using System.Data.Entity;
using UIDesing.util;
using UIDesing.Optimize;
namespace UIDesing
{
    public partial class FileAdmin : UserControl
    {
        public FileAdmin()
        {
            InitializeComponent();
        }
        /**
         * 初始化显示
         */
        private void FileAdmin_Load(object sender, EventArgs e)
        {
            List<Object> files;
            using(MyContext context=new MyContext()){
                files = context.get(0, new File_data());
            }           
            foreach (File_data file_data in files)
            {
               //调用显示函数
                toDataView(file_data);
           }
        }
        //实时更新数据库
        private void dataGridView1_cellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                File_data file_data = new File_data();
                data_upload(file_data);
                using (MyContext context = new MyContext())
                {
                    context.Database.CreateIfNotExists();
                    context.save(file_data.FileId, file_data);
                }
            }
            catch (TypeErrorException exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
        //新建数据文件
        private void newButton_Click(object sender, EventArgs e)
        {
            ////新建对话框
            File_data file_data = new File_data();
            ////获得filedata对象
            File_oper file_oper = new File_oper(file_data);
            DialogResult reslut = file_oper.ShowDialog();
            if (reslut == DialogResult.OK)
             {
                   file_data.CreateTime = DateTime.Now;
                   using (MyContext context = new MyContext())
                   {
                       context.Database.CreateIfNotExists();
                       context.save(0,file_data);
                   }
                   //实时显示
                   toDataView(file_data);        
           }
            
        }
        /*
         * 打开文件名
         */
        private void openbutton_Click(object sender, EventArgs e)
        {
             //数据库名获取
            if (this.dataGridView1.CurrentRow.Cells[0].Value != null)
            {
               Program.fileId = TypeChange.stringToInt(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
               DFileOpt dfileOpt = new DFileOpt();
               Program.form1.form_show(dfileOpt);
           }
        }
        private void optimize_button_Click(object sender, EventArgs e)
        {
            //数据库名获取
            if (this.dataGridView1.CurrentRow.Cells[0].Value != null)
            {
                Program.fileId = TypeChange.stringToInt(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                Program.fileNmae = Convert.ToString(this.dataGridView1.CurrentRow.Cells[1].Value);
                DataAndOpt dataAndOpt = new DataAndOpt();
                Program.form1.form_show(dataAndOpt);
            }
        }
        /**
         * 删除
         */
        private void delete_button_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentRow.Cells[0].Value != null)
            {

                int fileId = (int)this.dataGridView1.CurrentRow.Cells[0].Value;
                using (MyContext context = new MyContext())
                {
                    context.Database.CreateIfNotExists();
                    context.delete(fileId, null);
                }
                //删除对应数据库中的数据
                this.dataGridView1.Rows.Remove(this.dataGridView1.CurrentRow);
            }
        }
         /*
       * 输入:filedata
       * 将UI数据加载到数据库中
       * 
       */
        private void data_upload(File_data file_data)
        {
            int index = 1;
            try
            {
                file_data.FileId = (int)this.dataGridView1.CurrentRow.Cells[0].Value;
                file_data.FileName = TypeChange.stringToStrignAndThrow((String)this.dataGridView1.CurrentRow.Cells[1].Value);
                if (this.dataGridView1.CurrentRow.Cells[2].Value != null)
                    file_data.CreateTime = (DateTime)this.dataGridView1.CurrentRow.Cells[2].Value;
                file_data.ModifiedTime = DateTime.Now;
                index = 5;
                file_data.User = TypeChange.stringToStrignAndThrow((String)this.dataGridView1.CurrentRow.Cells[5].Value);
                file_data.Remark = TypeChange.stringToString((String)this.dataGridView1.CurrentRow.Cells[6].Value);
            }
            catch (TypeErrorException exp)
            {
                throw new TypeErrorException(this.dataGridView1.Columns[index].HeaderText + "为" + exp.Message);
            }      
        }
        //将数据转化为行显示
        private void  toDataView(File_data file_data)
        {
           Object[] row =new Object[7];
            row[0]=file_data.FileId;
            row[1] = file_data.FileName;
            row[2] = file_data.CreateTime;
            row[3] = file_data.ModifiedTime;
            row[4] = file_data.ProduceTime;
            row[5] = file_data.User;
            row[6] = file_data.Remark;
            this.dataGridView1.Rows.Add(row);
        }

      
    }
}

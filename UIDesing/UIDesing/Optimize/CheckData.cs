using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIDesing.dataSql.data;
using UIDesing.dataSql;

namespace UIDesing.Optimize
{
    public partial class CheckData : UserControl
    {
        public CheckData()
        {
            InitializeComponent();
        }

        private void CheckData_Load(object sender, EventArgs e)
        {
            List<Object> lists;
            using(MyContext context=new MyContext())
            {
                //pcb文件检测
                PCB_data pcb_data = new PCB_data();
                pcb_data.pcbId = -1;
                lists = context.get(Program.fileId,pcb_data);
                check(lists,"PCB");
                //插件文件数据检测
                Plug_data plug_data = new Plug_data();
                plug_data.id = -1;
                lists = context.get(Program.fileId, plug_data);
                check(lists,"插件数据");
                //分类数据文件检测
                Cate_data cate_data = new Cate_data();
                cate_data.id = -1;
                lists = context.get(Program.fileId, cate_data);
                check(lists, "分类数据");
                //Mark数据文件检测
                Mark_data mark_data = new Mark_data();
                mark_data.id = -1;
                lists = context.get(Program.fileId, mark_data);
                check(lists,"mark数据");
                //上料数据文件检测
                Feed_data feed_data = new Feed_data();
                feed_data.id = -1;
                lists = context.get(Program.fileId, feed_data);
                check(lists, "上料数据");
            }

        }
        private void check(List<Object> lists,String  name)
        {
          
            if (lists != null && lists.Count >= 1)
            {

                this.isfull.AppendText(name+"文件数据完整---------------->OK\n");
            }
            else
            {
                this.isfull.AppendText(name+"文件数据不完---------------->Error\n");
            }
        }
    }
}

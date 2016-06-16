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
using System.Threading;

namespace UIDesing
{
    public partial class AutoPage : UserControl
    {
        public AutoPage()
        {
            InitializeComponent();
        }

        private void AutoPage_Load(object sender, EventArgs e)
        {
            List<Object> files;
            using (MyContext context = new MyContext())
            {
                files = context.get(0, new File_data());
            }
            //数据源的绑定
             if(files!=null)
            {
               
                this.comboBox1.DataSource = files;
                this.comboBox1.DisplayMember = "FileName";
            }

        }

        private void start_button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("peace1");
            //加载数据
            //配置本次的生产信息
          
            Thread thread = new Thread(product_thread);
            thread.IsBackground = true;
            thread.Start();
        }

        private void kill_button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("peace2");
        }



        //生产线程
        /*
         *  Abort():通常使用该方法来终止一个线程 
         *  Suspend()：该方法并不终止未完成的线程，它仅仅挂起线程
         *  Resume():恢复被Suspend()方法挂起的线程
         */
        private void product_thread()
        {
            //送入并固定PCB板
            //完成检测PCB是否到位
            while (true)
            {
                
                //拾取元件--和插装
                //更新生产信息
            }
        }
      
    }
}

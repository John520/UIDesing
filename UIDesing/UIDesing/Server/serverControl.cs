using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace UIDesing
{
    public partial class serverControl : UserControl
    {
        public serverControl()
        {
            InitializeComponent();
        }
        delegate void  setMessageCallBack(string s);//用于显示服务器状态
        delegate void  setTableCallBack(Hashtable h);//用于显示全部连接信息
     

        myServer mysvr;

        public void showLinkTable(Hashtable h)
        {
            try
            {
                if (this.dataGridView1.InvokeRequired)
                {
                    setTableCallBack d = new setTableCallBack(showLinkTable);
                    this.Invoke(d, new object[] { h });
                }
                else
                {
                    this.dataGridView1.Rows.Clear();
                    foreach (DictionaryEntry d in h)
                    {
                        Object[] row = new Object[2];
                        row[0] = d.Key;
                        row[1] = d.Value;
                        this.dataGridView1.Rows.Add(row);
                    }

                }

            }
            catch { }
        }
        public void showStatus(string s)
        {
            try
            {
                if (this.statusLabel.InvokeRequired)
                {
                    setMessageCallBack d = new setMessageCallBack(showStatus);
                    this.Invoke(d, new object[] { s });
                }
                else
                {
                    this.statusLabel.Text = s;
                }

            }
            catch { }
        }

        private void startbutton_Click(object sender, EventArgs e)
        {
            mysvr.Port = (short)Convert.ToUInt16(this.portTextBox.Text);
            mysvr.start();
        }

        private void serverControl_Load(object sender, EventArgs e)
        {
             mysvr = new myServer(this);
        }

        private void stopbutton_Click(object sender, EventArgs e)
        {
            mysvr.stop();
        }

       
      
    }
}

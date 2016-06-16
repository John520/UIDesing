using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIDesing.Client
{

    
    public partial class clientControl : UserControl
    {
        public clientControl()
        {
            InitializeComponent();
        }
        mycli client;
       delegate void  setMessageCallBack(string s);//用于显示服务器状态
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

       private void clientControl_Load(object sender, EventArgs e)
       {
           client = new mycli(this);
       }

       private void startButton_Click(object sender, EventArgs e)
       {
           client.IP =IP.Text;
           client.Port = Convert.ToInt16(port.Text);
           client.start();
       }

       private void sendButton_Click(object sender, EventArgs e)
       {

       }

       private void stopButton_Click(object sender, EventArgs e)
       {
           client.stop();
       }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIDesing.Client
{
    class mycli:baseClient
    {
       
        private clientControl clientControl;
        

        public mycli(clientControl clientControl)
            : base()
        {
            // TODO: Complete member initialization
            this.clientControl = clientControl;
        }
        public override bool start()
        {
            if (base.start())
            {
                clientControl.showStatus("正在运行...");
                return true;
            }
            else
            {
                clientControl.showStatus("出错了");
                return false;
            }
        }
        public override bool stop()
        {
            if (base.stop())
            {
                clientControl.showStatus("停止");
                return true;
            }
            else
            {
                clientControl.showStatus("出错了");
                return false;
            }
        }
        public override void dataRcv(byte[] rcvdata)
        {
            throw new NotImplementedException();
        }

    }
}

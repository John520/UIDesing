using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIDesing.dataSql;
namespace UIDesing
{
    class myServer:baseServer
    {
        serverControl sControl;

      public  myServer(short port, serverControl usercontrol)
            : base(port)
        {
            this.sControl = usercontrol;
        }
      public  myServer(serverControl usercontrol)
          : base()
        {
            this.sControl = usercontrol;
        }
        public override bool start() {
            if (base.start()) { 
            sControl.showStatus("正在运行...");
            return true;
            }
            else {
                sControl.showStatus("出错了");
                return false;
            }
        }
        public override bool stop()
        {
            if (base.stop())
            {
                sControl.showStatus("停止");
                return true;
            }
            else
            {
                sControl.showStatus("出错了");
                return false;
            }
        }
        public override void dataRcv(TCPPacketBuffer buffer)
        {
            String jsonStr = Encoding.Unicode.GetString(buffer.data, 0, buffer.dataLength); ;
           File_data fdata= UIDesing.util.JsonUtil.JsonHelper.DeserializeJsonToObject<File_data>(jsonStr);

        }
        public override void showlink()
        {
            sControl.showLinkTable(this.LinkTable);
        }
    }
}

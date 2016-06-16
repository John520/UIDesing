using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIDesing
{
    public partial class DFileOpt : UserControl
    {
        
        
        public DFileOpt()
        {
           
            InitializeComponent();
        }


        private void DFileOpt_Load(object sender, EventArgs e)
        {
            //Pcb数据
            DPcbdata dPcbdata = new DPcbdata();
            pcbPage.Controls.Add(dPcbdata);    
            //元件分类
            DClassify dClassify = new DClassify();
            classifyPage.Controls.Add(dClassify);
            //上料数据：
            DMaterPosition materPos = new DMaterPosition();
            materPage.Controls.Add(materPos);
            //元件插装
            DMounting dMounting = new DMounting();
            mountingPage.Controls.Add(dMounting);
            //Mark点数据
            DMark dMark = new DMark();
            markPage.Controls.Add(dMark);
        }
    }
}

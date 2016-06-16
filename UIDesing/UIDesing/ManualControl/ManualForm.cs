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
    public partial class ManualForm : UserControl
    {
        public ManualForm()
        {
            InitializeComponent();
        }


        private void ManualForm_Load(object sender, EventArgs e)
        {
            //手动控制
            ManualPage manualPage=new ManualPage();
            manPage.Controls.Add(manualPage); 
        }
    }
}

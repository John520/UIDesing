using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIDesing.Optimize
{
    
    public partial class ParamDesinger : UserControl
    {
        public static List<int> headAndGroup;

        public ParamDesinger()
        {
            InitializeComponent();
        }

        private void confirm_button_Click(object sender, EventArgs e)
        {
            headAndGroup = new List<int>();
            if (this.tz1.Checked)
            {
                headAndGroup.Add(xz1.SelectedIndex);
            }
            if (this.tz2.Checked)
            {
                headAndGroup.Add(xz2.SelectedIndex);
            }
            if (this.tz3.Checked)
            {
                headAndGroup.Add(xz3.SelectedIndex);
            }
            if (this.tz4.Checked)
            {
                headAndGroup.Add(xz4.SelectedIndex);
            }

        }

        private void exit_button_Click(object sender, EventArgs e)
        {

        }
    }
}

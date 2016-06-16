using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIDesing.dataSql;
using UIDesing.util;

namespace UIDesing
{
    public partial class File_oper : Form
    {
        private File_data file_data;
        public File_oper(File_data file_data)
        {
            InitializeComponent();
            this.file_data = file_data;
        }

        private void save_Click(object sender, EventArgs e)
        {
            TextBox exText = this.fname;
            try
            {                
                this.file_data.FileName = TypeChange.stringToStrignAndThrow(fname.Text);
                exText = this.fuser;
                this.file_data.User = TypeChange.stringToStrignAndThrow(fuser.Text);           
                this.file_data.Remark = TypeChange.stringToString(fremark.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }catch(TypeErrorException exp){
                exText.Clear();
                exText.Focus();
                MessageBox.Show(exText.Name + "为" + exp.Message);
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

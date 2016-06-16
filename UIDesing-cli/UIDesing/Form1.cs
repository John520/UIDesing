using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIDesing.Client;

namespace UIDesing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void fileWindow_Click(object sender, EventArgs e)
        {
            //测试用于弹出数据文件管理窗口
            FileAdmin fileAdmin = new FileAdmin();
            form_show(fileAdmin);

        }
       

        private void Manual_Click(object sender, EventArgs e)
        {
            ManualForm manual = new ManualForm();
            form_show(manual);
        }

        private void Autobutton_Click(object sender, EventArgs e)
        {
            //自动生产
           AutoPage auto = new AutoPage();
           form_show(auto);
        }
        //显示数据编辑窗口函数，方便调用
        public void form_show(UserControl control)
        {
            //测试用于弹出数据文件管理窗口
            
            funSwitch.Controls.Clear();
            funSwitch.Controls.Add(control);
            control.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                icImagingControl1.LoadDeviceStateFromFile("E:\\device.xml", true);
                icImagingControl1.LiveStart();
            }
            catch { }
        }
        int i = 0;
        int j = 1;
        private void save_button_Click(object sender, EventArgs e)
        {
            i++;
            // Snap an image.
            icImagingControl1.MemorySnapImage();
            icImagingControl1.ImageActiveBuffer.SaveAsJpeg("E:\\"+i+"--"+ j + ".jpg", 100);   
        }

        private void up_button_Click(object sender, EventArgs e)
        {
            j = 1;
            try
            {
                icImagingControl1.LoadDeviceStateFromFile("E:\\device.xml", true);
                icImagingControl1.LiveStart();
            }
            catch { }
        }

        private void down_button_Click(object sender, EventArgs e)
        {
            j = 2;
            try
            {
                icImagingControl1.LoadDeviceStateFromFile("E:\\device2.xml", true);
                icImagingControl1.LiveStart();
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clientControl cli = new clientControl();
            form_show(cli);
        }
    }
}

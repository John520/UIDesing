using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            control.Show();
            funSwitch.Controls.Clear();
            funSwitch.Controls.Add(control);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                icImagingControl1.ShowDeviceSettingsDialog();
                icImagingControl1.LoadDeviceStateFromFile("E:\\device.xml", true);

                icImagingControl1.LiveDisplayDefault = false;
                icImagingControl1.LiveStart();
            }
            catch { }
        }
        int i = 0;
        int j = 1;
        bool up_flag = true;
        bool down_flag = true;
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
                if (up_flag) {
                    icImagingControl1.ShowDeviceSettingsDialog();
                    icImagingControl1.SaveDeviceStateToFile("E:\\device.xml");
                    up_flag = false;
                }
                icImagingControl1.LoadDeviceStateFromFile("E:\\device.xml", true);
                icImagingControl1.LiveDisplayDefault = false;
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
                icImagingControl1.LiveDisplayDefault = false;
                icImagingControl1.LiveStart();
            }
            catch { }
        }
        /**
         * 缩放处理
         * 
         */
        private void sldZoom_Scroll(object sender, EventArgs e)
        {
            if (icImagingControl1.LiveDisplayDefault == false)
            {
                icImagingControl1.LiveDisplayZoomFactor = (float)sldZoom.Value / 10.0f;               
            }
            else
            {
                MessageBox.Show("The zoom factor can only be set" + "\n" + "if LiveDisplayDefault returns False!");
            }
        }
        //可以左右移动
        private void chkScrollbarsEnable_CheckedChanged(object sender, EventArgs e)
        {
            icImagingControl1.ScrollbarsEnabled = chkScrollbarsEnable.Checked;
        }
        //拉动调用的函数暂时未用到
        private void icImagingControl1_Scroll(object sender, ScrollEventArgs e)
        {
            Point p = icImagingControl1.AutoScrollPosition;  
        }

        private void icImagingControl1_DeviceLost(object sender, TIS.Imaging.ICImagingControl.DeviceLostEventArgs e)
        {

        }
    }
}

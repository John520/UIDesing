using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIDesing.dataSql;
using UIDesing.DataManual;
using UIDesing.util;
using UIDesing.dataSql.data;
namespace UIDesing
{
    public partial class DClassify : UserControl
    {
        private Cate_data cate_data = new Cate_data();
        public DClassify()
        {
            InitializeComponent();
        }

        private void DClassify_Load(object sender, EventArgs e)
        {
            List<Object> marks;
            using (MyContext context = new MyContext())
            {
                cate_data.id = -1;
                marks = context.get(Program.fileId, cate_data);
            }
            foreach (Cate_data cate_data in marks)
            {
                //调用显示函数
                toDataView(cate_data);
            }
            //右边显示
            if (this.dataGridView1.CurrentRow != null && this.dataGridView1.CurrentRow.Cells[0].Value != null)
            {
                cate_data.id = (int)this.dataGridView1.CurrentRow.Cells[0].Value;
                using (MyContext context = new MyContext())
                {
                    marks = context.get(Program.fileId, cate_data);
                }

                if (marks != null)
                {
                    data_load((Cate_data)marks[0]);
                }
            }
        }
        //实时更新数据库
        private void dataGridView1_cellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            save_button_Click(sender, null);
        }
        //右边保存事件
        private void groupBox_Leave(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentRow.Cells[0].Value != null)
            {

                cate_data.id = (int)this.dataGridView1.CurrentRow.Cells[0].Value;
                data_upload(cate_data);
                using (MyContext context = new MyContext())
                {
                    context.save(Program.fileId, cate_data);
                }

            }
        }
        //每当单击一行时，右边显示变换：
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            List<Object> marks;
            //右边显示
            if (this.dataGridView1.CurrentRow.Cells[0].Value != null)
            {
                cate_data.id = (int)this.dataGridView1.CurrentRow.Cells[0].Value;
                using (MyContext context = new MyContext())
                {
                    marks = context.get(Program.fileId, cate_data);
                }

                if (marks != null)
                {
                    data_load((Cate_data)marks[0]);
                }
            }
        }
        /**
         * 新建
         */
        private void new_button_Click(object sender, EventArgs e)
        {
            //左边新增加一行
            this.dataGridView1.Rows.Add();
            //右边显示空白
            Cate_data cate=new Cate_data();
            cate.ComponentType = -1;
            cate.FeederType=-1;
            cate.Nozzle=-1;
            cate.XySpeed=-1;
            cate.ZSpeed=-1;
            data_load(cate);
        }
        /**
        * 保存
        */
        private void save_button_Click(object sender, EventArgs e)
        {
            try
            {
            if (this.dataGridView1.CurrentRow.Cells[0].Value == null)
            {

                data_upload(cate_data);
                cate_data.id = -1;
                using (MyContext context = new MyContext())
                {
                    cate_data.id = context.save(Program.fileId, cate_data);

                }

            }
            else
            {
                cate_data.id = (int)this.dataGridView1.CurrentRow.Cells[0].Value;
                data_upload(cate_data);
                using (MyContext context = new MyContext())
                {
                    context.save(Program.fileId, cate_data);
                }
            }
            this.dataGridView1.CurrentRow.Cells[0].Value = cate_data.id;
             }
             catch (TypeErrorException exp)
             {
                 MessageBox.Show(exp.Message);
             }
        }
        /**
        * 删除
        */
        private void delete_button_Click(object sender, EventArgs e)
        {
             try
            {
            if (this.dataGridView1.CurrentRow != null)
            {
                //删除对应数据库中的数据
                if (this.dataGridView1.CurrentRow.Cells[0].Value != null)
                {

                    data_upload(cate_data);
                    using (MyContext context = new MyContext())
                    {
                        context.delete(Program.fileId, cate_data);

                    }

                }
                this.dataGridView1.Rows.Remove(this.dataGridView1.CurrentRow);

            }
            }
             catch (TypeErrorException exp)
             {
                 MessageBox.Show(exp.Message);
             }
        }
        /**
        * 退出
        */
        private void exit_button_Click(object sender, EventArgs e)
        {
            Is_save is_saveForm = new Is_save();
            DialogResult reslut = is_saveForm.ShowDialog();
            if (reslut == DialogResult.OK)
            {
                //保存操作
                save_button_Click(sender, e);
            }
            //测试用于弹出数据文件管理窗口
            FileAdmin fileAdmin = new FileAdmin();
            Program.form1.form_show(fileAdmin);
        }
        /*
        * 输入:list[i]  feed对象
        * 将数据加载到ui显示，通过从list中获得指定的Mark对象进行显示
        * 
        */
        private void data_load(Cate_data cate_data)
        {
            //基本信息
            this.libRefid.Text = Convert.ToString(cate_data.LibRefId);
            this.componentType.SelectedIndex = cate_data.ComponentType;
            this.feederType.SelectedIndex = cate_data.FeederType;
            this.nozzle.SelectedIndex = cate_data.Nozzle;
            this.xySpeed.SelectedIndex = cate_data.XySpeed;
            this.zSpeed.SelectedIndex = cate_data.ZSpeed;
            this.delay.Text = Convert.ToString(cate_data.Delay);
            this.pickUpVacuum.Text = Convert.ToString(cate_data.PickUpVacuum);
            this.degree.Text = Convert.ToString(cate_data.Degree);
            this.height.Text = Convert.ToString(cate_data.Height);
            this.plugDelay.Text = Convert.ToString(cate_data.Plugdelay);
            this.plugVacuum.Text = Convert.ToString(cate_data.PlugVacuum);
            this.plugDegree.Text = Convert.ToString(cate_data.PlugDegree);
            this.plugHeight.Text = Convert.ToString(cate_data.PlugHeight);
            this.capturespeed.Text = Convert.ToString(cate_data.Capturespeed);
            this.error.Text = Convert.ToString(cate_data.Error);
            //外观信息
            this.compLength.Text = Convert.ToString(cate_data.CompLength);
            this.compWidth.Text = Convert.ToString(cate_data.CompWidth);
            this.compHeigh.Text = Convert.ToString(cate_data.CompHeigh);
            this.comPinNumN.Text = Convert.ToString(cate_data.CompPinNumN);
            this.comPinNumE.Text = Convert.ToString(cate_data.CompPinNumE);
            this.comPinNumW.Text = Convert.ToString(cate_data.CompPinNumW);
            this.comPinNumS.Text = Convert.ToString(cate_data.CompPinNumS);
            this.compPinWidthN.Text = Convert.ToString(cate_data.CompPinWidthN);
            this.compPinWidthE.Text = Convert.ToString(cate_data.CompPinWidthE);
            this.compPinWidthW.Text = Convert.ToString(cate_data.CompPinWidthW);
            this.compPinWidthS.Text = Convert.ToString(cate_data.CompPinWidthS);
            this.compPinSpacN.Text = Convert.ToString(cate_data.CompPinSpacN);
            this.compPinSpacE.Text = Convert.ToString(cate_data.CompPinSpacE);
            this.compPinSpacW.Text = Convert.ToString(cate_data.CompPinSpacW);
            this.compPinSpacS.Text = Convert.ToString(cate_data.CompPinSpacS);
            this.compPinLengthN.Text = Convert.ToString(cate_data.CompPinLengthN);
            this.compPinLengthE.Text = Convert.ToString(cate_data.CompPinLengthE);
            this.compPinLengthW.Text = Convert.ToString(cate_data.CompPinLengthW);
            this.compPinLengthS.Text = Convert.ToString(cate_data.CompPinLengthS);
        }
        /*
          * 输入:list[i]  cate对象
          * 将UI数据加载到数据库中
          * 
          */
        private void data_upload(Cate_data cate_data)
        {
           string exText = "库元件引用编号";
            try
            {   
            //基本信息
            cate_data.LibRefId = TypeChange.stringToInt(this.libRefid.Text);
            //TODO数据库中少了两个

            //插装和贴装信息:
            cate_data.ComponentType = this.componentType.SelectedIndex;
            cate_data.FeederType = this.feederType.SelectedIndex;
           //TODO cate_data.Num = TypeChange.stringToInt(this.feedNum.Text);
            cate_data.Nozzle =  TypeChange.combSelected(this.nozzle.SelectedIndex);
            cate_data.XySpeed =  TypeChange.combSelected(this.xySpeed.SelectedIndex);
            cate_data.ZSpeed =  TypeChange.combSelected(this.zSpeed.SelectedIndex);
            exText = "拾取延时";
            cate_data.Delay = TypeChange.stringToInt(this.delay.Text);
            exText = "拾取真空度";
            cate_data.PickUpVacuum = TypeChange.stringToInt(this.pickUpVacuum.Text);
            exText = "拾取角度";
            cate_data.Degree = TypeChange.stringToInt(this.degree.Text);
            exText = "拾取高度";
            cate_data.Height = TypeChange.stringToInt(this.height.Text);
            exText = "插装延时";
            cate_data.Plugdelay = TypeChange.stringToInt(this.plugDelay.Text);
            exText = "插装真空度";
            cate_data.PlugVacuum = TypeChange.stringToInt(this.plugVacuum.Text);
            exText = "插装角度";
            cate_data.PlugDegree = TypeChange.stringToInt(this.plugDegree.Text);
            exText = "插装高度";
            cate_data.PlugHeight = TypeChange.stringToInt(this.plugHeight.Text);
            exText = "抓图速度";
            cate_data.Capturespeed = TypeChange.stringToInt(this.capturespeed.Text);
            exText = "容许误差";
            cate_data.Error = TypeChange.stringToInt(this.error.Text);
            //元件外观信息
            exText = "元件长度";
            cate_data.CompLength = TypeChange.stringToFloat(this.compLength.Text);
            exText = "元件宽度";
            cate_data.CompWidth = TypeChange.stringToFloat(this.compWidth.Text);
            exText = "元件高度";
            cate_data.CompHeigh = TypeChange.stringToFloat(this.compHeigh.Text);
            exText = "N方向引脚数";
            cate_data.CompPinNumN = TypeChange.stringToInt(this.comPinNumN.Text);
            exText = "E方向引脚数";
            cate_data.CompPinNumE = TypeChange.stringToInt(this.comPinNumE.Text);
            exText = "W方向引脚数";
            cate_data.CompPinNumW = TypeChange.stringToInt(this.comPinNumW.Text);
            exText = "S方向引脚数";
            cate_data.CompPinNumS = TypeChange.stringToInt(this.comPinNumS.Text);
            exText = "N方向引脚宽度";
            cate_data.CompPinWidthN = TypeChange.stringToInt(this.compPinWidthN.Text);
            exText = "E方向引脚宽度";
            cate_data.CompPinWidthE = TypeChange.stringToInt(this.compPinWidthE.Text);
            exText = "W方向引脚宽度";
            cate_data.CompPinWidthW = TypeChange.stringToInt(this.compPinWidthW.Text);
            exText = "S方向引脚宽度";
            cate_data.CompPinWidthS = TypeChange.stringToInt(this.compPinWidthS.Text);
            exText = "N方向引脚间距";
            cate_data.CompPinSpacN = TypeChange.stringToInt(this.compPinSpacN.Text);
            exText = "E方向引脚间距";
            cate_data.CompPinSpacE = TypeChange.stringToInt(this.compPinSpacE.Text);
            exText = "W方向引脚间距";
            cate_data.CompPinSpacW = TypeChange.stringToInt(this.compPinSpacW.Text);
            exText = "S方向引脚间距";
            cate_data.CompPinSpacS = TypeChange.stringToInt(this.compPinSpacS.Text);
            exText = "N方向引脚长度";
            cate_data.CompPinLengthN = TypeChange.stringToInt(this.compPinLengthN.Text);
            exText = "E方向引脚长度";
            cate_data.CompPinLengthE = TypeChange.stringToInt(this.compPinLengthE.Text);
            exText = "W方向引脚长度";
            cate_data.CompPinLengthW = TypeChange.stringToInt(this.compPinLengthW.Text);
            exText = "S方向引脚长度";
            cate_data.CompPinLengthS = TypeChange.stringToInt(this.compPinLengthS.Text);
            }
            catch (TypeErrorException exp)
            {

                throw new TypeErrorException(exText + "为" + exp.Message);
            }
            int index = 1;
            try
            {
            //元件列表

            cate_data.id = TypeChange.stringToId(Convert.ToString(this.dataGridView1.CurrentRow.Cells[0].Value));
            cate_data.CateId= TypeChange.stringToInt(Convert.ToString(this.dataGridView1.CurrentRow.Cells[1].Value));
            index = 2;
            cate_data.CateName = TypeChange.stringToStrignAndThrow((String)this.dataGridView1.CurrentRow.Cells[2].Value);
            index = 3; 
            cate_data.Num = TypeChange.stringToInt(Convert.ToString(this.dataGridView1.CurrentRow.Cells[3].Value));
            }
            catch (TypeErrorException exp)
            {
                throw new TypeErrorException(this.dataGridView1.Columns[index].HeaderText + "为" + exp.Message);
            }     
        }
        //将数据转化为行显示
        private void toDataView(Cate_data cate_data)
        {
            Object[] row = new Object[4];
            row[0] = cate_data.id;
            row[1] = cate_data.CateId;
            row[2] = cate_data.CateName;
            row[3] = cate_data.Num;
            this.dataGridView1.Rows.Add(row);
        }     
    }
}

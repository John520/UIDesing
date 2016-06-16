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
using UIDesing.dataSql.data;

namespace UIDesing.Optimize
{
    public partial class AfterOpt : UserControl
    {
        public AfterOpt()
        {
            InitializeComponent();
        }

        private void AfterOpt_Load(object sender, EventArgs e)
        {
            List<Object> plug_list;
            using (MyContext context = new MyContext())
            {       
                //插件文件数据检测
                Plug_data plug_data = new Plug_data();
                plug_data.id = -1;
                plug_list = context.get(Program.fileId, plug_data);    
            }
            if (plug_list != null && plug_list.Count() >= 1)
            {
               List<Plug_data> list=optimized(paraion(plug_list), ParamDesinger.headAndGroup);
                foreach(Plug_data plug_data in list)
                {
                    toDataView(plug_data);
                }
            }
        }
        /**
         * 按照吸嘴对插件进行分类
         * <key,value>=<吸嘴ID，插件队列>
         */
        private Dictionary<int, Queue<Plug_data>> paraion(List<Object> plug_list)
        {
            Dictionary<int, Queue<Plug_data>> dict = new Dictionary<int, Queue<Plug_data>>();
             using (MyContext context = new MyContext())
            {
               foreach (Plug_data plug_data in plug_list)
              {
                  //吸嘴
                  int nozzel = context.get(Program.fileId, plug_data.CateName, new Cate_data());
                  plug_data.Nozzle = nozzel;
                  //喂料槽号
                  plug_data.FeedId = context.get(Program.fileId, plug_data.CateName,new Feed_data());
                   //包含吸嘴就如库
                  if (dict.ContainsKey(nozzel))
                  {
                      dict[nozzel].Enqueue(plug_data);
                  }
                  else
                  {
                      dict.Add(nozzel, new Queue<Plug_data>());
                      dict[nozzel].Enqueue(plug_data);
                  }
              }
            }
            return dict;
        }
        /**
         * 数据优化：
         * 1、组号的获得
         * 2、更具吸嘴有否获得插件顺序
         */
        private List<Plug_data> optimized(Dictionary<int, Queue<Plug_data>> dict, List<int> heads)
        {
            int i = 0;//组内号
            int headCount = heads.Count();//头数据
            List<Plug_data> plug_list = new List<Plug_data>();//存放优化后的插件数据
            while (dict.Count > 0)
            {
                i++;
                int order= 0;//插件顺序
                int flag = 0;//跳出判断
                for (int j = 0; j < headCount; j++)
                {
                    //优化处理
                    if (dict.ContainsKey(heads[j]))
                    {
                        if (dict[heads[j]].Count > 0)
                        {
                            order++;//组内顺序++
                            Plug_data plug_data = dict[heads[j]].Dequeue();
                            //所属组
                            plug_data.CartridgeNum = i;
                            //插件头ID
                            plug_data.PlugHeadId = j + 1;
                            //插件顺序
                            plug_data.PlugOrder = order;
                            //拾取顺序
                            plug_data.PickOrder = order;
                            //放入链表
                            plug_list.Add(plug_data);
                        }
                        else
                        {
                            dict.Remove(heads[j]);
                        }
                    }
                    else
                    {
                        flag++;
                    }
                }
                if (flag >headCount - 1) break;//如果吸嘴都不合适，则跳出  此处：可能需要注明TODO
            }
            return plug_list;
        }
        //将数据转化为行显示
        private void toDataView(Plug_data plug_data)
        {
            Object[] row = new Object[12];
            row[0] = plug_data.id;
            row[1] = plug_data.CartridgeNum;
            row[2] = plug_data.PlugId;
            row[3] = plug_data.Name;
            row[4] = plug_data.CateName;
            row[5] = plug_data.PlugHeadId;
            row[6] = plug_data.FeedId;
            row[7] = plug_data.Nozzle;
            row[8] = plug_data.PlugOrder;
            row[9] = plug_data.PickOrder;
            if (plug_data.IsPlug)
                row[10] = "true";
            else
                row[10] = "false";
            this.dataGridView1.Rows.Add(row);
        }     
    }
}

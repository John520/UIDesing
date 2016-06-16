using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIDesing.dataSql
{
   public class File_data
    {
        [Key]
        public int FileId { get; set; }
        public string FileName { get; set; }
        public Nullable<DateTime> CreateTime { get; set; }
        public Nullable<DateTime> ModifiedTime { get; set; }
        public Nullable<DateTime> ProduceTime { get; set; }
        public string User { get; set; }
        public string Remark { get; set; }
        public virtual List<PCB_data> PCBDatas { get; set; }
        public virtual List<Mark_data> MarkDatas { get; set; }
        public virtual List<Cate_data> CateDatas { get; set; }
        public virtual List<Feed_data> FeedDatas { get; set; }
        
    }

    


}

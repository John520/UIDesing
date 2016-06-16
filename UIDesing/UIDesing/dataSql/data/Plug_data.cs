using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIDesing.dataSql
{
    public class Plug_data
    {
        [Key]
        public int id { get; set; }
        //    [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PlugId { get; set; }

        public string Name
        {
            get;
            set;
        }

        public string CateName
        {
            get;
            set;
        }

        public float X
        {
            get;
            set;
        }

        public float Y
        {
            get;
            set;
        }


        public float Z
        {
            get;
            set;
        }


        public float U
        {
            get;
            set;
        }


        public int FeedId
        {
            get;
            set;
        }

        public bool IsPlug
        {
            get;
            set;
        }


        public int PlugHeadId
        {
            get;
            set;
        }


        public int CartridgeNum
        {
            get;
            set;
        }
        public int PlugOrder { get; set; }
        public int PickOrder { get; set; }
        public int Nozzle { get; set; }


        public virtual Cate_data Cate_data { get; set; }
    }
}

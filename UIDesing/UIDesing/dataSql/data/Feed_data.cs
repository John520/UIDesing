using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIDesing.dataSql
{
    public class Feed_data
    {


        [Key]
        public int id { get; set; }
    //    [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FeedId
        {
            get;
            set;
        }

        public string FeedComp
        {
            get;
            set;
        }

        public float PickPointX
        {
            get;
            set;
        }
        public float PickPointY
        {
            get;
            set;
        }


        public float PickPointZ
        {
            get;
            set;
        }
        public float UDegree
        {
            get;
            set;
        }
        public bool IsUsed
        {
            get;
            set;
        }
        public virtual File_data File_data { get; set; }

    }
}

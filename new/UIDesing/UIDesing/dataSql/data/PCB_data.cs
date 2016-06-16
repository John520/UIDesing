using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIDesing.dataSql
{
    public class PCB_data
    {
        [Key]
        public int pcbId { get; set; }
        public float Length { get; set; }
        public float Width { get; set; }
        public float Thickness { get; set; }
        public float X { get; set; }

        public float Y { get; set; }
        public int Clamp { get; set; }
        public int Speed { get; set; }
        public int MaxNum { get; set; }
        public int FinishedNum { get; set; }
        public string Describe { get; set; }

        public virtual File_data File_data { get; set; }


    }
}

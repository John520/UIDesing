using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIDesing.dataSql
{
    public class Mark_data
    {
        [Key]
        public int id { get; set; }
        //    [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MarkId { get; set; }

        public int Type
        {
            get;
            set;
        }


        public string Name { get; set; }


        public Nullable<float> X1
        {
            get;
            set;
        }


        public Nullable<float> Y1
        {
            get;
            set;
        }

        public Nullable<float> X2
        {
            get;
            set;
        }


        public Nullable<float> Y2
        {
            get;
            set;
        }


        public Nullable<float> Z
        {
            get;
            set;
        }


        public int RecogAlgorithm
        {
            get;
            set;
        }


        public int Brightness
        {
            get;
            set;
        }


        public int MinMatch
        {
            get;
            set;
        }

        public string TemplateFile
        {
            get;
            set;
        }


        public int Shape
        {
            get;
            set;
        }


        public int ReflectType
        {
            get;
            set;
        }

        public float XSize
        {
            get;
            set;
        }

        public float YSize
        {
            get;
            set;
        }

        public int Brightness2
        {
            get;
            set;
        }


        public int Threshold
        {
            get;
            set;
        }


        public int Error
        {
            get;
            set;
        }

        public float Zone
        {
            get;
            set;
        }


        public string Remarks
        {
            get;
            set;
        }
        public virtual File_data File_data { get; set; }
    }
}

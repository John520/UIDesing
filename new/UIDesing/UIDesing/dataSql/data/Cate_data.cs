using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace  UIDesing.dataSql
{
   public class Cate_data
        {
            [Key]
            public int id { get; set; }
            //    [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int CateId
            {
                get;
                set;
            }

            public string CateName
            {
                get;
                set;
            }

            public int Num{get;set;}
            public int LibRefId
            {
                get;
                set;
            }

            public int ComponentType
            {
                get;
                set;
            }


            public int FeederType
            {
                get;
                set;
            }


            public int Nozzle
            {
                get;
                set;
            }

            public int XySpeed
            {
                get;
                set;
            }


            public int ZSpeed
            {
                get;
                set;
            }

            public int Delay
            {
                get;
                set;
            }

            public int PickUpVacuum
            {
                get;
                set;
            }


            public float Degree
            {
                get;
                set;
            }


            public float Height
            {
                get;
                set;
            }


            public int Plugdelay
            {
                get;
                set;
            }


            public int PlugVacuum
            {
                get;
                set;
            }


            public float PlugDegree
            {
                get;
                set;
            }


            public float PlugHeight
            {
                get;
                set;
            }

            public int Capturespeed
            {
                get;
                set;
            }


            public int InnerBrightness
            {
                get;
                set;
            }

            public int ExtBrightness
            {
                get;
                set;
            }


            public int ReflectDegree
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


            public bool ManualCalibration
            {
                get;
                set;
            }


            public int RecogAlgorithm
            {
                get;
                set;
            }


            public string TempletFile
            {
                get;
                set;
            }


            public float CompLength
            {
                get;
                set;
            }


            public float CompWidth
            {
                get;
                set;
            }


            public float CompHeigh
            {
                get;
                set;
            }


            public int CompPinNumN
            {
                get;
                set;
            }
            public int CompPinNumE
            {
                get;
                set;
            }
            public int CompPinNumW
            {
                get;
                set;
            }
            public int CompPinNumS
            {
                get;
                set;
            }
            public int CompPinWidthN
            {
                get;
                set;
            }

            public int CompPinWidthE
            {
                get;
                set;
            }
            public int CompPinWidthW
            {
                get;
                set;
            }
            public int CompPinWidthS
            {
                get;
                set;
            }




            public int CompPinSpacN
            {
                get;
                set;
            }

            public int CompPinSpacE
            {
                get;
                set;
            }
            public int CompPinSpacW
            {
                get;
                set;
            }
            public int CompPinSpacS
            {
                get;
                set;
            }
            public int CompPinLengthN
            {
                get;
                set;
            }
            public int CompPinLengthE
            {
                get;
                set;
            }
            public int CompPinLengthW
            {
                get;
                set;
            }
            public int CompPinLengthS
            {
                get;
                set;
            }
              public virtual File_data File_data { get; set; }
              public virtual List<Plug_data> PlugDatas { get; set; }
        }
       

    }


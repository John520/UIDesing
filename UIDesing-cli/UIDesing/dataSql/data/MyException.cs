using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIDesing.dataSql.data
{ 
    public enum warming  { None=0,NoFile = 1, NoCate = 2, NoPlug = 3, NoPcb = 4, NoFeed = 5, NoMark = 6 };
    class MyException:Exception
    {
        public string Message { get; set; }
       
        public warming WarmType{get;set;}
        
    }
}

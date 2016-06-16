using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIDesing.util
{
    public class TypeErrorException:Exception
    {
        public TypeErrorException(){}
        public TypeErrorException(string message) : base(message) { }
    }
}

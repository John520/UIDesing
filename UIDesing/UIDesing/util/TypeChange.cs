using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIDesing.util
{
    public class TypeChange
    {
       /**
        * 
        * 字符串转换成float的转换函数
        * 可以抛出异常  ：类型转换错误
        */
        public static float stringToFloat(String s)
        {
            float f = 0;
            if (float.TryParse(s, out f))
            {
                return f;
            }
            else
            {
                throw new TypeErrorException("float型必须填写正确，不能为空和字符");
            }
           
        }
        /**
      * 
      * 字符串转换成float的转换函数
      * 可以抛出异常  ：类型转换错误
        输入包括转换的范围
      */
        public static float stringToFloatRange(String s,float min,float max)
        {
            float f = 0;
            if (float.TryParse(s, out f))
            {
                if (f >= min && f <= max)
                    return f;
                else
                {
                    throw new TypeErrorException("float型必须填写正确，需要大于"+min.ToString()+"小于"+max.ToString());
                }
            }
            else
            {
                throw new TypeErrorException("float型必须填写正确，需要大于" + min.ToString() + "小于" + max.ToString());
            }

        }
     /**
     * 
     * 自增长id的转换函数
      * 将字符串转换为id
     */
        public static int stringToId(String s)
        {
            int i = 0;
            if (int.TryParse(s, out i))
            {
                return i;
            }
            else
                return 0;

        }
        /**
     * 
     * 字符串转换成int的转换函数
     * 可以抛出异常  ：类型转换错误
     */
        public static int stringToInt(String s)
        {
            int i = 0;
            if (int.TryParse(s, out i))
            {
                if (i >= 0)
                {
                    return i;
                }
                else
                {
                    throw new TypeErrorException("int型需要大于0");
                }

            }
            else
            {
                throw new TypeErrorException("int型需要大于0");
            }
        }
        /**
     * 
     * 字符串转换成int的转换函数
     * 可以抛出异常  ：类型转换错误
       输入包括转换的范围
     */
        public static int stringToIntRange(String s, int min, int max)
        {
            int i = 0;
            if (int.TryParse(s, out i))
            {
                if (i >= min && i <= max)
                    return i;
                else
                {
                    throw new TypeErrorException("float型必须填写正确，需要大于" + min.ToString() + "小于" + max.ToString());
                }
            }
            else
            {
                throw new TypeErrorException("float型必须填写正确，需要大于" + min.ToString() + "小于" + max.ToString());
            }
        }
        /**
     * 
     * 字符串转换成字符串的转换函数
     */
        public static String stringToString(String s)
        {
            if (s != null && !"".Equals(s)) return s.ToString();
            else
            { return ""; }
        }
        /**
         * 
         * 字符串转换成字符串的转换函数
         * 会抛出异常错误
         */
        public static String stringToStrignAndThrow(String s)
        {
            if (s != null && !"".Equals(s)) return s.ToString();
            else
            {
                throw new TypeErrorException("字符串型必须填写正确，不能为空");
            }
        }
        /**
         * 
        * 下拉框的转换函数
         */
        public static int combSelected(int i)
        {
            if (i == -1)
                return 0;
            else
                return i;
        }
    }
}

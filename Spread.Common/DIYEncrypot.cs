using System;
using System.Collections.Generic;
using System.Text;

namespace Spread.Common
{
    /// <summary>
    /// 自定义数字加密
    /// </summary>
    public  class DIYEncrypot
    {
        /// <summary>
        /// 加密算法
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Encode(string str)
        {
            string result = "";
            int len = str.Length;
            int x = 0;
            for (int i = len - 1; i >= 0; i--)
            {
                result += str[i].ToString();
                if (x >= 2 && i > 0)
                {
                    result += "_";
                    x = 0;
                }
                else
                {
                    x++;
                }
            }
            return result;
        }

        /// <summary>
        /// 解密算法
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Decode(string str)
        {
            str=str.Replace("_", "");
            string result = "";
            int len = str.Length;
            for (int i = len - 1; i >= 0; i--)
            {
                result += str[i].ToString();
            }
            return result;
        }
    }
}

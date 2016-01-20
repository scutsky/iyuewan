using System;
using System.Collections.Generic;
using System.Text;

namespace Spread.Common
{
    public class VerifycodeUtils
    {
        public static string genVerifycode(int length)
        {
            if (length <= 0)
            {
                return string.Empty;
            }
            //验证码的字符集，去掉了一些容易混淆的字符
            char[] character = { '0', '1',  '2', '3', '4', '5', '6', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            Random random = new Random();
            StringBuilder builder = new StringBuilder();
            //产生随机的验证码并拼接起来
            for (int i = 0; i < length; i++)
            {
                builder.Append(character[random.Next(character.Length)]);
            }
            return builder.ToString();
        }
    }
}

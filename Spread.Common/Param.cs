using System;
using System.Xml;
using System.Configuration;
using System.Web;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace Spread.Common
{
    public class Param
    {
        /// <summary>
        /// 获取服务器上 ASP.NET 应用程序的虚拟应用程序根路径
        /// </summary>
        public static string ApplicationRootPath = ((HttpContext.Current.Request.ApplicationPath == "/") ? "" : HttpContext.Current.Request.ApplicationPath);

        /// <summary>
        /// 加密编码
        /// </summary>
        public static string EncCode = ConfigurationManager.AppSettings["EncCode"];
        public static byte[] Iv_64 = Encoding.UTF8.GetBytes(EncCode);
        public static byte[] Key_64 = Encoding.UTF8.GetBytes(EncCode);
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static string ConnectionStr = ConfigurationManager.AppSettings["ConnectionStr"];

        /// <summary>
        /// Acc数据库连接字符串
        /// </summary>
        public static string AccConnectionStr = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}{1}", HttpContext.Current.Server.MapPath("/"),ConfigurationManager.AppSettings["AccConnectionStr"]);

        /// <summary>
        /// 站点配置文件路径
        /// </summary>
        public static string WebSetpath = ConfigurationManager.AppSettings["WebSetpath"];

        /// <summary>
        /// 英文站点配置文件路径
        /// </summary>
        public static string enWebSetpath = ConfigurationManager.AppSettings["enWebSetpath"];

        /// <summary>
        /// 参数配置文件路径
        /// </summary>
        public static string DevPath = ConfigurationManager.AppSettings["DevConfigPath"];

        /// <summary>
        /// 系统模板名称
        /// </summary>
        public static string TempName = GetDevValue(0);

        /// <summary>
        /// 淘宝开放平台AppKey
        /// </summary>
        public static string AppKey = GetDevValue(1);
        /// <summary>
        /// 淘宝开放平台AppSecret
        /// </summary>
        public static string AppSecret = GetDevValue(2);
        /// <summary>
        /// 淘宝开放平台回调地址
        /// </summary>
        public static string RestUrl = GetDevValue(3);
        /// <summary>
        /// 淘宝客Pid
        /// </summary>
        public static string Pid = GetDevValue(4);

        /// <summary>
        /// 根据索引获取相关节点的值
        /// </summary>
        /// <returns></returns>
        public static string GetDevValue(int Index)
        {
            XmlDocument document = new XmlDocument();
            document.Load(HttpContext.Current.Server.MapPath(@DevPath));
            XmlNode node = document.ChildNodes[1];
            return node.ChildNodes[0].ChildNodes[Index].Attributes["value"].Value;
        }

        /// <summary>
        /// 根据索引设置相关节点的值
        /// </summary>
        /// <param name="Index"></param>
        /// <param name="ValueStr"></param>
        public static void SetDevValue(int Index, string ValueStr)
        {
            XmlDocument document = new XmlDocument();
            document.Load(HttpContext.Current.Server.MapPath(@DevPath));
            XmlNode node = document.ChildNodes[1];
            node.ChildNodes[0].ChildNodes[Index].Attributes["value"].Value = ValueStr;
            document.Load(HttpContext.Current.Server.MapPath(@DevPath));
        }
    }
}

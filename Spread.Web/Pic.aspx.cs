using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;

namespace Shannon.Web
{
    public partial class Pic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string picurl = Request["p"];

            picurl = Shannon.Common.DESEncrypt.Decrypt(picurl.ToUpper(), Shannon.Common.Param.EncCode);
            if (!string.IsNullOrEmpty(picurl))
            {
                Response.ContentType = "image/jpeg";
                Response.BinaryWrite(GetImageByte(picurl));
            }
        }
        /// <summary>
        ///图片二进制转换
        /// </summary>
        private byte[] GetImageByte(string Url)
        {
            WebClient wb = new WebClient();
            return wb.DownloadData(Url);
        }
    }
}

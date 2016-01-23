using Spread.Common;
using System;
using System.Web;
using System.Web.UI;
namespace Spread.Web.UI
{
	public class ControlBasePage : UserControl
	{
		protected string ListURL(string cid)
		{
			return string.Format("/product/list/d{0}.html", cid);
		}
		protected string ListURL(string cid, string keyword)
		{
			return string.Format("/product/list/d{0}.html?keyword={1}", cid, HttpUtility.UrlEncode(keyword));
		}
		protected string GoURL(string url)
		{
			return string.Format("/go/d{0}.html", DESEncrypt.Encrypt(url, Param.EncCode).ToLower());
		}
	}
}

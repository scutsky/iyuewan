using Spread.BLL;
using Spread.Common;
using Spread.Model;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
namespace Spread.Web.UI
{
	public class BasePage : Page
	{
		protected internal Spread.Model.WebSet webset;
		public BasePage()
		{
			this.webset = new Spread.BLL.WebSet().loadConfig(base.Server.MapPath(Param.WebSetpath));
		}
		protected DataTable GetAdbanner(string key, int top)
		{
			int adverID = new Spread.BLL.Advertising().GetAdverID(key);
			DataTable result;
			if (adverID > 0)
			{
				result = new Spread.BLL.Adbanner().GetList(top, string.Format("Aid={0} and IsLock=0", adverID), "AddTime").Tables[0];
			}
			else
			{
				result = null;
			}
			return result;
		}
		protected void jsAutoMsg(string msgtitle, string url)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(string.Concat(new string[]
			{
				"$(function(){ jsAutoMsg(\"",
				msgtitle,
				"\", \"",
				url,
				"\"); });"
			}));
			base.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "AutoMsg", stringBuilder.ToString(), true);
		}
		protected void jsLayMsg(int w, int h, string msgtitle, string msgbox, string url, string msgcss)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(string.Concat(new object[]
			{
				"$(function(){ jsLayMsg(",
				w,
				", ",
				h,
				", {title:\"",
				msgtitle,
				"\",msbox:\"",
				msgbox,
				"\",mscss:\"",
				msgcss,
				"\",url:\"",
				url,
				"\"}); });"
			}));
			base.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "LayMsg", stringBuilder.ToString(), true);
		}
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
			return string.Format("/go.html?u={0}", DESEncrypt.Encrypt(url, Param.EncCode).ToLower());
		}
	}
}

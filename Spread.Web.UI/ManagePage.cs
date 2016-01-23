using Spread.BLL;
using Spread.Common;
using Spread.Model;
using System;
using System.Web.UI;
namespace Spread.Web.UI
{
	public class ManagePage : Page
	{
		protected internal Spread.Model.WebSet webset;
		public ManagePage()
		{
			base.Load += new EventHandler(this.ManagePage_Load);
			this.webset = new Spread.BLL.WebSet().loadConfig(base.Server.MapPath(Param.WebSetpath));
		}
		private void ManagePage_Load(object sender, EventArgs e)
		{
			if (this.Session["AdminNo"] == null || this.Session["AdminName"] == null || this.Session["AdminLevel"] == null || this.Session["AdminType"] == null)
			{
				base.Response.Write("<script>parent.location.href='/admin/login.aspx'</script>");
				base.Response.End();
			}
		}
		protected void chkLoginLevel(string pagestr)
		{
			string text = "";
			int num = int.Parse(this.Session["AdminType"].ToString());
			string text2 = this.Session["AdminLevel"].ToString();
			if (num > 1)
			{
				pagestr += ",";
				if (text2.IndexOf(pagestr) == -1)
				{
					text += "<script type=\"text/javascript\">\n";
					text += "parent.jsmsg(350,230,\"警告提示\",\"<b>没有管理权限</b>您没有权限管理该功能，请勿非法进入。\",\"back\")\n";
					text += "</script>\n";
					base.Response.Write(text);
					base.Response.End();
				}
			}
		}
		protected void JscriptMsg(int w, int h, string msgtitle, string msgbox, string url, string msgcss)
		{
			string text = "";
			text += "<script type=\"text/javascript\">\n";
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"parent.jsmsg(",
				w,
				",",
				h,
				",\"",
				msgtitle,
				"\",\"",
				msgbox,
				"\",\"",
				url,
				"\",\"",
				msgcss,
				"\")\n"
			});
			text += "</script>\n";
			base.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "JsMsg", text);
		}
		protected void JscriptPrint(string msgtitle, string url, string msgcss)
		{
			string text = "";
			text += "<script type=\"text/javascript\">\n";
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"parent.jsprint(\"",
				msgtitle,
				"\",\"",
				url,
				"\",\"",
				msgcss,
				"\")\n"
			});
			text += "</script>\n";
			base.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "JsPrint", text);
		}
	}
}

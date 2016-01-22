using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Spread.Web.User
{
    public partial class Channeldetail : System.Web.UI.Page
    {
        Model.Channel cModel = new Model.Channel();
        BLL.Channel cbll = new BLL.Channel();
        public int Id;    //ID
        public Spread.Model.User modeluser = new Model.User();
        Spread.BLL.User blluser = new BLL.User();
        private string uid = "";
        private string pwd = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //取得栏目传参
            if (int.TryParse(Request.Params["Id"], out Id))
            {
                if (!Page.IsPostBack)
                {
                    if (!getUserCookies())
                    {
                        Response.Redirect("~/Index.aspx");
                    }
                    else
                    {
                        modeluser = blluser.GetModelByName(uid);
                    }
                    ChannelData = cbll.GetList(" c.ID='" + Id + "'").Tables[0];
                    ChannelTitle = cbll.GetList(" UserID='" + modeluser.ID + "'").Tables[0];
                    if (ChannelData.Rows.Count > 0)
                    {
                        lbChanel.Text = ChannelData.Rows[0]["Title"].ToString();
                    }
                }
            }
            else
            {
                string myScript = @"alertMsg('出现错误啦,参数不正确','error.gif');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                return;
            }
          
        }
        private bool getUserCookies()
        {

            if (Request.Cookies["UserPage_UID"] != null)
            {
                uid = Request.Cookies["UserPage_UID"].Value.ToString();
            }
            //获取登录时的PWD(MD5加密后)
            if (Request.Cookies["UserPage_PWD"] != null)
            {
                pwd = Request.Cookies["UserPage_PWD"].Value.ToString();
            }
            //当用户名UID或者密码PWD有一项为空时
            if (string.IsNullOrEmpty(uid) || string.IsNullOrEmpty(pwd))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        ///  产品
        /// </summary>
        protected DataTable ChannelData
        {
            get;
            set;
        }

        /// <summary>
        ///  产品
        /// </summary>
        protected DataTable ChannelTitle
        {
            get;
            set;
        }
    }
}
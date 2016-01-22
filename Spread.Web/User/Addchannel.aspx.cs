using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

namespace Spread.Web.User
{
    public partial class Addchannel : System.Web.UI.Page
    {
        public Spread.Model.Products model = new Model.Products();
        Spread.BLL.Products bll = new BLL.Products();
        public Spread.Model.User modeluser = new Model.User();
        Spread.BLL.User blluser = new BLL.User();
        Model.Channel cModel = new Model.Channel();
        BLL.Channel cbll = new BLL.Channel();
        private Spread.BLL.WebSet bllSet = new Spread.BLL.WebSet();
        private string uid = "";
        private string pwd = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!getUserCookies())
                {
                    Response.Redirect("~/Index.aspx");
                }
                else
                {
                    modeluser = blluser.GetModelByName(uid);

                }
                Spread.Model.WebSet model = new Spread.Model.WebSet();
                //bll.Get_Config(rwc);
                string pathurl = Server.MapPath(ConfigurationManager.AppSettings["WebSetpath"].ToString());
                model = bllSet.loadConfig(pathurl);
                DataTable dtChannel = cbll.GetList(" UserID='" + modeluser.ID + "' ").Tables[0];
                if (dtChannel.Rows.Count >= int.Parse(model.ChannelNum))
                {
                    string myScript = @"alertRedirectMsg('添加渠道不能大于" + model.ChannelNum + "!','error.gif','Channel.aspx');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                    return;
                }
                //TreeBind();
                DataTable dt = bll.GetList("").Tables[0];
                this.rptList.DataSource = dt;
                this.rptList.DataBind();
            }
        }

        ////绑定平台
        //private void TreeBind()
        //{
        //    Spread.BLL.Menu cbll = new Spread.BLL.Menu();
        //    DataTable dt = cbll.GetList("").Tables[0];
        //    channeltype.DataSource = dt;
        //    channeltype.DataTextField = "Title";
        //    channeltype.DataValueField = "Title";
        //    channeltype.DataBind();
        //    ListItem item = new ListItem("请选择行业", "0");
        //    channeltype.Items.Insert(0, item);
        //}

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
        protected void submitbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.channelname.Text))
            {
                string myScript = @"alertMsg('渠道名称不能为空!','error.gif');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                return;
            }
            #region 删除
            //if (this.channeltype.SelectedValue=="0")
            //{
            //    string myScript = @"alertMsg('请选择行业分类!','error.gif');";
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
            //    return;
            //}
            //if (this.channeltype.SelectedValue == "1")
            //{
            //    if (string.IsNullOrEmpty(this.txtWebName.Text))
            //    {
            //        string myScript = @"alertMsg('网站名称不能为空!','error.gif');";
            //        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
            //        return;
            //    }
            //    if (string.IsNullOrEmpty(this.txtWebUrl.Text))
            //    {
            //        string myScript = @"alertMsg('网站地址不能为空!','error.gif');";
            //        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
            //        return;
            //    }
            //}
            //else if (this.channeltype.SelectedValue == "5")
            //{
            //    if (string.IsNullOrEmpty(this.txtWebName.Text))
            //    {
            //        string myScript = @"alertMsg('软件名称不能为空!','error.gif');";
            //        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
            //        return;
            //    }
            //    if (string.IsNullOrEmpty(this.txtWebUrl.Text))
            //    {
            //        string myScript = @"alertMsg('软件下载连接不能为空!','error.gif');";
            //        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
            //        return;
            //    }
            //}
            //else if (this.channeltype.SelectedValue == "10")
            //{
            //    if (string.IsNullOrEmpty(this.txtWebName.Text))
            //    {
            //        string myScript = @"alertMsg('应用商店名称不能为空!','error.gif');";
            //        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
            //        return;
            //    }
            //    if (string.IsNullOrEmpty(this.txtWebUrl.Text))
            //    {
            //        string myScript = @"alertMsg('应用商店下载连接不能为空!','error.gif');";
            //        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
            //        return;
            //    }
            //}
            //else if (this.channeltype.SelectedValue == "12")
            //{
            //    if (string.IsNullOrEmpty(this.txtWebName.Text))
            //    {
            //        string myScript = @"alertMsg('网站名称不能为空!','error.gif');";
            //        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
            //        return;
            //    }
            //    if (string.IsNullOrEmpty(this.txtWebUrl.Text))
            //    {
            //        string myScript = @"alertMsg('网站地址不能为空!','error.gif');";
            //        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
            //        return;
            //    }
            //}
            //else if (this.channeltype.SelectedValue == "16")
            //{
            //    if (string.IsNullOrEmpty(this.txtWebName.Text))
            //    {
            //        string myScript = @"alertMsg('APP名称不能为空!','error.gif');";
            //        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
            //        return;
            //    }
            //    if (string.IsNullOrEmpty(this.txtWebUrl.Text))
            //    {
            //        string myScript = @"alertMsg('APP下载连接不能为空!','error.gif');";
            //        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
            //        return;
            //    }
            //}
            //else if (this.channeltype.SelectedValue == "19")
            //{
            //    if (string.IsNullOrEmpty(this.txtWebName.Text))
            //    {
            //        string myScript = @"alertMsg('自身资源说明不能为空!','error.gif');";
            //        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
            //        return;
            //    }

            //}
            //else if (this.channeltype.SelectedValue == "19")
            //{
            //    if (string.IsNullOrEmpty(this.txtWebName.Text))
            //    {
            //        string myScript = @"alertMsg('自身资源说明不能为空!','error.gif');";
            //        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
            //        return;
            //    }

            //}
            //else if (this.channeltype.SelectedValue == "21")
            //{
            //    if (string.IsNullOrEmpty(this.txtWebName.Text))
            //    {
            //        string myScript = @"alertMsg('自身资源说明不能为空!','error.gif');";
            //        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
            //        return;
            //    }

            //}
            //else if (this.channeltype.SelectedValue == "23")
            //{
            //    if (string.IsNullOrEmpty(this.txtWebName.Text))
            //    {
            //        string myScript = @"alertMsg('名称不能为空!','error.gif');";
            //        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
            //        return;
            //    } 
            //    if (string.IsNullOrEmpty(this.txtWebUrl.Text))
            //    {
            //        string myScript = @"alertMsg('覆盖AP数量不能为空!','error.gif');";
            //        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
            //        return;
            //    }

            //}
            #endregion
            //批量删除
            string ClassList="";
            int n = 0;
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("lb_id")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cb_id");
                if (cb.Checked)
                {
                    ClassList += id.ToString();
                    n++;
                }
            }
            if (n == 0)
            {
                string myScript = @"alertMsg('请选择产品!','error.gif');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                return;
            }
            else if (n>1)
            {
                string myScript = @"alertMsg('只能选择一种商品推广!','error.gif');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                return;
            }
            try
            {
                modeluser = blluser.GetModelByName(Request.Cookies["UserPage_UID"].Value.ToString());
                Model.Channel cModel = new Model.Channel();
                BLL.Channel cbll = new BLL.Channel();
                cModel.Title = channelname.Text;
                cModel.CatalogID = "";//channeltype.SelectedValue;
                cModel.Name = "";//txtWebName.Text;
                cModel.Url = "";//txtWebUrl.Text;
                cModel.ParentId = int.Parse(ClassList);
                cModel.Status = 1;
                cModel.UserID = modeluser.ID;
                cModel.Bak1 = "game" + ClassList + "_" + DateTime.Now.ToString("MMdd");
                int num=cbll.Add(cModel);
                if (num>0)
                {
                    Model.Log modLog = new Model.Log();
                    modLog.UserId = num;
                    modLog.UserName = channelname.Text;
                    InsertLog(modLog);
                    string myScript = @"alertRedirectMsg('渠道添加成功!','success.gif','Channel.aspx');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                }
            }
            catch
            {
                string myScript = @"alertMsg('渠道添加失败!','error.gif');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                return;
            }
        }


        private void InsertLog(Model.Log model)
        {
            BLL.Log bllLog = new BLL.Log();
            model.LogType = "新增渠道";
            model.Description = "新增渠道成功";
            model.LogTime = DateTime.Now;
            model.IsRead = "未阅读";
            bllLog.Add(model);
        }
    }
}
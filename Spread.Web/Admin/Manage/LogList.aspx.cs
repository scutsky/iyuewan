using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using Spread.BLL;
using Spread.Model;
using Spread.Common;
using Spread.Web.UI;
namespace Spread.Web.Admin.Manage
{
    public partial class LogList : ManagePage
    {
        Spread.BLL.Log bll = new Spread.BLL.Log();
        public int pcount { get; set; } //总条数
        public int page { get; set; } //当前页
        public readonly int pagesize = 15; //设置每页显示的大小
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                chkLoginLevel("viewLog");
                RptBind();
            }
        }

        //绑定数据
        void RptBind()
        { 
            string where = "";
            if (Request.QueryString["page"] != null && Convert.ToInt32(Request.QueryString["page"]) > 0)
            {
                page = Convert.ToInt32(Request.QueryString["page"]);
            }
            else
            {
                page = 0;
            }
            //利用PAGEDDAGASOURCE类来分页
            PagedDataSource pg = new PagedDataSource();
            pg.DataSource = bll.GetList(where).Tables[0].DefaultView;
            pg.AllowPaging = true;
            pg.PageSize = pagesize;
            pg.CurrentPageIndex = page;
            //获得总条数
            pcount = bll.GetRecordCount(where);
            //绑定数据
            rptList.DataSource = pg;
            rptList.DataBind();
        }

        //批量删除
        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            chkLoginLevel("delLog");
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((Label)rptList.Items[i].FindControl("lb_id")).Text);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cb_id");
                if (cb.Checked)
                {
                    chkLoginLevel("delLog");
                    bll.Delete(id);
                }
            }
            JscriptPrint("批量删除成功啦！", "", "Success");
            RptBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(((Label)e.Item.FindControl("lb_id")).Text);
            Spread.BLL.Log bll = new Spread.BLL.Log();
            Spread.Model.Log model = bll.GetModel(id);
            model.IsRead = "已阅读";
            switch (e.CommandName.ToLower())
            {
                case "btread":
                    bll.UpdateRead(model);
                    if (model.LogType == "用户注册")
                    {
                        Response.Redirect("/Admin/User/List.aspx");
                    }
                    else if (model.LogType == "新增渠道")
                    {
                        Response.Redirect("/Admin/Channel/List.aspx");
                    }
                    else if (model.LogType == "添加游戏")
                    {
                        Response.Redirect("/Admin/Channel/GameList.aspx?id=" + model.UserId + "");
                    }
                    break;
            }
            RptBind();
        }
    }
}

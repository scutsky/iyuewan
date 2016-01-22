using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spread.Web.UI;


namespace Spread.Web.Admin.statistics
{
    public partial class ReportTempMain : ManagePage
    {
        public int kindId; //栏目种类
        Spread.BLL.ReportTempMain bll = new Spread.BLL.ReportTempMain();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                chkLoginLevel("viewMenu");
                BindData();
            }
        }

        //数据绑定
        private void BindData()
        {
            DataTable dt = bll.GetList(0, "", "ID").Tables[0];
            this.rptClassList.DataSource = dt;
            this.rptClassList.DataBind();
        }

        //设置删除操作
        protected void rptClassList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(((HiddenField)e.Item.FindControl("lb_id")).Value);
            Spread.BLL.ReportTempMain bllMain = new Spread.BLL.ReportTempMain();
            Spread.Model.ReportTempMain model = bll.GetModel(id);
            switch (e.CommandName.ToLower())
            {
                case "btndel":
                    bll.Delete(id);
                    break;
            }
            BindData();
        }

        //美化列表
        protected void rptClassList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }



        /// <summary>
        /// 分类路径
        /// </summary>
        protected DataTable MenuPath
        {
            get;
            set;
        }
    }
}

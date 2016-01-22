using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spread.Common;
using System.IO;
using System.Collections;
using System.Data.OleDb;
using Spread.DBUtility;

namespace Spread.Web.Admin.statistics
{
    public partial class DaycountDetail : Spread.Web.UI.ManagePage
    {
        public int pcount;                                   //总条数
        public int page;                                     //当前页
        public readonly int pagesize = 15;                    //设置每页显示的大小
        public readonly int kindId = 1;                      //类别种类

        public int userid;
        public string date = "";
        public string property = "";
        BLL.Channel bllChannel = new BLL.Channel();
        Model.Channel modChannel = new Model.Channel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.Params["userid"] as string, out this.userid))
            {
                JscriptMsg(350, 230, "错误提示", "<b>出现错误啦！</b>您要修改主键不明确或参数不正确。", "back", "Error");
                return;

            }
            if (Request.Params["date"] == null)
            {
                JscriptMsg(350, 230, "错误提示", "<b>出现错误啦！</b>您要修改主键不明确或参数不正确。", "back", "Error");
                return;

            }
            else
            {
                date = Request.Params["date"].ToString();
            }
            this.hduserid.Value = userid.ToString();
            this.hddate.Value = date.ToString();
            
            if (!Page.IsPostBack)
            {
                chkLoginLevel("viewUser");
                RptBind("  UserID='" + this.hduserid.Value + "' and SumDate='" + this.hddate.Value + "'", "ID asc");
            }
        }

      
        #region 数据列表绑定
        private void RptBind(string strWhere, string orderby)
        {
            if (!int.TryParse(Request.Params["page"] as string, out this.page))
            {
                this.page = 0;
            }
            Spread.BLL.Report bll = new Spread.BLL.Report();
            this.rptList.DataSource = bll.GetList(strWhere);
            this.rptList.DataBind();
        }
        #endregion
    }
}

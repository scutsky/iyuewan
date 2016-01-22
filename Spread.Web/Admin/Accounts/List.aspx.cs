using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spread.Common;
using Spread.DBUtility;
using System.Data.SqlClient;

namespace Spread.Web.Admin.Accounts
{
    public partial class List : Spread.Web.UI.ManagePage
    {
        public int pcount;                                   //总条数
        public int page;                                     //当前页
        public readonly int pagesize = 15;                    //设置每页显示的大小
        public readonly int kindId = 1;                      //类别种类

        public int UserType;
        public string keywords = "";
        public string property = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.Params["UserType"] as string, out this.UserType))
            {
                this.UserType = 0;
            }
            this.hdClassid.Value = UserType.ToString();

           

            if (!Page.IsPostBack)
            {
                chkLoginLevel("viewUser");
                RptBind("Id>0" + this.CombSqlTxt(this.UserType, this.keywords, this.property), "ApplyTime desc");
            }
        }

        #region 数据列表绑定
        private void RptBind(string strWhere, string orderby)
        {
            if (!int.TryParse(Request.Params["page"] as string, out this.page))
            {
                this.page = 0;
            }
            Spread.BLL.ReportAccounts bll = new Spread.BLL.ReportAccounts();
            //获得总条数
            this.pcount = bll.GetRecordCount(strWhere);
            this.rptList.DataSource = bll.GetPageList(this.pagesize, this.page, strWhere, orderby);
            this.rptList.DataBind();
        }
        #endregion



        #region 组合查询语句
        protected string CombSqlTxt(int _classId, string _keywords, string _property)
        {
            StringBuilder strTemp = new StringBuilder();
            //_keywords = _keywords.Replace("'", "");
            //if (_classId > 0)
            //{
            //    strTemp.Append(" and UserID=" + _classId + "");
            //    //strTemp.Append(" and ClassId in(select Id from Channel where KindId=" + this.kindId + " and ClassList like '%," + _classId + ",%')");
            //}
            //if (!string.IsNullOrEmpty(_keywords))
            //{
            //    strTemp.Append(" and Name like '%" + _keywords + "%'");
            //}
            //if (!string.IsNullOrEmpty(_property))
            //{
            //    switch (_property)
            //    {
            //        case "isLock":
            //            strTemp.Append(" and IsLock=1");
            //            break;
            //        case "isNoLock":
            //            strTemp.Append(" and IsLock=0");
            //            break;

            //    }
            //}

            return strTemp.ToString();
        }
        #endregion

        #region 组合URL语句
        protected string CombUrlTxt(int _classId, string _keywords, string _property)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            //if (_classId > 0)
            //{
            //    strTemp.Append("UserType=" + _classId.ToString() + "&");
            //}
            //if (!string.IsNullOrEmpty(_keywords))
            //{
            //    strTemp.Append("keywords=" + Server.UrlEncode(_keywords) + "&");
            //}
            //if (!string.IsNullOrEmpty(_property))
            //{
            //    strTemp.Append("property=" + _property + "&");
            //}

            return strTemp.ToString();
        }
        #endregion

        //设置操作
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(((Label)e.Item.FindControl("lb_id")).Text);
            Spread.BLL.ReportAccounts bll = new Spread.BLL.ReportAccounts();
            Spread.Model.ReportAccounts model = bll.GetModel(id);
            switch (e.CommandName.ToLower())
            {
                case "ibtnstatus":
                    if (model.Status == "待审核")
                        bll.UpdateField(id, "Status='已审核'");
                    break;
            }
            RptBind("Id>0" + this.CombSqlTxt(this.UserType, this.keywords, this.property), "ApplyTime desc");
        }

        //分类筛选
        protected void ddlClassId_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int _classId;
            //if (int.TryParse(this.ddlClassId.SelectedValue.ToString(), out _classId))
            //{
            //    Response.Redirect("list.aspx?" + this.CombUrlTxt(_classId, this.keywords, this.property) + "page=0");
            //}
            //else
            //{
            //    Response.Redirect("list.aspx?" + this.CombUrlTxt(0, this.keywords, this.property) + "page=0");
            //}
        }

        //属性筛选
        protected void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Response.Redirect("List.aspx?" + this.CombUrlTxt(this.UserType, this.keywords, this.ddlProperty.SelectedValue) + "page=0");
        }

        //查询
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            //Response.Redirect("List.aspx?" + this.CombUrlTxt(this.UserType, txtKeywords.Text.Trim(), this.property) + "page=0");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try{
                BLL.ReportAccounts bllAcc = new BLL.ReportAccounts();
                 string SettlementCycle=DateTime.Now.ToString("yyyy-MM-dd");
                 if (bllAcc.GetRecordCount(" SettlementCycle='" + SettlementCycle + "'") > 0)
                 {
                     SqlParameter[] parameters = {
                        new SqlParameter("@SettlementCycle", SqlDbType.NVarChar,50)};
                     parameters[0].Value = SettlementCycle;
                     DbHelper.RunProcedure("SP_Process_ReportAccout", parameters);
                     JscriptMsg(350, 230, "操作成功", "操作成功", "back", "Success");
                 }
                 else
                 {
                     JscriptMsg(350, 230, "提示", "<b>今天已结算！</b>", "back", "Error");
                 }
               
            }catch{
                JscriptMsg(350, 230, "错误提示", "<b>操作提示！</b>", "back", "Error");
            }
        }
       

    }
}

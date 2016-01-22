using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spread.Common;

namespace Spread.Web.Admin.User
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
           
            if (!string.IsNullOrEmpty(Request.Params["keywords"]))
            {
                this.keywords = Request.Params["keywords"].Trim();
            }
            if (!string.IsNullOrEmpty(Request.Params["property"]))
            {
                this.property = Request.Params["property"].Trim();
            }

            if (!Page.IsPostBack)
            {
                chkLoginLevel("viewUser");
                RptBind("Id>0" + this.CombSqlTxt(this.UserType, this.keywords, this.property), "RegDate desc");
            }
        }

        #region 数据列表绑定
        private void RptBind(string strWhere, string orderby)
        {
            if (!int.TryParse(Request.Params["page"] as string, out this.page))
            {
                this.page = 0;
            }
            Spread.BLL.User bll = new Spread.BLL.User();
            //获得总条数
            this.pcount = bll.GetRecordCount(strWhere);
            if (this.pcount > 0)
            {
                this.lbtnDel.Enabled = true;
            }
            else
            {
                this.lbtnDel.Enabled = false;
            }
            if (this.UserType > 0)
            {
                this.ddlClassId.SelectedValue = this.UserType.ToString();
                this.ddlClassId.Enabled = false;
            }
            this.txtKeywords.Text = this.keywords;
            this.ddlProperty.SelectedValue = this.property;

            this.rptList.DataSource = bll.GetPageList(this.pagesize, this.page, strWhere, orderby);
            this.rptList.DataBind();
        }
        #endregion



        #region 组合查询语句
        protected string CombSqlTxt(int _classId, string _keywords, string _property)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (_classId > 0)
            {
                strTemp.Append(" and UserType=" + _classId + "");
                //strTemp.Append(" and ClassId in(select Id from Channel where KindId=" + this.kindId + " and ClassList like '%," + _classId + ",%')");
            }
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and Name like '%" + _keywords + "%'");
            }
            if (!string.IsNullOrEmpty(_property))
            {
                switch (_property)
                {
                    case "isLock":
                        strTemp.Append(" and IsLock=1");
                        break;
                    case "isNoLock":
                        strTemp.Append(" and IsLock=0");
                        break;
                        
                }
            }

            return strTemp.ToString();
        }
        #endregion

        #region 组合URL语句
        protected string CombUrlTxt(int _classId, string _keywords, string _property)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (_classId > 0)
            {
                strTemp.Append("UserType=" + _classId.ToString() + "&");
            }
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append("keywords=" + Server.UrlEncode(_keywords) + "&");
            }
            if (!string.IsNullOrEmpty(_property))
            {
                strTemp.Append("property=" + _property + "&");
            }

            return strTemp.ToString();
        }
        #endregion

        //设置操作
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(((Label)e.Item.FindControl("lb_id")).Text);
            Spread.BLL.User bll = new Spread.BLL.User();
            Spread.Model.User model = bll.GetModel(id);
            switch (e.CommandName.ToLower())
            {
                case "ibtnmsg":
                    if (model.IsLock == true)
                        bll.UpdateField(id, "IsLock=0");
                    else
                        bll.UpdateField(id, "IsLock=1");
                    break;
            }
            RptBind("Id>0" + this.CombSqlTxt(this.UserType, this.keywords, this.property), "AddTime desc");
        }

        //分类筛选
        protected void ddlClassId_SelectedIndexChanged(object sender, EventArgs e)
        {
            int _classId;
            if (int.TryParse(this.ddlClassId.SelectedValue.ToString(), out _classId))
            {
                Response.Redirect("list.aspx?" + this.CombUrlTxt(_classId, this.keywords, this.property) + "page=0");
            }
            else
            {
                Response.Redirect("list.aspx?" + this.CombUrlTxt(0, this.keywords, this.property) + "page=0");
            }
        }

        //属性筛选
        protected void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx?" + this.CombUrlTxt(this.UserType, this.keywords, this.ddlProperty.SelectedValue) + "page=0");
        }

        //查询
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx?" + this.CombUrlTxt(this.UserType, txtKeywords.Text.Trim(), this.property) + "page=0");
        }
        //删除
        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            chkLoginLevel("delUser");
            Spread.BLL.User bll = new Spread.BLL.User();
            //批量删除
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((Label)rptList.Items[i].FindControl("lb_id")).Text);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cb_id");
                if (cb.Checked)
                {
                    bll.Delete(id);
                }
            }
            JscriptPrint("批量删除成功啦！", "List.aspx?" + CombUrlTxt(this.UserType, this.keywords, this.property) + "page=0", "Success");
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {

        }

    }
}

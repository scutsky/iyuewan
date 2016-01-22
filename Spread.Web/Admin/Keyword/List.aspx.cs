using System;
using System.Text;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Spread.Common;
using Spread.Web.UI;
namespace Spread.Web.Admin.Keyword
{
    public partial class List :ManagePage
    {
        public int pcount;                                   //总条数
        public int page;                                     //当前页
        public readonly int pagesize = 14;                    //设置每页显示的大小
        public readonly int kindId = 2;                      //类别种类

        public int classId;
        public string property = "";
        public string keywords = "";
        public string prolistview = "";

        Spread.BLL.Tag bll = new Spread.BLL.Tag();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.Params["classId"] as string, out this.classId))
            {
                this.classId = 0;
            }

            if (!this.IsPostBack)
            {
                chkLoginLevel("viewKeyword");
                BindTree();
                this.RptBind("Id>0" + CombSqlTxt(this.classId, this.keywords, this.property), "CountTime desc");
            }
        }

        public void BindTree()
        {
            Spread.BLL.TagCategory bll = new Spread.BLL.TagCategory();
            string strWhere = "";
            DataTable dt = bll.GetList(strWhere).Tables[0];

            this.ddlTagCategoryId.Items.Clear();
            this.ddlTagCategoryId.Items.Add(new ListItem("所有类别", ""));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["ID"].ToString().Trim();
                string Title = dr["Name"].ToString().Trim();

                this.ddlTagCategoryId.Items.Add(new ListItem(Title, Id));
            }
        }

        #region 数据列表绑定
        private void RptBind(string strWhere, string orderby)
        {
            if (!int.TryParse(Request.Params["page"] as string, out this.page))
            {
                this.page = 0;
            }
            //获得总条数
            this.pcount = bll.GetCount(strWhere);
            if (this.pcount > 0)
            {
                this.lbtnDel.Enabled = true;
            }
            else
            {
                this.lbtnDel.Enabled = false;
            }
            if (this.classId > 0)
            {
                this.ddlTagCategoryId.SelectedValue = this.classId.ToString();
            }

            this.rptList.DataSource = bll.GetPageList(this.pagesize, this.page, strWhere, orderby);
            this.rptList.DataBind();

        }
        #endregion

        #region 组合查询语句
        protected string CombSqlTxt(int _classId, string _keywords, string _property)
        {
            StringBuilder strTemp = new StringBuilder();           
            if (_classId > 0)
            {
                strTemp.Append(" and TagCategoryID=" + _classId + "");
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
                strTemp.Append("classId=" + _classId.ToString() + "&");
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

        //批量删除
        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            chkLoginLevel("delKeyword");
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((Label)rptList.Items[i].FindControl("lb_id")).Text);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cb_id");
                if (cb.Checked)
                {
                    bll.Delete(id);
                }
            }
            JscriptPrint("批量删除成功啦！", "", "Success");
            this.RptBind("Id>0" + CombSqlTxt(this.classId, this.keywords, this.property), "CountTime desc");
        }

        protected void ddlTagCategoryId_SelectedIndexChanged(object sender, EventArgs e)
        {
            int _classId;
            if (int.TryParse(this.ddlTagCategoryId.SelectedValue.ToString(), out _classId))
            {
                Response.Redirect("List.aspx?" + this.CombUrlTxt(_classId, this.keywords, this.property) + "page=0");
            }
            else
            {
                Response.Redirect("List.aspx?" + this.CombUrlTxt(0, this.keywords, this.property) + "page=0");
            }
        }
        public string ShowClass(string ID)
        {
            string title = "";
            Spread.BLL.TagCategory bll = new Spread.BLL.TagCategory();
            Spread.Model.TagCategory model = new Spread.Model.TagCategory();
            model = bll.GetModel(int.Parse(ID));
            if (model != null)
            {
                title = model.Name;
            }
            return title;
        }
    }
}

    




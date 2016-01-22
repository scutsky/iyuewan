using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spread.Common;

namespace Spread.Web.Admin.Directory
{
    public partial class ListGoods : Spread.Web.UI.ManagePage
    {
        public int pcount;                                   //总条数
        public int page;                                     //当前页
        public readonly int pagesize = 15;                    //设置每页显示的大小
        public readonly int kindId = 1;                      //类别种类

        public int classId;
        public string keywords = "";
        public string property = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.Params["classId"] as string, out this.classId))
            {
                this.classId = 0;
            }
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
                chkLoginLevel("viewGoods");
                this.TreeBind();
                RptBind("Id>0 and LanguageType='zh' " + this.CombSqlTxt(this.classId, this.keywords, this.property), "AddTime desc");
            }
        }

        #region 数据列表绑定
        private void RptBind(string strWhere, string orderby)
        {
            if (!int.TryParse(Request.Params["page"] as string, out this.page))
            {
                this.page = 0;
            }
            Spread.BLL.DirectoryGoods bll = new Spread.BLL.DirectoryGoods();
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
                this.ddlClassId.SelectedValue = this.classId.ToString();
            }
            this.txtKeywords.Text = this.keywords;
           
            this.rptList.DataSource = bll.GetPageList(this.pagesize, this.page, strWhere, orderby);
            this.rptList.DataBind();
        }
        #endregion

        #region 类别绑定
        private void TreeBind()
        {
            Spread.BLL.MenuDirectory cbll = new Spread.BLL.MenuDirectory();
            //DataTable dt = cbll.GetList(0, this.kindId);
            DataTable dt = cbll.GetList(" LanguageType='zh'").Tables[0];
            this.ddlClassId.Items.Clear();
            this.ddlClassId.Items.Add(new ListItem("所有类别", ""));
            foreach (DataRow dr in dt.Rows)
            {
                int ClassLayer = Convert.ToInt32(dr["ClassLayer"]);
                string Id = dr["Id"].ToString().Trim();
                string Title = dr["Title"].ToString().Trim();

                if (ClassLayer == 1)
                {
                    this.ddlClassId.Items.Add(new ListItem(Title, Id));

                }
                else
                {
                    Title = "├ " + Title;
                    Title = StringPlus.StringOfChar(ClassLayer - 1, "　") + Title;

                    this.ddlClassId.Items.Add(new ListItem(Title, Id));
                }
            }
        }
        #endregion

        #region 组合查询语句
        protected string CombSqlTxt(int _classId, string _keywords, string _property)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (_classId > 0)
            {
                strTemp.Append(" and ClassId in(select Id from Menu where  ClassList like '%," + _classId + ",%')");
                //strTemp.Append(" and ClassId in(select Id from Channel where KindId=" + this.kindId + " and ClassList like '%," + _classId + ",%')");
            }
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and Title like '%" + _keywords + "%'");
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

        //设置操作
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(((Label)e.Item.FindControl("lb_id")).Text);
            Spread.BLL.DirectoryGoods bll = new Spread.BLL.DirectoryGoods();
            Spread.Model.DirectoryGoods model = bll.GetModel(id);
            switch (e.CommandName.ToLower())
            {
                case "ibtnmsg":
                    if (model.IsMsg ==true)
                        bll.UpdateField(id, "IsMsg=false");
                    else
                        bll.UpdateField(id, "IsMsg=true");
                    break;
                case "ibtntop":
                    if (model.IsTop == true)
                        bll.UpdateField(id, "IsTop=false");
                    else
                        bll.UpdateField(id, "IsTop=true");
                    break;
                case "ibtnred":
                    if (model.IsRed == true)
                        bll.UpdateField(id, "IsRed=false");
                    else
                        bll.UpdateField(id, "IsRed=true");
                    break;
                case "ibtnhot":
                    if (model.IsHot == true)
                        bll.UpdateField(id, "IsHot=false");
                    else
                        bll.UpdateField(id, "IsHot=true");
                    break;
                case "ibtnslide":
                    if (model.IsSlide == true)
                        bll.UpdateField(id, "IsSlide=false");
                    else
                        bll.UpdateField(id, "IsSlide=true");
                    break;
            }
            RptBind("Id>0 and LanguageType='zh' " + this.CombSqlTxt(this.classId, this.keywords, this.property), "AddTime desc");
        }

        //分类筛选
        protected void ddlClassId_SelectedIndexChanged(object sender, EventArgs e)
        {
            int _classId;
            if (int.TryParse(this.ddlClassId.SelectedValue.ToString(), out _classId))
            {
                Response.Redirect("ListGoods.aspx?" + this.CombUrlTxt(_classId, this.keywords, this.property) + "page=0");
            }
            else
            {
                Response.Redirect("ListGoods.aspx?" + this.CombUrlTxt(0, this.keywords, this.property) + "page=0");
            }
        }

        //属性筛选
        protected void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("ListGoods.aspx?" + this.CombUrlTxt(this.classId, this.keywords, this.property) + "page=0");
        }

        //查询
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListGoods.aspx?" + this.CombUrlTxt(this.classId, txtKeywords.Text.Trim(), this.property) + "page=0");
        }
        //删除
        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            chkLoginLevel("delGoods");
            Spread.BLL.DirectoryGoods bll = new Spread.BLL.DirectoryGoods();
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
            JscriptPrint("批量删除成功啦！", "ListGoods.aspx?" + CombUrlTxt(this.classId, this.keywords, this.property) + "page=0", "Success");
        }

    }
}

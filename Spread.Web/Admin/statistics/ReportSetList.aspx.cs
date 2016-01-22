using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spread.Common;
namespace Spread.Web.Admin.statistics
{
    public partial class ReportSetList : Spread.Web.UI.ManagePage
    {
        public int pcount;                                   //总条数
        public int page;                                     //当前页
        public readonly int pagesize = 15;                    //设置每页显示的大小
        public readonly int kindId = 1;                      //类别种类

        public int UserType;
        public string keywords = "";
        public string property = "";

        BLL.Menu bllMenu = new BLL.Menu();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.Params["UserType"] as string, out this.UserType))
            {
                this.UserType = 0;
            }
            //this.hdClassid.Value = UserType.ToString();

            if (!string.IsNullOrEmpty(Request.Params["keywords"]))
            {
                this.keywords = Request.Params["keywords"].Trim();
            }
            if (!Page.IsPostBack)
            {
                chkLoginLevel("viewUser");
                RptBind("Id>0" + this.CombSqlTxt(this.keywords), "ID asc");
            }
        }

        #region 数据列表绑定
        private void RptBind(string strWhere, string orderby)
        {
            if (!int.TryParse(Request.Params["page"] as string, out this.page))
            {
                this.page = 0;
            }
            Spread.BLL.ReportSet bll = new Spread.BLL.ReportSet();
            //获得总条数
            this.pcount = bll.GetRecordCount(strWhere);
            this.rptList.DataSource = bll.GetPageList(this.pagesize, this.page, strWhere, orderby);
            this.rptList.DataBind();
        }
        #endregion

        #region 组合查询语句
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and Title like '%" + _keywords + "%'");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 组合URL语句
        protected string CombUrlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append("keywords=" + Server.UrlEncode(_keywords) + "&");
            }
            return strTemp.ToString();
        }
        #endregion

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
            JscriptPrint("批量删除成功啦！", "ReportSetList.aspx?" + CombUrlTxt(this.keywords) + "page=0", "Success");
        }

        /// <summary>
        /// 获取子节点连接
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        protected string getName(object id)
        {
            string strId =id.ToString();
            if (strId == "0")
            {
                return "第一列";
            }
            else if (strId == "1")
            {
                return "第二列";
            }
            else if (strId == "2")
            {
                return "第三列";
            }
            else if (strId == "3")
            {
                return "第四列";
            }
            else if (strId == "4")
            {
                return "第五列";
            }
            else if (strId == "5")
            {
                return "第六列";
            }
            else if (strId == "6")
            {
                return "第七列";
            }
            else if (strId == "7")
            {
                return "第八列";
            }
            else if (strId == "8")
            {
                return "第九列";
            }
            else if (strId == "9")
            {
                return "第十列";
            }
            else if (strId == "10")
            {
                return "第十一列";
            }
            else if (strId == "11")
            {
                return "第十二列";
            }
            else if (strId == "12")
            {
                return "第十三列";
            }
            else if (strId == "13")
            {
                return "第十四列";
            }
            else if (strId == "14")
            {
                return "第十五列";
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 获取子节点连接
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        protected string getMenuName(object id)
        {
            int Id = int.Parse(id.ToString());
            Model.Menu modelMenu=new Model.Menu();

            modelMenu = bllMenu.GetModel(Id);
            if (modelMenu!=null)
            {
                return modelMenu.Title;
            }
            else
            {
                return "";
            }
        }

        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(((HiddenField)e.Item.FindControl("lb_id")).Value);
            Spread.BLL.ReportSet bll = new Spread.BLL.ReportSet();
            Spread.Model.ReportSet model = bll.GetModel(id);
            switch (e.CommandName.ToLower())
            {
                case "btndel":
                        bll.Delete(id);
                    break;
            }
            RptBind("Id>0" + this.CombSqlTxt(this.keywords), "ID asc");
        }
    }
}

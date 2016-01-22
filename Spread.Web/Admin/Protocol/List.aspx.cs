using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spread.Common;

namespace Spread.Web.Admin.Protocol
{
    public partial class List : Spread.Web.UI.ManagePage
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
                chkLoginLevel("viewProtocol");
                RptBind("Id>0" + this.CombSqlTxt(this.classId, this.keywords, this.property), "AddTime desc");
            }
        }

        #region 数据列表绑定
        private void RptBind(string strWhere, string orderby)
        {
            if (!int.TryParse(Request.Params["page"] as string, out this.page))
            {
                this.page = 0;
            }
            Spread.BLL.Protocol bll = new Spread.BLL.Protocol();
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
                strTemp.Append(" and ClassId=" + _classId + "");
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
            Spread.BLL.Protocol bll = new Spread.BLL.Protocol();
            Spread.Model.Protocol model = bll.GetModel(id);
            
            RptBind("Id>0" + this.CombSqlTxt(this.classId, this.keywords, this.property), "AddTime desc");
        }


        //删除
        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            chkLoginLevel("delProtocol");
            Spread.BLL.Protocol bll = new Spread.BLL.Protocol();
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
            JscriptPrint("批量删除成功啦！", "List.aspx?" + CombUrlTxt(this.classId, this.keywords, this.property) + "page=0", "Success");
        }

    }
}

using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spread.Web.UI;

namespace Spread.Web.Admin.Menu
{
    public partial class List : ManagePage
    {
        public int kindId; //栏目种类
        Spread.BLL.Menu bll = new Spread.BLL.Menu();
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
            DataTable dt = bll.GetList(0, "", "ClassOrder").Tables[0];
            this.rptClassList.DataSource = dt;
            this.rptClassList.DataBind();
        }

        //设置删除操作
        protected void rptClassList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
           
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

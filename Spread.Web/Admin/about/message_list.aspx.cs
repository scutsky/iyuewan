using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spread.Web.UI;

namespace Spread.Web.Admin.about
{
    public partial class message_list : ManagePage
    {
        public int kindId; //栏目种类
        Spread.BLL.Messages bll = new Spread.BLL.Messages();
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
            
            DataTable dt = bll.GetList(0, " Type='中文' ", "ID").Tables[0];

            this.rptClassList.DataSource = dt;
            this.rptClassList.DataBind();
        }

        //设置删除操作
        protected void rptClassList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField txtId = (HiddenField)e.Item.FindControl("txtId");
            int id = Convert.ToInt32(txtId.Value);
            switch (e.CommandName.ToLower())
            {
                case "btndel":
                    bll.Delete(id);
                    BindData();
                    JscriptPrint("批量删除成功啦！", "", "Success");
                    break;
            }
        }

        //美化列表
        protected void rptClassList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            
        }

        /// <summary>
        /// 获取子节点连接
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        protected string getSubLink(object id, object title, object layer)
        {
            int classLayer = Convert.ToInt32(layer.ToString());
            if (classLayer >= 3)
            {
                return title.ToString();
            }
            else
            {
                return string.Format("<a href=\"List.aspx?pid={0}\" title=\"查看子分类\">{1}</a>", id, title);
            }
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

using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spread.Web.UI;

namespace Spread.Web.Admin.Channel
{
    public partial class Plist : ManagePage
    {
        public int classId;
        Spread.BLL.Pchannel bll = new Spread.BLL.Pchannel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.Params["classId"] as string, out this.classId))
            {
                this.classId = 0;
            }
            if (!Page.IsPostBack)
            {
                chkLoginLevel("viewChannel");
                BindData();
            }
        }
       
        //数据绑定
        private void BindData()
        {
            if (classId > 0)
            {
                DataTable dt = bll.GetList("").Tables[0];
                this.rptClassList.DataSource = dt;
                this.rptClassList.DataBind();
               
            }
            else
            {
                DataTable dt = bll.GetList("").Tables[0];
                this.rptClassList.DataSource = dt;
                this.rptClassList.DataBind();
            }
        }

        //删除操作
        protected void rptClassList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(((HiddenField)e.Item.FindControl("lb_id")).Value);
            Spread.BLL.Pchannel bll = new Spread.BLL.Pchannel();
            Spread.Model.Pchannel model = bll.GetModel(id);
            switch (e.CommandName.ToLower())
            {
                case "btndel":
                    bll.Delete(id);
                    break;
            }
            BindData();
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
        protected DataTable ChannelPath
        {
            get;
            set;
        }
    }
}

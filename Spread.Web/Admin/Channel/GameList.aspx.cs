using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spread.Web.UI;

namespace Spread.Web.Admin.Channel
{
    public partial class GameList : ManagePage
    {
        public int Id;
        Spread.BLL.ExtendGame bll = new Spread.BLL.ExtendGame();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.Params["Id"] as string, out this.Id))
            {
                this.Id = 0;
            }
            if (!Page.IsPostBack)
            {
                chkLoginLevel("viewExtendGame");
                BindData();
            }
        }
        
        //数据绑定
        private void BindData()
        {
            DataTable dt = bll.GetList("ChanelID='" + Id + "'").Tables[0];
            this.rptClassList.DataSource = dt;
            this.rptClassList.DataBind();
        }

        //删除操作
        protected void rptClassList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField txtClassId = (HiddenField)e.Item.FindControl("txtClassId");
            int id = Convert.ToInt32(txtClassId.Value);
            //switch (e.CommandName.ToLower())
            //{
            //    case "btndel":
            //        bll.Delete(Convert.ToInt32(txtClassId.Value));
            //        BindData();
            //        JscriptPrint("批量删除成功啦！", "", "Success");
            //        break;
            //    case "ibtnshow":
            //        Spread.Model.Channel model = bll.GetModel(id);
            //        if (model.IsShow == true)
            //            bll.UpdateField(id, "IsShow=false");
            //        else
            //            bll.UpdateField(id, "IsShow=true");
            //        BindData();
            //        break;               
            //    case "ibtnlock":
            //        Spread.Model.Channel model2 = bll.GetModel(id);
            //        if (model2.IsLock == true)
            //            bll.UpdateField(id, "IsLock=false");
            //        else
            //            bll.UpdateField(id, "IsLock=true");
            //        BindData();
            //        break;
            //}
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

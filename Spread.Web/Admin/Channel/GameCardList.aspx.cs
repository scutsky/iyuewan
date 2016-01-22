using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spread.Web.UI;

namespace Spread.Web.Admin.Channel
{
    public partial class GameCardList : ManagePage
    {
        private Spread.BLL.ExtendGame bll = new Spread.BLL.ExtendGame();
        private Spread.Model.ExtendGame model = new Spread.Model.ExtendGame();
        public int id;    //ID
        public int cid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (int.TryParse(Request.Params["id"], out id) && int.TryParse(Request.Params["cid"], out cid))
            {
                model = bll.GetModel(id);
                if (!Page.IsPostBack)
                {
                    //ShowInfo();
                }
            }
            else
            {
                JscriptMsg(350, 230, "错误提示", "<b>出现错误啦！</b>您要修改主键不明确或参数不正确。", "back", "Error");
            }
        }
    }
}
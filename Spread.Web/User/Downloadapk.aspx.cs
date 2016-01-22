using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Spread.Web.User
{
    public partial class Downloadapk : System.Web.UI.Page
    {
        private Spread.BLL.ExtendGame bll = new Spread.BLL.ExtendGame();
        private Spread.Model.ExtendGame model = new Spread.Model.ExtendGame();
        public int id;    //ID
        public string Verifycode;
        protected void Page_Load(object sender, EventArgs e)
        {
            //取得栏目传参
            Verifycode = Request.Params["vc"];
            if (int.TryParse(Request.Params["id"], out id))
            {
                model = bll.GetModel(id);
                //model.Bak1 = "http://downali.game.uc.cn/wm/0/16/51117175955_skzhv1.0.5_UCv3.5.3.1_3000zhengshi_3621104_132311a58e9d.apk";

                if (model.Verifycode != null && model.Verifycode.Equals(Verifycode) && !string.IsNullOrEmpty(model.Bak1))
                {
                    Response.Redirect(model.Bak1);
                }
            }
            Response.Write("资源不存在");
        }
    }
}
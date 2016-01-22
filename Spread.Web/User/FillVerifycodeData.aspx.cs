using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spread.Common;

namespace Spread.Web.User
{
    public partial class FillVerifycodeData : System.Web.UI.Page
    {
        private Spread.BLL.ExtendGame bll = new Spread.BLL.ExtendGame();
        private Spread.Model.ExtendGame model = new Spread.Model.ExtendGame();
        protected void Page_Load(object sender, EventArgs e)
        {
            Console.WriteLine("begin fill verifycode" + System.DateTime.Now);
            bool flag = true;
            int count = 0;
            while (flag) {
                List<Model.ExtendGame> models = bll.GetTopList(20, " Verifycode is null", "");
                count += models.Count;
                if (models.Count > 0)
                {
                    foreach(Model.ExtendGame model in models) {
                        model.Verifycode = VerifycodeUtils.genVerifycode(6);
                        if (!bll.SetVerifycode(model)) {
                            Console.WriteLine("set verifycode fail : " + model.ID);
                        }
                    }
                    Console.WriteLine("success number : " + models.Count);
                }
                else {
                    flag = false;
                }
            }
            Console.WriteLine("fill verifycode end success number : " + count);
        }
    }
}
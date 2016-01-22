using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Spread.Web
{
    public partial class step3Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (password.Value.Replace(" ", "") != confirmpassword.Value.Replace(" ", ""))
                {
                    string myScript = @"alertMsg('密码不相同!','error.gif');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                    return;
                }
                else
                {
                    if (Session["changeName"] != null)
                    {
                        Spread.BLL.User bll = new BLL.User();
                        string name = Session["changeName"].ToString();
                        if (bll.UpdatePassword(name, this.password.Value))
                        {
                            string myScript = @"alertRedirectMsg('密码修改成功!','success.gif','Index.aspx');";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                        }
                        else
                        {
                            string myScript = @"alertMsg('密码修改错误!','error.gif');";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                            return;
                        }
                    }
                    else
                    {
                        string myScript = @"alertMsg('密码修改错误!','error.gif');";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                        return;
                    }
                }
            }
            catch
            {
                string myScript = @"alertMsg('密码修改错误!','error.gif');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                return;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Spread.Web
{
    public partial class Register : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitbtn_Click(object sender, EventArgs e)
        {
            try
            {

                Spread.Model.User model = new Model.User();
                Spread.BLL.User bll = new BLL.User();
                if (bll.chkExists(this.username.Value))
                {
                    string myScript = @"alertMsg('用户名已存在!','error.gif');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                    return;
                }
                if (this.usertype01.Checked)
                {
                    model.UserType = 1;
                }
                else
                {
                    model.UserType = 2;
                }
                model.Name = this.username.Value;
                model.Password =Common.DESEncrypt.Encrypt(this.password.Value);
                model.CompanyName = this.company.Value;
                model.CompanyAddress = this.address.Value;
                model.RegistrationMark = this.license.Value;
                model.TrueName = this.legal.Value;
                model.IdentityCard = this.legalidcard.Value;
                model.CorporateName = this.contact.Value;
                model.QQ = this.contactqq.Value;
                model.Email = this.email.Value;
                model.Applicationdesc = this.remark.Value;
                model.Phone = this.telphone.Value;
                model.Tel = this.tel.Value;
                model.RegDate = DateTime.Now;
                model.LastLogin = DateTime.Now;
                int num=bll.Add(model);
                if (num > 0)
                {
                    Model.Log modLog = new Model.Log();
                    modLog.UserId = num;
                    modLog.UserName = this.username.Value;
                    InsertLog(modLog);
                    string myScript = @"alertRedirectMsg('注册成功!','success.gif','Index.aspx');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);

                }
                else
                {
                    string myScript = @"alertMsg('注册失败!','error.gif');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);

                }
            }
            catch
            {
                string myScript = @"alertMsg('注册失败!','error.gif');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
            }
            
        }

        protected void submitbtn2_Click(object sender, EventArgs e)
        {
            try
            {
                Spread.Model.User model = new Model.User();
                Spread.BLL.User bll = new BLL.User();
                if (bll.chkExists(this.gusername.Value))
                {
                    string myScript = @"alertMsg('用户名已存在!','error.gif');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                    return;
                }
                if (this.gusertype01.Checked)
                {
                    model.UserType = 1;
                }
                else
                {
                    model.UserType = 2;
                }
                model.Name = this.gusername.Value;
                model.Password = Common.DESEncrypt.Encrypt(this.gpassword.Value); 
                model.TrueName = this.gcontactor.Value;
                model.IdentityCard = "";// this.gidcard.Value;
                model.PaypalAccount = this.gpaypalAccount.Value;
                if (this.gsex01.Checked)
                {
                    model.Sex = true;
                }
                else
                {
                    model.Sex = false;
                }
                model.QQ = this.gqq.Value;
                model.RegistrationMark = this.gqq.Value;
                model.Email = "";//this.gemail.Value;
                model.Applicationdesc = this.gremark.Value;
                model.Phone = this.gtelphone.Value;
                model.Tel = "";// this.gtel.Value;
                model.RegDate = DateTime.Now;
                model.LastLogin = DateTime.Now;
                int num = bll.Add(model);
                if (num > 0)
                {
                    Model.Log modLog = new Model.Log();
                    modLog.UserId = num;
                    modLog.UserName = this.gusername.Value;                    
                    InsertLog(modLog);
                    string myScript = @"alertRedirectMsg('注册成功!','success.gif','registerSuccess.aspx');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);

                }
                else
                {
                    string myScript = @"alertMsg('注册失败!','error.gif');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);

                }
            }
            catch
            {
                string myScript = @"alertMsg('注册失败!','error.gif');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
            }
            
        }

        private void InsertLog(Model.Log model)
        {
            BLL.Log bllLog = new BLL.Log();
            model.LogType = "用户注册";
            model.Description = "注册成功";
            model.LogTime = DateTime.Now;
            model.IsRead = "未阅读";
            bllLog.Add(model);
        }
    }

   
}
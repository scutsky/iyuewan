using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spread.Common;

namespace Spread.Web.Admin.User
{
    public partial class Detail : Spread.Web.UI.ManagePage
    {
        Spread.BLL.User bll = new Spread.BLL.User();
        protected internal Spread.Model.User userModel;
        public int Id;
        public string strPwd = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.Params["id"] as string, out this.Id))
            {
                JscriptMsg(350, 230, "错误提示", "<b>出现错误啦！</b>您要修改的信息不存在或参数不正确。", "back", "Error");
                return;
            }
            
            if (!Page.IsPostBack)
            {
                userModel = bll.GetModel(this.Id);
                strPwd = DESEncrypt.Decrypt(userModel.Password);
                if (userModel.UserType == 1)
                {
                    this.Panel1.Visible = false;
                    this.Panel2.Visible = true;
                    QyView(userModel);
                }
                else
                {
                    this.Panel1.Visible = true;
                    this.Panel2.Visible = false;
                    GrView(userModel);
                }
            }
        }

        private void QyView(Model.User model)
        {
            txtqCompanyName.Text = model.CompanyName;
            txtqCompanyAddress.Text = model.CompanyAddress;
            txtqRegistrationMark.Text = model.RegistrationMark;
            txtqTrueName.Text = model.TrueName;
            txtgIdentityCard.Text = model.IdentityCard;
            txtqCorporateName.Text = model.CorporateName;
            txtqQQ.Text = model.QQ;
            txtqEmail.Text = model.Email;
            txtqApplicationdesc.Text = model.Applicationdesc;
            txtqPhone.Text = model.Phone;
            txtqTel.Text = model.Tel;
        }
        private void GrView(Model.User model)
        {
            txtTrueName.Text = model.TrueName;
            txtIdentityCard.Text = model.IdentityCard;
            txtQQ.Text = model.QQ;
            txtEmail.Text = model.Email;
            txtApplicationdesc.Text = model.Applicationdesc;
            txtPhone.Text = model.Phone;
            txtTel.Text = model.Tel;
            txtPaypalAccount.Text = model.PaypalAccount;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                userModel = bll.GetModel(this.Id);
                userModel.TrueName = txtTrueName.Text;
                userModel.IdentityCard = txtIdentityCard.Text;
                userModel.QQ = txtQQ.Text;
                userModel.Email = txtEmail.Text;
                userModel.Applicationdesc = txtApplicationdesc.Text;
                userModel.Phone = txtPhone.Text;
                userModel.Tel = txtTel.Text;
                userModel.PaypalAccount = txtPaypalAccount.Text;
                bll.Update(userModel);
                JscriptPrint("保存成功啦！", "List.aspx", "Success");
            }
            catch
            {
                JscriptMsg(350, 230, "错误提示", "<b>保存错误啦！</b>", "back", "Error");
            }
        }
        protected void btnSave2_Click(object sender, EventArgs e)
        {
            try
            {
                userModel = bll.GetModel(this.Id);
                userModel.CompanyName = txtqCompanyName.Text;
                userModel.CompanyAddress = txtqCompanyAddress.Text;
                userModel.RegistrationMark = txtqRegistrationMark.Text;
                userModel.TrueName = txtqTrueName.Text;
                userModel.IdentityCard = txtgIdentityCard.Text;
                userModel.CorporateName = txtqCorporateName.Text;
                userModel.QQ = txtqQQ.Text;
                userModel.Email = txtqEmail.Text;
                userModel.Applicationdesc = txtqApplicationdesc.Text;
                userModel.Phone = txtqPhone.Text;
                userModel.Tel = txtqTel.Text;                
                bll.Update(userModel);
                JscriptPrint("保存成功啦！", "List.aspx", "Success");
            }
            catch
            {
                JscriptMsg(350, 230, "错误提示", "<b>保存错误啦！</b>", "back", "Error");
            }
        }
    }
}
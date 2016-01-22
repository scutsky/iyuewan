using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Spread.Web
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Spread.BLL.theme bll = new Spread.BLL.theme();
                Spread.Model.theme  model= bll.getmodel();
                lbAdress.Text = model.Adress;
                lbFax.Text = model.fax;
                lbTel.Text = model.Tel;
                lbMail.Text = model.Mail;
            }
            catch
            {
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                Spread.BLL.Messages bll = new Spread.BLL.Messages();
                Spread.Model.Messages model = new Spread.Model.Messages();
                model.Subject = ddlSubject.Value;
                model.FullName = txtFullName.Value;
                model.Mail = txtMail.Value;
                model.Address = txtAddress.Value;
                model.ZipCode = txtZipCode.Value;
                model.Province = hdProv.Value;
                model.City = hdCity.Value;
                model.Phone = txtPhone.Value;
                model.Fax = txtFax.Value;
                model.Question = txtQuestion.Value;
                model.Type ="中文";
                bll.Add(model);
                //如果没有就如下代码
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script>alert('提交成功');</script>", true);
            }
            catch
            {
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script>alert('提交失败');</script>", true);
            }
        }
    }
}
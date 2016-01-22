using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Spread.Model;
using Spread.BLL;

namespace Spread.Web.Admin.about
{
    public partial class theme_add : Spread.Web.UI.ManagePage
    {
      
        Spread.Model.theme model = new Spread.Model.theme();
        Spread.BLL.theme bll = new Spread.BLL.theme();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                chkLoginLevel("theme_add");
            }

        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
           
            model.Contacts = this.Textpeople.Text;
            model.Postal = this.txtEmial.Text;
            model.Phone = this.Textphone.Text;
            model.Tel = this.Textdianhau.Text;
            model.Mail = this.Textyouxiang.Text;
            model.fax = this.Textcuanzheng.Text;
            model.Adress = this.Textaddress.Text;

            bll.Add(model);
            Response.Write("<script>alert('添加信息成功了')</script>");
        }
    }
}

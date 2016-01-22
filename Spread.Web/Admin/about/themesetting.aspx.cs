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
using Spread.BLL;
using Spread.Model;

namespace Spread.Web.Admin.about
{
    public partial class themesetting : Spread.Web.UI.ManagePage
    {
      
        Spread.BLL.theme bll = new Spread.BLL.theme();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
               chkLoginLevel("themesetting");
               Binddata();
            }
            

        }


        public void Binddata()
        {
            Spread.Model.theme model = new Spread.Model.theme();
            
            model = bll.getmodel();

            Textpeople.Text = model.Contacts;
            txtEmial.Text = model.Postal;
            Textphone.Text = model.Phone;
            Textdianhau.Text = model.Tel;
            Textyouxiang.Text = model.Mail;
            Textcuanzheng.Text = model.fax;
            Textaddress.Text = model.Adress;
         
        }


        public int getid()
        {   int id;
            Spread.Model.theme model = new Spread.Model.theme();
            Spread.BLL.theme bll = new Spread.BLL.theme();
            model = bll.getmodel();
            id = model.ID;
         
            return id;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            Spread.Model.theme modle = new Spread.Model.theme();

            if (Textpeople.Text == "" || txtEmial.Text == "" || Textphone.Text == "" || Textdianhau.Text == "")
            {
                Response.Write("<script>alert('请添加公司信息')</script>");

            }

            else
            {
                modle.Contacts = Textpeople.Text;
                modle.Postal = txtEmial.Text;
                modle.Phone = Textphone.Text;
                modle.Tel = Textdianhau.Text;
                modle.Mail = Textyouxiang.Text;
                modle.fax = Textcuanzheng.Text;
                modle.Adress = Textaddress.Text;
                modle.ID = getid();

                bll.UPTADE(modle);

                Response.Write("<script>alert('更新信息成功！！')</script>");

            }
             
        }
    }
}

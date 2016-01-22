using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spread.Common;

namespace Spread.Web.Admin.Dealer
{
    public partial class Add : Spread.Web.UI.ManagePage
    {
        public Spread.BLL.Dealer bll = new Spread.BLL.Dealer();
        public Spread.Model.Dealer model = new Spread.Model.Dealer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                chkLoginLevel("addDealer");
                TreeBind();               
                BrandBind();
                if (!string.IsNullOrEmpty(Request.Params["classId"]))
                {
                    ddlClassId.SelectedValue = Request.Params["classId"].Trim();
                }
            }
        }

        //绑定类别
        private void TreeBind()
        {
            Spread.BLL.Tag cbll = new Spread.BLL.Tag();
            DataTable dt = cbll.GetList(" TagCategoryID=6").Tables[0];
            ddlClassId.DataSource = dt;
            ddlClassId.DataTextField = "Name";
            ddlClassId.DataValueField = "ID";
            ddlClassId.DataBind();
            ListItem item = new ListItem("请选择所属类型...", "0");
            ddlClassId.Items.Insert(0, item);
        }

        //绑定品牌
        private void BrandBind()
        {
            Spread.BLL.Tag cbll = new Spread.BLL.Tag();
            DataTable dt = cbll.GetList(" TagCategoryID=7").Tables[0];
            ddlBrand.DataSource = dt;
            ddlBrand.DataTextField = "Name";
            ddlBrand.DataValueField = "Name";
            ddlBrand.DataBind();
            ListItem item = new ListItem("请选择所属省份...", "0");
            ddlBrand.Items.Insert(0, item);
        }

        //保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            model.Title = txtTitle.Text.Trim();
            model.Form = txtForm.Text.Trim();
            model.ClassId = int.Parse(ddlClassId.SelectedValue);
            model.ImgUrl = "";
            model.AddTime = DateTime.Now;
            model.Zhaiyao ="";
            model.IsMsg = false;
            model.IsTop = false;
            model.IsRed = false;
            model.IsHot = false;
            model.IsSlide = false;
            model.GType ="";
            model.GFactory = "";
            model.GBrand = this.ddlBrand.SelectedValue;
            model.Code1 = "";
            model.Code2 = "";            
            model.LanguageType = "zh";
            bll.Add(model);
            Response.Write("<script>alert('经销商发布成功！!!!')</script>");


        }

    }
}

using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spread.Common;

namespace Spread.Web.Admin.Dealer
{
    public partial class Edit : Spread.Web.UI.ManagePage
    {
        public int Id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.Params["id"] as string, out this.Id))
            {
                JscriptMsg(350, 230, "错误提示", "<b>出现错误啦！</b>您要修改的信息不存在或参数不正确。", "back", "Error");
                return;
            }
            if (!Page.IsPostBack)
            {
                chkLoginLevel("editDealer");
                TreeBind();               
                BrandBind();
                ShowInfo(this.Id);
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
        //赋值操作
        private void ShowInfo(int _id)
        {
            Spread.BLL.Dealer bll = new Spread.BLL.Dealer();
            Spread.Model.Dealer model = bll.GetModel(_id);
            txtTitle.Text = model.Title;
            txtForm.Text = model.Form;
            ddlClassId.SelectedValue = model.ClassId.ToString();
            this.ddlBrand.SelectedValue = model.GBrand.ToString();
        }

        //保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Spread.BLL.Dealer bll = new Spread.BLL.Dealer();
            Spread.Model.Dealer model = bll.GetModel(this.Id);

            model.Title = txtTitle.Text.Trim();
            model.Form = txtForm.Text.Trim();
            model.ClassId = int.Parse(ddlClassId.SelectedValue);
            model.ImgUrl = "";
            model.AddTime = DateTime.Now;
            model.Zhaiyao = "";
            model.IsMsg = false;
            model.IsTop = false;
            model.IsRed = false;
            model.IsHot = false;
            model.IsSlide = false;
            model.GType = "";
            model.GFactory = "";
            model.GBrand = ddlBrand.SelectedValue;
            model.Code1 = "";
            model.Code2 ="";            
            model.LanguageType = "zh";
            bll.Update(model);
            JscriptPrint("经销商编辑成功啦！", "List.aspx", "Success");
        }

    }
}

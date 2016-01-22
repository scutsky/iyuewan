using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Spread.Common;

namespace Spread.Web.Admin.Directory
{
    public partial class AddGoods : Spread.Web.UI.ManagePage
    {
        public Spread.BLL.DirectoryGoods bll = new Spread.BLL.DirectoryGoods();
        public Spread.Model.DirectoryGoods model = new Spread.Model.DirectoryGoods();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                chkLoginLevel("addDirectoryGoods");
                TreeBind();
                TypeBind();
                YearBind();
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
            Spread.BLL.MenuDirectory cbll = new Spread.BLL.MenuDirectory();
            DataTable dt = cbll.GetList(" LanguageType='zh'").Tables[0];

            this.ddlClassId.Items.Clear();
            this.ddlClassId.Items.Add(new ListItem("请选择所属类别...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["Id"].ToString();
                int ClassLayer = int.Parse(dr["ClassLayer"].ToString());
                string Title = dr["Title"].ToString().Trim();

                if (ClassLayer == 1)
                {
                    this.ddlClassId.Items.Add(new ListItem(Title, Id));
                }
                else
                {
                    Title = "├ " + Title;
                    Title = StringPlus.StringOfChar(ClassLayer - 1, "　") + Title;
                    this.ddlClassId.Items.Add(new ListItem(Title, Id));
                }
            }
        }


        //绑定型号
        private void TypeBind()
        {
            Spread.BLL.Tag cbll = new Spread.BLL.Tag();
            DataTable dt = cbll.GetList(" TagCategoryID=4").Tables[0];
            ddlType.DataSource = dt;
            ddlType.DataTextField = "Name";
            ddlType.DataValueField = "Name";
            ddlType.DataBind();
            ListItem item = new ListItem("请选择所属型号...", "0");
            ddlType.Items.Insert(0, item);
        }


        //绑定年份
        private void YearBind()
        {
            Spread.BLL.Tag cbll = new Spread.BLL.Tag();
            DataTable dt = cbll.GetList(" TagCategoryID=5").Tables[0];
            ddlYear.DataSource = dt;
            ddlYear.DataTextField = "Name";
            ddlYear.DataValueField = "Name";
            ddlYear.DataBind();
            ListItem item = new ListItem("请选择所属年份...", "0");
            ddlYear.Items.Insert(0, item);
        }


        //绑定品牌
        private void BrandBind()
        {
            Spread.BLL.Tag cbll = new Spread.BLL.Tag();
            DataTable dt = cbll.GetList(" TagCategoryID=3").Tables[0];
            ddlBrand.DataSource = dt;
            ddlBrand.DataTextField = "Name";
            ddlBrand.DataValueField = "Name";
            ddlBrand.DataBind();
            ListItem item = new ListItem("请选择所属品牌...", "0");
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
            model.Zhaiyao = "";
            model.IsMsg = false;
            model.IsTop = false;
            model.IsRed = false;
            model.IsHot = false;
            model.IsSlide = false;
            model.GType = this.ddlType.SelectedValue;
            model.GFactory = this.ddlYear.SelectedValue;
            model.GBrand = this.ddlBrand.SelectedValue;
            model.Code1 = this.txtCode1.Text;
            model.Code2 = this.txtCode2.Text;
            model.IsMsg = false;
            model.IsTop = false;
            model.IsRed = false;
            model.IsHot = false;
            model.LanguageType = "zh";           
            bll.Add(model);
            Response.Write("<script>alert('应用发布成功啦！!!!')</script>");


        }

    }
}

using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spread.Common;

namespace Spread.Web.Admin.Directory
{
    public partial class EditGoods : Spread.Web.UI.ManagePage
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
                chkLoginLevel("editGoods");
                TreeBind();
                TypeBind();
                YearBind();
                BrandBind();
                ShowInfo(this.Id);
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
        //赋值操作
        private void ShowInfo(int _id)
        {
            Spread.BLL.DirectoryGoods bll = new Spread.BLL.DirectoryGoods();
            Spread.Model.DirectoryGoods model = bll.GetModel(_id);
            txtTitle.Text = model.Title;
            txtForm.Text = model.Form;
            ddlClassId.SelectedValue = model.ClassId.ToString();
            txtImgUrl.Text = model.ImgUrl;
            
            this.ddlType.SelectedValue = model.GType.ToString();
            this.ddlYear.SelectedValue = model.GFactory.ToString();
            this.ddlBrand.SelectedValue = model.GBrand.ToString();
            this.txtCode1.Text = model.Code1;
            this.txtCode2.Text = model.Code2;
        }

        //保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Spread.BLL.DirectoryGoods bll = new Spread.BLL.DirectoryGoods();
            Spread.Model.DirectoryGoods model = bll.GetModel(this.Id);

            model.Title = txtTitle.Text.Trim();
            model.Form = txtForm.Text.Trim();
            model.ClassId = int.Parse(ddlClassId.SelectedValue);
            model.ImgUrl = txtImgUrl.Text.Trim();
            model.AddTime = DateTime.Now;
            model.Zhaiyao = "";
            model.IsMsg = false;
            model.IsTop = false;
            model.IsRed = false;
            model.IsHot = false;
            model.IsSlide = false;
            model.GType = ddlType.SelectedValue;
            model.GFactory = ddlYear.SelectedValue;
            model.GBrand = ddlBrand.SelectedValue;
            model.Code1 = this.txtCode1.Text;
            model.Code2 = this.txtCode2.Text;
            model.LanguageType = "zh";
           
            model.IsMsg = false;
            model.IsTop = false;
            model.IsRed = false;
            model.IsHot = false;
            model.IsSlide = false;
            
            bll.Update(model);
            JscriptPrint("应用编辑成功啦！", "ListGoods.aspx", "Success");
        }

    }
}



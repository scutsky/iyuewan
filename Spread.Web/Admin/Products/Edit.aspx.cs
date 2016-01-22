using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spread.Common;

namespace Spread.Web.Admin.Products
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
                chkLoginLevel("editProducts");
                ShowInfo(this.Id);
            }
        }

        //赋值操作
        private void ShowInfo(int _id)
        {
            Spread.BLL.Products bll = new Spread.BLL.Products();
            Spread.Model.Products model = bll.GetModel(_id);
            ddlClassId.SelectedValue = model.ClassId.ToString();
            txtTitle.Text = model.Title;
            txtBrand.Text=model.Brand;
            txtAuthor.Text = model.AddUser;
            txtKeyword.Text = model.Keyword;
            cbIsTop.Checked = model.IsTop;
            cbIsLock.Checked=model.IsLock;            
        }

        //保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Spread.BLL.Products bll = new Spread.BLL.Products();
            Spread.Model.Products model = bll.GetModel(this.Id);
            model.Title = txtTitle.Text.Trim();
            model.Brand = txtBrand.Text.Trim();
            model.AddUser = txtAuthor.Text.Trim();
            model.ClassId = int.Parse(ddlClassId.SelectedValue);
            model.ImgUrl = "";
            model.Url ="";
            model.Keyword = txtKeyword.Text;
            model.IsTop = cbIsTop.Checked;
            model.IsLock = cbIsLock.Checked;
            model.AddTime = DateTime.Now;
            bll.Update(model);
            JscriptPrint("产品编辑成功啦！", "List.aspx", "Success");
        }

    }
}

using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spread.Common;

namespace Spread.Web.Admin.Products
{
    public partial class Add : Spread.Web.UI.ManagePage
    {
        public Spread.BLL.Products bll = new Spread.BLL.Products();
        public Spread.Model.Products model = new Spread.Model.Products();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                chkLoginLevel("addProducts");
            }
        }

        //保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            model.Title = txtTitle.Text.Trim();
            model.Brand = txtBrand.Text.Trim();
            model.AddUser = txtAuthor.Text.Trim();
            model.ClassId = int.Parse(ddlClassId.SelectedValue);
            model.ImgUrl = "";
            model.Url = "";
            model.Keyword = txtKeyword.Text;
            model.IsTop = cbIsTop.Checked;
            model.IsLock = cbIsLock.Checked;
            model.AddTime = DateTime.Now;
            bll.Add(model);
            JscriptPrint("成功啦！", "List.aspx", "Success");
        }

    }
}

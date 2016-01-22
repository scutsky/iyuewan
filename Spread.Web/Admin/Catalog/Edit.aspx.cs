using System;
using System.Data;
using System.Web;
using Spread.Web.UI;

namespace Spread.Web.Admin.Catalog
{
    public partial class Edit : ManagePage
    {
        private Spread.BLL.Catalog bll = new Spread.BLL.Catalog();
        private Spread.Model.Catalog model = new Spread.Model.Catalog();
        public int classId;    //ID
        protected void Page_Load(object sender, EventArgs e)
        {
            chkLoginLevel("editCatalog");
            //取得栏目传参
            if ( int.TryParse(Request.Params["classId"], out classId))
            {
                model = bll.GetModel(classId);
                if (!Page.IsPostBack)
                {
                    ShowInfo();
                }
            }
            else
            {
                JscriptMsg(350, 230, "错误提示", "<b>出现错误啦！</b>您要修改类别的编号不明确或参数不正确。", "back", "Error");
            }
        }

        //绑定数据
        private void ShowInfo()
        {
            this.lblPid.Text = model.ParentId.ToString();
            if (model.ParentId>0)
            {
                this.lblPname.Text = bll.GetCatalogTitle(model.ParentId);
            }
            else
            {
                this.lblPname.Text = "顶级游戏分类";
            }
            this.txtTitle.Text = model.Title;
            this.lblCatalodId.Text = model.CatalogID.ToString();
            this.txtClassOrder.Text = model.ClassOrder.ToString();

            if (model.IsShow == true)
            {
                cblItem.Items[0].Selected = true;
            }
            if (model.IsMenu == true)
            {
                cblItem.Items[1].Selected = true;
            }
            if (model.IsLock == true)
            {
                cblItem.Items[2].Selected = true;
            }
        }

        //保存修改
        protected void btnSave_Click(object sender, EventArgs e)
        {
            model.Title = txtTitle.Text.Trim();
            model.CatalogID =long.Parse( lblCatalodId.Text.Trim());
            model.ClassOrder = int.Parse(txtClassOrder.Text.Trim());
            model.IsShow = false;
            model.IsLock = false;
            model.IsMenu = false;

            if (cblItem.Items[0].Selected == true)
            {
                model.IsShow = true;
            }
            if (cblItem.Items[1].Selected == true)
            {
                model.IsMenu = true;
            }
            if (cblItem.Items[2].Selected == true)
            {
                model.IsLock = true;
            }
            //修改栏目
            bll.Update(model);
            JscriptPrint("游戏分类修改成功啦！", "List.aspx", "Success");
        }

    }
}

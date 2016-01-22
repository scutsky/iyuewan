using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spread.Common;

namespace Spread.Web.Admin.Goods
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
                chkLoginLevel("editGoods");
                ShowInfo(this.Id);
            }
        }

        //赋值操作
        private void ShowInfo(int _id)
        {
            Spread.BLL.Goods bll = new Spread.BLL.Goods();
            Spread.Model.Goods model = bll.GetModel(_id);
            txtTitle.Text = model.Title;
            txtForm.Text = model.Form;
            txtImgUrl.Text = model.ImgUrl;
            content1.Value = model.Zhaiyao;
            if (model.IsMsg == true)
            {
                cblItem.Items[0].Selected = true;
            }
            if (model.IsTop == true)
            {
                cblItem.Items[1].Selected = true;
            }
            if (model.IsRed == true)
            {
                cblItem.Items[2].Selected = true;
            }
            if (model.IsHot == true)
            {
                cblItem.Items[3].Selected = true;
            }
            if (model.IsSlide == true)
            {
                cblItem.Items[4].Selected = true;
            }
            this.txtBak5.Text=model.Bak5;
        }

        //保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Spread.BLL.Goods bll = new Spread.BLL.Goods();
            Spread.Model.Goods model = bll.GetModel(this.Id);

            model.Title = txtTitle.Text.Trim();
            model.Form = txtForm.Text.Trim();  
            model.ClassId = 0;
            model.ImgUrl = txtImgUrl.Text.Trim();
            model.AddTime = DateTime.Now;
            model.Zhaiyao = content1.Value;
            model.IsMsg = false;
            model.IsTop = false;
            model.IsRed = false;
            model.IsHot = false;
            model.IsSlide = false;
            model.GType = "";
            model.GFactory = "";
            model.GBrand = "";
            model.Code1 = "";
            model.Code2 = "";
            model.Bak1 = "";
            model.Bak2 = "";
            model.Bak3 = "";
            model.Bak4 = "";
            model.Bak5 = "";
            if (cblItem.Items[0].Selected == true)
            {
                model.IsMsg = true;
            }
            if (cblItem.Items[1].Selected == true)
            {
                model.IsTop = true;
            }
            if (cblItem.Items[2].Selected == true)
            {
                model.IsRed = true;
            }
            if (cblItem.Items[3].Selected == true)
            {
                model.IsHot = true;
            }
            if (cblItem.Items[4].Selected == true)
            {
                model.IsSlide = true;
            }
            bll.Update(model);
            JscriptPrint("游戏编辑成功啦！", "List.aspx", "Success");
        }

    }
}

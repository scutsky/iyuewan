using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spread.Common;

namespace Spread.Web.Admin.Goods
{
    public partial class Add : Spread.Web.UI.ManagePage
    {
        public Spread.BLL.Goods bll = new Spread.BLL.Goods();
        public Spread.Model.Goods model = new Spread.Model.Goods();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                chkLoginLevel("addGoods");
            }
        }


        //保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
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
            model.GType ="";
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
            bll.Add(model);
            Response.Write("<script>alert('游戏发布成功啦！!!!')</script>");
           
           
        }

    }
}

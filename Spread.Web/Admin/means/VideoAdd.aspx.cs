using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Spread.Common;

namespace Spread.Web.Admin.means
{
    public partial class VideoAdd : Spread.Web.UI.ManagePage
    {
        public Spread.BLL.Video bll = new Spread.BLL.Video();
        public Spread.Model.Video model = new Spread.Model.Video();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                chkLoginLevel("addMeans");
            }
        }




        //保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(Server.MapPath("~/UpLoadFiles/Files/") + FileUpload1.FileName);

            }
            model.Title = txtTitle.Text.Trim();
            model.Form = txtForm.Text.Trim();
            model.ClassId = 0;
            model.ImgUrl = "";
            model.AddTime = DateTime.Now;
            model.Zhaiyao = "/UpLoadFiles/Files/" + FileUpload1.FileName;
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
            model.IsMsg = false;
            model.IsTop = false;
            model.IsRed = false;
            model.IsHot = false;
            model.LanguageType = "zh";
            bll.Add(model);
            Response.Write("<script>alert('视频发布成功啦！!!!')</script>");


        }

    }
}

using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spread.Common;

namespace Spread.Web.Admin.Protocol
{
    public partial class Add : Spread.Web.UI.ManagePage
    {
        public Spread.BLL.Protocol bll = new Spread.BLL.Protocol();
        public Spread.Model.Protocol model = new Spread.Model.Protocol();
        public int classId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!int.TryParse(Request.Params["classId"] as string, out this.classId))
                {
                    this.classId = 0;
                }
                chkLoginLevel("addProtocol");
            }
        }


        //保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            model.Title = txtTitle.Text.Trim();
            model.Author = txtAuthor.Text.Trim();
            model.Form = FCKeditor2.Value.Trim();
            model.ClassId = 0;
            model.ImgUrl ="";
            model.Content = FCKeditor.Value;
            model.Click = int.Parse(txtClick.Text.Trim());

            model.IsMsg = false;
            model.IsTop = false;
            model.IsRed = false;
            model.IsHot = false;
            model.IsSlide = false;



            bll.Add(model);
            Response.Write("<script>alert('协议发布成功啦！!!!')</script>");

        }

    }
}

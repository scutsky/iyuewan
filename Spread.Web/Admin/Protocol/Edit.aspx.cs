using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spread.Common;

namespace Spread.Web.Admin.Protocol
{
    public partial class Edit : Spread.Web.UI.ManagePage
    {
        public int Id;
        public int classId;
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!int.TryParse(Request.Params["id"] as string, out this.Id))
            {
                JscriptMsg(350, 230, "错误提示", "<b>出现错误啦！</b>您要修改的信息不存在或参数不正确。", "back", "Error");
                return;
            }
            if (!Page.IsPostBack)
            {
                chkLoginLevel("editProtocol");
               
                ShowInfo(this.Id);
            }
        }

       

        //赋值操作
        private void ShowInfo(int _id)
        {
            Spread.BLL.Protocol bll = new Spread.BLL.Protocol();
            Spread.Model.Protocol model = bll.GetModel(_id);

            txtTitle.Text = model.Title;
            txtAuthor.Text = model.Author;
            FCKeditor2.Value = model.Form;
            FCKeditor.Value = model.Content;
            txtClick.Text = model.Click.ToString();
        }

        //保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Spread.BLL.Protocol bll = new Spread.BLL.Protocol();
            Spread.Model.Protocol model = bll.GetModel(this.Id);

            model.Title = txtTitle.Text.Trim();
            model.Author = txtAuthor.Text.Trim();
            model.Form = FCKeditor2.Value.Trim();
         
          
            model.ClassId =0;
            model.ImgUrl = "";
            model.Content = FCKeditor.Value;
            model.Click = int.Parse(txtClick.Text.Trim());

            model.IsMsg = false;
            model.IsTop = false;
            model.IsRed = false;
            model.IsHot = false;
            model.IsSlide = false;
            bll.Update(model);
            Response.Write("<script>alert('协议编辑成功啦！！!!!')</script>");
           
        }

    }
}

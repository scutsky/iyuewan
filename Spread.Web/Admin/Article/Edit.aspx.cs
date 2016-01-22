using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spread.Common;

namespace Spread.Web.Admin.Article
{
    public partial class Edit : Spread.Web.UI.ManagePage
    {
        public int Id;
        public int classId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.Params["classId"] as string, out this.classId))
            {
                this.classId = 0;
            }
            if (!int.TryParse(Request.Params["id"] as string, out this.Id))
            {
                JscriptMsg(350, 230, "错误提示", "<b>出现错误啦！</b>您要修改的信息不存在或参数不正确。", "back", "Error");
                return;
            }
            if (!Page.IsPostBack)
            {
                chkLoginLevel("editArticle");
                TreeBind();
                ShowInfo(this.Id);
            }
        }

        //绑定类别
        private void TreeBind()
        {
            Spread.BLL.Article_type cbll = new Spread.BLL.Article_type();
            DataTable dt = cbll.GetList(0);

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

        //赋值操作
        private void ShowInfo(int _id)
        {
            Spread.BLL.Article bll = new Spread.BLL.Article();
            Spread.Model.Article model = bll.GetModel(_id);

            txtTitle.Text = model.Title;
            txtAuthor.Text = model.Author;
            txtForm.Text = model.Form;
           
            ddlClassId.SelectedValue = model.ClassId.ToString();
            txtImgUrl.Text = model.ImgUrl;
           
            FCKeditor.Value = model.Content;
            txtClick.Text = model.Click.ToString();
          
           
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
        }

        //保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Spread.BLL.Article bll = new Spread.BLL.Article();
            Spread.Model.Article model = bll.GetModel(this.Id);

            model.Title = txtTitle.Text.Trim();
            model.Author = txtAuthor.Text.Trim();
            model.Form = txtForm.Text.Trim();
         
          
            model.ClassId = int.Parse(ddlClassId.SelectedValue);
            model.ImgUrl = txtImgUrl.Text.Trim();
            model.Content = FCKeditor.Value;
            model.Click = int.Parse(txtClick.Text.Trim());

            model.IsMsg = false;
            model.IsTop = false;
            model.IsRed = false;
            model.IsHot = false;
            model.IsSlide = false;
         
          
          
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
            Response.Write("<script>alert('文章编辑成功啦！！!!!')</script>");
           
        }

    }
}

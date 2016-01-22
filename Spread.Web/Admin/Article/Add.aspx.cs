using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spread.Common;

namespace Spread.Web.Admin.Article
{
    public partial class Add : Spread.Web.UI.ManagePage
    {
        public Spread.BLL.Article bll = new Spread.BLL.Article();
        public Spread.Model.Article model = new Spread.Model.Article();
        public int classId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!int.TryParse(Request.Params["classId"] as string, out this.classId))
                {
                    this.classId = 0;
                }
                chkLoginLevel("addArticle");
                TreeBind();
                if (!string.IsNullOrEmpty(Request.Params["classId"]))
                {
                    ddlClassId.SelectedValue = Request.Params["classId"].Trim();
                }
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

        //保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
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
            bll.Add(model);
            Response.Write("<script>alert('公告发布成功啦！!!!')</script>");
           
        }

    }
}

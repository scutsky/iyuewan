using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Spread.Web.Admin.Goods
{
    public partial class GameAdd : Spread.Web.UI.ManagePage
    {
        public Spread.BLL.Game bll = new Spread.BLL.Game();
        public Spread.Model.Game model = new Spread.Model.Game();
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txtDate.Text=DateTime.Now.ToString("yyyy-MM-dd");
                chkLoginLevel("addGame");
                TreeBind();
            }
        }

        //绑定类别
        private void TreeBind()
        {
            Spread.BLL.Menu bllMenu = new BLL.Menu();
            DataTable dt = bllMenu.GetList("").Tables[0];

            this.ddlPlatform.Items.Clear();
            this.ddlPlatform.Items.Add(new ListItem("请选择所属平台...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["Title"].ToString();
                string Title = dr["Title"].ToString().Trim();
                this.ddlPlatform.Items.Add(new ListItem(Title, Id));
            }
        }
        //保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (file1.HasFile)
            {
                file1.SaveAs(Server.MapPath("~/UpLoadFiles/Files/") + file1.FileName);

            }
            if (file2.HasFile)
            {
                file2.SaveAs(Server.MapPath("~/UpLoadFiles/Files/") + file2.FileName);

            } 
            model.Name = txtTitle.Text.Trim();
            model.version = txtVersion.Text.Trim();
            model.Platform = ddlPlatform.SelectedValue;
            model.FirstLetter = ddlFirstLetter.Text.Trim();
            model.UpdateDate = DateTime.Now;
            model.OnTime = DateTime.Parse(txtDate.Text);
            model.Bak2 = "/UpLoadFiles/Files/" + file1.FileName;
            model.Bak3 = "/UpLoadFiles/Files/" + file2.FileName;
            bll.Add(model);
            JscriptPrint("游戏新增成功啦！", "GameList.aspx", "Success");



        }

    }
}

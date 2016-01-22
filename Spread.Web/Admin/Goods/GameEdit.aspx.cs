using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Spread.Web.Admin.Goods
{
    public partial class GameEdit : Spread.Web.UI.ManagePage
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
                TreeBind();
                ShowInfo(this.Id);
               
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
        //赋值操作
        private void ShowInfo(int _id)
        {
            Spread.BLL.Game bll = new Spread.BLL.Game();
            Spread.Model.Game model = bll.GetModel(_id);
            txtTitle.Text = model.Name;
            txtVersion.Text = model.version;
            ddlPlatform.SelectedValue = model.Platform;
            txtDate.Text = model.UpdateDate.ToString();

            this.ddlFirstLetter.SelectedValue = model.FirstLetter;
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
            Spread.BLL.Game bll = new Spread.BLL.Game();
            Spread.Model.Game model = bll.GetModel(this.Id);
            model.Name = txtTitle.Text.Trim();
            model.version = txtVersion.Text.Trim();
            model.Platform = ddlPlatform.SelectedValue;
            model.FirstLetter = ddlFirstLetter.Text.Trim();
            model.UpdateDate = DateTime.Now;
            model.OnTime = DateTime.Parse(txtDate.Text);
            if (file1.HasFile)
            {
                model.Bak2 = "/UpLoadFiles/Files/" + file1.FileName;
            }
            else
            {
                model.Bak2 = lbFile1.Text;
            }
            if (file2.HasFile)
            {
                model.Bak3 = "/UpLoadFiles/Files/" + file2.FileName;
            }
            else
            {
                model.Bak3 = lbFile2.Text;
            }
            bll.Update(model);
            JscriptPrint("游戏编辑成功啦！", "GameList.aspx", "Success");


        }
    }
}
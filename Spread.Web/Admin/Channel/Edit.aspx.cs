using System;
using System.Data;
using System.Web;
using Spread.Web.UI;

namespace Spread.Web.Admin.Channel
{
    public partial class Edit : ManagePage
    {
        private Spread.BLL.Channel bll = new Spread.BLL.Channel();
        private Spread.Model.Channel model = new Spread.Model.Channel();
        public int id;    //ID
        protected void Page_Load(object sender, EventArgs e)
        {
            chkLoginLevel("editChannel");
            //取得栏目传参
            if (int.TryParse(Request.Params["id"], out id))
            {
                model = bll.GetModel(id);
                if (!Page.IsPostBack)
                {
                    ShowInfo();
                }
            }
            else
            {
                JscriptMsg(350, 230, "错误提示", "<b>出现错误啦！</b>您要修改主键不明确或参数不正确。", "back", "Error");
            }
        }

        //绑定数据
        private void ShowInfo()
        {

            Model.User userMod = new Model.User();
            BLL.User userBll = new BLL.User();
            Model.Products proMod = new Model.Products();
            BLL.Products proBll = new BLL.Products();
            userMod = userBll.GetModel(Convert.ToInt32(model.UserID));
            proMod = proBll.GetModel(Convert.ToInt32(model.ParentId));
            this.lbChanel.Text = model.Title;
            this.lbProducts.Text = proMod.Title;
            this.lbBak1.Text = model.Bak1;
            this.lbUser.Text = userMod.Name;
            this.ddlStatus.SelectedValue = model.Status.ToString();
            
        }

        //保存修改
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int _id = 0;
            if (int.TryParse(Request.Params["id"], out _id))
            {
                //修改栏目
                bll.UpdateStatus(id, this.ddlStatus.SelectedValue);
                JscriptPrint("渠道修改成功啦！", "List.aspx", "Success");
            }
            else
            {
                JscriptPrint("渠道修改错误！", "List.aspx", "Error");
            }


        }
    }
}

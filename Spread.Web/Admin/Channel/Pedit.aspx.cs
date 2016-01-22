using System;
using System.Data;
using System.Web;
using Spread.Web.UI;
using System.Web.UI.WebControls;

namespace Spread.Web.Admin.Channel
{
    public partial class Pedit : ManagePage
    {
        private Spread.BLL.Pchannel bll = new Spread.BLL.Pchannel();
        private Spread.Model.Pchannel model = new Spread.Model.Pchannel();
        public int kindId; //栏目种类
        public int Id;    //栏目父ID
        public string pTitle = "顶级类别";
        protected void Page_Load(object sender, EventArgs e)
        {
            chkLoginLevel("addChannel");
            //取得栏目传参
            if (int.TryParse(Request.Params["Id"], out Id))
            {
                model = bll.GetModel(Id);
                if (!Page.IsPostBack)
                {
                    TreeBind();
                    ShowInfo();
                }
            }
            else
            {
                JscriptMsg(350, 230, "错误提示", "<b>出现错误啦！</b>您要修改类别的编号不明确或参数不正确。", "back", "Error");
            }
        }


        //绑定数据
        private void ShowInfo()
        {
            ddlMenu.SelectedValue = model.ParentId.ToString();
            txtTitle.Text = model.Title;
        }

        //绑定平台
        private void TreeBind()
        {
            Spread.BLL.Menu cbll = new Spread.BLL.Menu();
            DataTable dt = cbll.GetList("").Tables[0];
            ddlMenu.DataSource = dt;
            ddlMenu.DataTextField = "Title";
            ddlMenu.DataValueField = "ID";
            ddlMenu.DataBind();
            ListItem item = new ListItem("请选择所属平台...", "0");
            ddlMenu.Items.Insert(0, item);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            model.Title = this.txtTitle.Text.Trim();
            model.ParentId = int.Parse(ddlMenu.SelectedValue);    
            //添加栏目
            bll.Update(model);
            JscriptPrint("修改平台渠道成功啦！", "Plist.aspx", "Success");
        }
    }
}

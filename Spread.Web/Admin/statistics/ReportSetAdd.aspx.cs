using System;
using System.Data;
using System.Web;
using Spread.Web.UI;
using System.Web.UI.WebControls;

namespace Spread.Web.Admin.statistics
{
    public partial class ReportSetAdd : ManagePage
    {
        private Spread.BLL.ReportSet bll = new Spread.BLL.ReportSet();
        private Spread.Model.ReportSet model = new Spread.Model.ReportSet();
        public int pId;    //栏目父ID
        public string pTitle = "顶级商品分类";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                chkLoginLevel("addReportSetAdd");
                TreeBind();
            }
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
            int Id;
            if (ddlMenu.SelectedValue == "")
            {
                Response.Write("<script>alert('请选择所属平台！')</script>");
                return;
            }
            model.SumDate = ddlSumDate.SelectedValue;
            model.ChannelName =ddlChannelName.SelectedValue;
            model.GameName = ddlGameName.SelectedValue;
            model.RegisterValue = ddlRegisterValue.SelectedValue;
            model.ConsumptionValue = ddlConsumptionValue.SelectedValue;
            model.Income = ddlIncome.SelectedValue;
            model.Bak1 = ddlMenu.SelectedValue;
            model.Bak2 = "";
            model.Bak3= "";
            //添加栏目
            Id = bll.Add(model);
            JscriptPrint("增加报表设置成功啦！", "ReportSetList.aspx", "Success");
        }
    }
}

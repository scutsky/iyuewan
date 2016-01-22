using System;
using System.Data;
using System.Web;
using Spread.Web.UI;
using System.Web.UI.WebControls;

namespace Spread.Web.Admin.statistics
{
    public partial class ReportSetEdit : ManagePage
    {
        private Spread.BLL.ReportSet bll = new Spread.BLL.ReportSet();
        private Spread.Model.ReportSet model = new Spread.Model.ReportSet();
        public int Id;    //ID
        protected void Page_Load(object sender, EventArgs e)
        {
            
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
        //绑定数据
        private void ShowInfo()
        {
            ddlSumDate.SelectedValue = model.SumDate;
            ddlChannelName.SelectedValue = model.ChannelName;
            ddlGameName.SelectedValue = model.GameName;
            ddlRegisterValue.SelectedValue = model.RegisterValue;
            ddlConsumptionValue.SelectedValue = model.ConsumptionValue;
            ddlIncome.SelectedValue = model.Income;
            ddlMenu.SelectedValue = model.Bak1;
        }

        //保存修改
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlMenu.SelectedValue == "")
            {
                Response.Write("<script>alert('请选择所属平台！')</script>");
                return;
            }
            model.SumDate = ddlSumDate.SelectedValue;
            model.ChannelName = ddlChannelName.SelectedValue;
            model.GameName = ddlGameName.SelectedValue;
            model.RegisterValue = ddlRegisterValue.SelectedValue;
            model.ConsumptionValue = ddlConsumptionValue.SelectedValue;
            model.Income = ddlIncome.SelectedValue;
            model.Bak1 = ddlMenu.SelectedValue;
            model.Bak2 = "";
            model.Bak3 = "";
            //修改栏目
            bll.Update(model);
            JscriptPrint("报表设置修改成功啦！", "ReportSetList.aspx", "Success");
        }

    }
}
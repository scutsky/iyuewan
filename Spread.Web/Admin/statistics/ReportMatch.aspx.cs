using System;
using System.Data;
using System.Web;
using Spread.Web.UI;
using System.Web.UI.WebControls;

namespace Spread.Web.Admin.statistics
{
    public partial class ReportMatch : ManagePage
    {
        private Spread.BLL.ReportTemp bll = new Spread.BLL.ReportTemp();
        private Spread.Model.ReportTemp model = new Spread.Model.ReportTemp();
        public int Id;    //ID
        public string Num = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            //取得栏目传参
            if (int.TryParse(Request.Params["Id"], out Id))
            {
                model = bll.GetModel(Id);
                if (!Page.IsPostBack)
                {
                    ShowInfo();
                }
            }
            else
            {
                JscriptMsg(350, 230, "错误提示", "<b>出现错误啦！</b>您要修改类别的编号不明确或参数不正确。", "back", "Error");
            }
            if (Request.Params["Num"]!=null)
            {
                Num = Request.Params["Num"].ToString();
            }
        }
       
        //绑定数据
        private void ShowInfo()
        {
            lbSumDate.Text = model.SumDate;
            lbChannelName.Text = model.ChannelName;
            lbGameName.Text = model.GameName;
            lbRegisterValue.Text = model.RegisterValue.ToString();
            lbConsumptionValue.Text = model.ConsumptionValue.ToString();
            DataTable dt = bll.GetList("Bak4='" + model.GameName + "'").Tables[0];
            this.rptList.DataSource = dt;
            this.rptList.DataBind();
            //ddlMenu.SelectedValue = model.Bak1;
        }

        //保存修改
        protected void btnSave_Click(object sender, EventArgs e)
        {
            JscriptPrint("报表设置修改成功啦！", "ReportSetList.aspx?Num=" + Num.ToString() + "", "Success");
        }

        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spread.Common;

namespace Spread.Web.Admin.Accounts
{
    public partial class Edit : Spread.Web.UI.ManagePage
    {
        Spread.BLL.ReportAccounts bll = new Spread.BLL.ReportAccounts();
        protected internal Spread.Model.ReportAccounts reportrModel;
        public int Id;
        public string strPwd = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.Params["id"] as string, out this.Id))
            {
                JscriptMsg(350, 230, "错误提示", "<b>出现错误啦！</b>您要修改的信息不存在或参数不正确。", "back", "Error");
                return;
            }
            if (!Page.IsPostBack)
            {
                reportrModel = bll.GetModel(this.Id);
                QyView(reportrModel);
            }
        }


        private void QyView(Model.ReportAccounts model)
        {
            txtIncome.Text = model.Settlement.ToString();
            txtActualPlay.Text = model.ActualPlay.ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                reportrModel = bll.GetModel(this.Id);
                reportrModel.Status = "已审核";
                reportrModel.Settlement = Decimal.Parse(txtIncome.Text);
                reportrModel.ActualPlay = Decimal.Parse(txtActualPlay.Text); 
                bll.Update(reportrModel);
                JscriptPrint("保存成功啦！", "List.aspx", "Success");
            }
            catch
            {
                JscriptMsg(350, 230, "错误提示", "<b>保存错误啦！</b>", "back", "Error");
            }
        }
        }
}
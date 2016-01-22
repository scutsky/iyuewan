using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Text;

namespace Spread.Web.User
{
    public partial class Applay : System.Web.UI.Page
    {
        Model.Channel cModel = new Model.Channel();
        BLL.Report rbll = new BLL.Report();
        public Spread.Model.User modeluser = new Model.User();
        Spread.BLL.User blluser = new BLL.User();
        private string uid = "";
        private string pwd = "";
        private Spread.BLL.WebSet bll = new Spread.BLL.WebSet();
        protected internal Spread.Model.WebSet webset;
        public string startDateStr = "";
        public string endDateStr = "";
        Spread.BLL.Report bllReport = new Spread.BLL.Report();

        Spread.BLL.ReportAccounts accBll = new BLL.ReportAccounts();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                string pathurl = Server.MapPath(ConfigurationManager.AppSettings["WebSetpath"].ToString());
                webset = bll.loadConfig(pathurl);
                int num = int.Parse(webset.SettlementCycle);
                this.startDate.Text = DateTime.Now.AddDays(-num).ToString("yyyy-MM-dd");
                this.endDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                startDateStr = this.startDate.Text;
                endDateStr = this.endDate.Text;
                if (!getUserCookies())
                {
                    Response.Redirect("~/Index.aspx");
                }
                else
                {
                    modeluser = blluser.GetModelByName(uid);
                    hduserid.Value = modeluser.ID.ToString();
                    hdusername.Value = modeluser.Name.ToString();
                    alipayPayeeName.Text = modeluser.TrueName;
                    alipayPayeeAccount.Text = modeluser.PaypalAccount;
                    getUserInfo(modeluser.ID);
                }
                DataTable dt = accBll.GetList(" and UserID='" + hduserid.Value + "' and CONVERT(varchar(100),ApplyTime,23)='"+DateTime.Now.ToString("yyyy-MM-dd")+"'  ").Tables[0];
                if (dt.Rows.Count >0)
                {
                    if (dt.Rows[0]["Status"].ToString() == "待审核")
                    {
                        this.btnSave.Enabled = false;
                        this.btnSave.Text = "已申请结算";
                    }
                    else
                    {
                        this.btnSave.Enabled = false;
                        this.btnSave.Text = "已经结算";
                    }
                }
                //ChannelData = rbll.GetList(" UserID='" + modeluser.ID + "'").Tables[0];
            }
        }

        private void getUserInfo(int userid)
        {
            
            StringBuilder strTemp = new StringBuilder();
            strTemp.Append(" and UserID='" + this.hduserid.Value + "' ");
            if (!string.IsNullOrEmpty(this.startDate.Text))
            {
                strTemp.Append(" and SumDate >='" + this.startDate.Text + "'");
            }
            if (!string.IsNullOrEmpty(this.endDate.Text))
            {
                strTemp.Append(" and SumDate <='" + this.endDate.Text + "'");
            }
            DataTable dt = bllReport.GetSumListZT(strTemp.ToString()).Tables[0];
            if (dt.Rows.Count>0)
            {
                consumeMoney.Text = dt.Rows[0]["ConsumptionValue"].ToString();
                validMoney.Text = dt.Rows[0]["Income"].ToString();
            }
            else
            {
                consumeMoney.Text = "0";
                validMoney.Text = "0";
            }
        }
        private bool getUserCookies()
        {

            if (Request.Cookies["UserPage_UID"] != null)
            {
                uid = Request.Cookies["UserPage_UID"].Value.ToString();
            }
            //获取登录时的PWD(MD5加密后)
            if (Request.Cookies["UserPage_PWD"] != null)
            {
                pwd = Request.Cookies["UserPage_PWD"].Value.ToString();
            }
            //当用户名UID或者密码PWD有一项为空时
            if (string.IsNullOrEmpty(uid) || string.IsNullOrEmpty(pwd))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        ///  产品
        /// </summary>
        protected DataTable ChannelData
        {
            get;
            set;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (consumeMoney.Text == "0")
            {
                string myScript = @"alertMsg('没有充值记录!','error.gif');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                return;
            }
            else
            {
                try
                {
                    Spread.Model.ReportAccounts accModel = new Model.ReportAccounts();
                    accModel.ApplyTime = DateTime.Now;
                    accModel.UserID = int.Parse(hduserid.Value);
                    accModel.UserName = hdusername.Value;
                    accModel.SettlementCycle = this.startDate.Text + "~" + this.endDate.Text;
                    accModel.Recharge = Decimal.Parse(consumeMoney.Text);
                    accModel.Income = Decimal.Parse(validMoney.Text);
                    accModel.Settlement = 0;
                    accModel.Status = "待审核";
                    accModel.ActualPlay = 0;
                    accModel.Bak1 = "全部渠道";
                    accBll.Add(accModel);
                    string myScript = @"alertRedirectMsg('申请成功!','success.gif','individualbal.aspx');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                }
                catch
                {
                    string myScript = @"alertMsg('申请失败!','error.gif');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                }
                //accBll.Add
            }
        }
    }
}
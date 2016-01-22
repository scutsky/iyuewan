using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using NPOI;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace Spread.Web.User
{
    public partial class Individualbal : System.Web.UI.Page
    {
        Model.Channel cModel = new Model.Channel();
        BLL.Channel cbll = new BLL.Channel();
        public Spread.Model.User modeluser = new Model.User();
        Spread.BLL.User blluser = new BLL.User();
        private string uid = "";
        private string pwd = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.startdate.Value = DateTime.Now.ToString("yyyy-MM-dd");
                this.enddate.Value = DateTime.Now.ToString("yyyy-MM-dd");
                if (!getUserCookies())
                {
                    Response.Redirect("~/Index.aspx");
                }
                else
                {
                    modeluser = blluser.GetModelByName(uid);
                    hduserid.Value = modeluser.ID.ToString();
                }
                ChannelData = cbll.GetList(" UserID='" + modeluser.ID + "'").Tables[0];
                RptBind();
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
      

        #region 数据列表绑定
        private void RptBind()
        {
            Spread.BLL.ReportAccounts bll = new Spread.BLL.ReportAccounts();
            StringBuilder strWhere = new StringBuilder();
            strWhere.Append(" and UserID='" + hduserid.Value + "' and Status='已审核' ");
            if (this.startdate.Value != "")
                strWhere.Append(" and CONVERT(varchar(100),ApplyTime,23) >='" + this.startdate.Value + "'");
            if (this.enddate.Value != "")
                strWhere.Append(" and CONVERT(DATETIME,ApplyTime) <='" + DateTime.Parse(this.enddate.Value).AddDays(1).ToString("yyyy-MM-dd") + "'");
         
            DataTable dt = bll.GetList(strWhere.ToString()).Tables[0];
            lbCount.Text = dt.Rows.Count.ToString();
            this.rptList.DataSource = dt;
            this.rptList.DataBind();
        }
        #endregion
      
        /// <summary>
        ///  产品
        /// </summary>
        protected DataTable ChannelData
        {
            get;
            set;
        }

        protected void searchBtn_Click(object sender, EventArgs e)
        {
            RptBind();
        }

        protected void export_Click(object sender, EventArgs e)
        {
            Spread.BLL.Report bll = new Spread.BLL.Report();
            StringBuilder strWhere = new StringBuilder();
            if (!string.IsNullOrEmpty(this.startdate.Value))
                strWhere.Append(" and CONVERT(Datetime,SumDate) >='" + this.startdate.Value + "'");
            if (!string.IsNullOrEmpty(this.enddate.Value))
                strWhere.Append(" and CONVERT(Datetime,SumDate) <='" + this.enddate.Value + "'");
          
            DataTable dt = bll.GetSumList(strWhere.ToString()).Tables[0];
            //ExportDataTableToExcel(dt, "详细报表");
            ExportDetailToExcel(dt, "详细报表");
        }

        private void ExportDetailToExcel(DataTable dt, string sheetName)
        {
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet(sheetName);//雨情
            #region
            HSSFRow headerRow = (HSSFRow)sheet1.CreateRow(1);
            HSSFCellStyle headStyle = (HSSFCellStyle)book.CreateCellStyle();
            headStyle.Alignment = HorizontalAlignment.Center;
            HSSFFont font = (HSSFFont)book.CreateFont();
            //设置单元格边框 
            headStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Red.Index;


            font.FontHeightInPoints = 10;
            font.Boldweight = 700;
            headStyle.SetFont(font);
            #endregion

            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
            row1.CreateCell(0).SetCellValue("日期");
            row1.CreateCell(1).SetCellValue("注册用户");
            row1.CreateCell(2).SetCellValue("充值金额");
            row1.CreateCell(3).SetCellValue("收入");


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);
                rowtemp.CreateCell(0).SetCellValue(dt.Rows[i]["SumDate"].ToString());
                rowtemp.CreateCell(1).SetCellValue(dt.Rows[i]["num"].ToString());
                rowtemp.CreateCell(2).SetCellValue(dt.Rows[i]["RegisterValue"].ToString());
                rowtemp.CreateCell(3).SetCellValue(dt.Rows[i]["Income"].ToString());
            }
            // 写入到客户端 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}.xls", sheetName + DateTime.Now.ToString("yyyyMMddHHmmssfff")));
            Response.BinaryWrite(ms.ToArray());
            book = null;
            ms.Close();
            ms.Dispose();
        }


    }
}

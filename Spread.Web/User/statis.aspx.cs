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
    public partial class statis : System.Web.UI.Page
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
                this.txtDate1.Value = DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd");
                this.txtDate2.Value = DateTime.Now.ToString("yyyy-MM-dd");
                
                if (!getUserCookies())
                {
                    Response.Redirect("~/Index.aspx");
                }
                else
                {
                    modeluser = blluser.GetModelByName(uid);
                    hduserid.Value = modeluser.ID.ToString();
                }
                if (Request.Params["startDateStr"] != null)
                {
                    this.txtDate1.Value = Request.Params["startDateStr"].ToString();
                }
                if (Request.Params["endDateStr"] != null)
                {
                    this.txtDate2.Value = Request.Params["endDateStr"].ToString();
                }
                ChannelData = cbll.GetList(" UserID='" + modeluser.ID + "'").Tables[0];
                MenuBind();
                TreeBind(ChannelData);
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

        #region 绑定类别
        private void MenuBind()
        {
            BLL.ExtendGame bllExtend = new BLL.ExtendGame();
            DataTable dt = bllExtend.GetListByUserId(hduserid.Value).Tables[0];
            ddlMenu.DataSource = dt;
            ddlMenu.DataTextField = "Title";
            ddlMenu.DataValueField = "Title";
            ddlMenu.DataBind();
            ListItem item = new ListItem("汇总", "0");
            ddlMenu.Items.Insert(0, item);
        }
        #endregion

        #region 绑定类别
        private void TreeBind(DataTable dt)
        {

            ddlChanel.DataSource = dt;
            ddlChanel.DataTextField = "Title";
            ddlChanel.DataValueField = "ID";
            ddlChanel.DataBind();
            ListItem item = new ListItem("汇总", "0");
            ddlChanel.Items.Insert(0, item);
        }
        #endregion

        #region 数据列表绑定
        private void RptBind()
        {
            Spread.BLL.Report bll = new Spread.BLL.Report();
            StringBuilder strWhere = new StringBuilder();
            strWhere.Append("   and UserID='" + hduserid.Value + "' ");
            if (this.txtDate1.Value != "")
                strWhere.Append(" and CONVERT(DATETIME,SumDate) >='" + this.txtDate1.Value + "'");
            if (this.txtDate2.Value != "")
                strWhere.Append(" and CONVERT(DATETIME,SumDate) <='" + this.txtDate2.Value + "'");
            if (this.ddlChanel.SelectedValue != "0")
                strWhere.Append(" and Bak2='" + this.ddlChanel.SelectedItem.Text + "'");
            if (this.gameinput.Value != "")
                strWhere.Append(" and GameName like '%" + this.gameinput.Value + "%' ");
            if (this.ddlMenu.SelectedValue != "0")
                strWhere.Append(" and Bak1='" + this.ddlMenu.SelectedValue + "' ");
            DataTable dt = bll.GetSumList(strWhere.ToString()).Tables[0];
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
            strWhere.Append("   and UserID='" + hduserid.Value + "' ");
            if (this.txtDate1.Value != "")
                strWhere.Append(" and CONVERT(DATETIME,SumDate) >='" + this.txtDate1.Value + "'");
            if (this.txtDate2.Value != "")
                strWhere.Append(" and CONVERT(DATETIME,SumDate) <='" + this.txtDate2.Value + "'");
            if (this.ddlChanel.SelectedValue != "0")
                strWhere.Append(" and Bak2='" + this.ddlChanel.SelectedItem.Text + "'");
            if (this.gameinput.Value != "")
                strWhere.Append(" and GameName like '%" + this.gameinput.Value + "%' ");
            if (this.ddlMenu.SelectedValue != "0")
                strWhere.Append(" and Bak1='" + this.ddlMenu.SelectedValue + "' ");
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
                rowtemp.CreateCell(2).SetCellValue(dt.Rows[i]["ConsumptionValue"].ToString());
                rowtemp.CreateCell(3).SetCellValue(dt.Rows[i]["Income"].ToString());
            }
            // 写入到客户端 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}.xls", sheetName+DateTime.Now.ToString("yyyyMMddHHmmssfff")));
            Response.BinaryWrite(ms.ToArray());
            book = null;
            ms.Close();
            ms.Dispose();
        }
        private void ExportDataTableToExcel(DataTable sourceTable, string sheetName)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            MemoryStream ms = new MemoryStream();
            ISheet sheet = workbook.CreateSheet(sheetName);
            IRow headerRow = sheet.CreateRow(0);
            foreach (DataColumn column in sourceTable.Columns)
            {
                headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
            }
            int rowIndex = 1;

            foreach (DataRow row in sourceTable.Rows)
            {
                IRow dataRow = sheet.CreateRow(rowIndex);

                foreach (DataColumn column in sourceTable.Columns)
                {
                    dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                }

                rowIndex++;
            }

            workbook.Write(ms);
            //ms.Flush();
            //ms.Position = 0;
            sheet = null;
            headerRow = null;
            workbook = null;
            ms.Close();
            ms.Dispose();
           

            //return ms;
        }

        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Trim()!="")
            {
                Spread.BLL.Report bll = new Spread.BLL.Report();
                StringBuilder strWhere = new StringBuilder();
                strWhere.Append(" UserID='" + this.hduserid.Value + "' ");
                if (e.CommandName.Trim() != "总计")
                {
                    strWhere.Append("AND SumDate='" + e.CommandName.Trim() + "'");
                }
               
                if (this.ddlChanel.SelectedValue != "0")
                    strWhere.Append(" and Bak2='" + this.ddlChanel.SelectedItem.Text + "'");
                if (this.gameinput.Value != "")
                    strWhere.Append(" and GameName like '%" + this.gameinput.Value + "%' ");
                if (this.ddlMenu.SelectedValue != "0")
                    strWhere.Append(" and Bak1='" + this.ddlMenu.SelectedValue + "' ");
                DataTable dt = bll.GetList(strWhere.ToString()).Tables[0];
                ExportDetailToExcel2(dt, "详细报表");
            }
        }
        private void ExportDetailToExcel2(DataTable dt, string sheetName)
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
            row1.CreateCell(0).SetCellValue("统计日期");
            row1.CreateCell(1).SetCellValue("平台");
            row1.CreateCell(2).SetCellValue("游戏");
            row1.CreateCell(3).SetCellValue("渠道");
            row1.CreateCell(4).SetCellValue("注册值");
            row1.CreateCell(5).SetCellValue("消费值");
            row1.CreateCell(6).SetCellValue("收入");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);
                rowtemp.CreateCell(0).SetCellValue(dt.Rows[i]["SumDate"].ToString());
                rowtemp.CreateCell(1).SetCellValue(dt.Rows[i]["Bak1"].ToString());
                rowtemp.CreateCell(2).SetCellValue(dt.Rows[i]["GameName"].ToString());
                rowtemp.CreateCell(3).SetCellValue(dt.Rows[i]["Bak2"].ToString());
                rowtemp.CreateCell(4).SetCellValue(dt.Rows[i]["RegisterValue"].ToString());
                rowtemp.CreateCell(5).SetCellValue(dt.Rows[i]["ConsumptionValue"].ToString());
                rowtemp.CreateCell(6).SetCellValue(dt.Rows[i]["Income"].ToString());
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

        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
           
        }

       
    }
}
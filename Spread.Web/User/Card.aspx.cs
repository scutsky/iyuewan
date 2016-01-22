using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using NPOI;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;


namespace Spread.Web.User
{
    public partial class Card : System.Web.UI.Page
    {
        BLL.CardGame bll = new BLL.CardGame();
        Model.CardGame model = new Model.CardGame();
        private string uid = "";
        private string pwd = "";
        public string keywords = "";
        public Spread.Model.User modeluser = new Model.User();
        Spread.BLL.User blluser = new BLL.User();
        Model.Channel cModel = new Model.Channel();
        BLL.Channel cbll = new BLL.Channel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!getUserCookies())
                {
                    Response.Redirect("~/Index.aspx");
                }
                else
                {
                    modeluser = blluser.GetModelByName(uid);
                    hduid.Value = modeluser.ID.ToString();

                }
                if (Request.Params["cooperationModelId"] != null)
                {
                    cModel = cbll.GetModel(int.Parse(Request.Params["cooperationModelId"].ToString()));
                    if (cModel.ID > 0)
                    {
                        hdcid.Value = cModel.ID.ToString();
                        hdcname.Value = cModel.Name;
                        RptBind(" ChanelID='" + cModel.ID.ToString() + "'" + this.CombSqlTxt(this.keywords));

                    }
                }

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
        #region 组合查询语句
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and gameName like '%" + _keywords + "%'");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 数据列表绑定
        private void RptBind(string strWhere)
        {
            this.rptList.DataSource = bll.GetList(strWhere);
            this.rptList.DataBind();
        }
        #endregion
        protected void searchBtn_Click(object sender, EventArgs e)
        {
            RptBind(" ChanelID='" + cModel.ID.ToString() + "'" + this.CombSqlTxt(this.keywords));
        }

        protected void linkInport_Click(object sender, EventArgs e)
        {
            DataTable dt = bll.GetList(" ChanelID='" + hdcid.Value + "'").Tables[0];
            //ExportDataTableToExcel(dt, "详细报表");
            ExportDetailToExcel(dt, "游戏礼包");
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
            row1.CreateCell(0).SetCellValue("游戏名称");
            row1.CreateCell(1).SetCellValue("礼包名称");
            row1.CreateCell(2).SetCellValue("礼包类型");
            row1.CreateCell(3).SetCellValue("可用状态");
            row1.CreateCell(4).SetCellValue("修改时间");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);
                rowtemp.CreateCell(0).SetCellValue(dt.Rows[i]["gamename"].ToString());
                rowtemp.CreateCell(1).SetCellValue(dt.Rows[i]["CardName"].ToString());
                rowtemp.CreateCell(2).SetCellValue(dt.Rows[i]["CardType"].ToString());
                rowtemp.CreateCell(3).SetCellValue(dt.Rows[i]["Status"].ToString());
                rowtemp.CreateCell(4).SetCellValue(dt.Rows[i]["UpdateDate"].ToString());
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using NPOI;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace Spread.Web.User
{
    public partial class Downloadgames : System.Web.UI.Page
    {
        BLL.ExtendGame extbll = new BLL.ExtendGame();
        Model.ExtendGame extmodel = new Model.ExtendGame();
        Model.Channel cModel = new Model.Channel();
        BLL.Channel cbll = new BLL.Channel();

        public int pcount;                                   //总条数
        public int page;                                     //当前页
        public readonly int pagesize = 10;                    //设置每页显示的大小
        public string classId="";
        public string cooperateModelId = "";
        public string keywords = "";
        private string uid = "";
        private string pwd = "";
        public string platformId = "";
        public Spread.Model.User modeluser = new Model.User();
        Spread.BLL.User blluser = new BLL.User();
        Spread.BLL.Menu bllMenu = new Spread.BLL.Menu();
        public string baseUrl = "";
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

                baseUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.IndexOf(Request.RawUrl));
                
                if (Request.Params["classId"] != null)
                {
                    classId = Request.Params["classId"].ToString();
                    platformId = Request.Params["classId"].ToString();
                }
                else
                {
                    platformId = "所有平台";
                }
                if (Request.Params["keywords"] != null)
                {
                    keywords = Request.Params["keywords"].ToString();
                    searchinput.Value = Request.Params["keywords"].ToString();
                }
                if (Request.Params["cooperateModelId"] != null)
                {
                    DataTable dt = cbll.GetList(" UserID='" + modeluser.ID + "'  AND c.id='" + Request.Params["cooperateModelId"] + "'").Tables[0]; 
                    if (dt.Rows.Count > 0)
                    {
                        lbTitle.Text = dt.Rows[0]["Title"].ToString();
                        lbBrand.Text = dt.Rows[0]["Brand"].ToString();
                        lbPtitle.Text = dt.Rows[0]["Ptitle"].ToString();
                    }
                    cooperateModelId = Request.Params["cooperateModelId"].ToString();
                    cModel = cbll.GetModel(int.Parse(Request.Params["cooperateModelId"].ToString()));
                     if (cModel.ID > 0)
                     {
                         hdcid.Value = cModel.ID.ToString();
                         hdcname.Value = cModel.Name;
                         RptBind(this.CombSqlTxt(this.classId, this.keywords), "UpdateDate desc");
                     }
                }
            }
            InfoView();
        }
        public DataTable MenuData
        {
            get;
            set;
        }
        private void InfoView()
        {
            MenuData = bllMenu.GetList("").Tables[0];
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
        private void RptBind(string strWhere, string orderby)
        {
            if (!int.TryParse(Request.Params["page"] as string, out this.page))
            {
                this.page = 0;
            }
            //获得总条数
            this.pcount = extbll.GetCount(" ChanelID='" + hdcid.Value + "'" + strWhere);
            this.rptList.DataSource = extbll.GetPageList(this.pagesize, this.page, " ChanelID='" + hdcid.Value + "'" + strWhere, orderby);
            this.rptList.DataBind();
        }
        #endregion


        #region 组合查询语句
        protected string CombSqlTxt(string _classId, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_classId))
            {
                strTemp.Append(" and Platform='" + _classId + "'");
            }
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and gameName like '%" + _keywords + "%'");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 组合URL语句
        protected string CombUrlTxt(string _cooperateModelId, string _classId, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append("keywords=" + Server.UrlEncode(_keywords) + "&");
            }
            if (!string.IsNullOrEmpty(_cooperateModelId))
            {
                strTemp.Append("cooperateModelId=" + Server.UrlEncode(_cooperateModelId) + "&");
            }
            if (!string.IsNullOrEmpty(_classId))
            {
                strTemp.Append("classId=" + Server.UrlEncode(_classId) + "&");
            }
            return strTemp.ToString();
        }
        #endregion

        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField txtId = (HiddenField)e.Item.FindControl("txtId");
            HiddenField txtbak1 = (HiddenField)e.Item.FindControl("txtbak1");
            HiddenField txtVerifycode = (HiddenField)e.Item.FindControl("txtVerifycode");
             switch (e.CommandName.ToLower())
            {
                //case "btnexport1":
                //    string myScript = @"copyToClipboard('" + txtbak1.Value + "');";
                //        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                //    break;
                case "btnexport2":
                    Spread.BLL.Report bll = new Spread.BLL.Report();
                    string sql = " e.ChanelID='" + hdcid.Value + "' and e.ID='" + txtId.Value + "'";
                    DataTable dt = extbll.GetList(sql).Tables[0];
                    ExportDetailToExcel(dt, "游戏包下载");
                    break;
                case "btnexport3":
                    string redirectUrl = "~/user/downloadapk.aspx?id=" + txtId.Value + "&vc=" + txtVerifycode.Value;
                    Response.Redirect(redirectUrl);
                    break;
            }
        }

        protected void searchbtn_Click(object sender, EventArgs e)
        {
            this.classId = this.hdPlatform.Value;
            this.keywords = this.searchinput.Value;
           ;
           //this.pcount = extbll.GetCount(" ChanelID='" + hdcid.Value + "'" + CombSqlTxt(classId, keywords));
           //this.rptList.DataSource = extbll.GetPageList(this.pagesize,0, " ChanelID='" + hdcid.Value + "'" + CombSqlTxt(classId, keywords), "UpdateDate desc");
           // this.rptList.DataBind();
            //RptBind(this.CombSqlTxt(this.classId, this.keywords), "UpdateDate desc");
            Response.Redirect("Downloadgames.aspx?" + this.CombUrlTxt(hdcid.Value, classId, this.keywords) + "page=0");
       
        }

        protected void lbdownall_Click(object sender, EventArgs e)
        {
            DataTable dt = extbll.GetList(" ChanelID='" + hdcid.Value + "'").Tables[0];
            //ExportDataTableToExcel(dt, "详细报表");
            ExportDetailToExcel(dt, "游戏包下载");
        }

        private void ExportDetailToExcel(DataTable dt, string sheetName)
        {
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet(sheetName);//雨情
            baseUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.IndexOf(Request.RawUrl));
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
            row1.CreateCell(1).SetCellValue("版本号");
            row1.CreateCell(2).SetCellValue("更新类型");
            row1.CreateCell(3).SetCellValue("获取包");


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);
                rowtemp.CreateCell(0).SetCellValue(dt.Rows[i]["gamename"].ToString());
                rowtemp.CreateCell(1).SetCellValue(dt.Rows[i]["version"].ToString());
                rowtemp.CreateCell(2).SetCellValue(dt.Rows[i]["UpdateType"].ToString());
                /*if (!string.IsNullOrEmpty(dt.Rows[i]["Verifycode"].ToString()))
                {
                    rowtemp.CreateCell(3).SetCellValue(baseUrl + "/user/downloadapk.aspx?id=" + dt.Rows[i]["ID"].ToString() + "&vc=" + dt.Rows[i]["Verifycode"].ToString());
                }
                else 
                {
                    rowtemp.CreateCell(3).SetCellValue(dt.Rows[i]["Bak1"].ToString());
                }*/
                rowtemp.CreateCell(3).SetCellValue(baseUrl + "/user/downloadapk.aspx?id=" + dt.Rows[i]["ID"].ToString() + "&vc=" + dt.Rows[i]["Verifycode"].ToString());
                
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
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                //LinkButton lbexport1 = (LinkButton)e.Item.FindControl("lbexport1");
                LinkButton lbexport2 = (LinkButton)e.Item.FindControl("lbexport2");
                LinkButton lbexport3 = (LinkButton)e.Item.FindControl("lbexport3");
                string classLayer =lbexport2.ToolTip;
                if (classLayer == "正在打包")
                {
                    //lbexport1.Visible = false;
                    lbexport2.Visible = false;
                    lbexport3.Visible = false;
                }
                else
                {
                    //lbexport1.Visible = true;
                    lbexport2.Visible = true;
                    lbexport3.Visible = true;
                }
            }
        }
    }
}
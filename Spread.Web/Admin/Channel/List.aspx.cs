using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spread.Web.UI;
using NPOI;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;


namespace Spread.Web.Admin.Channel
{
    public partial class List : ManagePage
    {
        public int classId;
        Spread.BLL.Channel bll = new Spread.BLL.Channel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.Params["classId"] as string, out this.classId))
            {
                this.classId = 0;
            }
            if (!Page.IsPostBack)
            {
                chkLoginLevel("viewChannel");
                TreeBind();
                BindData();
            }
        }
        #region 文章类别绑定
        private void TreeBind()
        {
            Spread.BLL.User cbll = new Spread.BLL.User();
            DataTable dt = cbll.GetList("").Tables[0];
            this.ddlClassId.Items.Clear();
            this.ddlClassId.Items.Add(new ListItem("所有账户", ""));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["Id"].ToString().Trim();
                string Name = dr["Name"].ToString().Trim();
                this.ddlClassId.Items.Add(new ListItem(Name, Id));
            }
        }
        #endregion
        //数据绑定
        private void BindData()
        {
            if (classId > 0)
            {
                DataTable dt = bll.GetList("UserId='" + classId + "'").Tables[0];
                this.rptClassList.DataSource = dt;
                this.rptClassList.DataBind();
                this.ddlClassId.SelectedValue = this.classId.ToString();
                this.ddlClassId.Enabled = false;
            }
            else
            {
                DataTable dt = bll.GetList("").Tables[0];
                this.rptClassList.DataSource = dt;
                this.rptClassList.DataBind();
            }
        }

        //删除操作
        protected void rptClassList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField txtClassId = (HiddenField)e.Item.FindControl("txtClassId");
            int id = Convert.ToInt32(txtClassId.Value);
            //switch (e.CommandName.ToLower())
            //{
            //    case "btndel":
            //        bll.Delete(Convert.ToInt32(txtClassId.Value));
            //        BindData();
            //        JscriptPrint("批量删除成功啦！", "", "Success");
            //        break;
            //    case "ibtnshow":
            //        Spread.Model.Channel model = bll.GetModel(id);
            //        if (model.IsShow == true)
            //            bll.UpdateField(id, "IsShow=false");
            //        else
            //            bll.UpdateField(id, "IsShow=true");
            //        BindData();
            //        break;               
            //    case "ibtnlock":
            //        Spread.Model.Channel model2 = bll.GetModel(id);
            //        if (model2.IsLock == true)
            //            bll.UpdateField(id, "IsLock=false");
            //        else
            //            bll.UpdateField(id, "IsLock=true");
            //        BindData();
            //        break;
            //}
        }
        //分类筛选
        protected void ddlClassId_SelectedIndexChanged(object sender, EventArgs e)
        {
            int _classId=0;
            if (int.TryParse(this.ddlClassId.SelectedValue.ToString(), out _classId))
            {
                DataTable dt = bll.GetList("UserId='" + _classId + "'").Tables[0];
                this.rptClassList.DataSource = dt;
                this.rptClassList.DataBind();
            }
            else
            {
                DataTable dt = bll.GetList("").Tables[0];
                this.rptClassList.DataSource = dt;
                this.rptClassList.DataBind();
            }

            //if (_classId > 0)
            //{
            //    DataTable dt = bll.GetList("UserId='" + classId + "'").Tables[0];
            //    this.rptClassList.DataSource = dt;
            //    this.rptClassList.DataBind();
            //    this.ddlClassId.SelectedValue = this.classId.ToString();
            //    this.ddlClassId.Enabled = false;
            //}
            //else
            //{
            //    DataTable dt = bll.GetList("").Tables[0];
            //    this.rptClassList.DataSource = dt;
            //    this.rptClassList.DataBind();
            //}
            
        }

        /// <summary>
        /// 获取子节点连接
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        protected string getSubLink(object id, object title, object layer)
        {
            int classLayer = Convert.ToInt32(layer.ToString());
            if (classLayer >= 3)
            {
                return title.ToString();
            }
            else
            {
                return string.Format("<a href=\"List.aspx?pid={0}\" title=\"查看子分类\">{1}</a>", id, title);
            }
        }
        

        /// <summary>
        /// 分类路径
        /// </summary>
        protected DataTable ChannelPath
        {
            get;
            set;
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            string strWhere = "";
            string userid=this.ddlClassId.SelectedValue.ToString();
            if (userid!="")
            {
                strWhere = "UserId='" + userid+"'";
            }
            DataTable dt = bll.GetListAll(strWhere).Tables[0];
            ExportDetailToExcel(dt, "详细渠道信息");
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
            row1.CreateCell(0).SetCellValue("渠道名称");
            row1.CreateCell(1).SetCellValue("推广游戏");
            row1.CreateCell(2).SetCellValue("平台");
            row1.CreateCell(3).SetCellValue("平台渠道");
            row1.CreateCell(4).SetCellValue("平台游戏");
            row1.CreateCell(5).SetCellValue("分成比例");
            row1.CreateCell(6).SetCellValue("推广包状态");
            row1.CreateCell(7).SetCellValue("更新类型");
            row1.CreateCell(8).SetCellValue("版本号");
            row1.CreateCell(9).SetCellValue("包连接");
            row1.CreateCell(10).SetCellValue("打包时间");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);
                rowtemp.CreateCell(0).SetCellValue(dt.Rows[i]["渠道名称"].ToString());
                rowtemp.CreateCell(1).SetCellValue(dt.Rows[i]["推广游戏"].ToString());
                rowtemp.CreateCell(2).SetCellValue(dt.Rows[i]["平台"].ToString());
                rowtemp.CreateCell(3).SetCellValue(dt.Rows[i]["平台渠道"].ToString());
                rowtemp.CreateCell(4).SetCellValue(dt.Rows[i]["平台游戏"].ToString());
                rowtemp.CreateCell(5).SetCellValue(dt.Rows[i]["分成比例"].ToString());
                rowtemp.CreateCell(6).SetCellValue(dt.Rows[i]["推广包状态"].ToString());
                rowtemp.CreateCell(7).SetCellValue(dt.Rows[i]["更新类型"].ToString());
                rowtemp.CreateCell(8).SetCellValue(dt.Rows[i]["版本号"].ToString());
                rowtemp.CreateCell(9).SetCellValue(dt.Rows[i]["包连接"].ToString());
                rowtemp.CreateCell(10).SetCellValue(dt.Rows[i]["打包时间"].ToString());
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

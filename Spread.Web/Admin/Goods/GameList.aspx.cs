using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spread.Common;
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Collections;
using Spread.DBUtility;

namespace Spread.Web.Admin.Goods
{
    public partial class GameList : Spread.Web.UI.ManagePage
    {
        public int pcount;                                   //总条数
        public int page;                                     //当前页
        public readonly int pagesize = 10;                    //设置每页显示的大小
        public readonly int kindId = 1;                      //类别种类

        public string classId = "";
        public string keywords = "";
        public string property = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Params["keywords"]))
            {
                this.keywords = Request.Params["keywords"].Trim();
            }
            if (!Page.IsPostBack)
            {
                chkLoginLevel("viewGoods");
                TreeBind();
                RptBind("Id>0" + this.CombSqlTxt(this.classId, this.keywords, this.property), "UpdateDate desc");
            }
        }
        //绑定类别
        private void TreeBind()
        {
            Spread.BLL.Menu bllMenu = new BLL.Menu();
            DataTable dt = bllMenu.GetList("").Tables[0];
            this.ddlPlatform.Items.Clear();
            this.ddlPlatform.Items.Add(new ListItem("请选择所属平台...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["Title"].ToString();
                string Title = dr["Title"].ToString().Trim();
                this.ddlPlatform.Items.Add(new ListItem(Title, Id));
            }
        }

        #region 数据列表绑定
        private void RptBind(string strWhere, string orderby)
        {
            if (!int.TryParse(Request.Params["page"] as string, out this.page))
            {
                this.page = 0;
            }
            Spread.BLL.Game bll = new Spread.BLL.Game();
            //获得总条数
            this.pcount = bll.GetRecordCount(strWhere);
            if (this.pcount > 0)
            {
                this.lbtnDel.Enabled = true;
            }
            else
            {
                this.lbtnDel.Enabled = false;
            }
            this.txtKeywords.Text = this.keywords;
            this.rptList.DataSource = bll.GetPageList(this.pagesize, this.page, strWhere, orderby);
            this.rptList.DataBind();
        }
        #endregion



        #region 组合查询语句
        protected string CombSqlTxt(string _classId, string _keywords, string _property)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");           
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and Title like '%" + _keywords + "%'");
            }
            if (!string.IsNullOrEmpty(classId))
            {
                strTemp.Append(" and Platform='" + _classId + "'");
            }
            if (!string.IsNullOrEmpty(property))
            {
                strTemp.Append(" and FirstLetter='" + _property + "'");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 组合URL语句 
        protected string CombUrlTxt(string _classId, string _keywords, string _property)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and Title like '%" + _keywords + "%'");
            }
            if (!string.IsNullOrEmpty(_classId))
            {
                strTemp.Append(" and Platform='" + _classId + "'");
            }
            if (!string.IsNullOrEmpty(_property))
            {
                strTemp.Append(" and FirstLetter='" + _property + "'");
            }           
            return strTemp.ToString();
        }
        #endregion

        //设置操作
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            
        }

        //分类筛选
        protected void ddlClassId_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("GameList.aspx?" + this.CombUrlTxt(this.classId, this.keywords, this.property) + "page=0");

        }

        //属性筛选
        protected void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("GameList.aspx?" + this.CombUrlTxt(this.classId, this.keywords, this.property) + "page=0");
        }

        //查询
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            Response.Redirect("GameList.aspx?" + this.CombUrlTxt(this.classId, this.keywords, this.property) + "page=0");
        }
        //删除
        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            chkLoginLevel("delGoods");
            Spread.BLL.Goods bll = new Spread.BLL.Goods();
            //批量删除
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((Label)rptList.Items[i].FindControl("lb_id")).Text);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cb_id");
                if (cb.Checked)
                {
                    bll.Delete(id);
                }
            }
            JscriptPrint("批量删除成功啦！", "GameList.aspx" + CombUrlTxt(this.classId,this.keywords,this.property) + "page=0", "Success");
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            if (ddlPlatform.SelectedValue=="")
            {
                Response.Write("<script>alert('请选择游戏平台！')</script>");
                return;
            }
            if (!file1.HasFile)
            {
                Response.Write("<script>alert('请选择上传文件！')</script>");
                return;
            }
            else
            {
                string fileName = file1.FileName;
                string savePath = Server.MapPath("~/file/");
                FileOperatpr(fileName, savePath);
                file1.PostedFile.SaveAs(savePath + fileName);//将图片存储到服务器上
                //FileUpload file = new FileUpload();
                //file.SaveAs(savePath + fileName);
                DataOperator(fileName, savePath);
                JscriptPrint("导入成功啦！", "GameList.aspx?" + CombUrlTxt(this.classId, this.keywords, this.property) + "page=0", "Success");
            }
        }

        #region 导入操作
        /// <summary>  
        /// 数据操作  
        /// </summary>  
        /// <param name="fileName"></param>  
        /// <param name="savePath"></param>  
        private void DataOperator(string fileName, string savePath)
        {

            string strConn = "Provider=Microsoft.Ace.OleDb.12.0;Data Source=" + savePath + fileName +
                             ";Extended Properties='Excel 12.0 Xml; HDR=YES; IMEX=1'";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            string strExcel = "select * from [Sheet1$]";
            OleDbDataAdapter da = new OleDbDataAdapter(strExcel, strConn);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
                conn.Close();
                DataSetOperator(ds, savePath + fileName);
            }
            catch (Exception ex)
            {
                throw new Exception("读取Excel失败：" + ex.Message);
            }
        }
        /// <summary>  
        /// 数据集操作  
        /// </summary>  
        /// <param name="ds"></param>  
        private void DataSetOperator(DataSet ds, string filePath)
        {
            int k = 0;
            if (ds.Tables[0].Rows.Count < 1)
            {
                JscriptMsg(350, 230, "错误提示", "<b>没有数据！</b>", "back", "Error");
                return;
            }
            try
            {
                string strPlatform=this.ddlPlatform.SelectedValue;
                //string strFirstLetter=this.ddlFirstLetter.SelectedValue;
                ArrayList SQLStringList1 = new ArrayList();
                Spread.BLL.Game bllGame = new BLL.Game();
                bllGame.DeletByPlatform(strPlatform);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    k++;
                    string sqlStr1 = "insert into Game(Name,Platform,FirstLetter,UpdateDate,IsLock)";
                    sqlStr1 += "values ('" + ds.Tables[0].Rows[i][1].ToString().Trim() + "',";
                    sqlStr1 += "'" + strPlatform + "',";
                    sqlStr1 += "'" + ds.Tables[0].Rows[i][0].ToString().Trim() + "',";
                    sqlStr1 += "'" + DateTime.Now + "',";
                    sqlStr1 += "'False')";//其他备注
                    SQLStringList1.Add(sqlStr1);
                }
                DbHelper.ExecuteSqlTran(SQLStringList1);
            }
            catch (Exception ex)
            {
                JscriptMsg(350, 230, "错误提示", "<b>没有数据！" + ex.Message + "</b>", "back", "Error");
            }
            finally
            {
                JscriptMsg(350, 230, "上传成功", "上传成功" + k + "条", "back", "Error");
                File.Delete(filePath);
            }
        }
        /// <summary>  
        /// 文件操作  
        /// </summary>  
        /// <param name="fileName"></param>  
        /// <param name="savePath"></param>  
        private void FileOperatpr(string fileName, string savePath)
        {
            if (!System.IO.Directory.Exists(savePath))
            {
                System.IO.Directory.CreateDirectory(savePath);
            }
            if (File.Exists(savePath + fileName))
            {
                File.Delete(savePath + fileName);
            }
        }
        #endregion
    }
}

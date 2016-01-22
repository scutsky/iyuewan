using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spread.Common;
using System.IO;
using System.Collections;
using System.Data.OleDb;
using Spread.DBUtility;
using System.Data.SqlClient;

namespace Spread.Web.Admin.statistics
{
    public partial class ReportUpload : Spread.Web.UI.ManagePage
    {
        public int pcount;                                   //总条数
        public int page;                                     //当前页
        public readonly int pagesize = 15;                    //设置每页显示的大小
        public readonly int kindId = 1;                      //类别种类

        public int userid;
        public string keywords = "";
        public string date1 = "";
        public string date2 = "";
        public string property = "";
        BLL.Menu bllMenu = new BLL.Menu();
        Model.Menu modMenu = new Model.Menu();
        private string strNum = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["Num"] != null)
            {
                this.hdNum.Value = Request.Params["Num"].ToString();
            }
            if (!Page.IsPostBack)
            {
                chkLoginLevel("viewUser");
                TreeBind(userid);
                ReportDataBind();
               // RptBind(" and Id>0" + this.CombSqlTxt(this.userid, this.keywords, date1, date2, this.property), "RegDate desc");
            }
        }

        #region 绑定类别
        private void TreeBind(int userID)
        {
            Spread.BLL.Tag cbll = new Spread.BLL.Tag();
            DataTable dt = bllMenu.GetList("").Tables[0];
            ddlMenu.DataSource = dt;
            ddlMenu.DataTextField = "Title";
            ddlMenu.DataValueField = "ID";
            ddlMenu.DataBind();
            ListItem item = new ListItem("汇总", "0");
            ddlMenu.Items.Insert(0, item);
        }
        #endregion

        private int int_SumDate = 0;
        private int int_ChannelName = 0;
        private int int_GameName = 0;
        private int int_RegisterValue = 0;
        private int int_ConsumptionValue = 0;
        private int int_Income = 0;
      
        protected void btnImport_Click(object sender, EventArgs e)
        {
            
            if (ddlMenu.SelectedValue == "")
            {
                JscriptMsg(350, 230, "错误提示", "<b>请选择平台！</b>", "back", "Error");
                return;
            }
            else
            {
                BLL.ReportSet bllSet = new BLL.ReportSet();
                Model.ReportSet modSet = new Model.ReportSet();
                modSet = bllSet.GetModelByBak(ddlMenu.SelectedValue);
                if (modSet != null)
                {
                    int_SumDate = int.Parse(modSet.SumDate);
                    int_ChannelName = int.Parse(modSet.ChannelName);
                    int_GameName = int.Parse(modSet.GameName);
                    int_RegisterValue = int.Parse(modSet.RegisterValue);
                    int_ConsumptionValue = int.Parse(modSet.ConsumptionValue);
                    int_Income = int.Parse(modSet.Income);
                }
                else
                {
                    JscriptMsg(350, 230, "错误提示", "<b>请先维护上传设置！</b>", "back", "Error");
                    return;
                }
            }
            if (FileUpload1.HasFile)
            {
                string fileName = FileUpload1.FileName;
                string savePath = Server.MapPath("~/file/");
                FileOperatpr(fileName, savePath);
                FileUpload1.PostedFile.SaveAs(savePath + fileName);//将图片存储到服务器上
                //FileUpload file = new FileUpload();
                //file.SaveAs(savePath + fileName);
                DataOperator(fileName, savePath);
                this.hdNum.Value = strNum;
                this.rptList.DataSource = DbHelper.Query(" select * from ReportTemp where Bak4= '" + strNum + "'").Tables[0];
                this.rptList.DataBind();
                //Response.Redirect("ReportUpload.aspx?Num=" + strNum);
                //JscriptPrint("导入成功啦！", "ReportUpload.aspx?Num=" + strNum + "", "Success");
                 //JscriptMsg(350, 230, "上传成功", "上传成功" + k + "条", "back", "Success");
            }
            else
            {
                JscriptMsg(350, 230, "错误提示", "<b>请选择文件！</b>", "back", "Error");
            }
        }

        private void ReportDataBind()
        {

            this.rptList.DataSource = DbHelper.Query(" select * from ReportTemp where Bak4= '" + this.hdNum.Value + "' order by bak3 ").Tables[0];
            this.rptList.DataBind();
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
                DateTime strSumDate;
                string strChannelName;
                string strGameName;
                decimal strRegisterValue;
                decimal strConsumptionValue;
                decimal strIncome;
                strNum = Guid.NewGuid().ToString();
                ArrayList SQLStringList1 = new ArrayList();
                ArrayList SQLStringList2 = new ArrayList();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    k++;
                    #region 统计日期格式转换
                    try
                    {
                        strSumDate = Convert.ToDateTime(ds.Tables[0].Rows[i][int_SumDate].ToString().Trim());
                    }
                    catch
                    {
                        SQLStringList2.Add("第" + k + "行统计日期错误");
                        break;
                    }
                    #endregion

                    #region 渠道名称格式转换
                    try
                    {
                        if (ds.Tables[0].Rows[i][int_ChannelName].ToString().Trim().Length > 0)
                        {
                            strChannelName = ds.Tables[0].Rows[i][int_ChannelName].ToString().Trim();
                        }
                        else
                        {
                            SQLStringList2.Add("第" + k + "行渠道名称不能为空");
                            break;
                        }
                    }
                    catch
                    {
                        SQLStringList2.Add("第" + k + "行渠道名称错误");
                        break;
                    }
                    #endregion

                    #region 游戏名称格式转换
                    try
                    {
                        if (ds.Tables[0].Rows[i][int_GameName].ToString().Trim().Length > 0)
                        {
                            strGameName = ds.Tables[0].Rows[i][int_GameName].ToString().Trim();
                        }
                        else
                        {
                            SQLStringList2.Add("第" + k + "行游戏名称不能为空");
                            break;
                        }
                    }
                    catch
                    {
                        SQLStringList2.Add("第" + k + "行游戏名称错误");
                        break;
                    }
                    #endregion

                    #region 注册值格式转换
                    try
                    {
                        strRegisterValue = decimal.Parse(ds.Tables[0].Rows[i][int_RegisterValue].ToString().Trim());
                    }
                    catch
                    {
                        SQLStringList2.Add("第" + k + "行注册值错误");
                        break;
                    }
                    #endregion

                    #region 消费值格式转换
                    try
                    {
                        strConsumptionValue = decimal.Parse(ds.Tables[0].Rows[i][int_ConsumptionValue].ToString().Trim());
                    }
                    catch
                    {
                        SQLStringList2.Add("第" + k + "行消费值错误");
                        break;
                    }
                    #endregion

                    #region 收入值格式转换
                    try
                    {
                        strIncome = decimal.Parse(ds.Tables[0].Rows[i][int_Income].ToString().Trim());
                    }
                    catch
                    {
                        SQLStringList2.Add("第" + k + "行收入值错误");
                        break;
                    }
                    #endregion

                    string sqlStr1 = "insert into ReportTemp([SumDate],[ChannelName],[GameName],[RegisterValue],[ConsumptionValue],[Bak1],[Bak4],[AddDate])";
                    sqlStr1 += "values ('" + strSumDate.ToString("yyyy-MM-dd") + "',";//SumDate 统计日期
                    sqlStr1 += "'" + strChannelName + "',";//ChannelName 渠道
                    sqlStr1 += "'" + strGameName + "',";//GameName  游戏名称
                    sqlStr1 += "'" + strRegisterValue + "',";//RegisterValue 注册值
                    sqlStr1 += "'" + strConsumptionValue + "',";//ConsumptionValue 消费值
                    sqlStr1 += "'" + ddlMenu.SelectedItem.Text + "',";//平台
                    //sqlStr1 += "'0',";//Income 收入
                    sqlStr1 += "'" + strNum + "',";//导入总单号
                    sqlStr1 += "'" + DateTime.Now + "')";//AddDate 添加时间
                    //sqlStr1 += "'" + hduserid.Value + "')";//UserID 用户ID
                    SQLStringList1.Add(sqlStr1);
                }
                if (SQLStringList2.Count == 0)
                {
                    DbHelper.ExecuteSqlTran(SQLStringList1);

                    BLL.ReportTempMain bllMain = new BLL.ReportTempMain();
                    Model.ReportTempMain modMain = new Model.ReportTempMain();
                    modMain.Name = ddlMenu.SelectedItem.Text + string.Format("{0:yyyyMMddHHmmssffff}", DateTime.Now);
                    modMain.Num = strNum;
                    bllMain.Add(modMain);
                    SqlParameter[] parameters = {
                    new SqlParameter("@NumID", SqlDbType.NVarChar,50)};
                    parameters[0].Value = strNum;
                    DbHelper.RunProcedure("SP_Process_Report", parameters);
                    int num = Convert.ToInt32(DbHelper.GetSingle("select count(*) from ReportTemp where bak4='" + strNum + "' and ChannelID=0 "));
                    if (num > 0)
                    {
                        JscriptMsg(350, 230, "错误提示", "<b>验证失败有错误信息！</b>", "back", "Error");
                    }
                    else
                    {
                        SqlParameter[] parameters2 = {
                        new SqlParameter("@NumID", SqlDbType.NVarChar,50)};
                        parameters2[0].Value = strNum;
                        DbHelper.RunProcedure("SP_Insert_Report", parameters2);
                    }
                }
                else
                {
                    string msg = "";
                    for (int i = 0; i < SQLStringList2.Count; i++)
                    {
                        msg += SQLStringList2[i].ToString();
                    }
                    JscriptMsg(350, 230, "错误提示", "<b>没有数据！" + msg + "</b>", "back", "Error");
                }
            }
            catch (Exception ex)
            {
                JscriptMsg(350, 230, "错误提示", "<b>没有数据！" + ex.Message + "</b>", "back", "Error");
            }
            finally
            {
                JscriptMsg(350, 230, "上传成功", "上传成功" + k + "条", "back", "Success");
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

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

namespace Spread.Web.Admin.statistics
{
    public partial class Daycount : Spread.Web.UI.ManagePage
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
        BLL.Channel bllChannel = new BLL.Channel();
        Model.Channel modChannel = new Model.Channel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.Params["userid"] as string, out this.userid))
            {
                JscriptMsg(350, 230, "错误提示", "<b>出现错误啦！</b>您要修改主键不明确或参数不正确。", "back", "Error");
                return;

            }
            this.hduserid.Value = userid.ToString();
            if (!string.IsNullOrEmpty(Request.Params["keywords"]))
            {
                this.keywords = Request.Params["keywords"].Trim();
            }
            if (!string.IsNullOrEmpty(Request.Params["property"]))
            {
                this.property = Request.Params["property"].Trim();
            }

            if (!Page.IsPostBack)
            {
                chkLoginLevel("viewUser");
                TreeBind(userid);
                RptBind(" and Id>0" + this.CombSqlTxt(this.userid, this.keywords, date1, date2, this.property), "RegDate desc");
            }
        }

        #region 绑定类别
        private void TreeBind(int userID)
         {
             Spread.BLL.Tag cbll = new Spread.BLL.Tag();
             DataTable dt = bllChannel.GetList(" UserID='" + userID.ToString() + "'").Tables[0];
             ddlChanel.DataSource = dt;
             ddlChanel.DataTextField = "Title";
             ddlChanel.DataValueField = "ID";
             ddlChanel.DataBind();
             ListItem item = new ListItem("汇总", "0");
             ddlChanel.Items.Insert(0, item);
         }
        #endregion

        #region 数据列表绑定
        private void RptBind(string strWhere, string orderby)
        {
            if (!int.TryParse(Request.Params["page"] as string, out this.page))
            {
                this.page = 0;
            }
            Spread.BLL.Report bll = new Spread.BLL.Report();            
            if (this.userid > 0)
            {
                //this.ddlClassId.SelectedValue = this.UserType.ToString();
                //this.ddlClassId.Enabled = false;
            }
            //this.txtKeywords.Text = this.keywords;
            //this.ddlProperty.SelectedValue = this.property;

            this.rptList.DataSource = bll.GetSumList(strWhere);
            this.rptList.DataBind();
        }
        #endregion

        #region 组合查询语句
        protected string CombSqlTxt(int _classId, string _keywords,string _date1,string _date2, string _property)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (_classId > 0)
            {
                strTemp.Append(" and UserId=" + _classId + "");
                //strTemp.Append(" and ClassId in(select Id from Channel where KindId=" + this.kindId + " and ClassList like '%," + _classId + ",%')");
            }
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and Title like '%" + _keywords + "%'");
            }
            if (!string.IsNullOrEmpty(_date1))
            {
                strTemp.Append(" and CONVERT(Datetime,SumDate) >='" + _date1 + "'");
            }
            if (!string.IsNullOrEmpty(_date2))
            {
                strTemp.Append(" and CONVERT(Datetime,SumDate) <='" + _date2 + "'");
            }
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and Title like '%" + _keywords + "%'");
            }
            if (!string.IsNullOrEmpty(_property))
            {
                switch (_property)
                {
                    case "isLock":
                        strTemp.Append(" and IsLock=1");
                        break;
                    case "isNoLock":
                        strTemp.Append(" and IsLock=0");
                        break;

                }
            }

            return strTemp.ToString();
        }
        #endregion

        #region 组合URL语句
        protected string CombUrlTxt(int _classId, string _keywords, string _property)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (_classId > 0)
            {
                strTemp.Append("UserType=" + _classId.ToString() + "&");
            }
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append("keywords=" + Server.UrlEncode(_keywords) + "&");
            }
            if (!string.IsNullOrEmpty(_property))
            {
                strTemp.Append("property=" + _property + "&");
            }

            return strTemp.ToString();
        }
        #endregion

        //设置操作
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(((Label)e.Item.FindControl("lb_id")).Text);
            Spread.BLL.User bll = new Spread.BLL.User();
            Spread.Model.User model = bll.GetModel(id);
            switch (e.CommandName.ToLower())
            {
                case "ibtnmsg":
                    if (model.IsLock == true)
                        bll.UpdateField(id, "IsLock=0");
                    else
                        bll.UpdateField(id, "IsLock=1");
                    break;
            }
            RptBind("Id>0" + this.CombSqlTxt(this.userid, this.keywords, date1, date2,this.property), "AddTime desc");
        }
        //分类筛选
        protected void ddlClassId_SelectedIndexChanged(object sender, EventArgs e)
        {
            int _classId;
            //if (int.TryParse(this.ddlClassId.SelectedValue.ToString(), out _classId))
            //{
            //    Response.Redirect("UserList.aspx?" + this.CombUrlTxt(_classId, this.keywords, this.property) + "page=0");
            //}
            //else
            //{
            //    Response.Redirect("UserList.aspx?" + this.CombUrlTxt(0, this.keywords, this.property) + "page=0");
            //}
        }
        //属性筛选
        protected void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Response.Redirect("UserList.aspx?" + this.CombUrlTxt(this.UserType, this.keywords, this.ddlProperty.SelectedValue) + "page=0");
        }
        //查询
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            RptBind(" and Id>0" + this.CombSqlTxt(this.userid, this.keywords, this.txtDate1.Text,this.txtDate2.Text,this.property), "RegDate desc");
        }
        //删除
        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            chkLoginLevel("delUser");
            Spread.BLL.User bll = new Spread.BLL.User();
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
            JscriptPrint("批量删除成功啦！", "UserList.aspx?" + CombUrlTxt(this.userid, this.keywords, this.property) + "page=0", "Success");
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {

            if (FileUpload1.HasFile)
            {

                string fileName = FileUpload1.FileName;
                string savePath = Server.MapPath("~/file/");
                FileOperatpr(fileName, savePath);
                FileUpload1.PostedFile.SaveAs(savePath + fileName);//将图片存储到服务器上
                //FileUpload file = new FileUpload();
                //file.SaveAs(savePath + fileName);
                DataOperator(fileName, savePath);
                JscriptPrint("导入成功啦！", "Daycount.aspx?userid=" + userid + "&page=0", "Success");
            }
            else
            {
                JscriptMsg(350, 230, "错误提示", "<b>请选择文件！</b>", "back", "Error");
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
                ArrayList SQLStringList1 = new ArrayList();
                ArrayList SQLStringList2 = new ArrayList();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string sqlStr1 = "insert into Report([SumDate],[ChannelName],[GameName],[RegisterValue],[ConsumptionValue],[Income],[AddDate],[UserID])";
                    sqlStr1 += "values ('" + ds.Tables[0].Rows[i][0].ToString() + "',";//SumDate 统计日期
                    sqlStr1 += "'" + ds.Tables[0].Rows[i][1].ToString() + "',";//ChannelName 渠道
                    sqlStr1 += "'" + ds.Tables[0].Rows[i][2].ToString() + "',";//GameName  游戏名称
                    sqlStr1 += "'" + ds.Tables[0].Rows[i][3].ToString() + "',";//RegisterValue 注册值
                    sqlStr1 += "'" + ds.Tables[0].Rows[i][4].ToString() + "',";//ConsumptionValue 消费值
                    sqlStr1 += "'" + ds.Tables[0].Rows[i][5].ToString() + "',";//Income 收入
                    sqlStr1 += "'" + DateTime.Now + "',";//AddDate 添加时间
                    sqlStr1 += "'" + hduserid.Value + "')";//UserID 用户ID
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
                //JscriptMsg(350, 230, "上传成功", "上传成功" + k + "条", "back", "Error");
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

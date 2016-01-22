using System;
using System.Collections.Generic;
using System.Text;
using Spread.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace Spread.DAL
{
    public class ReportAccounts
    {
        public ReportAccounts()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.ReportAccounts model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ReportAccounts(");
            strSql.Append("ApplyTime,SettlementCycle,Recharge,Income,Settlement,Status,ActualPlay,UserID,UserName,Bak1,Bak2,Bak3)");
            strSql.Append(" values (");
            strSql.Append("@ApplyTime,@SettlementCycle,@Recharge,@Income,@Settlement,@Status,@ActualPlay,@UserID,@UserName,@Bak1,@Bak2,@Bak3)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ApplyTime", SqlDbType.DateTime),
					new SqlParameter("@SettlementCycle", SqlDbType.NVarChar,50),
					new SqlParameter("@Recharge", SqlDbType.Decimal,9),
					new SqlParameter("@Income", SqlDbType.Decimal,9),
					new SqlParameter("@Settlement", SqlDbType.Decimal,9),
					new SqlParameter("@Status", SqlDbType.NVarChar,50),
					new SqlParameter("@ActualPlay", SqlDbType.Decimal,9),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Bak1", SqlDbType.NVarChar,50),
					new SqlParameter("@Bak2", SqlDbType.NVarChar,50),
					new SqlParameter("@Bak3", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ApplyTime;
            parameters[1].Value = model.SettlementCycle;
            parameters[2].Value = model.Recharge;
            parameters[3].Value = model.Income;
            parameters[4].Value = model.Settlement;
            parameters[5].Value = model.Status;
            parameters[6].Value = model.ActualPlay;
            parameters[7].Value = model.UserID;
            parameters[8].Value = model.UserName;
            parameters[9].Value = model.Bak1;
            parameters[10].Value = model.Bak2;
            parameters[11].Value = model.Bak3;

            object obj = DbHelper.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.ReportAccounts model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ReportAccounts set ");
            strSql.Append("ApplyTime=@ApplyTime,");
            strSql.Append("SettlementCycle=@SettlementCycle,");
            strSql.Append("Recharge=@Recharge,");
            strSql.Append("Income=@Income,");
            strSql.Append("Settlement=@Settlement,");
            strSql.Append("Status=@Status,");
            strSql.Append("ActualPlay=@ActualPlay,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("Bak1=@Bak1,");
            strSql.Append("Bak2=@Bak2,");
            strSql.Append("Bak3=@Bak3");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ApplyTime", SqlDbType.DateTime),
					new SqlParameter("@SettlementCycle", SqlDbType.NVarChar,50),
					new SqlParameter("@Recharge", SqlDbType.Decimal,9),
					new SqlParameter("@Income", SqlDbType.Decimal,9),
					new SqlParameter("@Settlement", SqlDbType.Decimal,9),
					new SqlParameter("@Status", SqlDbType.NVarChar,50),
					new SqlParameter("@ActualPlay", SqlDbType.Decimal,9),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Bak1", SqlDbType.NVarChar,50),
					new SqlParameter("@Bak2", SqlDbType.NVarChar,50),
					new SqlParameter("@Bak3", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.ApplyTime;
            parameters[1].Value = model.SettlementCycle;
            parameters[2].Value = model.Recharge;
            parameters[3].Value = model.Income;
            parameters[4].Value = model.Settlement;
            parameters[5].Value = model.Status;
            parameters[6].Value = model.ActualPlay;
            parameters[7].Value = model.UserID;
            parameters[8].Value = model.UserName;
            parameters[9].Value = model.Bak1;
            parameters[10].Value = model.Bak2;
            parameters[11].Value = model.Bak3;
            parameters[12].Value = model.ID;

            int rows = DbHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 修改一条数据
        /// </summary>
        public void UpdateField(int Id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [ReportAccounts] set " + strValue);
            strSql.Append(" where Id=" + Id);
            DbHelper.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetPageList(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            if (currentPage > 0)
            {
                int topNum = pageSize * currentPage;
                strSql.Append("select top " + pageSize + " * from [ReportAccounts]");
                strSql.Append(" where Id not in(select top " + topNum + " Id from [ReportAccounts]");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                strSql.Append(" order by " + filedOrder + ")");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" and " + strWhere);
                }
                strSql.Append(" order by " + filedOrder);
            }
            else
            {
                strSql.Append("select top " + pageSize + " * from [ReportAccounts]");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                strSql.Append(" order by " + filedOrder);
            }

            return DbHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ReportAccounts ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            int rows = DbHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteByDate(string strDate)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ReportAccounts ");
            strSql.Append(" where SettlementCycle=@SettlementCycle");
            SqlParameter[] parameters = {
					new SqlParameter("@SettlementCycle", SqlDbType.NVarChar,50)
			};
            parameters[0].Value = strDate;

            int rows = DbHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ReportAccounts ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelper.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.ReportAccounts GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,ApplyTime,SettlementCycle,Recharge,Income,Settlement,Status,ActualPlay,UserID,UserName,Bak1,Bak2,Bak3 from ReportAccounts ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Model.ReportAccounts model = new Model.ReportAccounts();
            DataSet ds = DbHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.ReportAccounts DataRowToModel(DataRow row)
        {
            Model.ReportAccounts model = new Model.ReportAccounts();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["ApplyTime"] != null && row["ApplyTime"].ToString() != "")
                {
                    model.ApplyTime = DateTime.Parse(row["ApplyTime"].ToString());
                }
                if (row["SettlementCycle"] != null)
                {
                    model.SettlementCycle = row["SettlementCycle"].ToString();
                }
                if (row["Recharge"] != null && row["Recharge"].ToString() != "")
                {
                    model.Recharge = decimal.Parse(row["Recharge"].ToString());
                }
                if (row["Income"] != null && row["Income"].ToString() != "")
                {
                    model.Income = decimal.Parse(row["Income"].ToString());
                }
                if (row["Settlement"] != null && row["Settlement"].ToString() != "")
                {
                    model.Settlement = decimal.Parse(row["Settlement"].ToString());
                }
                if (row["Status"] != null)
                {
                    model.Status = row["Status"].ToString();
                }
                if (row["ActualPlay"] != null && row["ActualPlay"].ToString() != "")
                {
                    model.ActualPlay = decimal.Parse(row["ActualPlay"].ToString());
                }
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["Bak1"] != null)
                {
                    model.Bak1 = row["Bak1"].ToString();
                }
                if (row["Bak2"] != null)
                {
                    model.Bak2 = row["Bak2"].ToString();
                }
                if (row["Bak3"] != null)
                {
                    model.Bak3 = row["Bak3"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,ApplyTime,SettlementCycle,Recharge,Income,Settlement,Status,ActualPlay,UserID,UserName,Bak1,Bak2,Bak3 ");
            strSql.Append(" FROM ReportAccounts ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where 0=0 " + strWhere);
            }
            return DbHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,ApplyTime,SettlementCycle,Recharge,Income,Settlement,Status,ActualPlay,UserID,UserName,Bak1,Bak2,Bak3 ");
            strSql.Append(" FROM ReportAccounts ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM ReportAccounts ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelper.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from ReportAccounts T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelper.Query(strSql.ToString());
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}


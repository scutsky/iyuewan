using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Spread.DBUtility;

namespace Spread.DAL
{

    /// <summary>
    /// 数据访问类:Report
    /// </summary>
    public partial class Report
    {
        public Report()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Report model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Report(");
            strSql.Append("SumDate,ChannelID,ChannelName,GameID,GameName,RegisterValue,ConsumptionValue,Income,AddDate,UserID,UserName,Bak1,Bak2,Bak3,Bak4)");
            strSql.Append(" values (");
            strSql.Append("@SumDate,@ChannelID,@ChannelName,@GameID,@GameName,@RegisterValue,@ConsumptionValue,@Income,@AddDate,@UserID,@UserName,@Bak1,@Bak2,@Bak3,@Bak4)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@SumDate", SqlDbType.NVarChar,50),
					new SqlParameter("@ChannelID", SqlDbType.Int,4),
					new SqlParameter("@ChannelName", SqlDbType.NVarChar,50),
					new SqlParameter("@GameID", SqlDbType.Int,4),
					new SqlParameter("@GameName", SqlDbType.NVarChar,50),
					new SqlParameter("@RegisterValue", SqlDbType.Decimal,9),
					new SqlParameter("@ConsumptionValue", SqlDbType.Decimal,9),
					new SqlParameter("@Income", SqlDbType.Decimal,9),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Bak1", SqlDbType.NVarChar,50),
					new SqlParameter("@Bak2", SqlDbType.NVarChar,50),
					new SqlParameter("@Bak3", SqlDbType.NVarChar,50),
					new SqlParameter("@Bak4", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.SumDate;
            parameters[1].Value = model.ChannelID;
            parameters[2].Value = model.ChannelName;
            parameters[3].Value = model.GameID;
            parameters[4].Value = model.GameName;
            parameters[5].Value = model.RegisterValue;
            parameters[6].Value = model.ConsumptionValue;
            parameters[7].Value = model.Income;
            parameters[8].Value = model.AddDate;
            parameters[9].Value = model.UserID;
            parameters[10].Value = model.UserName;
            parameters[11].Value = model.Bak1;
            parameters[12].Value = model.Bak2;
            parameters[13].Value = model.Bak3;
            parameters[14].Value = model.Bak4;

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
        public bool Update(Model.Report model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Report set ");
            strSql.Append("SumDate=@SumDate,");
            strSql.Append("ChannelID=@ChannelID,");
            strSql.Append("ChannelName=@ChannelName,");
            strSql.Append("GameID=@GameID,");
            strSql.Append("GameName=@GameName,");
            strSql.Append("RegisterValue=@RegisterValue,");
            strSql.Append("ConsumptionValue=@ConsumptionValue,");
            strSql.Append("Income=@Income,");
            strSql.Append("AddDate=@AddDate,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("Bak1=@Bak1,");
            strSql.Append("Bak2=@Bak2,");
            strSql.Append("Bak3=@Bak3,");
            strSql.Append("Bak4=@Bak4");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@SumDate", SqlDbType.NVarChar,50),
					new SqlParameter("@ChannelID", SqlDbType.Int,4),
					new SqlParameter("@ChannelName", SqlDbType.NVarChar,50),
					new SqlParameter("@GameID", SqlDbType.Int,4),
					new SqlParameter("@GameName", SqlDbType.NVarChar,50),
					new SqlParameter("@RegisterValue", SqlDbType.Decimal,9),
					new SqlParameter("@ConsumptionValue", SqlDbType.Decimal,9),
					new SqlParameter("@Income", SqlDbType.Decimal,9),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Bak1", SqlDbType.NVarChar,50),
					new SqlParameter("@Bak2", SqlDbType.NVarChar,50),
					new SqlParameter("@Bak3", SqlDbType.NVarChar,50),
					new SqlParameter("@Bak4", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.SumDate;
            parameters[1].Value = model.ChannelID;
            parameters[2].Value = model.ChannelName;
            parameters[3].Value = model.GameID;
            parameters[4].Value = model.GameName;
            parameters[5].Value = model.RegisterValue;
            parameters[6].Value = model.ConsumptionValue;
            parameters[7].Value = model.Income;
            parameters[8].Value = model.AddDate;
            parameters[9].Value = model.UserID;
            parameters[10].Value = model.UserName;
            parameters[11].Value = model.Bak1;
            parameters[12].Value = model.Bak2;
            parameters[13].Value = model.Bak3;
            parameters[14].Value = model.Bak4;
            parameters[15].Value = model.ID;

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
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Report ");
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Report ");
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
        public Model.Report GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,SumDate,ChannelID,ChannelName,GameID,GameName,RegisterValue,ConsumptionValue,Income,AddDate,UserID,UserName,Bak1,Bak2,Bak3,Bak4 from Report ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Model.Report model = new Model.Report();
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
        public Model.Report DataRowToModel(DataRow row)
        {
            Model.Report model = new Model.Report();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["SumDate"] != null)
                {
                    model.SumDate = row["SumDate"].ToString();
                }
                if (row["ChannelID"] != null && row["ChannelID"].ToString() != "")
                {
                    model.ChannelID = int.Parse(row["ChannelID"].ToString());
                }
                if (row["ChannelName"] != null)
                {
                    model.ChannelName = row["ChannelName"].ToString();
                }
                if (row["GameID"] != null && row["GameID"].ToString() != "")
                {
                    model.GameID = int.Parse(row["GameID"].ToString());
                }
                if (row["GameName"] != null)
                {
                    model.GameName = row["GameName"].ToString();
                }
                if (row["RegisterValue"] != null && row["RegisterValue"].ToString() != "")
                {
                    model.RegisterValue = decimal.Parse(row["RegisterValue"].ToString());
                }
                if (row["ConsumptionValue"] != null && row["ConsumptionValue"].ToString() != "")
                {
                    model.ConsumptionValue = decimal.Parse(row["ConsumptionValue"].ToString());
                }
                if (row["Income"] != null && row["Income"].ToString() != "")
                {
                    model.Income = decimal.Parse(row["Income"].ToString());
                }
                if (row["AddDate"] != null && row["AddDate"].ToString() != "")
                {
                    model.AddDate = DateTime.Parse(row["AddDate"].ToString());
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
                if (row["Bak4"] != null)
                {
                    model.Bak4 = row["Bak4"].ToString();
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
            strSql.Append(" select * from Report ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            strSql.Append(" ID,SumDate,ChannelID,ChannelName,GameID,GameName,RegisterValue,ConsumptionValue,Income,AddDate,UserID,UserName,Bak1,Bak2,Bak3,Bak4 ");
            strSql.Append(" FROM Report ");
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
            strSql.Append("select count(1) FROM Report ");
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
            strSql.Append(")AS Row, T.*  from Report T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelper.Query(strSql.ToString());
        }
        public DataSet GetSumList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM (SELECT  SumDate, SUM(RegisterValue) AS num, SUM(ConsumptionValue) AS ConsumptionValue, SUM(Income) AS Income ");
            strSql.Append(" FROM  dbo.Report where 0=0 " + strWhere + "");
            strSql.Append(" GROUP BY SumDate ");
            strSql.Append(" UNION ALL ");
            strSql.Append(" SELECT  '总计', SUM(RegisterValue) AS num, SUM(ConsumptionValue) AS ConsumptionValue, SUM(Income) AS Income ");
            strSql.Append(" FROM  dbo.Report where 0=0  " + strWhere + " ) A" );
            strSql.Append(" ORDER BY (case A.SumDate when '总计' then 1 else 0 end), SumDate DESC");
            
            return DbHelper.Query(strSql.ToString());
        }
        public DataSet GetSumListZT(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT  '总计', SUM(RegisterValue) AS num, SUM(ConsumptionValue) AS ConsumptionValue, SUM(Income) AS Income ");
            strSql.Append(" FROM  dbo.Report where 0=0  " + strWhere + " ");
            return DbHelper.Query(strSql.ToString());
        }
       
        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "Report";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}


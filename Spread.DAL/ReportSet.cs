using System;
using System.Collections.Generic;
using System.Text;
using Spread.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace Spread.DAL
{
    public class ReportSet
    {
        public ReportSet()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.ReportSet model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ReportSet(");
            strSql.Append("SumDate,ChannelName,GameName,RegisterValue,ConsumptionValue,Income,Bak1,Bak2,Bak3)");
            strSql.Append(" values (");
            strSql.Append("@SumDate,@ChannelName,@GameName,@RegisterValue,@ConsumptionValue,@Income,@Bak1,@Bak2,@Bak3)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@SumDate", SqlDbType.NVarChar,50),
					new SqlParameter("@ChannelName", SqlDbType.NVarChar,50),
					new SqlParameter("@GameName", SqlDbType.NVarChar,50),
					new SqlParameter("@RegisterValue", SqlDbType.NVarChar,50),
					new SqlParameter("@ConsumptionValue", SqlDbType.NVarChar,50),
					new SqlParameter("@Income", SqlDbType.NVarChar,50),
					new SqlParameter("@Bak1", SqlDbType.NVarChar,50),
					new SqlParameter("@Bak2", SqlDbType.NVarChar,50),
					new SqlParameter("@Bak3", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.SumDate;
            parameters[1].Value = model.ChannelName;
            parameters[2].Value = model.GameName;
            parameters[3].Value = model.RegisterValue;
            parameters[4].Value = model.ConsumptionValue;
            parameters[5].Value = model.Income;
            parameters[6].Value = model.Bak1;
            parameters[7].Value = model.Bak2;
            parameters[8].Value = model.Bak3;

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
        public bool Update(Model.ReportSet model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ReportSet set ");
            strSql.Append("SumDate=@SumDate,");
            strSql.Append("ChannelName=@ChannelName,");
            strSql.Append("GameName=@GameName,");
            strSql.Append("RegisterValue=@RegisterValue,");
            strSql.Append("ConsumptionValue=@ConsumptionValue,");
            strSql.Append("Income=@Income,");
            strSql.Append("Bak1=@Bak1,");
            strSql.Append("Bak2=@Bak2,");
            strSql.Append("Bak3=@Bak3");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@SumDate", SqlDbType.NVarChar,50),
					new SqlParameter("@ChannelName", SqlDbType.NVarChar,50),
					new SqlParameter("@GameName", SqlDbType.NVarChar,50),
					new SqlParameter("@RegisterValue", SqlDbType.NVarChar,50),
					new SqlParameter("@ConsumptionValue", SqlDbType.NVarChar,50),
					new SqlParameter("@Income", SqlDbType.NVarChar,50),
					new SqlParameter("@Bak1", SqlDbType.NVarChar,50),
					new SqlParameter("@Bak2", SqlDbType.NVarChar,50),
					new SqlParameter("@Bak3", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.SumDate;
            parameters[1].Value = model.ChannelName;
            parameters[2].Value = model.GameName;
            parameters[3].Value = model.RegisterValue;
            parameters[4].Value = model.ConsumptionValue;
            parameters[5].Value = model.Income;
            parameters[6].Value = model.Bak1;
            parameters[7].Value = model.Bak2;
            parameters[8].Value = model.Bak3;
            parameters[9].Value = model.ID;

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
            strSql.Append("delete from ReportSet ");
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
            strSql.Append("delete from ReportSet ");
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
        public Model.ReportSet GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,SumDate,ChannelName,GameName,RegisterValue,ConsumptionValue,Income,Bak1,Bak2,Bak3 from ReportSet ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Model.ReportSet model = new Model.ReportSet();
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
        public Model.ReportSet GetModelByBak(string Bak1)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,SumDate,ChannelName,GameName,RegisterValue,ConsumptionValue,Income,Bak1,Bak2,Bak3 from ReportSet ");
            strSql.Append(" where Bak1=@Bak1");
            SqlParameter[] parameters = {
					new SqlParameter("@Bak1", SqlDbType.NVarChar,50)
			};
            parameters[0].Value = Bak1;

            Model.ReportSet model = new Model.ReportSet();
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
        public Model.ReportSet DataRowToModel(DataRow row)
        {
            Model.ReportSet model = new Model.ReportSet();
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
                if (row["ChannelName"] != null)
                {
                    model.ChannelName = row["ChannelName"].ToString();
                }
                if (row["GameName"] != null)
                {
                    model.GameName = row["GameName"].ToString();
                }
                if (row["RegisterValue"] != null)
                {
                    model.RegisterValue = row["RegisterValue"].ToString();
                }
                if (row["ConsumptionValue"] != null)
                {
                    model.ConsumptionValue = row["ConsumptionValue"].ToString();
                }
                if (row["Income"] != null)
                {
                    model.Income = row["Income"].ToString();
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
            strSql.Append("select ID,SumDate,ChannelName,GameName,RegisterValue,ConsumptionValue,Income,Bak1,Bak2,Bak3 ");
            strSql.Append(" FROM ReportSet ");
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
            strSql.Append(" ID,SumDate,ChannelName,GameName,RegisterValue,ConsumptionValue,Income,Bak1,Bak2,Bak3 ");
            strSql.Append(" FROM ReportSet ");
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
            strSql.Append("select count(1) FROM ReportSet ");
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
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetPageList(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            if (currentPage > 0)
            {
                int topNum = pageSize * currentPage;
                strSql.Append("select top " + pageSize + " * from [ReportSet]");
                strSql.Append(" where Id not in(select top " + topNum + " Id from [ReportSet]");
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
                strSql.Append("select top " + pageSize + " * from [ReportSet]");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                strSql.Append(" order by " + filedOrder);
            }

            return DbHelper.Query(strSql.ToString());
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
            strSql.Append(")AS Row, T.*  from ReportSet T ");
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


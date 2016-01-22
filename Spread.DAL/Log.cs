using System;
using System.Collections.Generic;

using System.Text;

using System.Data;
using System.Data.OleDb;

using Spread.Common;
using Spread.Model;
using Spread.DBUtility;
using System.Data.SqlClient;

namespace Spread.DAL
{
    public class Log
    {
        public Log()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Log");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Log model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Log(");
            strSql.Append("Description,UserId,UserName,LogTime,IpAddress,LogType,IsRead)");
            strSql.Append(" values (");
            strSql.Append("@Description,@UserId,@UserName,@LogTime,@IpAddress,@LogType,@IsRead)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Description", SqlDbType.NVarChar,50),
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@LogTime", SqlDbType.DateTime),
					new SqlParameter("@IpAddress", SqlDbType.NVarChar,50),
					new SqlParameter("@LogType", SqlDbType.NVarChar,50),
					new SqlParameter("@IsRead", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.Description;
            parameters[1].Value = model.UserId;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.LogTime;
            parameters[4].Value = model.IpAddress;
            parameters[5].Value = model.LogType;
            parameters[6].Value = model.IsRead;

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
        public bool Update(Model.Log model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Log set ");
            strSql.Append("Description=@Description,");
            strSql.Append("UserId=@UserId,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("LogTime=@LogTime,");
            strSql.Append("IpAddress=@IpAddress,");
            strSql.Append("LogType=@LogType,");
            strSql.Append("IsRead=@IsRead");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Description", SqlDbType.NVarChar,50),
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@LogTime", SqlDbType.DateTime),
					new SqlParameter("@IpAddress", SqlDbType.NVarChar,50),
					new SqlParameter("@LogType", SqlDbType.NVarChar,50),
					new SqlParameter("@IsRead", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Description;
            parameters[1].Value = model.UserId;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.LogTime;
            parameters[4].Value = model.IpAddress;
            parameters[5].Value = model.LogType;
            parameters[6].Value = model.IsRead;
            parameters[7].Value = model.ID;

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
        /// 更新一条数据
        /// </summary>
        public bool UpdateRead(Model.Log model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Log set ");
            strSql.Append("IsRead=@IsRead");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@IsRead", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.IsRead;
            parameters[1].Value = model.ID;

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
            strSql.Append("delete from Log ");
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
            strSql.Append("delete from Log ");
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
        public Model.Log GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Description,UserId,UserName,LogTime,IpAddress,LogType,IsRead from Log ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Model.Log model = new Model.Log();
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
        public Model.Log DataRowToModel(DataRow row)
        {
            Model.Log model = new Model.Log();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["Description"] != null)
                {
                    model.Description = row["Description"].ToString();
                }
                if (row["UserId"] != null && row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["LogTime"] != null && row["LogTime"].ToString() != "")
                {
                    model.LogTime = DateTime.Parse(row["LogTime"].ToString());
                }
                if (row["IpAddress"] != null)
                {
                    model.IpAddress = row["IpAddress"].ToString();
                }
                if (row["LogType"] != null && row["LogType"].ToString() != "")
                {
                    model.LogType = row["LogType"].ToString();
                }
                if (row["IsRead"] != null)
                {
                    model.IsRead = row["IsRead"].ToString();
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
            strSql.Append("select ID,Description,UserId,UserName,LogTime,IpAddress,LogType,IsRead ");
            strSql.Append(" FROM Log ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere );
            }
            strSql.Append(" Order by LogTime desc");
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
            strSql.Append(" ID,Description,UserId,UserName,LogTime,IpAddress,LogType,IsRead ");
            strSql.Append(" FROM Log ");
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
            strSql.Append("select count(1) FROM Log ");
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
            strSql.Append(")AS Row, T.*  from Log T ");
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


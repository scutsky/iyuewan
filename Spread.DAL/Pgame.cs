using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Spread.DBUtility;
using Spread.Model;

namespace Spread.DAL
{
    public class Pgame
    {
         public Pgame()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Spread.Model.Pgame model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Pgame(");
            strSql.Append("Name,version,Platform,Status,UpdateType,UpdateDate,OnTime,FirstLetter,IsLock,Bak1,Bak2,Bak3)");
            strSql.Append(" values (");
            strSql.Append("@Name,@version,@Platform,@Status,@UpdateType,@UpdateDate,@OnTime,@FirstLetter,@IsLock,@Bak1,@Bak2,@Bak3)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@version", SqlDbType.NVarChar,50),
					new SqlParameter("@Platform", SqlDbType.NVarChar,50),
					new SqlParameter("@Status", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateType", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime),
					new SqlParameter("@OnTime", SqlDbType.DateTime),
					new SqlParameter("@FirstLetter", SqlDbType.NVarChar,50),
					new SqlParameter("@IsLock", SqlDbType.Bit,1),
					new SqlParameter("@Bak1", SqlDbType.NVarChar,50),
					new SqlParameter("@Bak2", SqlDbType.NVarChar,50),
					new SqlParameter("@Bak3", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.version;
            parameters[2].Value = model.Platform;
            parameters[3].Value = model.Status;
            parameters[4].Value = model.UpdateType;
            parameters[5].Value = model.UpdateDate;
            parameters[6].Value = model.OnTime;
            parameters[7].Value = model.FirstLetter;
            parameters[8].Value = model.IsLock;
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
        public bool Update(Model.Pgame model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Pgame set ");
            strSql.Append("Name=@Name,");
            strSql.Append("version=@version,");
            strSql.Append("Platform=@Platform,");
            strSql.Append("Status=@Status,");
            strSql.Append("UpdateType=@UpdateType,");
            strSql.Append("UpdateDate=@UpdateDate,");
            strSql.Append("OnTime=@OnTime,");
            strSql.Append("FirstLetter=@FirstLetter,");
            strSql.Append("IsLock=@IsLock,");
            strSql.Append("Bak1=@Bak1,");
            strSql.Append("Bak2=@Bak2,");
            strSql.Append("Bak3=@Bak3");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@version", SqlDbType.NVarChar,50),
					new SqlParameter("@Platform", SqlDbType.NVarChar,50),
					new SqlParameter("@Status", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateType", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime),
					new SqlParameter("@OnTime", SqlDbType.DateTime),
					new SqlParameter("@FirstLetter", SqlDbType.NVarChar,50),
					new SqlParameter("@IsLock", SqlDbType.Bit,1),
					new SqlParameter("@Bak1", SqlDbType.NVarChar,50),
					new SqlParameter("@Bak2", SqlDbType.NVarChar,50),
					new SqlParameter("@Bak3", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.version;
            parameters[2].Value = model.Platform;
            parameters[3].Value = model.Status;
            parameters[4].Value = model.UpdateType;
            parameters[5].Value = model.UpdateDate;
            parameters[6].Value = model.OnTime;
            parameters[7].Value = model.FirstLetter;
            parameters[8].Value = model.IsLock;
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
        /// 删除一条数据
        /// </summary>
        public bool DeletByPlatform(string Platform)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Pgame ");
            strSql.Append(" where Platform=@Platform");
            SqlParameter[] parameters = {
					new SqlParameter("@Platform", SqlDbType.NVarChar,50)
			};
            parameters[0].Value = Platform;

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
            strSql.Append("delete from Pgame ");
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
            strSql.Append("delete from Pgame ");
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
        public Model.Pgame GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Name,version,Platform,Status,UpdateType,UpdateDate,OnTime,FirstLetter,IsLock,Bak1,Bak2,Bak3 from Pgame ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Model.Pgame model = new Model.Pgame();
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
        public Model.Pgame DataRowToModel(DataRow row)
        {
            Model.Pgame model = new Model.Pgame();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["version"] != null)
                {
                    model.version = row["version"].ToString();
                }
                if (row["Platform"] != null)
                {
                    model.Platform = row["Platform"].ToString();
                }
                if (row["Status"] != null)
                {
                    model.Status = row["Status"].ToString();
                }
                if (row["UpdateType"] != null)
                {
                    model.UpdateType = row["UpdateType"].ToString();
                }
                if (row["UpdateDate"] != null && row["UpdateDate"].ToString() != "")
                {
                    model.UpdateDate = DateTime.Parse(row["UpdateDate"].ToString());
                }
                if (row["OnTime"] != null && row["OnTime"].ToString() != "")
                {
                    model.OnTime = DateTime.Parse(row["OnTime"].ToString());
                }
                if (row["FirstLetter"] != null)
                {
                    model.FirstLetter = row["FirstLetter"].ToString();
                }
                if (row["IsLock"] != null && row["IsLock"].ToString() != "")
                {
                    if ((row["IsLock"].ToString() == "1") || (row["IsLock"].ToString().ToLower() == "true"))
                    {
                        model.IsLock = true;
                    }
                    else
                    {
                        model.IsLock = false;
                    }
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
            strSql.Append("select ID,Name,version,Platform,Status,UpdateType,UpdateDate,OnTime,FirstLetter,IsLock,Bak1,Bak2,Bak3 ");
            strSql.Append(" FROM Pgame ");
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
            strSql.Append(" ID,Name,version,Platform,Status,UpdateType,UpdateDate,OnTime,FirstLetter,IsLock,Bak1,Bak2,Bak3 ");
            strSql.Append(" FROM Pgame ");
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
            strSql.Append("select count(1) FROM Pgame ");
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
            strSql.Append(")AS Row, T.*  from Pgame T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelper.Query(strSql.ToString());
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
                strSql.Append("select top " + pageSize + " * from Pgame");
                strSql.Append(" where Id not in(select top " + topNum + " Id from Pgame)");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" and " + strWhere);
                }
                //strSql.Append(" order by " + filedOrder + ")");
            }
            else
            {
                strSql.Append("select  top " + pageSize + " * from Pgame");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                //strSql.Append(" order by " + filedOrder);
            }

            return DbHelper.Query(strSql.ToString());
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

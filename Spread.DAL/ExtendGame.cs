using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Spread.DBUtility;

namespace Spread.DAL
{
    public class ExtendGame
    {
        public ExtendGame()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.ExtendGame model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ExtendGame(");
            strSql.Append("gameID,ChanelID,ChanelName,UserID,version,Status,UpdateType,UpdateDate,OnTime,Bak1,Bak2,Bak3,gameName,Verifycode)");
            strSql.Append(" values (");
            strSql.Append("@gameID,@ChanelID,@ChanelName,@UserID,@version,@Status,@UpdateType,@UpdateDate,@OnTime,@Bak1,@Bak2,@Bak3,@gameName,@Verifycode)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@gameID", SqlDbType.Int,4),
					new SqlParameter("@ChanelID", SqlDbType.Int,4),
					new SqlParameter("@ChanelName", SqlDbType.NVarChar,50),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@version", SqlDbType.NVarChar,50),
					new SqlParameter("@Status", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateType", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime),
					new SqlParameter("@OnTime", SqlDbType.DateTime),
					new SqlParameter("@Bak1", SqlDbType.NVarChar,50),
					new SqlParameter("@Bak2", SqlDbType.NVarChar,50),
					new SqlParameter("@Bak3", SqlDbType.NVarChar,50),
                    new SqlParameter("@gameName", SqlDbType.NVarChar,50),
                    new SqlParameter("@Verifycode", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.gameID;
            parameters[1].Value = model.ChanelID;
            parameters[2].Value = model.ChanelName;
            parameters[3].Value = model.UserID;
            parameters[4].Value = model.version;
            parameters[5].Value = model.Status;
            parameters[6].Value = model.UpdateType;
            parameters[7].Value = model.UpdateDate;
            parameters[8].Value = model.OnTime;
            parameters[9].Value = model.Bak1;
            parameters[10].Value = model.Bak2;
            parameters[11].Value = model.Bak3;
            parameters[12].Value = model.gameName;
            parameters[13].Value = model.Verifycode;
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
        /// 检查提交的游戏是不是已经提交过
        /// </summary>
        public bool Exists(int userID, int ChanelID,string gameName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ExtendGame");
            strSql.Append(" where UserID=@UserID and ChanelID=@ChanelID and gameName=@gameName  ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
                    new SqlParameter("@ChanelID", SqlDbType.Int,4),
                    new SqlParameter("@gameName", SqlDbType.NVarChar,50)};
            parameters[0].Value = userID;
            parameters[1].Value = ChanelID;
            parameters[2].Value = gameName;


            return DbHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 检查打包时平台&渠道&游戏是否重复
        /// </summary>
        public bool checkrepeat(string Bak2, string Bak3, string Bak4)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ExtendGame");
            strSql.Append(" where Bak2=@Bak2 and Bak3=@Bak3 and Bak4=@Bak4  ");
            SqlParameter[] parameters = {
					new SqlParameter("@Bak2", SqlDbType.NVarChar,50),
                    new SqlParameter("@Bak3", SqlDbType.NVarChar,50),
                    new SqlParameter("@Bak4", SqlDbType.NVarChar,50)};
            parameters[0].Value = Bak2;
            parameters[1].Value = Bak3;
            parameters[2].Value = Bak4;


            return DbHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 检查打包时网址是否重复
        /// </summary>
        public bool checkURL(string Bak1)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ExtendGame");
            strSql.Append(" where Bak1=@Bak1  ");
            SqlParameter[] parameters = {
					new SqlParameter("@Bak1", SqlDbType.NVarChar,500),};
            parameters[0].Value = Bak1;
            return DbHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.ExtendGame model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ExtendGame set ");
            strSql.Append("gameID=@gameID,");
            strSql.Append("ChanelID=@ChanelID,");
            strSql.Append("ChanelName=@ChanelName,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("version=@version,");
            strSql.Append("Status=@Status,");
            strSql.Append("UpdateType=@UpdateType,");
            strSql.Append("UpdateDate=@UpdateDate,");
            strSql.Append("OnTime=@OnTime,");
            strSql.Append("Bak1=@Bak1,");
            strSql.Append("Bak2=@Bak2,");
            strSql.Append("Bak3=@Bak3,");
            strSql.Append("gameName=@gameName");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@gameID", SqlDbType.Int,4),
					new SqlParameter("@ChanelID", SqlDbType.Int,4),
					new SqlParameter("@ChanelName", SqlDbType.NVarChar,50),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@version", SqlDbType.NVarChar,50),
					new SqlParameter("@Status", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateType", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime),
					new SqlParameter("@OnTime", SqlDbType.DateTime),
					new SqlParameter("@Bak1", SqlDbType.NVarChar,50),
					new SqlParameter("@Bak2", SqlDbType.NVarChar,50),
					new SqlParameter("@Bak3", SqlDbType.NVarChar,50),
                    new SqlParameter("@gameName", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.gameID;
            parameters[1].Value = model.ChanelID;
            parameters[2].Value = model.ChanelName;
            parameters[3].Value = model.UserID;
            parameters[4].Value = model.version;
            parameters[5].Value = model.Status;
            parameters[6].Value = model.UpdateType;
            parameters[7].Value = model.UpdateDate;
            parameters[8].Value = model.OnTime;
            parameters[9].Value = model.Bak1;
            parameters[10].Value = model.Bak2;
            parameters[11].Value = model.Bak3;
            parameters[12].Value = model.gameName;
            parameters[13].Value = model.ID;

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
        public bool UpdateStatus(Model.ExtendGame model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ExtendGame set ");
            strSql.Append("version=@version,");
            strSql.Append("Status=@Status,");
            strSql.Append("UpdateType=@UpdateType,");
            strSql.Append("UpdateDate=@UpdateDate,");
            strSql.Append("Bak1=@Bak1,");
            strSql.Append("Bak2=@Bak2,");
            strSql.Append("Bak3=@Bak3,");
            strSql.Append("Bak4=@Bak4,");
            strSql.Append("Bak5=@Bak5,");
            strSql.Append("gameName=@gameName");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@version", SqlDbType.NVarChar,50),
					new SqlParameter("@Status", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateType", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime),
					new SqlParameter("@Bak1", SqlDbType.NVarChar,500),
                    new SqlParameter("@Bak2", SqlDbType.NVarChar,50),
                    new SqlParameter("@Bak3", SqlDbType.NVarChar,50),
                    new SqlParameter("@Bak4", SqlDbType.NVarChar,50),
                    new SqlParameter("@Bak5", SqlDbType.NVarChar,50),
                    new SqlParameter("@gameName", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.version;
            parameters[1].Value = model.Status;
            parameters[2].Value = model.UpdateType;
            parameters[3].Value = model.UpdateDate;
            parameters[4].Value = model.Bak1;
            parameters[5].Value = model.Bak2;
            parameters[6].Value = model.Bak3;
            parameters[7].Value = model.Bak4;
            parameters[8].Value = model.Bak5;
            parameters[9].Value = model.gameName;
            parameters[10].Value = model.ID;
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
            strSql.Append("delete from ExtendGame ");
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
        public bool Delete(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ExtendGame ");
            strSql.Append(" where " + strWhere);
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ExtendGame ");
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
        public Model.ExtendGame GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,gameID,ChanelID,ChanelName,UserID,version,Status,UpdateType,UpdateDate,OnTime,Bak1,Bak2,Bak3,Bak4,Bak5,gameName,Verifycode from ExtendGame ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Model.ExtendGame model = new Model.ExtendGame();
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
        public Model.ExtendGame DataRowToModel(DataRow row)
        {
            Model.ExtendGame model = new Model.ExtendGame();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["gameID"] != null && row["gameID"].ToString() != "")
                {
                    model.gameID = int.Parse(row["gameID"].ToString());
                }
                if (row["ChanelID"] != null && row["ChanelID"].ToString() != "")
                {
                    model.ChanelID = int.Parse(row["ChanelID"].ToString());
                }
                if (row["ChanelName"] != null)
                {
                    model.ChanelName = row["ChanelName"].ToString();
                }
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["version"] != null)
                {
                    model.version = row["version"].ToString();
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
                if (row["Bak5"] != null)
                {
                    model.Bak5 = row["Bak5"].ToString();
                }
                if (row["gameName"] != null)
                {
                    model.gameName = row["gameName"].ToString();
                }
                if (row["Verifycode"] != null)
                {
                    model.Verifycode = row["Verifycode"].ToString();
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
            strSql.Append("select e.*,g.Platform Platform,g.bak1 gbak1,g.bak2 gbak2,g.bak3 gbak3 ");
            strSql.Append(" FROM ExtendGame e left join  Game g ON e.gamename=g.Name ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere + "Order by Platform");
            }
            return DbHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByUserId(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT DISTINCT Bak2 Title FROM ExtendGame ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where USERID='" + strWhere + "' and Bak2<>''  ");
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
            strSql.Append(" ID,gameID,ChanelID,ChanelName,UserID,version,Status,UpdateType,UpdateDate,OnTime,Bak1,Bak2,Bak3,Bak4,Bak5,gameName,Verifycode ");
            strSql.Append(" FROM ExtendGame ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by " + filedOrder);
            }
            return DbHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM ExtendGame ");
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
            strSql.Append(")AS Row, T.*  from ExtendGame T ");
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
                strSql.Append("select top " + pageSize + " * from V_ExtendGame");
                strSql.Append(" where Id not in(select top " + topNum + " Id from V_ExtendGame");
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
                strSql.Append("select top " + pageSize + " * from V_ExtendGame");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                strSql.Append(" order by " + filedOrder);
            }

            return DbHelper.Query(strSql.ToString());
        }
        /// <summary>
        /// 返回长查询数据总数 （分页用到）
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from V_ExtendGame ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelper.GetSingle(strSql.ToString()));
        }

        public bool SetVerifycode(Model.ExtendGame model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ExtendGame set ");
            strSql.Append("Verifycode=@Verifycode");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Verifycode", SqlDbType.NVarChar,10),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Verifycode;
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

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}


using System;
using System.Data;
using System.Text;

using System.Data.OleDb;
using Spread.DBUtility;
using System.Data.SqlClient;//请先添加引用

namespace Spread.DAL
{
    public class Pchannel
    {
        public Pchannel()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Pchannel");
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
        public int Add(Model.Pchannel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Pchannel(");
            strSql.Append("CatalogID,Title,ParentId,ClassList,ClassLayer,UserID,IsShow,IsLock,IsMenu,Name,Url,status,Bak1,Bak2,Bak3,Bak4)");
            strSql.Append(" values (");
            strSql.Append("@CatalogID,@Title,@ParentId,@ClassList,@ClassLayer,@UserID,@IsShow,@IsLock,@IsMenu,@Name,@Url,@status,@Bak1,@Bak2,@Bak3,@Bak4)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@CatalogID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@ParentId", SqlDbType.Int,4),
					new SqlParameter("@ClassList", SqlDbType.NVarChar,50),
					new SqlParameter("@ClassLayer", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@IsShow", SqlDbType.Bit,1),
					new SqlParameter("@IsLock", SqlDbType.Bit,1),
					new SqlParameter("@IsMenu", SqlDbType.Bit,1),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Url", SqlDbType.NVarChar,50),
                    new SqlParameter("@status", SqlDbType.Int,4),
                    new SqlParameter("@Bak1", SqlDbType.NVarChar,50),
                    new SqlParameter("@Bak2", SqlDbType.NVarChar,50),
                    new SqlParameter("@Bak3", SqlDbType.NVarChar,50),
                    new SqlParameter("@Bak4", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.CatalogID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.ParentId;
            parameters[3].Value = model.ClassList;
            parameters[4].Value = model.ClassLayer;
            parameters[5].Value = model.UserID;
            parameters[6].Value = model.IsShow;
            parameters[7].Value = model.IsLock;
            parameters[8].Value = model.IsMenu;
            parameters[9].Value = model.Name;
            parameters[10].Value = model.Url;
            parameters[11].Value = model.Status;
            parameters[12].Value = model.Bak1;
            parameters[13].Value = model.Bak2;
            parameters[14].Value = model.Bak3;
            parameters[15].Value = model.Bak4;
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
        public bool Update(Model.Pchannel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Pchannel set ");
            strSql.Append("CatalogID=@CatalogID,");
            strSql.Append("Title=@Title,");
            strSql.Append("ParentId=@ParentId,");
            strSql.Append("ClassList=@ClassList,");
            strSql.Append("ClassLayer=@ClassLayer,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("IsShow=@IsShow,");
            strSql.Append("IsLock=@IsLock,");
            strSql.Append("IsMenu=@IsMenu,");
            strSql.Append("Name=@Name,");
            strSql.Append("Url=@Url,");
            strSql.Append("status=@status,");
            strSql.Append("Bak1=@Bak1,");
            strSql.Append("Bak2=@Bak2,");
            strSql.Append("Bak3=@Bak3,");
            strSql.Append("Bak4=@Bak4");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@CatalogID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@ParentId", SqlDbType.Int,4),
					new SqlParameter("@ClassList", SqlDbType.NVarChar,50),
					new SqlParameter("@ClassLayer", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@IsShow", SqlDbType.Bit,1),
					new SqlParameter("@IsLock", SqlDbType.Bit,1),
					new SqlParameter("@IsMenu", SqlDbType.Bit,1),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Url", SqlDbType.NVarChar,50),
                    new SqlParameter("@status", SqlDbType.Int,4),
                    new SqlParameter("@Bak1", SqlDbType.NVarChar,50),
                    new SqlParameter("@Bak2", SqlDbType.NVarChar,50),
                    new SqlParameter("@Bak3", SqlDbType.NVarChar,50),
                    new SqlParameter("@Bak4", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.CatalogID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.ParentId;
            parameters[3].Value = model.ClassList;
            parameters[4].Value = model.ClassLayer;
            parameters[5].Value = model.UserID;
            parameters[6].Value = model.IsShow;
            parameters[7].Value = model.IsLock;
            parameters[8].Value = model.IsMenu;
            parameters[9].Value = model.Name;
            parameters[10].Value = model.Url;
            parameters[11].Value = model.Status;
            parameters[12].Value = model.Bak1;
            parameters[13].Value = model.Bak2;
            parameters[14].Value = model.Bak3;
            parameters[15].Value = model.Bak4;
            parameters[16].Value = model.ID;

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
        public bool UpdateStatus(int id, string Status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Pchannel set ");
            strSql.Append("status=@status");
            strSql.Append(" where ID='" + id + "'");
            SqlParameter[] parameters = {
                    new SqlParameter("@status", SqlDbType.Int,4),              
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = Status;
            parameters[1].Value = id;
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
            strSql.Append("delete from Pchannel ");
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
            strSql.Append("delete from Pchannel ");
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
        public Model.Pchannel GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,CatalogID,Title,ParentId,ClassList,ClassLayer,UserID,IsShow,IsLock,IsMenu,Name,Url,status,Bak1,Bak2,Bak3,Bak4 from Pchannel ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Model.Pchannel model = new Model.Pchannel();
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
        public Model.Pchannel DataRowToModel(DataRow row)
        {
            Model.Pchannel model = new Model.Pchannel();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["CatalogID"] != null && row["CatalogID"].ToString() != "")
                {
                    model.CatalogID = int.Parse(row["CatalogID"].ToString());
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["ParentId"] != null && row["ParentId"].ToString() != "")
                {
                    model.ParentId = int.Parse(row["ParentId"].ToString());
                }
                if (row["ClassList"] != null)
                {
                    model.ClassList = row["ClassList"].ToString();
                }
                if (row["ClassLayer"] != null && row["ClassLayer"].ToString() != "")
                {
                    model.ClassLayer = int.Parse(row["ClassLayer"].ToString());
                }
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["IsShow"] != null && row["IsShow"].ToString() != "")
                {
                    if ((row["IsShow"].ToString() == "1") || (row["IsShow"].ToString().ToLower() == "true"))
                    {
                        model.IsShow = true;
                    }
                    else
                    {
                        model.IsShow = false;
                    }
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
                if (row["IsMenu"] != null && row["IsMenu"].ToString() != "")
                {
                    if ((row["IsMenu"].ToString() == "1") || (row["IsMenu"].ToString().ToLower() == "true"))
                    {
                        model.IsMenu = true;
                    }
                    else
                    {
                        model.IsMenu = false;
                    }
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["Url"] != null)
                {
                    model.Url = row["Url"].ToString();
                }
                if (row["status"] != null && row["status"].ToString() != "")
                {
                    model.Status = int.Parse(row["status"].ToString());
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
            strSql.Append("select c.*,p.Title ptitle ");
            strSql.Append(" FROM Pchannel c left join dbo.Menu p on c.ParentId=p.id  ");
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
            strSql.Append(" ID,CatalogID,Title,ParentId,ClassList,ClassLayer,UserID,IsShow,IsLock,IsMenu,Name,Url,status,Bak1,Bak2,Bak3,Bak4 ");
            strSql.Append(" FROM Pchannel ");
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
            strSql.Append("select count(1) FROM Pchannel ");
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
            strSql.Append(")AS Row, T.*  from Pchannel T ");
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


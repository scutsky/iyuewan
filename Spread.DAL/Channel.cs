using System;
using System.Data;
using System.Text;

using System.Data.OleDb;
using Spread.DBUtility;
using System.Data.SqlClient;//�����������
namespace Spread.DAL
{
	/// <summary>
	/// ���ݷ�����Channel��
	/// </summary>
	public class Channel
	{
        public Channel()
        { }
        #region  BasicMethod
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Channel");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Model.Channel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Channel(");
            strSql.Append("CatalogID,Title,ParentId,ClassList,ClassLayer,UserID,IsShow,IsLock,IsMenu,Name,Url,status,Bak1,Bak2,Bak3,Bak4)");
            strSql.Append(" values (");
            strSql.Append("@CatalogID,@Title,@ParentId,@ClassList,@ClassLayer,@UserID,@IsShow,@IsLock,@IsMenu,@Name,@Url,@status,@Bak1,@Bak2,@Bak3,@Bak4)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@CatalogID", SqlDbType.NVarChar,50),
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
        /// ����һ������
        /// </summary>
        public bool Update(Model.Channel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Channel set ");
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
					new SqlParameter("@CatalogID", SqlDbType.NVarChar,50),
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
        /// ����һ������
        /// </summary>
        public bool UpdateStatus(int id, string Status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Channel set ");
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
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Channel ");
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
        /// ����ɾ������
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Channel ");
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
        /// �õ�һ������ʵ��
        /// </summary>
        public Model.Channel GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,CatalogID,Title,ParentId,ClassList,ClassLayer,UserID,IsShow,IsLock,IsMenu,Name,Url,status,Bak1,Bak2,Bak3,Bak4 from Channel ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Model.Channel model = new Model.Channel();
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
        /// �õ�һ������ʵ��
        /// </summary>
        public Model.Channel DataRowToModel(DataRow row)
        {
            Model.Channel model = new Model.Channel();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["CatalogID"] != null && row["CatalogID"].ToString() != "")
                {
                    model.CatalogID = row["CatalogID"].ToString();
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
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select c.*,p.Title ptitle,p.Brand Brand,u.name username ");
            strSql.Append(" FROM Channel c left join Products p on c.ParentId=p.ID LEFT JOIN [USER] u ON c.UserID=u.ID  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID");
            return DbHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetListAll(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM [V_ExtendGameListAll]  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.Query(strSql.ToString());
        }
        /// <summary>
        /// ���ǰ��������
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
            strSql.Append(" FROM Channel ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// ��ȡ��¼����
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Channel ");
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
        /// ��ҳ��ȡ�����б�
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
            strSql.Append(")AS Row, T.*  from Channel T ");
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


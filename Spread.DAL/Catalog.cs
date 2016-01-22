using System;
using System.Data;
using System.Text;

using System.Data.OleDb;
using Spread.DBUtility;
using System.Data.SqlClient;//请先添加引用
namespace Spread.DAL
{
    /// <summary>
    /// 数据访问类Catalog。
    /// </summary>
    public class Catalog
    {
        public Catalog()
        { }
        #region  成员方法
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return DbHelper.GetMaxID(FieldName, "[Catalog]");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Catalog");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            return DbHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 返回栏目名称
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public string GetCatalogTitle(int classId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 Title from [Catalog]");
            strSql.Append(" where Id=" + classId);
            return Convert.ToString(DbHelper.GetSingle(strSql.ToString()));
        }
        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int Id, string strField)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Catalog] set " + strField);
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.BigInt,8)};
            parameters[0].Value = Id;

            DbHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Spread.Model.Catalog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [Catalog](");
            strSql.Append("CatalogID,Title,ParentId,ClassList,ClassLayer,ClassOrder,IsShow,IsLock,IsMenu)");
            strSql.Append(" values (");
            strSql.Append("@CatalogID ,@Title,@ParentId,@ClassList,@ClassLayer,@ClassOrder,@IsShow,@IsLock,@IsMenu)");
            SqlParameter[] parameters = {
					new SqlParameter("@CatalogID", SqlDbType.NVarChar,100),
                    new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@ParentId", SqlDbType.Int,4),
					new SqlParameter("@ClassList", SqlDbType.NVarChar,300),
					new SqlParameter("@ClassLayer", SqlDbType.Int,4),
					new SqlParameter("@ClassOrder", SqlDbType.Int,4),
                    new SqlParameter("@IsShow", SqlDbType.Bit),
                    new SqlParameter("@IsLock",SqlDbType.Bit),
					new SqlParameter("@IsMenu", SqlDbType.Bit)};
            parameters[0].Value = model.CatalogID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.ParentId;
            parameters[3].Value = model.ClassList;
            parameters[4].Value = model.ClassLayer;
            parameters[5].Value = model.ClassOrder;
            parameters[6].Value = model.IsShow;
            parameters[7].Value = model.IsLock;
            parameters[8].Value = model.IsMenu;

            DbHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Spread.Model.Catalog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Catalog] set ");
            strSql.Append("CatalogID=@CatalogID,");
            strSql.Append("Title=@Title,");
            strSql.Append("ParentId=@ParentId,");
            strSql.Append("ClassList=@ClassList,");
            strSql.Append("ClassLayer=@ClassLayer,");
            strSql.Append("ClassOrder=@ClassOrder,");
            strSql.Append("IsShow=@IsShow,");
            strSql.Append("IsLock=@IsLock,");
            strSql.Append("IsMenu=@IsMenu");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@CatalogID", SqlDbType.NVarChar,100),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@ParentId", SqlDbType.Int,4),
					new SqlParameter("@ClassList", SqlDbType.NVarChar,300),
					new SqlParameter("@ClassLayer", SqlDbType.Int,4),
					new SqlParameter("@ClassOrder", SqlDbType.Int,4),
                    new SqlParameter("@IsShow", SqlDbType.Bit),
                    new SqlParameter("@IsLock",SqlDbType.Bit),
					new SqlParameter("@IsMenu", SqlDbType.Bit),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.CatalogID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.ParentId;
            parameters[3].Value = model.ClassList;
            parameters[4].Value = model.ClassLayer;
            parameters[5].Value = model.ClassOrder;
            parameters[6].Value = model.IsShow;
            parameters[7].Value = model.IsLock;
            parameters[8].Value = model.IsMenu;
            parameters[9].Value = model.Id;

            DbHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除该类别及所有属下分类数据
        /// </summary>
        public void Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [Catalog] ");
            strSql.Append(" where ClassList like '%," + Id + ",%' ");

            DbHelper.Query(strSql.ToString());
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Spread.Model.Catalog GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,CatalogID,Title,ParentId,ClassList,ClassLayer,ClassOrder,IsShow,IsLock,IsMenu from [Catalog] ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            Spread.Model.Catalog model = new Spread.Model.Catalog();
            DataSet ds = DbHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CatalogID"].ToString() != "")
                {
                    model.CatalogID = long.Parse(ds.Tables[0].Rows[0]["CatalogID"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                if (ds.Tables[0].Rows[0]["ParentId"].ToString() != "")
                {
                    model.ParentId = int.Parse(ds.Tables[0].Rows[0]["ParentId"].ToString());
                }
                model.ClassList = ds.Tables[0].Rows[0]["ClassList"].ToString();
                if (ds.Tables[0].Rows[0]["ClassLayer"].ToString() != "")
                {
                    model.ClassLayer = int.Parse(ds.Tables[0].Rows[0]["ClassLayer"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ClassOrder"].ToString() != "")
                {
                    model.ClassOrder = int.Parse(ds.Tables[0].Rows[0]["ClassOrder"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsShow"].ToString() != "")
                {
                    model.IsShow = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsShow"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsLock"].ToString() != "")
                {
                    model.IsLock = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsLock"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsMenu"].ToString() != "")
                {
                    model.IsMenu = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsMenu"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 取得所有栏目列表
        /// </summary>
        /// <param name="PId">父ID</param>
        /// <param name="KId">种类ID</param>
        /// <returns></returns>
        public DataTable GetList(int PId)
        {
            DataTable data = new DataTable();
            //创建列
            DataColumn Id = new DataColumn("Id", typeof(int));
            DataColumn CatalogID = new DataColumn("CatalogID", typeof(long));
            DataColumn Title = new DataColumn("Title", typeof(string));
            DataColumn ParentId = new DataColumn("ParentId", typeof(int));
            DataColumn ClassList = new DataColumn("ClassList", typeof(string));
            DataColumn ClassLayer = new DataColumn("ClassLayer", typeof(int));
            DataColumn ClassOrder = new DataColumn("ClassOrder", typeof(int));
            DataColumn IsShow = new DataColumn("IsShow", typeof(bool));
            DataColumn IsLock = new DataColumn("IsLock", typeof(bool));
            DataColumn IsMenu = new DataColumn("IsMenu", typeof(bool));
            //添加列
            data.Columns.Add(Id);
            data.Columns.Add(CatalogID);
            data.Columns.Add(Title);
            data.Columns.Add(ParentId);
            data.Columns.Add(ClassList);
            data.Columns.Add(ClassLayer);
            data.Columns.Add(ClassOrder);
            data.Columns.Add(IsShow);
            data.Columns.Add(IsLock);
            data.Columns.Add(IsMenu);
            //调用迭代组合成DAGATABLE
            GetCatalogChild(data, PId);
            return data;
        }

        /// <summary>
        /// 取得该栏目的所有下级栏目列表
        /// </summary>
        /// <param name="data">DATATABLE名</param>
        /// <param name="PId">父栏目ID</param>
        /// <param name="KId">种类ID</param>
        private void GetCatalogChild(DataTable data, int PId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,CatalogID,Title,ParentId,ClassList,ClassLayer,ClassOrder,IsShow,IsLock,IsMenu from [Catalog]");
            strSql.Append(" where ParentId=" + PId + " order by ClassOrder asc,Id desc");
            DataSet ds = DbHelper.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    //添加一行数据
                    DataRow row = data.NewRow();
                    row[0] = int.Parse(dr["Id"].ToString());
                    row[1] = int.Parse(dr["CatalogID"].ToString());
                    row[2] = dr["Title"].ToString();
                    row[3] = int.Parse(dr["ParentId"].ToString());
                    row[4] = dr["ClassList"].ToString();
                    row[5] = int.Parse(dr["ClassLayer"].ToString());
                    row[6] = int.Parse(dr["ClassOrder"].ToString());
                    row[7] = Convert.ToBoolean(dr["IsShow"].ToString());
                    row[8] = Convert.ToBoolean(dr["IsLock"].ToString());
                    row[9] = Convert.ToBoolean(dr["IsMenu"].ToString());
                    data.Rows.Add(row);
                    //调用自身迭代
                    this.GetCatalogChild(data, int.Parse(dr["Id"].ToString()));
                }
            }
        }

        /// <summary>
        /// 取得该栏目下的所有子栏目的ID
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public DataSet GetCatalogListByClassId(int classId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ClassList,ClassLayer from [Catalog]");
            strSql.Append(" where Id=" + classId + " ");
            return DbHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,CatalogID,Title,ParentId,ClassList,ClassLayer,ClassOrder,IsShow,IsLock,IsMenu ");
            strSql.Append(" FROM [Catalog] ");
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
            strSql.Append(" Id,CatalogID,Title,ParentId,ClassList,ClassLayer,ClassOrder,IsShow,IsLock,IsMenu ");
            strSql.Append(" FROM [Catalog] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string fildes ,string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + fildes);
            strSql.Append(" FROM [Catalog] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string fildes, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " );
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString() );
            }
            strSql.Append(" " + fildes);
            strSql.Append(" from [Catalog] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 取得最大排序记录
        /// </summary>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        public int GetMaxSortID(int ParentID)
        {
            string strsql = "select max(ClassOrder)  from [Catalog] where ParentId= " + ParentID.ToString() + "";
            object obj = DbHelper.GetSingle(strsql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString()) + 1;
            }
        }
        #endregion  成员方法
    }
}


using System;
using System.Data;
using System.Text;

using System.Data.OleDb;
using Spread.DBUtility;
using System.Data.SqlClient;//请先添加引用

namespace Spread.DAL
{
    public class MenuDirectory
    {
        public MenuDirectory()
        { }
        #region  成员方法
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return DbHelper.GetMaxID(FieldName, "[MenuDirectory]");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from MenuDirectory");
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
        public string GetMenuTitle(int classId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 Title from [MenuDirectory]");
            strSql.Append(" where Id=" + classId);
            return Convert.ToString(DbHelper.GetSingle(strSql.ToString()));
        }
        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int Id, string strField)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [MenuDirectory] set " + strField);
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.BigInt,8)};
            parameters[0].Value = Id;

            DbHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Spread.Model.MenuDirectory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [MenuDirectory](");
            strSql.Append("MenuID,Title,ParentId,ClassList,ClassLayer,ClassOrder,IsShow,IsLock,IsMenu,ImgUrl,LanguageType)");
            strSql.Append(" values (");
            strSql.Append("@MenuID ,@Title,@ParentId,@ClassList,@ClassLayer,@ClassOrder,@IsShow,@IsLock,@IsMenu,@ImgUrl,@LanguageType)");
            SqlParameter[] parameters = {
					new SqlParameter("@MenuID", SqlDbType.NVarChar,100),
                    new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@ParentId", SqlDbType.Int,4),
					new SqlParameter("@ClassList", SqlDbType.NVarChar,300),
					new SqlParameter("@ClassLayer", SqlDbType.Int,4),
					new SqlParameter("@ClassOrder", SqlDbType.Int,4),
                    new SqlParameter("@IsShow", SqlDbType.Bit),
                    new SqlParameter("@IsLock",SqlDbType.Bit),
					new SqlParameter("@IsMenu", SqlDbType.Bit),
                    new SqlParameter("@ImgUrl", SqlDbType.NVarChar,300),
                    new SqlParameter("@LanguageType", SqlDbType.NVarChar,300)};
            parameters[0].Value = model.MenuID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.ParentId;
            parameters[3].Value = model.ClassList;
            parameters[4].Value = model.ClassLayer;
            parameters[5].Value = model.ClassOrder;
            parameters[6].Value = model.IsShow;
            parameters[7].Value = model.IsLock;
            parameters[8].Value = model.IsMenu;
            parameters[9].Value = model.ImgUrl;
            parameters[10].Value = model.LanguageType;

            DbHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Spread.Model.MenuDirectory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [MenuDirectory] set ");
            strSql.Append("MenuID=@MenuID,");
            strSql.Append("Title=@Title,");
            strSql.Append("ParentId=@ParentId,");
            strSql.Append("ClassList=@ClassList,");
            strSql.Append("ClassLayer=@ClassLayer,");
            strSql.Append("ClassOrder=@ClassOrder,");
            strSql.Append("IsShow=@IsShow,");
            strSql.Append("IsLock=@IsLock,");
            strSql.Append("IsMenu=@IsMenu,");
            strSql.Append("ImgUrl=@ImgUrl,");
            strSql.Append("LanguageType=@LanguageType");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@MenuID", SqlDbType.NVarChar,100),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@ParentId", SqlDbType.Int,4),
					new SqlParameter("@ClassList", SqlDbType.NVarChar,300),
					new SqlParameter("@ClassLayer", SqlDbType.Int,4),
					new SqlParameter("@ClassOrder", SqlDbType.Int,4),
                    new SqlParameter("@IsShow", SqlDbType.Bit),
                    new SqlParameter("@IsLock",SqlDbType.Bit),
					new SqlParameter("@IsMenu", SqlDbType.Bit),
                    new SqlParameter("@ImgUrl",SqlDbType.NVarChar,300),
                    new SqlParameter("@LanguageType", SqlDbType.NVarChar,300),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.MenuID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.ParentId;
            parameters[3].Value = model.ClassList;
            parameters[4].Value = model.ClassLayer;
            parameters[5].Value = model.ClassOrder;
            parameters[6].Value = model.IsShow;
            parameters[7].Value = model.IsLock;
            parameters[8].Value = model.IsMenu;
            parameters[9].Value = model.ImgUrl;
            parameters[10].Value = model.LanguageType;
            parameters[11].Value = model.Id;

            DbHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除该类别及所有属下分类数据
        /// </summary>
        public void Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [MenuDirectory] ");
            strSql.Append(" where ClassList like '%," + Id + ",%' ");

            DbHelper.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Spread.Model.MenuDirectory GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,MenuID,Title,ParentId,ClassList,ClassLayer,ClassOrder,IsShow,IsLock,IsMenu,ImgUrl,LanguageType from [MenuDirectory] ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            Spread.Model.MenuDirectory model = new Spread.Model.MenuDirectory();
            DataSet ds = DbHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MenuID"].ToString() != "")
                {
                    model.MenuID = long.Parse(ds.Tables[0].Rows[0]["MenuID"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                if (ds.Tables[0].Rows[0]["ParentId"].ToString() != "")
                {
                    model.ParentId = int.Parse(ds.Tables[0].Rows[0]["ParentId"].ToString());
                }
                model.ClassList = ds.Tables[0].Rows[0]["ClassList"].ToString();
                model.ImgUrl = ds.Tables[0].Rows[0]["ImgUrl"].ToString();
                model.LanguageType = ds.Tables[0].Rows[0]["LanguageType"].ToString();
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
            DataColumn MenuID = new DataColumn("MenuID", typeof(long));
            DataColumn Title = new DataColumn("Title", typeof(string));
            DataColumn ParentId = new DataColumn("ParentId", typeof(int));
            DataColumn ClassList = new DataColumn("ClassList", typeof(string));
            DataColumn ClassLayer = new DataColumn("ClassLayer", typeof(int));
            DataColumn ClassOrder = new DataColumn("ClassOrder", typeof(int));
            DataColumn IsShow = new DataColumn("IsShow", typeof(bool));
            DataColumn IsLock = new DataColumn("IsLock", typeof(bool));
            DataColumn IsMenu = new DataColumn("IsMenu", typeof(bool));
            DataColumn ImgUrl = new DataColumn("ImgUrl", typeof(string));
            DataColumn LanguageType = new DataColumn("LanguageType", typeof(string));
            //添加列
            data.Columns.Add(Id);
            data.Columns.Add(MenuID);
            data.Columns.Add(Title);
            data.Columns.Add(ParentId);
            data.Columns.Add(ClassList);
            data.Columns.Add(ClassLayer);
            data.Columns.Add(ClassOrder);
            data.Columns.Add(IsShow);
            data.Columns.Add(IsLock);
            data.Columns.Add(IsMenu);
            data.Columns.Add(ImgUrl);
            data.Columns.Add(LanguageType);
            //调用迭代组合成DAGATABLE
            GetMenuChild(data, PId);
            return data;
        }

        /// <summary>
        /// 取得该栏目的所有下级栏目列表
        /// </summary>
        /// <param name="data">DATATABLE名</param>
        /// <param name="PId">父栏目ID</param>
        /// <param name="KId">种类ID</param>
        private void GetMenuChild(DataTable data, int PId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,MenuID,Title,ParentId,ClassList,ClassLayer,ClassOrder,IsShow,IsLock,IsMenu,ImgUrl,LanguageType from [MenuDirectory]");
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
                    row[1] = int.Parse(dr["MenuID"].ToString());
                    row[2] = dr["Title"].ToString();
                    row[3] = int.Parse(dr["ParentId"].ToString());
                    row[4] = dr["ClassList"].ToString();
                    row[5] = int.Parse(dr["ClassLayer"].ToString());
                    row[6] = int.Parse(dr["ClassOrder"].ToString());
                    row[7] = Convert.ToBoolean(dr["IsShow"].ToString());
                    row[8] = Convert.ToBoolean(dr["IsLock"].ToString());
                    row[9] = Convert.ToBoolean(dr["IsMenu"].ToString());
                    row[10] = dr["ImgUrl"].ToString();
                    row[11] = dr["LanguageType"].ToString();
                    data.Rows.Add(row);
                    //调用自身迭代
                    this.GetMenuChild(data, int.Parse(dr["Id"].ToString()));
                }
            }
        }

        /// <summary>
        /// 取得该栏目下的所有子栏目的ID
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public DataSet GetMenuListByClassId(int classId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ClassList,ClassLayer from [MenuDirectory]");
            strSql.Append(" where Id=" + classId + " ");
            return DbHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,MenuID,Title,ParentId,ClassList,ClassLayer,ClassOrder,IsShow,IsLock,IsMenu,ImgUrl,LanguageType ");
            strSql.Append(" FROM [MenuDirectory] ");
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
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select ");
                if (Top > 0)
                {
                    strSql.Append(" top " + Top.ToString());
                }
                strSql.Append(" Id,MenuID,Title,ParentId,ClassList,ClassLayer,ClassOrder,IsShow,IsLock,IsMenu,ImgUrl,LanguageType ");
                strSql.Append(" FROM [MenuDirectory] ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                strSql.Append(" order by " + filedOrder);
                return DbHelper.Query(strSql.ToString());
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string fildes ,string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + fildes);
            strSql.Append(" FROM [MenuDirectory] ");
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
            strSql.Append(" from [MenuDirectory] ");
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
            string strsql = "select max(ClassOrder)  from [MenuDirectory] where ParentId= " + ParentID.ToString() + "";
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

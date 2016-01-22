using System;
using System.Data;
using System.Text;

using System.Data.OleDb;
using Spread.DBUtility;
using System.Data.SqlClient;//请先添加引用
namespace Spread.DAL
{
	/// <summary>
	/// 数据访问类Products。
	/// </summary>
	public class Products
	{
		public Products()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Products");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			return DbHelper.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 返回长查询数据总数 （分页用到）
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from Products ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelper.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int Id, string strField)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Products set " + strField);
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            DbHelper.ExecuteSql(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Spread.Model.Products model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Products(");
            strSql.Append("Title,Brand,ClassId,Sort,AddTime,Url,ImgUrl,AddUser,Keyword,IsTop,IsLock)");
			strSql.Append(" values (");
            strSql.Append("@Title,@Brand,@ClassId,@Sort,@AddTime,@Url,@ImgUrl,@AddUser,@Keyword,@IsTop,@IsLock)");
			SqlParameter[] parameters = {
                    new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@Brand", SqlDbType.NVarChar,100),
					new SqlParameter("@ClassId", SqlDbType.Int,4),
                    new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
                    new SqlParameter("@Url", SqlDbType.NVarChar,200),
                    new SqlParameter("@ImgUrl", SqlDbType.NVarChar,100),
                    new SqlParameter("@AddUser", SqlDbType.NVarChar,50),
                    new SqlParameter("@Keyword", SqlDbType.NVarChar,500),
                    new SqlParameter("@IsTop", SqlDbType.Bit),
                    new SqlParameter("@IsLock", SqlDbType.Bit)};
            parameters[0].Value = model.Title;
			parameters[1].Value = model.Brand;
			parameters[2].Value = model.ClassId;
            parameters[3].Value = model.Sort;
			parameters[4].Value = model.AddTime;
            parameters[5].Value = model.Url;
            parameters[6].Value = model.ImgUrl;
            parameters[7].Value = model.AddUser;
            parameters[8].Value = model.Keyword;
            parameters[9].Value = model.IsTop;
            parameters[10].Value = model.IsLock;
            DbHelper.ExecuteSql(strSql.ToString(), parameters);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Spread.Model.Products model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Products set ");
			strSql.Append("Brand=@Brand,");
			strSql.Append("ClassId=@ClassId,");
            strSql.Append("Sort=@Sort,");
			strSql.Append("AddTime=@AddTime,");
            strSql.Append("Url=@Url,");
            strSql.Append("ImgUrl=@ImgUrl,");
            strSql.Append("AddUser=@AddUser,");
            strSql.Append("Keyword=@Keyword,");
            strSql.Append("IsTop=@IsTop,");
            strSql.Append("IsLock=@IsLock,");
            strSql.Append("Title=@Title");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Brand",SqlDbType.NVarChar,100),
					new SqlParameter("@ClassId", SqlDbType.Int,4),
                    new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime),                    
                    new SqlParameter("@Url", SqlDbType.NVarChar,200),
                    new SqlParameter("@ImgUrl", SqlDbType.NVarChar,100),
                    new SqlParameter("@AddUser", SqlDbType.NVarChar,50),
                    new SqlParameter("@Keyword", SqlDbType.NVarChar,500),
                    new SqlParameter("@IsTop", SqlDbType.Bit),
                    new SqlParameter("@IsLock", SqlDbType.Bit),
                    new SqlParameter("@Title", SqlDbType.NVarChar,100),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.Brand;
			parameters[1].Value = model.ClassId;
            parameters[2].Value = model.Sort;
			parameters[3].Value = model.AddTime;
            parameters[4].Value = model.Url;
            parameters[5].Value = model.ImgUrl;
            parameters[6].Value = model.AddUser;
            parameters[7].Value = model.Keyword;
            parameters[8].Value = model.IsTop;
            parameters[9].Value = model.IsLock;
            parameters[10].Value = model.Title;
            parameters[11].Value = model.Id;

			DbHelper.ExecuteSql(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 更新商品编号
        /// </summary>
        public void UpdateBrand(Spread.Model.Products model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Products set ");
            strSql.Append("Brand=@Brand");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
                  new SqlParameter("@Brand", SqlDbType.NVarChar,100),
                  new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.Brand;
            parameters[1].Value = model.Id;

            DbHelper.ExecuteSql(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Products ");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			DbHelper.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Spread.Model.Products GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 * from Products ");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			Spread.Model.Products model=new Spread.Model.Products();
			DataSet ds=DbHelper.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
                model.Brand = ds.Tables[0].Rows[0]["Brand"].ToString();
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.Sort =int.Parse( ds.Tables[0].Rows[0]["Sort"].ToString());
				if(ds.Tables[0].Rows[0]["ClassId"].ToString()!="")
				{
					model.ClassId=int.Parse(ds.Tables[0].Rows[0]["ClassId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
				}
                model.Url = ds.Tables[0].Rows[0]["Url"].ToString();
                model.ImgUrl = ds.Tables[0].Rows[0]["ImgUrl"].ToString();
                model.AddUser = ds.Tables[0].Rows[0]["AddUser"].ToString();
                model.Keyword = ds.Tables[0].Rows[0]["Keyword"].ToString();
                if (ds.Tables[0].Rows[0]["IsTop"].ToString() != "")
                {
                    model.IsTop = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsTop"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsLock"].ToString() != "")
                {
                    model.IsLock = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsLock"].ToString());
                }
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
            string strSql = "select * from [Products]";			
			if(strWhere.Trim()!="")
			{
                strSql += " where " + strWhere;				
			}
            return DbHelper.Query(strSql, null);
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
            string strSql = "select ";			
			if(Top>0)
			{
				strSql+=" top "+Top.ToString();
			}
            strSql += " * FROM Products ";			
			if(strWhere.Trim()!="")
			{
				strSql+=" where "+strWhere;
			}
            if (filedOrder.Trim() != "")
            {
                strSql += " order by " + filedOrder;
            }			
			return DbHelper.Query(strSql,null);
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
                strSql.Append("select top " + pageSize + " * from Products");
                strSql.Append(" where Id not in(select top " + topNum + " Id from Products");
               
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" and " + strWhere);
                }
                strSql.Append(" order by " + filedOrder);
            }
            else
            {
                strSql.Append("select top " + pageSize + " * from Products");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                strSql.Append(" order by " + filedOrder);
            }

            return DbHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得最新添加的ID
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="TableName">表名</param>
        /// <returns></returns>
        public int GetLastProID(string ID, string TableName)
        {
            return DbHelper.GetMaxID(ID, TableName);
        }

        /// <summary>
        /// 获得产品所属类的编号
        /// </summary>
        /// <param name="TypeID"></param>
        /// <returns></returns>
        public string GetClassID(int TypeID)
        {
            string result = "";
            string strSql = "select Id,Brand from Channel where ParentId=" + TypeID + " order by Id asc";
            DataTable dt = new DataTable();
            dt = DbHelper.Query(strSql, null).Tables[0];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    result += " ClassId=" + Convert.ToInt32(dt.Rows[i]["Id"].ToString()) + " or ";
                    result += GetClassID(int.Parse(dt.Rows[i]["Id"].ToString()));
                }
            }
            return result;
        }

        /// <summary>
        /// 取得最大排序记录
        /// </summary>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        public int GetMaxSortID(int ClassId)
        {
            string strsql = "select max(sort)  from Products where ClassId= " + ClassId.ToString() + "";
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


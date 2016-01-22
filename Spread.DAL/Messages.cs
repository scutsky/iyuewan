using System;
using System.Data;
using System.Text;

using System.Data.OleDb;
using Spread.DBUtility;
using System.Data.SqlClient;//请先添加引用

namespace Spread.DAL
{
    /// <summary>
    /// 数据访问类Messages。
    /// </summary>
    public class Messages
    {
        public Messages()
		{}

        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Messages");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            return DbHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 返回长查询数据总数 （分页用到）
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from Messages ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelper.GetSingle(strSql.ToString()));
        }

       

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Spread.Model.Messages model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Messages(");
            strSql.Append("Subject,FullName,Mail,Address,ZipCode,Province,City,Phone,Fax,Type,Question,AddTime)");
            strSql.Append(" values (");
            strSql.Append("@Subject,@FullName,@Mail,@Address,@ZipCode,@Province,@City,@Phone,@Fax,@Type,@Question,@AddTime)");
            SqlParameter[] parameters = {
					new SqlParameter("@Subject", SqlDbType.NVarChar,100),
					new SqlParameter("@FullName", SqlDbType.NVarChar,50),
					new SqlParameter("@Mail", SqlDbType.NVarChar,50),					
					new SqlParameter("@Address", SqlDbType.NVarChar,50),
					new SqlParameter("@ZipCode", SqlDbType.NVarChar,50),					
					new SqlParameter("@Province", SqlDbType.NVarChar,50),
					new SqlParameter("@City", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@Fax", SqlDbType.NVarChar,50),
					new SqlParameter("@Type", SqlDbType.NVarChar,50),
					new SqlParameter("@Question", SqlDbType.NVarChar,50),				
					new SqlParameter("@AddTime", SqlDbType.DateTime)};



            parameters[0].Value = model.Subject;
            parameters[1].Value = model.FullName;
            parameters[2].Value = model.Mail;
            parameters[3].Value = model.Address;
            parameters[4].Value = model.ZipCode;
            parameters[5].Value = model.Province;
            parameters[6].Value = model.City;
            parameters[7].Value = model.Phone;
            parameters[8].Value = model.Fax;
            parameters[9].Value = model.Type;
            parameters[10].Value = model.Question;
            parameters[11].Value = model.AddTime;
            DbHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改一条数据
        /// </summary>
        public void UpdateField(int Id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Messages set " + strValue);
            strSql.Append(" where Id=" + Id);
            DbHelper.ExecuteSql(strSql.ToString());
        }
        

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Messages ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            DbHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Spread.Model.Messages GetModel(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Subject,FullName,Mail,Address,ZipCode,Province,City,Phone,Fax,Type,Question,AddTime from Messages ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            Spread.Model.Messages model = new Spread.Model.Messages();
            DataSet ds = DbHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.Subject = ds.Tables[0].Rows[0]["Subject"].ToString();
                model.FullName = ds.Tables[0].Rows[0]["FullName"].ToString();
                model.Mail = ds.Tables[0].Rows[0]["Mail"].ToString();
                model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                model.ZipCode = ds.Tables[0].Rows[0]["ZipCode"].ToString();
                model.Province = ds.Tables[0].Rows[0]["Province"].ToString();
                model.City = ds.Tables[0].Rows[0]["City"].ToString();
                model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                model.Fax = ds.Tables[0].Rows[0]["Fax"].ToString();
                model.Type = ds.Tables[0].Rows[0]["Type"].ToString();
                model.Question = ds.Tables[0].Rows[0]["Question"].ToString();
                if (ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }



                return model;
            }
            else
            {
                return null;
            }
        }

       

        /// <summary>
        /// 获得条件下的所有数据
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(" * ");
            strSql.Append(" FROM Messages");
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
            string strSql = "select ";
            if (Top > 0)
            {
                strSql += " top " + Top.ToString();
            }
            strSql += " * FROM Messages ";
            if (strWhere.Trim() != "")
            {
                strSql += " where " + strWhere;
            }
            if (filedOrder.Trim() != "")
            {
                strSql += " order by " + filedOrder;
            }
            return DbHelper.Query(strSql, null);
        }

        /// <summary>
        /// 获得指定的类别下所有文章
        /// </summary>
        public DataSet GetList(int classId, int kindId, int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Id,Subject,FullName,Mail,Address,ZipCode,Province,City,Phone,Fax,Type,Question,AddTime ");
            strSql.Append(" FROM Messages");
            strSql.Append(" where  0=0 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
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
                strSql.Append("select top " + pageSize + " Id,Subject,FullName,Mail,Address,ZipCode,Province,City,Phone,Fax,Type,Question,AddTime from Messages");
                strSql.Append(" where Id not in(select top " + topNum + " Id from Messages");
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
                strSql.Append("select top " + pageSize + " Id,Subject,FullName,Mail,Address,ZipCode,Province,City,Phone,Fax,Type,Question,AddTime from Messages");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                strSql.Append(" order by " + filedOrder);
            }

            return DbHelper.Query(strSql.ToString());
        }

        #endregion  成员方法
    }
}

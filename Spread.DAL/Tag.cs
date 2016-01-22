using System;
using System.Collections.Generic;

using System.Text;

using System.Data;
using System.Data.OleDb;
using Spread.DBUtility;
using System.Data.SqlClient;
namespace Spread.DAL
{
    public class Tag
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Spread.Model.Tag model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Tag(");
            strSql.Append("Name,TagCategoryID,ModelType,DaySearchCount,YesterdaySearchCount,TotalSearchCount,UserID,UserName,CountTime)");
            strSql.Append(" values (");
            strSql.Append("@Name,@TagCategoryID,@ModelType,@DaySearchCount,@YesterdaySearchCount,@TotalSearchCount,@UserID,@UserName,@CountTime)");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@TagCategoryID", SqlDbType.Int,4),
					new SqlParameter("@ModelType", SqlDbType.Int,4),
					new SqlParameter("@DaySearchCount", SqlDbType.Int,4),				
					new SqlParameter("@YesterdaySearchCount", SqlDbType.Int,4),
					new SqlParameter("@TotalSearchCount", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),					
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),                 
					new SqlParameter("@CountTime", SqlDbType.DateTime)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.TagCategoryId;
            parameters[2].Value = model.ModelType;
            parameters[3].Value = model.DaySearchCount;
            parameters[4].Value = model.YesterdaySearchCount;//5_1_a_s_p_x
            parameters[5].Value = model.TotalSearchCount;
            parameters[6].Value = model.UserID;
            parameters[7].Value = model.UserName;
            parameters[8].Value = model.CountTime;

            DbHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Tag ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            DbHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 返回长查询数据总数 （分页用到）
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from Tag ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelper.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Tag ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
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
                strSql.Append("select top " + pageSize + " * from Tag");
                strSql.Append(" where ID not in(select top " + topNum + " ID from Tag");
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
                strSql.Append("select top " + pageSize + " * from Tag");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                strSql.Append(" order by " + filedOrder);
            }

            return DbHelper.Query(strSql.ToString());
        }
    }
}

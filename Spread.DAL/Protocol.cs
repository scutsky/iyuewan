using System;
using System.Data;
using System.Text;

using System.Data.OleDb;
using Spread.DBUtility;
using System.Data.SqlClient;//请先添加引用
namespace Spread.DAL
{
    /// <summary>
    /// 数据访问类Protocol。
    /// </summary>
    public class Protocol
    {
        public Protocol()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Protocol");
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
            strSql.Append(" from Protocol ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelper.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 返回该类别下的所有记录总数
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="classId">类别</param>
        /// <param name="kindId">种类</param>
        /// <returns></returns>
        public int GetCount(string strWhere, int classId, int kindId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from Protocol ");
            strSql.Append(" where ClassId in(select Id from Protocol_type where KindId=" + kindId + " and ClassList like '%," + classId + ",%')");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            return Convert.ToInt32(DbHelper.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Spread.Model.Protocol model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Protocol(");
            strSql.Append("Title,Author,Form,ClassId,ImgUrl,Content,Click,IsMsg,IsTop,IsRed,IsHot,IsSlide,AddTime)");
            strSql.Append(" values (");
            strSql.Append("@Title,@Author,@Form,@ClassId,@ImgUrl,@Content,@Click,@IsMsg,@IsTop,@IsRed,@IsHot,@IsSlide,@AddTime)");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@Author", SqlDbType.NVarChar,50),
					new SqlParameter("@Form", SqlDbType.NVarChar,500),
					
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@ImgUrl", SqlDbType.NVarChar,250),
					
					new SqlParameter("@Content", SqlDbType.NVarChar,100000),
					new SqlParameter("@Click", SqlDbType.Bit),
					new SqlParameter("@IsMsg", SqlDbType.Bit),
					new SqlParameter("@IsTop", SqlDbType.Bit),
					new SqlParameter("@IsRed", SqlDbType.Bit),
					new SqlParameter("@IsHot", SqlDbType.Bit),
					new SqlParameter("@IsSlide", SqlDbType.Bit),
				
					new SqlParameter("@AddTime", SqlDbType.DateTime)};



            parameters[0].Value = model.Title;
            parameters[1].Value = model.Author;
            parameters[2].Value = model.Form;
            parameters[3].Value = model.ClassId;
            parameters[4].Value = model.ImgUrl;

            parameters[5].Value = model.Content;
            parameters[6].Value = model.Click;
            parameters[7].Value = model.IsMsg;
            parameters[8].Value = model.IsTop;
            parameters[9].Value = model.IsRed;
            parameters[10].Value = model.IsHot;
            parameters[11].Value = model.IsSlide;

            parameters[12].Value = model.AddTime;



            DbHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改一条数据
        /// </summary>
        public void UpdateField(int Id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Protocol set " + strValue);
            strSql.Append(" where Id=" + Id);
            DbHelper.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Spread.Model.Protocol model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Protocol set ");
            strSql.Append("[Title]=@Title, ");
            strSql.Append("[Author]=@Author, ");
            strSql.Append("[Form]=@Form, ");
            strSql.Append("[ClassId]=@ClassId, ");
            strSql.Append("[ImgUrl]=@ImgUrl, ");
            strSql.Append("[Content]=@Content, ");
            strSql.Append("[Click]=@Click, ");
            strSql.Append("[IsMsg]=@IsMsg, ");
            strSql.Append("[IsTop]=@IsTop, ");
            strSql.Append("[IsRed]=@IsRed, ");
            strSql.Append("[IsHot]=@IsHot, ");
            strSql.Append("[IsSlide]=@IsSlide, ");

            strSql.Append("[AddTime]=@AddTime ");
            strSql.Append("where [Id]=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@Author", SqlDbType.NVarChar,50),
					new SqlParameter("@Form", SqlDbType.NVarChar,500),
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@ImgUrl", SqlDbType.NVarChar,250),
                    new SqlParameter("@Content", SqlDbType.NVarChar,100000),
                    new SqlParameter("@Click", SqlDbType.Bit),
					new SqlParameter("@IsMsg", SqlDbType.Bit),
					new SqlParameter("@IsTop", SqlDbType.Bit),
					new SqlParameter("@IsRed", SqlDbType.Bit),
					new SqlParameter("@IsHot", SqlDbType.Bit),
					new SqlParameter("@IsSlide", SqlDbType.Bit),
                  
					new SqlParameter("@AddTime", SqlDbType.DateTime),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.Author;
            parameters[2].Value = model.Form;
            parameters[3].Value = model.ClassId;
            parameters[4].Value = model.ImgUrl;
            parameters[5].Value = model.Content;
            parameters[6].Value = model.Click;
            parameters[7].Value = model.IsMsg;
            parameters[8].Value = model.IsTop;
            parameters[9].Value = model.IsRed;
            parameters[10].Value = model.IsHot;
            parameters[11].Value = model.IsSlide;

            parameters[12].Value = model.AddTime;
            parameters[13].Value = model.Id;
            DbHelper.ExecuteSql(strSql.ToString(), parameters);

        }

        /// <summary>
        /// 更新内容
        /// </summary>
        public void UpdateContent(Spread.Model.Protocol model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Protocol set ");
            strSql.Append("Content=@Content");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
                  new SqlParameter("@Content", SqlDbType.NVarChar),
                  new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.Content;
            parameters[1].Value = model.Id;

            DbHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新点击数
        /// </summary>
        public void UpdateClick(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Protocol set ");
            strSql.Append("Click=Click+1");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
                  new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            DbHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Protocol ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            DbHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Spread.Model.Protocol GetModel(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Title,Author,Form,ClassId,ImgUrl,Content,Click,IsMsg,IsTop,IsRed,IsHot,IsSlide,AddTime from Protocol ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            Spread.Model.Protocol model = new Spread.Model.Protocol();
            DataSet ds = DbHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.Author = ds.Tables[0].Rows[0]["Author"].ToString();
                model.Form = ds.Tables[0].Rows[0]["Form"].ToString();

                if (ds.Tables[0].Rows[0]["ClassId"].ToString() != "")
                {
                    model.ClassId = int.Parse(ds.Tables[0].Rows[0]["ClassId"].ToString());
                }
                model.ImgUrl = ds.Tables[0].Rows[0]["ImgUrl"].ToString();

                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                if (ds.Tables[0].Rows[0]["Click"].ToString() != "")
                {
                    model.Click = int.Parse(ds.Tables[0].Rows[0]["Click"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsMsg"].ToString() != "")
                {
                    model.IsMsg = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsMsg"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsTop"].ToString() != "")
                {
                    model.IsTop = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsTop"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsRed"].ToString() != "")
                {
                    model.IsRed = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsRed"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsHot"].ToString() != "")
                {
                    model.IsHot = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsHot"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsSlide"].ToString() != "")
                {
                    model.IsSlide = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsSlide"].ToString());
                }

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
        /// 得到下一个或上一个实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Spread.Model.Protocol GetUpDownModel(int Id, bool UpOrDown)
        {
            StringBuilder strSql = new StringBuilder();
            if (UpOrDown)
            {
                strSql.Append("select top 1 * from [Protocol] WHERE Id > @Id order by Id asc ");
            }
            else { strSql.Append("select * from [Protocol] WHERE Id < @Id order by Id desc "); }
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            Spread.Model.Protocol model = new Spread.Model.Protocol();
            DataSet ds = DbHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.Author = ds.Tables[0].Rows[0]["Author"].ToString();
                model.Form = ds.Tables[0].Rows[0]["Form"].ToString();

                if (ds.Tables[0].Rows[0]["ClassId"].ToString() != "")
                {
                    model.ClassId = int.Parse(ds.Tables[0].Rows[0]["ClassId"].ToString());
                }
                model.ImgUrl = ds.Tables[0].Rows[0]["ImgUrl"].ToString();

                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                if (ds.Tables[0].Rows[0]["Click"].ToString() != "")
                {
                    model.Click = int.Parse(ds.Tables[0].Rows[0]["Click"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsMsg"].ToString() != "")
                {
                    model.IsMsg = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsMsg"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsTop"].ToString() != "")
                {
                    model.IsTop = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsTop"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsRed"].ToString() != "")
                {
                    model.IsRed = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsRed"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsHot"].ToString() != "")
                {
                    model.IsHot = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsHot"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsSlide"].ToString() != "")
                {
                    model.IsSlide = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsSlide"].ToString());
                }

                if (ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
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
            strSql.Append(" FROM Protocol");
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
            strSql += " * FROM Protocol ";
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
            strSql.Append(" Id,Title,Author,Form,ClassId,ImgUrl,Content,Click,IsMsg,IsTop,IsRed,IsHot,IsSlide,AddTime ");
            strSql.Append(" FROM Protocol");
            strSql.Append(" where ClassId in(select Id from Protocol_type where ClassList like '%," + classId + ",%')");
            //strSql.Append(" where ClassId in(select Id from Channel where KindId=" + kindId + " and ClassList like '%," + classId + ",%')");
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
                strSql.Append("select top " + pageSize + " Id,Title,Author,Form,ClassId,ImgUrl,Content,Click,IsMsg,IsTop,IsRed,IsHot,IsSlide,AddTime from Protocol");
                strSql.Append(" where Id not in(select top " + topNum + " Id from Protocol");
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
                strSql.Append("select top " + pageSize + " Id,Title,Author,Form,ClassId,ImgUrl,Content,Click,IsMsg,IsTop,IsRed,IsHot,IsSlide,AddTime from Protocol");
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
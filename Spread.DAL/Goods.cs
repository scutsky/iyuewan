using System;
using System.Data;
using System.Text;

using System.Data.OleDb;
using Spread.DBUtility;
using System.Data.SqlClient;//请先添加引用
namespace Spread.DAL
{
	/// <summary>
	/// 数据访问类Goods。
	/// </summary>
	public class Goods
	{
        public Goods()
		{}
		#region  成员方法
        /// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Goods");
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
            strSql.Append(" from Goods ");
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
            strSql.Append(" from Goods ");
            strSql.Append(" where ClassId in(select Id from Channel where KindId=" + kindId + " and ClassList like '%," + classId + ",%')");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            return Convert.ToInt32(DbHelper.GetSingle(strSql.ToString()));
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Spread.Model.Goods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Goods(");
            strSql.Append("Title,Form,ClassId,ImgUrl,IsMsg,IsTop,IsRed,IsHot,IsSlide,IsLock,AddTime,Zhaiyao,GType,GFactory,GBrand,Code1,Code2,Bak1,Bak2,Bak3,Bak4,Bak5)");
			strSql.Append(" values (");
            strSql.Append("@Title,@Form,@ClassId,@ImgUrl,@IsMsg,@IsTop,@IsRed,@IsHot,@IsSlide,@IsLock,@AddTime,@Zhaiyao,@GType,@GFactory,@GBrand,@Code1,@Code2,@Bak1,@Bak2,@Bak3,@Bak4,@Bak5)");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@Form", SqlDbType.NVarChar,50),
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@ImgUrl", SqlDbType.NVarChar,250),
					new SqlParameter("@IsMsg", SqlDbType.Bit),
					new SqlParameter("@IsTop", SqlDbType.Bit),
					new SqlParameter("@IsRed", SqlDbType.Bit),
					new SqlParameter("@IsHot", SqlDbType.Bit),
					new SqlParameter("@IsSlide", SqlDbType.Bit),
					new SqlParameter("@IsLock", SqlDbType.Bit),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
                    new SqlParameter("@Zhaiyao", SqlDbType.NVarChar,1000),
                    new SqlParameter("@GType", SqlDbType.NVarChar,50),
                    new SqlParameter("@GFactory", SqlDbType.NVarChar,50),
                    new SqlParameter("@GBrand", SqlDbType.NVarChar,50),
                    new SqlParameter("@Code1", SqlDbType.NVarChar,50),
                    new SqlParameter("@Code2", SqlDbType.NVarChar,50),
                    new SqlParameter("@Bak1", SqlDbType.NVarChar,50),
                    new SqlParameter("@Bak2", SqlDbType.NVarChar,50),
                    new SqlParameter("@Bak3", SqlDbType.NVarChar,50),
                    new SqlParameter("@Bak4", SqlDbType.NVarChar,50),
                    new SqlParameter("@Bak5", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.Form;
			parameters[2].Value = model.ClassId;
			parameters[3].Value = model.ImgUrl;
			parameters[4].Value = model.IsMsg;
			parameters[5].Value = model.IsTop;
			parameters[6].Value = model.IsRed;
			parameters[7].Value = model.IsHot;
			parameters[8].Value = model.IsSlide;
			parameters[9].Value = model.IsLock;
			parameters[10].Value = model.AddTime;
            parameters[11].Value = model.Zhaiyao;
            parameters[12].Value = model.GType;
            parameters[13].Value = model.GFactory;
            parameters[14].Value = model.GBrand;
            parameters[15].Value = model.Code1;
            parameters[16].Value = model.Code2;
            parameters[17].Value = model.Bak1;
            parameters[18].Value = model.Bak2;
            parameters[19].Value = model.Bak3;
            parameters[20].Value = model.Bak4;
            parameters[21].Value = model.Bak5;
            DbHelper.ExecuteSql(strSql.ToString(), parameters);
		}
        /// <summary>
        /// 修改一条数据
        /// </summary>
        public void UpdateField(int Id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Goods set " + strValue);
            strSql.Append(" where Id=" + Id);
            DbHelper.ExecuteSql(strSql.ToString());
        }
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Spread.Model.Goods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Goods set ");
			strSql.Append("Title=@Title,");
			strSql.Append("Form=@Form,");
			strSql.Append("ClassId=@ClassId,");
			strSql.Append("ImgUrl=@ImgUrl,");
			strSql.Append("IsMsg=@IsMsg, ");
			strSql.Append("IsTop=@IsTop, ");
			strSql.Append("IsRed=@IsRed, ");
			strSql.Append("IsHot=@IsHot, ");
            strSql.Append("IsSlide=@IsSlide, ");
            strSql.Append("IsLock=@IsLock, ");
            strSql.Append("AddTime=@AddTime, ");
            strSql.Append("Zhaiyao=@Zhaiyao,   ");
            strSql.Append("GType=@GType,   ");
            strSql.Append("GFactory=@GFactory,   ");
            strSql.Append("GBrand=@GBrand,  ");
            strSql.Append("Code1=@Code1,  ");
            strSql.Append("Code2=@Code2,  ");
            strSql.Append("Bak1=@Bak1,  ");
            strSql.Append("Bak2=@Bak2,  ");
            strSql.Append("Bak3=@Bak3,  ");
            strSql.Append("Bak4=@Bak4,  ");
            strSql.Append("Bak5=@Bak5  ");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@Form", SqlDbType.NVarChar,50),
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@ImgUrl", SqlDbType.NVarChar,250),
					new SqlParameter("@IsMsg", SqlDbType.Bit),
					new SqlParameter("@IsTop", SqlDbType.Bit),
					new SqlParameter("@IsRed", SqlDbType.Bit),
					new SqlParameter("@IsHot", SqlDbType.Bit),
					new SqlParameter("@IsSlide", SqlDbType.Bit),
					new SqlParameter("@IsLock", SqlDbType.Bit),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
                    new SqlParameter("@Zhaiyao", SqlDbType.NVarChar,2550),
                    new SqlParameter("@GType", SqlDbType.NVarChar,50),
                    new SqlParameter("@GFactory", SqlDbType.NVarChar,50),                  
                    new SqlParameter("@GBrand", SqlDbType.NVarChar,50),
                    new SqlParameter("@Code1", SqlDbType.NVarChar,50),
                    new SqlParameter("@Code2", SqlDbType.NVarChar,50),
                    new SqlParameter("@Bak1", SqlDbType.NVarChar,50),
                    new SqlParameter("@Bak2", SqlDbType.NVarChar,50),
                    new SqlParameter("@Bak3", SqlDbType.NVarChar,50),
                    new SqlParameter("@Bak4", SqlDbType.NVarChar,50),
                    new SqlParameter("@Bak5", SqlDbType.NVarChar,50),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.Form;
			parameters[2].Value = model.ClassId;
			parameters[3].Value = model.ImgUrl;
			parameters[4].Value = model.IsMsg;
			parameters[5].Value = model.IsTop;
			parameters[6].Value = model.IsRed;
			parameters[7].Value = model.IsHot;
			parameters[8].Value = model.IsSlide;
			parameters[9].Value = model.IsLock;
			parameters[10].Value = model.AddTime;
            parameters[11].Value = model.Zhaiyao;
            parameters[12].Value = model.GType;
            parameters[13].Value = model.GFactory;
            parameters[14].Value = model.GBrand;
            parameters[15].Value = model.Code1;
            parameters[16].Value = model.Code2;
            parameters[17].Value = model.Bak1;
            parameters[18].Value = model.Bak2;
            parameters[19].Value = model.Bak3;
            parameters[20].Value = model.Bak4;
            parameters[21].Value = model.Bak5;
            parameters[22].Value = model.Id;

			DbHelper.ExecuteSql(strSql.ToString(),parameters);
		}

        /// <summary>
		/// 更新内容
		/// </summary>
        public void UpdateContent(Spread.Model.Goods model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Goods set ");
            strSql.Append("Zhaiyao=@Content");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
                  new SqlParameter("@Content", SqlDbType.NVarChar),
                  new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.Zhaiyao;
            parameters[1].Value = model.Id;

            DbHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新点击数
        /// </summary>
        public void UpdateClick(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Goods set ");
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
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Goods ");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			DbHelper.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Spread.Model.Goods GetModel(int Id)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 Id,Title,Form,ClassId,ImgUrl,IsMsg,IsTop,IsRed,IsHot,IsSlide,IsLock,AddTime,Zhaiyao,GType,GFactory,GBrand,Code1,Code2,Bak1,Bak2,Bak3,Bak4,Bak5 from Goods ");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			Spread.Model.Goods model=new Spread.Model.Goods();
			DataSet ds=DbHelper.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				
				model.Form=ds.Tables[0].Rows[0]["Form"].ToString();
			
				model.Zhaiyao=ds.Tables[0].Rows[0]["Zhaiyao"].ToString();
                model.GType = ds.Tables[0].Rows[0]["GType"].ToString();
                model.GFactory = ds.Tables[0].Rows[0]["GFactory"].ToString();
                model.GBrand = ds.Tables[0].Rows[0]["GBrand"].ToString();
                model.Code1 = ds.Tables[0].Rows[0]["Code1"].ToString();
                model.Code2 = ds.Tables[0].Rows[0]["Code2"].ToString();
                model.Bak1 = ds.Tables[0].Rows[0]["Bak1"].ToString();
                model.Bak2 = ds.Tables[0].Rows[0]["Bak2"].ToString();
                model.Bak3 = ds.Tables[0].Rows[0]["Bak3"].ToString();
                model.Bak4 = ds.Tables[0].Rows[0]["Bak4"].ToString();
                model.Bak5 = ds.Tables[0].Rows[0]["Bak5"].ToString();
				if(ds.Tables[0].Rows[0]["ClassId"].ToString()!="")
				{
					model.ClassId=int.Parse(ds.Tables[0].Rows[0]["ClassId"].ToString());
				}
				model.ImgUrl=ds.Tables[0].Rows[0]["ImgUrl"].ToString();
              
               
				if(ds.Tables[0].Rows[0]["IsMsg"].ToString()!="")
				{
					model.IsMsg=Convert.ToBoolean(ds.Tables[0].Rows[0]["IsMsg"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsTop"].ToString()!="")
				{
                    model.IsTop = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsTop"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRed"].ToString()!="")
				{
                    model.IsRed = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsRed"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsHot"].ToString()!="")
				{
                    model.IsHot = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsHot"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsSlide"].ToString()!="")
				{
                    model.IsSlide = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsSlide"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsLock"].ToString()!="")
				{
                    model.IsLock = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsLock"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
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
        public Spread.Model.Goods GetUpDownModel(int Id, bool UpOrDown)
		{
			StringBuilder strSql=new StringBuilder();
            if (UpOrDown)
            {
                strSql.Append("select top 1 * from [Goods] WHERE Id > @Id order by Id asc ");
            }
            else { strSql.Append("select * from [Goods] WHERE Id < @Id order by Id desc "); }
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			Spread.Model.Goods model=new Spread.Model.Goods();
			DataSet ds=DbHelper.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
			
				model.Form=ds.Tables[0].Rows[0]["Form"].ToString();
			
				model.Zhaiyao=ds.Tables[0].Rows[0]["Zhaiyao"].ToString();
                model.GType = ds.Tables[0].Rows[0]["GType"].ToString();
                model.GFactory = ds.Tables[0].Rows[0]["GFactory"].ToString();
                model.GBrand = ds.Tables[0].Rows[0]["GBrand"].ToString();
                model.Code1 = ds.Tables[0].Rows[0]["Code1"].ToString();
                model.Code2 = ds.Tables[0].Rows[0]["Code2"].ToString();
                model.Bak1 = ds.Tables[0].Rows[0]["Bak1"].ToString();
                model.Bak2 = ds.Tables[0].Rows[0]["Bak2"].ToString();
                model.Bak3 = ds.Tables[0].Rows[0]["Bak3"].ToString();
                model.Bak4 = ds.Tables[0].Rows[0]["Bak4"].ToString();
                model.Bak5 = ds.Tables[0].Rows[0]["Bak5"].ToString();
				if(ds.Tables[0].Rows[0]["ClassId"].ToString()!="")
				{
					model.ClassId=int.Parse(ds.Tables[0].Rows[0]["ClassId"].ToString());
				}
				model.ImgUrl=ds.Tables[0].Rows[0]["ImgUrl"].ToString();

				if(ds.Tables[0].Rows[0]["IsMsg"].ToString()!="")
				{
					model.IsMsg=Convert.ToBoolean(ds.Tables[0].Rows[0]["IsMsg"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsTop"].ToString()!="")
				{
                    model.IsTop = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsTop"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRed"].ToString()!="")
				{
                    model.IsRed = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsRed"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsHot"].ToString()!="")
				{
                    model.IsHot = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsHot"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsSlide"].ToString()!="")
				{
                    model.IsSlide = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsSlide"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsLock"].ToString()!="")
				{
                    model.IsLock = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsLock"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
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
            strSql.Append(" FROM Goods");            
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
            strSql += " * FROM Goods ";
            if (strWhere.Trim() != "")
            {
                strSql += " where " + strWhere;
            }
            if (filedOrder.Trim() != "")
            {
                strSql += " order by " + filedOrder;
            }
            return DbHelper.Query( strSql, null);
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
            strSql.Append(" Id,Title,Form,Zhaiyao,ClassId,ImgUrl,IsMsg,IsTop,IsRed,IsHot,IsSlide,IsLock,AddTime,GType,GFactory,GBrand,Code1,Code2,Bak1,Bak2,Bak3,Bak4,Bak5 ");
            strSql.Append(" FROM Goods");
            strSql.Append(" where ClassId in(select Id from Menu where ClassList like '%," + classId + ",%')");
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
                strSql.Append("select top " + pageSize + " * from Goods");
                strSql.Append(" where Id not in(select top " + topNum + " Id from Goods)");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" and " + strWhere);
                }
                //strSql.Append(" order by " + filedOrder + ")");
            }
            else
            {
                strSql.Append("select  top " + pageSize + " * from Goods");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                //strSql.Append(" order by " + filedOrder);
            }

            return DbHelper.Query(strSql.ToString());
        }

		#endregion  成员方法
	}
}
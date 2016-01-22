using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Spread.DBUtility;

namespace Spread.DAL
{
    public class CardGame
    {
        public CardGame()
        { }
		#region  BasicMethod


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.CardGame model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CardGame(");
			strSql.Append("GameID,CardName,CardType,Status,UpdateDate,ChanelID,ChanelName,UserID,Bak1,Bak2,Bak3)");
			strSql.Append(" values (");
			strSql.Append("@GameID,@CardName,@CardType,@Status,@UpdateDate,@ChanelID,@ChanelName,@UserID,@Bak1,@Bak2,@Bak3)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@GameID", SqlDbType.Int,4),
					new SqlParameter("@CardName", SqlDbType.NVarChar,50),
					new SqlParameter("@CardType", SqlDbType.NVarChar,50),
					new SqlParameter("@Status", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime),
					new SqlParameter("@ChanelID", SqlDbType.Int,4),
					new SqlParameter("@ChanelName", SqlDbType.NVarChar,50),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@Bak1", SqlDbType.NVarChar,50),
					new SqlParameter("@Bak2", SqlDbType.NVarChar,50),
					new SqlParameter("@Bak3", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.GameID;
			parameters[1].Value = model.CardName;
			parameters[2].Value = model.CardType;
			parameters[3].Value = model.Status;
			parameters[4].Value = model.UpdateDate;
			parameters[5].Value = model.ChanelID;
			parameters[6].Value = model.ChanelName;
			parameters[7].Value = model.UserID;
			parameters[8].Value = model.Bak1;
			parameters[9].Value = model.Bak2;
			parameters[10].Value = model.Bak3;

			object obj = DbHelper.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(Model.CardGame model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CardGame set ");		
			strSql.Append("CardName=@CardName,");
			strSql.Append("CardType=@CardType,");
			strSql.Append("Status=@Status,");
			strSql.Append("UpdateDate=@UpdateDate");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {				
					new SqlParameter("@CardName", SqlDbType.NVarChar,50),
					new SqlParameter("@CardType", SqlDbType.NVarChar,50),
					new SqlParameter("@Status", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.CardName;
			parameters[1].Value = model.CardType;
			parameters[2].Value = model.Status;
			parameters[3].Value = model.UpdateDate;
			parameters[4].Value = model.ID;

			int rows=DbHelper.ExecuteSql(strSql.ToString(),parameters);
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
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CardGame ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			int rows=DbHelper.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CardGame ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelper.ExecuteSql(strSql.ToString());
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
		public Model.CardGame GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,GameID,CardName,CardType,Status,UpdateDate,ChanelID,ChanelName,UserID,Bak1,Bak2,Bak3 from CardGame ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			Model.CardGame model=new Model.CardGame();
			DataSet ds=DbHelper.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
        public Model.CardGame GetModelbyChanelID(int ChanelID, int GameID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,GameID,CardName,CardType,Status,UpdateDate,ChanelID,ChanelName,UserID,Bak1,Bak2,Bak3 from CardGame ");
            strSql.Append(" where ChanelID=@ChanelID and GameID=@GameID");
            SqlParameter[] parameters = {
					new SqlParameter("@ChanelID", SqlDbType.Int,4),
                    new SqlParameter("@GameID", SqlDbType.Int,4)
			};
            parameters[0].Value = ChanelID;
            parameters[1].Value = GameID;
            Model.CardGame model = new Model.CardGame();
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
		public Model.CardGame DataRowToModel(DataRow row)
		{
			Model.CardGame model=new Model.CardGame();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["GameID"]!=null && row["GameID"].ToString()!="")
				{
					model.GameID=int.Parse(row["GameID"].ToString());
				}
				if(row["CardName"]!=null)
				{
					model.CardName=row["CardName"].ToString();
				}
				if(row["CardType"]!=null)
				{
					model.CardType=row["CardType"].ToString();
				}
				if(row["Status"]!=null)
				{
					model.Status=row["Status"].ToString();
				}
				if(row["UpdateDate"]!=null && row["UpdateDate"].ToString()!="")
				{
					model.UpdateDate=DateTime.Parse(row["UpdateDate"].ToString());
				}
				if(row["ChanelID"]!=null && row["ChanelID"].ToString()!="")
				{
					model.ChanelID=int.Parse(row["ChanelID"].ToString());
				}
				if(row["ChanelName"]!=null)
				{
					model.ChanelName=row["ChanelName"].ToString();
				}
				if(row["UserID"]!=null && row["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(row["UserID"].ToString());
				}
				if(row["Bak1"]!=null)
				{
					model.Bak1=row["Bak1"].ToString();
				}
				if(row["Bak2"]!=null)
				{
					model.Bak2=row["Bak2"].ToString();
				}
				if(row["Bak3"]!=null)
				{
					model.Bak3=row["Bak3"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  e.*,g.NAME gamename,g.Platform Platform ");
            strSql.Append(" FROM CardGame e left join  Game g ON e.gameID=g.ID ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelper.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,GameID,CardName,CardType,Status,UpdateDate,ChanelID,ChanelName,UserID,Bak1,Bak2,Bak3 ");
			strSql.Append(" FROM CardGame ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelper.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM CardGame ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from CardGame T ");
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


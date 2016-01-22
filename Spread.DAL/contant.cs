using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using Spread.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace Spread.DAL
{
   public class contant
    {
       public contant()
       {
           //构造函数
       }

        #region  成员方法

       /// <summary>
       /// 添加企业信息
       /// </summary>
       /// <param name="model"></param>
       public void Add(Spread.Model.contant model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into contant(");
           strSql.Append("ContName,ContAddres,ContImage,Contcont)");
           strSql.Append(" values (");
           strSql.Append("@ContName,@ContAddres,@ContImage,@Contcont)");
           SqlParameter[] parameters = {
					new SqlParameter("@ContName", SqlDbType.NVarChar,30),
					new SqlParameter("@ContAddres", SqlDbType.NVarChar,50),
					new SqlParameter("@ContImage", SqlDbType.NVarChar,250),
					new SqlParameter("@Contcont", SqlDbType.NVarChar,12500)};

           parameters[0].Value = model.ContName;
           parameters[1].Value = model.ContAddres;
           parameters[2].Value = model.ContImage;
           parameters[3].Value = model.Contcont;

           DbHelper.ExecuteSql(strSql .ToString(),parameters);
       }
       /// <summary>
       /// 获取公司信息返回实体对象
       /// </summary>
       public Spread.Model.contant GetModel()
       {
           Spread.Model.contant model = new Spread.Model.contant();
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 1 ID,ContName,ContAddres,ContImage,Contcont,Hits  from contant ");
           SqlParameter[] parameters = {
                    new SqlParameter ("@ID",SqlDbType.Int),
					new SqlParameter("@ContName", SqlDbType.NVarChar,30),
					new SqlParameter("@ContAddres", SqlDbType.NVarChar,50),
					new SqlParameter("@ContImage", SqlDbType.NVarChar,250),
					new SqlParameter("@Contcont", SqlDbType.NVarChar,12500),
                    new SqlParameter("@Hits", SqlDbType.Int)};
           parameters[0].Value = model.ID;
           parameters[1].Value = model.ContName;
           parameters[2].Value = model.ContAddres;
           parameters[3].Value = model.ContImage;
           parameters[4].Value = model.Contcont;
           parameters[5].Value = model.Hits;
           DataSet ds = DbHelper.Query(strSql.ToString(), parameters);
           if (ds.Tables[0].Rows.Count > 0)
           {
               model.ID = Convert.ToInt32( ds.Tables[0].Rows[0]["ID"].ToString());
               model.ContName = ds.Tables[0].Rows[0]["ContName"].ToString();
               model.ContAddres = ds.Tables[0].Rows[0]["ContAddres"].ToString();
              
               model.ContImage = ds.Tables[0].Rows[0]["ContImage"].ToString();
               model.Contcont = ds.Tables[0].Rows[0]["Contcont"].ToString();
               model.Hits = Convert.ToInt32(ds.Tables[0].Rows[0]["Hits"].ToString());
               return model;
               
           }
           else
           {
               return null;
           }
       }

       /// <summary>
       /// 修改公司信息
       /// </summary>
       /// <param name="model"></param>
       public void update( Spread.Model.contant model)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("update contant set  ");
           strSql.Append("ContName=@ContName, ");

           strSql.Append("ContAddres=@ContAddres, ");

           strSql.Append("ContImage=@ContImage, ");
           strSql.Append("Contcont=@Contcont  ");
         
           strSql.Append(" where ID=@ID ");
           SqlParameter[] parameters = {
					new SqlParameter("@ContName", SqlDbType.NVarChar,30),
					new SqlParameter("@ContAddres", SqlDbType.NVarChar,50),
					new SqlParameter("@ContImage", SqlDbType.NVarChar,250),
					new SqlParameter("@Contcont", SqlDbType.NVarChar,12500),
                    new SqlParameter ("@ID",SqlDbType.Int,4)};
           parameters[0].Value = model.ContName;
           parameters[1].Value = model.ContAddres;
           parameters[2].Value = model.ContImage;
           parameters[3].Value = model.Contcont;
           parameters[4].Value =model.ID;

           DbHelper.ExecuteSql(strSql.ToString(), parameters);
       }
       /// <summary>
       /// 修改点击量
       /// </summary>
       /// <param name="model"></param>
       public void updateHits()
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("update contant set  ");
           strSql.Append("Hits=Hits+1 ");
           DbHelper.ExecuteSql(strSql.ToString());
       }
        #endregion 成员方法
    }
}

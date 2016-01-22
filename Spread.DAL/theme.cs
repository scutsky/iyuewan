using System;
using System.Data;
using System.Text;

using System.Data.OleDb;
using Spread.DBUtility;
using System.Data.SqlClient;//请先添加引用

namespace Spread.DAL
{
   public  class theme
    {

       public theme()
       {
           //
       }
       /// <summary>
       /// 添加联系方式
       /// </summary>
       /// <param name="model"></param>
       public void  Add(Spread.Model.theme model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into ContactUs(");
           strSql.Append("Contacts,Postal,phone,Tel,fax,Mail,Adress)");
           strSql.Append(" values (");
           strSql.Append("@Contacts,@Postal,@phone,@Tel,@fax,@Mail,@Adress)");
           SqlParameter[] parameters = {
					new SqlParameter("@Contacts", SqlDbType.NVarChar,50),
					new SqlParameter("@Postal", SqlDbType.NVarChar,20),
					new SqlParameter("@phone", SqlDbType.NVarChar,30),
					new SqlParameter("@Tel", SqlDbType.NVarChar,20),
                    new SqlParameter("@fax", SqlDbType.NVarChar,20),
					new SqlParameter("@Mail", SqlDbType.NVarChar,50),
					new SqlParameter("@Adress", SqlDbType.NVarChar,1000),};

           parameters[0].Value = model.Contacts;
           parameters[1].Value = model.Postal;
           parameters[2].Value = model.Phone;
           parameters[3].Value = model.Tel;
           parameters[4].Value = model.fax;
           parameters[5].Value = model.Mail;
           parameters[6].Value = model.Adress;

           DbHelper.ExecuteSql(strSql.ToString(), parameters);

       }

       /// <summary>
       /// 
       /// </summary>
       /// <returns></returns>
       public Spread.Model.theme getmodel()
       {

           Spread.Model.theme model = new Spread.Model.theme();
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 1 ID,Contacts,Postal,Phone,Tel,fax,Mail,Adress  from ContactUs ");
           SqlParameter[] parameters = {
                    new SqlParameter("@ID",SqlDbType.Int,4),
					new SqlParameter("@Contacts", SqlDbType.NVarChar,50),
					new SqlParameter("@Postal", SqlDbType.NVarChar,20),
					new SqlParameter("@phone", SqlDbType.NVarChar,30),
					new SqlParameter("@Tel", SqlDbType.NVarChar,20),
                    new SqlParameter("@fax", SqlDbType.NVarChar,20),
					new SqlParameter("@Mail", SqlDbType.NVarChar,50),
					new SqlParameter("@Adress", SqlDbType.NVarChar,1000)};
           parameters[0].Value = model.ID;
           parameters[1].Value = model.Contacts;
           parameters[2].Value = model.Postal;
           parameters[3].Value = model.Phone;
           parameters[4].Value = model.Tel;
           parameters[5].Value = model.fax;
           parameters[6].Value = model.Mail;
           parameters[7].Value = model.Adress;
           DataSet ds = DbHelper.Query(strSql.ToString(), parameters);
           if (ds.Tables[0].Rows.Count > 0)
           {
               model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"].ToString());
               model.Contacts = ds.Tables[0].Rows[0]["Contacts"].ToString();
               model.Postal = ds.Tables[0].Rows[0]["Postal"].ToString();
               model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();

               model.Tel = ds.Tables[0].Rows[0]["Tel"].ToString();
               model.fax = ds.Tables[0].Rows[0]["fax"].ToString();

               model.Mail = ds.Tables[0].Rows[0]["Mail"].ToString();
               model.Adress = ds.Tables[0].Rows[0]["Adress"].ToString();
               return model;

           }
           else
           {
               return null;
           }

       }

       /// <summary>
       /// 修改企业信息
       /// </summary>
       public void update(Spread.Model.theme model)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("update ContactUs set  ");
           strSql.Append("Contacts=@Contacts, ");

           strSql.Append("Postal=@Postal, ");

           strSql.Append("Phone=@Phone, ");
           strSql.Append("Tel=@Tel,  ");
           strSql.Append("fax=@fax, ");

           strSql.Append("Mail=@Mail, ");
           strSql.Append("Adress=@Adress  ");

           strSql.Append("where ID=@ID");


           SqlParameter[] parameters = {
               
					new SqlParameter("@Contacts", SqlDbType.NVarChar,50),
					new SqlParameter("@Postal", SqlDbType.NVarChar,20),
					new SqlParameter("@phone", SqlDbType.NVarChar,30),
					new SqlParameter("@Tel", SqlDbType.NVarChar,20),
                    new SqlParameter("@fax", SqlDbType.NVarChar,20),
					new SqlParameter("@Mail", SqlDbType.NVarChar,50),
					new SqlParameter("@Adress", SqlDbType.NVarChar,1000),
                    new SqlParameter("@ID",SqlDbType.Int,4)};

           parameters[0].Value = model.Contacts;
           parameters[1].Value = model.Postal;
           parameters[2].Value = model.Phone;
           parameters[3].Value = model.Tel;
           parameters[4].Value = model.fax;
           parameters[5].Value = model.Mail;
           parameters[6].Value = model.Adress;
           parameters[7].Value = model.ID;

           DbHelper.ExecuteSql(strSql.ToString(), parameters);
       }

    }

    
}

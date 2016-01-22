using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Spread.DBUtility;
using System.Data;

namespace Spread.DAL
{
    /// <summary>
    /// 数据访问类:User
    /// </summary>
    public partial class User
    {
        public User()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [User]");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelper.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 检查登录用户
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="UserPwd"></param>
        /// <returns></returns>
        public bool chkUserLoign(string UserName, string UserPwd)
        {
            string strSql = "select count(*) from [User] where Name=@UserName and Password=@UserPwd and isLock=0";
            SqlParameter[] parameters = {
                new SqlParameter("@UserName",SqlDbType.NVarChar,50),
                new SqlParameter("@UserPwd", SqlDbType.NVarChar,50)};
            parameters[0].Value = UserName;
            parameters[1].Value = UserPwd;
            return DbHelper.Exists(strSql, parameters);
        }

        /// <summary>
        /// 检查用户名是否重复
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public bool chkExists(string UserName)
        {
            string strSql = "select count(*) from [User] where Name=@UserName";
            SqlParameter[] parameters = {
                new SqlParameter("@UserName",SqlDbType.NVarChar,50)};
            parameters[0].Value = UserName;
            return DbHelper.Exists(strSql, parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Spread.Model.User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [User](");
            strSql.Append("Name,Password,RegDate,Email,Sex,IdentityCard,TrueName,IsLock,Tel,Phone,QQ,UserType,LastLogin,CompanyName,CompanyAddress,RegistrationMark,CorporateName,Applicationdesc,PaypalAccount,Salesman,SalesPhone,SalesQQ,Bak1,Bak2,Bak3,Bak4,Bak5)");
            strSql.Append(" values (");
            strSql.Append("@Name,@Password,@RegDate,@Email,@Sex,@IdentityCard,@TrueName,@IsLock,@Tel,@Phone,@QQ,@UserType,@LastLogin,@CompanyName,@CompanyAddress,@RegistrationMark,@CorporateName,@Applicationdesc,@PaypalAccount,@Salesman,@SalesPhone,@SalesQQ,@Bak1,@Bak2,@Bak3,@Bak4,@Bak5)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Password", SqlDbType.NVarChar,50),
					new SqlParameter("@RegDate", SqlDbType.DateTime),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.Bit,1),
					new SqlParameter("@IdentityCard", SqlDbType.NVarChar,50),
					new SqlParameter("@TrueName", SqlDbType.NVarChar,50),
					new SqlParameter("@IsLock", SqlDbType.Bit,1),
					new SqlParameter("@Tel", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@QQ", SqlDbType.NVarChar,50),
					new SqlParameter("@UserType", SqlDbType.Int,4),
					new SqlParameter("@LastLogin", SqlDbType.DateTime),
					new SqlParameter("@CompanyName", SqlDbType.NVarChar,100),
					new SqlParameter("@CompanyAddress", SqlDbType.NVarChar,500),
					new SqlParameter("@RegistrationMark", SqlDbType.NVarChar,100),
					new SqlParameter("@CorporateName", SqlDbType.NVarChar,100),
					new SqlParameter("@Applicationdesc", SqlDbType.NVarChar,1000),
					new SqlParameter("@PaypalAccount", SqlDbType.NVarChar,100),
					new SqlParameter("@Salesman", SqlDbType.NVarChar,100),
					new SqlParameter("@SalesPhone", SqlDbType.NVarChar,50),
					new SqlParameter("@SalesQQ", SqlDbType.NVarChar,50),
					new SqlParameter("@Bak1", SqlDbType.NVarChar,100),
					new SqlParameter("@Bak2", SqlDbType.NVarChar,100),
					new SqlParameter("@Bak3", SqlDbType.NVarChar,100),
					new SqlParameter("@Bak4", SqlDbType.NVarChar,100),
					new SqlParameter("@Bak5", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.RegDate;
            parameters[3].Value = model.Email;
            parameters[4].Value = model.Sex;
            parameters[5].Value = model.IdentityCard;
            parameters[6].Value = model.TrueName;
            parameters[7].Value = model.IsLock;
            parameters[8].Value = model.Tel;
            parameters[9].Value = model.Phone;
            parameters[10].Value = model.QQ;
            parameters[11].Value = model.UserType;
            parameters[12].Value = model.LastLogin;
            parameters[13].Value = model.CompanyName;
            parameters[14].Value = model.CompanyAddress;
            parameters[15].Value = model.RegistrationMark;
            parameters[16].Value = model.CorporateName;
            parameters[17].Value = model.Applicationdesc;
            parameters[18].Value = model.PaypalAccount;
            parameters[19].Value = model.Salesman;
            parameters[20].Value = model.SalesPhone;
            parameters[21].Value = model.SalesQQ;
            parameters[22].Value = model.Bak1;
            parameters[23].Value = model.Bak2;
            parameters[24].Value = model.Bak3;
            parameters[25].Value = model.Bak4;
            parameters[26].Value = model.Bak5;

            object obj = DbHelper.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(Spread.Model.User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [User] set ");
            strSql.Append("Name=@Name,");
            strSql.Append("Password=@Password,");
            strSql.Append("RegDate=@RegDate,");
            strSql.Append("Email=@Email,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("IdentityCard=@IdentityCard,");
            strSql.Append("TrueName=@TrueName,");
            strSql.Append("IsLock=@IsLock,");
            strSql.Append("Tel=@Tel,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("QQ=@QQ,");
            strSql.Append("UserType=@UserType,");
            strSql.Append("LastLogin=@LastLogin,");
            strSql.Append("CompanyName=@CompanyName,");
            strSql.Append("CompanyAddress=@CompanyAddress,");
            strSql.Append("RegistrationMark=@RegistrationMark,");
            strSql.Append("CorporateName=@CorporateName,");
            strSql.Append("Applicationdesc=@Applicationdesc,");
            strSql.Append("PaypalAccount=@PaypalAccount,");
            strSql.Append("Salesman=@Salesman,");
            strSql.Append("SalesPhone=@SalesPhone,");
            strSql.Append("SalesQQ=@SalesQQ,");
            strSql.Append("Bak1=@Bak1,");
            strSql.Append("Bak2=@Bak2,");
            strSql.Append("Bak3=@Bak3,");
            strSql.Append("Bak4=@Bak4,");
            strSql.Append("Bak5=@Bak5");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Password", SqlDbType.NVarChar,50),
					new SqlParameter("@RegDate", SqlDbType.DateTime),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.Bit,1),
					new SqlParameter("@IdentityCard", SqlDbType.NVarChar,50),
					new SqlParameter("@TrueName", SqlDbType.NVarChar,50),
					new SqlParameter("@IsLock", SqlDbType.Bit,1),
					new SqlParameter("@Tel", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@QQ", SqlDbType.NVarChar,50),
					new SqlParameter("@UserType", SqlDbType.Int,4),
					new SqlParameter("@LastLogin", SqlDbType.DateTime),
					new SqlParameter("@CompanyName", SqlDbType.NVarChar,100),
					new SqlParameter("@CompanyAddress", SqlDbType.NVarChar,500),
					new SqlParameter("@RegistrationMark", SqlDbType.NVarChar,100),
					new SqlParameter("@CorporateName", SqlDbType.NVarChar,100),
					new SqlParameter("@Applicationdesc", SqlDbType.NVarChar,1000),
					new SqlParameter("@PaypalAccount", SqlDbType.NVarChar,100),
					new SqlParameter("@Salesman", SqlDbType.NVarChar,100),
					new SqlParameter("@SalesPhone", SqlDbType.NVarChar,50),
					new SqlParameter("@SalesQQ", SqlDbType.NVarChar,50),
					new SqlParameter("@Bak1", SqlDbType.NVarChar,100),
					new SqlParameter("@Bak2", SqlDbType.NVarChar,100),
					new SqlParameter("@Bak3", SqlDbType.NVarChar,100),
					new SqlParameter("@Bak4", SqlDbType.NVarChar,100),
					new SqlParameter("@Bak5", SqlDbType.NVarChar,100),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.RegDate;
            parameters[3].Value = model.Email;
            parameters[4].Value = model.Sex;
            parameters[5].Value = model.IdentityCard;
            parameters[6].Value = model.TrueName;
            parameters[7].Value = model.IsLock;
            parameters[8].Value = model.Tel;
            parameters[9].Value = model.Phone;
            parameters[10].Value = model.QQ;
            parameters[11].Value = model.UserType;
            parameters[12].Value = model.LastLogin;
            parameters[13].Value = model.CompanyName;
            parameters[14].Value = model.CompanyAddress;
            parameters[15].Value = model.RegistrationMark;
            parameters[16].Value = model.CorporateName;
            parameters[17].Value = model.Applicationdesc;
            parameters[18].Value = model.PaypalAccount;
            parameters[19].Value = model.Salesman;
            parameters[20].Value = model.SalesPhone;
            parameters[21].Value = model.SalesQQ;
            parameters[22].Value = model.Bak1;
            parameters[23].Value = model.Bak2;
            parameters[24].Value = model.Bak3;
            parameters[25].Value = model.Bak4;
            parameters[26].Value = model.Bak5;
            parameters[27].Value = model.ID;

            int rows = DbHelper.ExecuteSql(strSql.ToString(), parameters);
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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [User] ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            int rows = DbHelper.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [User] ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelper.ExecuteSql(strSql.ToString());
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
        public Spread.Model.User GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Name,Password,RegDate,Email,Sex,IdentityCard,TrueName,IsLock,Tel,Phone,QQ,UserType,LastLogin,CompanyName,CompanyAddress,RegistrationMark,CorporateName,Applicationdesc,PaypalAccount,Salesman,SalesPhone,SalesQQ,Bak1,Bak2,Bak3,Bak4,Bak5 from [User] ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Spread.Model.User model = new Spread.Model.User();
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
        public Spread.Model.User GetModelByName(string name)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Name,Password,RegDate,Email,Sex,IdentityCard,TrueName,IsLock,Tel,Phone,QQ,UserType,LastLogin,CompanyName,CompanyAddress,RegistrationMark,CorporateName,Applicationdesc,PaypalAccount,Salesman,SalesPhone,SalesQQ,Bak1,Bak2,Bak3,Bak4,Bak5 from [User] ");
            strSql.Append(" where Name=@Name");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50)
			};
            parameters[0].Value = name;

            Spread.Model.User model = new Spread.Model.User();
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
        public Spread.Model.User DataRowToModel(DataRow row)
        {
            Spread.Model.User model = new Spread.Model.User();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["Password"] != null)
                {
                    model.Password = row["Password"].ToString();
                }
                if (row["RegDate"] != null && row["RegDate"].ToString() != "")
                {
                    model.RegDate = DateTime.Parse(row["RegDate"].ToString());
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
                }
                if (row["Sex"] != null && row["Sex"].ToString() != "")
                {
                    if ((row["Sex"].ToString() == "1") || (row["Sex"].ToString().ToLower() == "true"))
                    {
                        model.Sex = true;
                    }
                    else
                    {
                        model.Sex = false;
                    }
                }
                if (row["IdentityCard"] != null)
                {
                    model.IdentityCard = row["IdentityCard"].ToString();
                }
                if (row["TrueName"] != null)
                {
                    model.TrueName = row["TrueName"].ToString();
                }
                if (row["IsLock"] != null && row["IsLock"].ToString() != "")
                {
                    if ((row["IsLock"].ToString() == "1") || (row["IsLock"].ToString().ToLower() == "true"))
                    {
                        model.IsLock = true;
                    }
                    else
                    {
                        model.IsLock = false;
                    }
                }
                if (row["Tel"] != null)
                {
                    model.Tel = row["Tel"].ToString();
                }
                if (row["Phone"] != null)
                {
                    model.Phone = row["Phone"].ToString();
                }
                if (row["QQ"] != null)
                {
                    model.QQ = row["QQ"].ToString();
                }
                if (row["UserType"] != null && row["UserType"].ToString() != "")
                {
                    model.UserType = int.Parse(row["UserType"].ToString());
                }
                if (row["LastLogin"] != null && row["LastLogin"].ToString() != "")
                {
                    model.LastLogin = DateTime.Parse(row["LastLogin"].ToString());
                }
                if (row["CompanyName"] != null)
                {
                    model.CompanyName = row["CompanyName"].ToString();
                }
                if (row["CompanyAddress"] != null)
                {
                    model.CompanyAddress = row["CompanyAddress"].ToString();
                }
                if (row["RegistrationMark"] != null)
                {
                    model.RegistrationMark = row["RegistrationMark"].ToString();
                }
                if (row["CorporateName"] != null)
                {
                    model.CorporateName = row["CorporateName"].ToString();
                }
                if (row["Applicationdesc"] != null)
                {
                    model.Applicationdesc = row["Applicationdesc"].ToString();
                }
                if (row["PaypalAccount"] != null)
                {
                    model.PaypalAccount = row["PaypalAccount"].ToString();
                }
                if (row["Salesman"] != null)
                {
                    model.Salesman = row["Salesman"].ToString();
                }
                if (row["SalesPhone"] != null)
                {
                    model.SalesPhone = row["SalesPhone"].ToString();
                }
                if (row["SalesQQ"] != null)
                {
                    model.SalesQQ = row["SalesQQ"].ToString();
                }
                if (row["Bak1"] != null)
                {
                    model.Bak1 = row["Bak1"].ToString();
                }
                if (row["Bak2"] != null)
                {
                    model.Bak2 = row["Bak2"].ToString();
                }
                if (row["Bak3"] != null)
                {
                    model.Bak3 = row["Bak3"].ToString();
                }
                if (row["Bak4"] != null)
                {
                    model.Bak4 = row["Bak4"].ToString();
                }
                if (row["Bak5"] != null)
                {
                    model.Bak5 = row["Bak5"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Name,Password,RegDate,Email,Sex,IdentityCard,TrueName,IsLock,Tel,Phone,QQ,UserType,LastLogin,CompanyName,CompanyAddress,RegistrationMark,CorporateName,Applicationdesc,PaypalAccount,Salesman,SalesPhone,SalesQQ,Bak1,Bak2,Bak3,Bak4,Bak5 ");
            strSql.Append(" FROM [User] ");
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
            strSql.Append(" ID,Name,Password,RegDate,Email,Sex,IdentityCard,TrueName,IsLock,Tel,Phone,QQ,UserType,LastLogin,CompanyName,CompanyAddress,RegistrationMark,CorporateName,Applicationdesc,PaypalAccount,Salesman,SalesPhone,SalesQQ,Bak1,Bak2,Bak3,Bak4,Bak5 ");
            strSql.Append(" FROM [User] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM [User] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from [User] T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
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
                strSql.Append("select top " + pageSize + " Id,Name,Password,RegDate,Email,Sex,IdentityCard,TrueName,IsLock,Tel,Phone,QQ,UserType,LastLogin,CompanyName,CompanyAddress,RegistrationMark,CorporateName,Applicationdesc,PaypalAccount,Salesman,SalesPhone,SalesQQ,Bak1,Bak2,Bak3,Bak4,Bak5 from [User]");
                strSql.Append(" where Id not in(select top " + topNum + " Id from [User]");
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
                strSql.Append("select top " + pageSize + " Id,Name,Password,RegDate,Email,Sex,IdentityCard,TrueName,IsLock,Tel,Phone,QQ,UserType,LastLogin,CompanyName,CompanyAddress,RegistrationMark,CorporateName,Applicationdesc,PaypalAccount,Salesman,SalesPhone,SalesQQ,Bak1,Bak2,Bak3,Bak4,Bak5 from [User]");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                strSql.Append(" order by " + filedOrder);
            }

            return DbHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 修改一条数据
        /// </summary>
        public void UpdateField(int Id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [User] set " + strValue);
            strSql.Append(" where Id=" + Id);
            DbHelper.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 修改一条数据
        /// </summary>
        public bool UpdatePassword(string Name, string Password)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [User] set Password='"+Password+"'");
            strSql.Append(" where Name='" + Name+"'");
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
        /// 修改一条数据
        /// </summary>
        public bool UpdateQQ(string Name, string qq)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [User] set QQ='" + qq + "'");
            strSql.Append(" where Name='" + Name + "'");
            int rows = DbHelper.ExecuteSql(strSql.ToString());
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
        /// 修改一条数据
        /// </summary>
        public bool UpdatePhone(string Name, string phone)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [User] set Phone='" + phone + "'");
            strSql.Append(" where Name='" + Name + "'");
            int rows = DbHelper.ExecuteSql(strSql.ToString());
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
        /// 修改一条数据
        /// </summary>
        public bool UpdateEmail(string Name, string Email)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [User] set Email='" + Email + "'");
            strSql.Append(" where Name='" + Name + "'");
            int rows = DbHelper.ExecuteSql(strSql.ToString());
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
        /// 修改一条数据
        /// </summary>
        public bool UpdatePayinfo(string Name, string PayCode,string TureName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [User] set TrueName='" + TureName + "',PaypalAccount='" + PayCode + "'");
            strSql.Append(" where Name='" + Name + "'");
            int rows = DbHelper.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

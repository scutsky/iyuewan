using System;
using System.Data;
using System.Collections.Generic;
using Spread.Model;
using Spread.Common;
using System.Web;
namespace Spread.BLL
{
	/// <summary>
	/// 业务逻辑类Admin 的摘要说明。
	/// </summary>
	public class Admin
	{
		private readonly Spread.DAL.Admin dal=new Spread.DAL.Admin();
        Spread.BLL.Log logbll = new Spread.BLL.Log();

		public Admin()
		{}
		#region  成员方法

        /// <summary>
        /// 检查登录是否成功
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPwd"></param>
        /// <returns></returns>
        public bool chkAdminLogin(string userName, string userPwd)
        {
            return dal.chkAdminLoign(userName, DESEncrypt.Encrypt(userPwd, Param.EncCode));
        }

        /// <summary>
        /// 获得数据总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			return dal.Exists(Id);
		}
        public bool Exists(string UserName)
        {
            return dal.Exists(UserName);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Spread.Model.Admin model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(Spread.Model.Admin model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int Id)
		{			
			dal.Delete(Id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Spread.Model.Admin GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}

        /// <summary>
        /// 根据用户名取得一行数据
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public Spread.Model.Admin GetModel(string userName)
        {
            return dal.GetModel(userName);
        }

        public Spread.Model.Admin GetLogModel()
        {
            Spread.Model.Admin admin = new Spread.Model.Admin();
            admin.Id = int.Parse(HttpContext.Current.Request.Cookies["AdminState"]["AdminNo"]);
            admin.UserName = Spread.Common.Function.UrlDecode(HttpContext.Current.Request.Cookies["AdminState"]["AdminName"]);
            admin.ReadName = Spread.Common.Function.UrlDecode(HttpContext.Current.Request.Cookies["AdminState"]["ReadName"]);
            admin.UserPwd = Spread.Common.Function.UrlDecode(HttpContext.Current.Request.Cookies["AdminState"]["UserPwd"]);
            return admin;
        }

        public void SetLoginState(Spread.Model.Admin model)
        {
            Spread.BLL.Log logbll = new Spread.BLL.Log();
            HttpContext.Current.Response.Cookies["AdminState"]["AdminNo"] = model.Id.ToString();
            HttpContext.Current.Response.Cookies["AdminState"]["AdminName"] = Spread.Common.Function.UrlEncode(model.UserName);
            HttpContext.Current.Response.Cookies["AdminState"]["ReadName"] = Spread.Common.Function.UrlEncode(model.ReadName);
            HttpContext.Current.Response.Cookies["AdminState"]["UserPwd"] = Spread.Common.Function.DESEncrypt(model.UserPwd);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Spread.Model.Admin> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Spread.Model.Admin> DataTableToList(DataTable dt)
		{
			List<Spread.Model.Admin> modelList = new List<Spread.Model.Admin>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Spread.Model.Admin model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Spread.Model.Admin();
					if(dt.Rows[n]["Id"].ToString()!="")
					{
						model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
					}
					model.UserName=dt.Rows[n]["UserName"].ToString();
					model.UserPwd=dt.Rows[n]["UserPwd"].ToString();
					model.ReadName=dt.Rows[n]["ReadName"].ToString();
					model.UserEmail=dt.Rows[n]["UserEmail"].ToString();
					if(dt.Rows[n]["UserType"].ToString()!="")
					{
						model.UserType=int.Parse(dt.Rows[n]["UserType"].ToString());
					}
					model.UserLevel=dt.Rows[n]["UserLevel"].ToString();
					if(dt.Rows[n]["IsLock"].ToString()!="")
					{
						model.IsLock=Convert.ToBoolean(dt.Rows[n]["IsLock"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

        public void ClearCookie()
        {
            HttpContext.Current.Response.Cookies["AdminState"].Expires = DateTime.Now.AddDays(-1.0);
        }
		#endregion  成员方法
	}
}


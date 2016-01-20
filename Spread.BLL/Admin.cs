using System;
using System.Data;
using System.Collections.Generic;
using Spread.Model;
using Spread.Common;
using System.Web;
namespace Spread.BLL
{
	/// <summary>
	/// ҵ���߼���Admin ��ժҪ˵����
	/// </summary>
	public class Admin
	{
		private readonly Spread.DAL.Admin dal=new Spread.DAL.Admin();
        Spread.BLL.Log logbll = new Spread.BLL.Log();

		public Admin()
		{}
		#region  ��Ա����

        /// <summary>
        /// ����¼�Ƿ�ɹ�
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPwd"></param>
        /// <returns></returns>
        public bool chkAdminLogin(string userName, string userPwd)
        {
            return dal.chkAdminLoign(userName, DESEncrypt.Encrypt(userPwd, Param.EncCode));
        }

        /// <summary>
        /// �����������
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

		/// <summary>
		/// �Ƿ���ڸü�¼
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
		/// ����һ������
		/// </summary>
		public void Add(Spread.Model.Admin model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int Update(Spread.Model.Admin model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int Id)
		{			
			dal.Delete(Id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Spread.Model.Admin GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}

        /// <summary>
        /// �����û���ȡ��һ������
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
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Spread.Model.Admin> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
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
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

        public void ClearCookie()
        {
            HttpContext.Current.Response.Cookies["AdminState"].Expires = DateTime.Now.AddDays(-1.0);
        }
		#endregion  ��Ա����
	}
}


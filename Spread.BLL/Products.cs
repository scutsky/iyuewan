using System;
using System.Data;
using System.Collections.Generic;
using Spread.Model;
namespace Spread.BLL
{
	/// <summary>
	/// 业务逻辑类Products 的摘要说明。
	/// </summary>
	public class Products
	{
		private readonly Spread.DAL.Products dal=new Spread.DAL.Products();
        Spread.BLL.Log logbll = new Spread.BLL.Log();
		public Products()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			return dal.Exists(Id);
		}

        /// <summary>
        /// 返回查询数据总数（分页用到）
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int Id, string strField)
        {
            dal.UpdateField(Id, strField);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Spread.Model.Products model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Spread.Model.Products model)
		{
			dal.Update(model);
		}

        /// <summary>
        /// 更新商品编号
        /// </summary>
        public void UpdateBrand(Spread.Model.Products model)
        {
            this.dal.UpdateBrand(model);
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
		public Spread.Model.Products GetModel(int Id)
		{
			
			return dal.GetModel(Id);
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
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetPageList(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            return dal.GetPageList(pageSize, currentPage, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得最新添加的ID
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public int GetLastProID(string ID, string TableName)
        {
            return this.dal.GetLastProID(ID, TableName);
        }

         /// <summary>
        /// 获得产品所属类的编号
        /// </summary>
        /// <param name="TypeID"></param>
        /// <returns></returns>
        public string GetClassID(int TypeID)
        {
            return this.dal.GetClassID(TypeID);
        }

        /// <summary>
        /// 取得最大排序记录
        /// </summary>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        public int GetMaxSortID(int ClassId)
        {
            return this.dal.GetMaxSortID(ClassId);
        }
		#endregion  成员方法
	}
}


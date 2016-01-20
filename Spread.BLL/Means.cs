using System;
using System.Data;
using System.Collections.Generic;
using Spread.Model;

namespace Spread.BLL
{
    public class Means
    { 
        private readonly Spread.DAL.Means dal=new Spread.DAL.Means();
        public Means()
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
        /// 返回长查询数据总数
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
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
            return dal.GetCount(strWhere, classId, kindId);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Spread.Model.Means model)
		{
			dal.Add(model);
		}

        /// <summary>
        /// 修改一条数据
        /// </summary>
        public void UpdateField(int Id, string strValue)
        {
            dal.UpdateField(Id, strValue);
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Spread.Model.Means model)
		{
			dal.Update(model);
		}

        /// <summary>
		/// 更新内容
		/// </summary>
        public void UpdateContent(Spread.Model.Means model)
        {
            this.dal.UpdateContent(model);
        }

        /// <summary>
        /// 更新点击数
        /// </summary>
        public void UpdateClick(int Id)
        {
            this.dal.UpdateClick(Id);
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
		public Spread.Model.Means GetModel(int Id)
		{			
			return dal.GetModel(Id);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Spread.Model.Means GetUpDownModel(int Id, bool UpOrDown)
        {
            return dal.GetUpDownModel(Id, UpOrDown);
        }
         /// <summary>
        /// 获得条件下的所有数据
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
		{
			return dal.GetList(Top, strWhere, filedOrder);
		}

		/// <summary>
		/// 获得指定类别下的前几行数据
		/// </summary>
        public DataSet GetList(int classId, int kindId, int Top, string strWhere, string filedOrder)
		{
			return dal.GetList(classId, kindId, Top, strWhere, filedOrder);
		}

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetPageList(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            return dal.GetPageList(pageSize, currentPage, strWhere, filedOrder);
        }

		#endregion  成员方法
    }
}

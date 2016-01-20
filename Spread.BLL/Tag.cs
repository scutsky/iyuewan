using System;
using System.Collections.Generic;

using System.Text;

using Spread.DAL;
using System.Data;
namespace Spread.BLL
{
    public class Tag
    {
        private readonly Spread.DAL.Tag dal = new Spread.DAL.Tag();

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Spread.Model.Tag model)
        {
            this.dal.Add(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Id)
        {
            this.dal.Delete(Id);            
        }

        /// <summary>
        /// 返回长查询数据总数 （分页用到）
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

         /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetPageList(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            return dal.GetPageList(pageSize, currentPage, strWhere, filedOrder);
        }
    }
}

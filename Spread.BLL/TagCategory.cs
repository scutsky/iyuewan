using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
namespace Spread.BLL
{
    public class TagCategory
    {
        private readonly Spread.DAL.TagCategory dal = new Spread.DAL.TagCategory();

        public void Add(Spread.Model.TagCategory model)
        {
            this.dal.Add(model);
        }

        public void Delete(int ID)
        {
            this.dal.Delete(ID);
        }

        public void Update(Spread.Model.TagCategory model)
        {
            this.dal.Update(model);
        }

        /// <summary>
        /// 返回长查询数据总数 （分页用到）
        /// </summary>
        public int GetCount(string strWhere)
        {
            return this.dal.GetCount(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public Spread.Model.TagCategory GetModel(int ID)
        {
            return this.dal.GetModel(ID);
        }
    }
}

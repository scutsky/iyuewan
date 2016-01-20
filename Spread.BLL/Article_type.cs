using System;
using System.Data;
using System.Collections.Generic;
using Spread.Model;

namespace Spread.BLL
{
    public class Article_type
    {
        private readonly Spread.DAL.Article_type dal = new Spread.DAL.Article_type();
        public Article_type() { }
        #region  成员方法
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return dal.GetMaxID(FieldName);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            return dal.Exists(Id);
        }

        /// <summary>
        /// 返回栏目名称
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public string GetChannelTitle(int classId)
        {
            return dal.GetChannelTitle(classId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Spread.Model.Article_type model)
        {
            dal.Add(model);
            return dal.GetMaxID("Id");
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Spread.Model.Article_type model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 修改一条数据
        /// </summary>
        public void UpdateField(int Id, string strValue)
        {
            dal.UpdateField(Id, strValue);
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
        public Spread.Model.Article_type GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(int PId, int KId)
        {
            return dal.GetList(PId, KId);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(int PId)
        {
            return dal.GetList(PId);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string fildes, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, fildes, strWhere, filedOrder);
        }
        /// <summary>
        /// 取得该栏目下的所有子栏目
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public DataSet GetChannelListByClassId(int classId)
        {
            return dal.GetChannelListByClassId(classId);
        }

        /// <summary>
        /// 获取新闻分类列表
        /// </summary>
        /// <returns></returns>
        public DataSet Getlist()
        {
            return dal.Getlist();
        }
        /// <summary>
        /// 删除新闻分类列表
        /// </summary>
        /// <param name="Id"></param>
        public void dalete(int Id)
        {
            dal.Delete(Id);
        }

        #endregion  成员方法
    }
}

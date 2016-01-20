using System;
using System.Data;
using System.Collections.Generic;
using Spread.Model;
namespace Spread.BLL
{
    /// <summary>
    /// 业务逻辑类Menu 的摘要说明。
    /// </summary>
    public class Menu
    {
        private readonly Spread.DAL.Menu dal = new Spread.DAL.Menu();
        public Menu()
        { }
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
        public string GetMenuTitle(int classId)
        {
            return dal.GetMenuTitle(classId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Spread.Model.Menu model)
        {
            dal.Add(model);
            return dal.GetMaxID("Id");
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Spread.Model.Menu model)
        {
            dal.Update(model);
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
        public Spread.Model.Menu GetModel(int Id)
        {

            return dal.GetModel(Id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Spread.Model.Menu GetModelByName(string name)
        {

            return dal.GetModelByName(name);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(int PId)
        {
            return dal.GetList(PId);
        }
        /// <summary>
        /// 修改一条数据
        /// </summary>
        public void UpdateField(int Id, string strValue)
        {
            dal.UpdateField(Id, strValue);
        }
        /// <summary>
        /// 取得该栏目下的所有子栏目
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public DataSet GetMenuListByClassId(int classId)
        {
            return dal.GetMenuListByClassId(classId);
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string fildes, string strWhere)
        {
            return dal.GetList(fildes,strWhere);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string fildes, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, fildes, strWhere, filedOrder);
        }

        /// <summary>
        /// 取得最大排序记录
        /// </summary>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        public int GetMaxSortID(int ParentID)
        {
            return dal.GetMaxSortID(ParentID);
        }
        #endregion  成员方法
    }
}


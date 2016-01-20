using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Spread.BLL
{
    public class ExtendGame
    {
        private readonly DAL.ExtendGame dal = new DAL.ExtendGame();
        public ExtendGame()
        { }
        #region  BasicMethod
        /// <summary>
        /// 检查提交的游戏是不是已经提交过
        /// </summary>
        public bool Exists(int userID, int ChanelID, string gameName)
        {
            return dal.Exists(userID, ChanelID, gameName);
        }

        /// <summary>
        /// 检查打包时平台&渠道&游戏是否重复
        /// </summary>
        public bool checkrepeat(string Bak2, string Bak3, string Bak4)
        {
            return dal.checkrepeat(Bak2, Bak3, Bak4);
        }
        /// <summary>
        /// 检查打包时网址是否重复
        /// </summary>
        public bool checkURL(string Bak1)
        {
            return dal.checkURL(Bak1);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.ExtendGame model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.ExtendGame model)
        {
            return dal.Update(model);
        }
        public bool UpdateStatus(Model.ExtendGame model)
        {
            return dal.UpdateStatus(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string strWhere)
        {

            return dal.Delete(strWhere);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.ExtendGame GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

       

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        public DataSet GetListByUserId(string strWhere)
        {
            return dal.GetListByUserId(strWhere);
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
        public List<Model.ExtendGame> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.ExtendGame> DataTableToList(DataTable dt)
        {
            List<Model.ExtendGame> modelList = new List<Model.ExtendGame>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.ExtendGame model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
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
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Model.ExtendGame> GetTopList(int Top, string strWhere, string filedOrder)
        {
            DataSet ds = dal.GetList(Top, strWhere, filedOrder);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}
        public DataSet GetPageList(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            return dal.GetPageList(pageSize, currentPage, strWhere, filedOrder);
        }
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }
        /// <summary>
        /// 添加Verifycode
        /// </summary>
        public bool SetVerifycode(Model.ExtendGame model)
        {
            return dal.SetVerifycode(model);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod

        public bool GetCount()
        {
            throw new NotImplementedException();
        }
    }
}


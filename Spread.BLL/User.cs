using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Spread.Common;

namespace Spread.BLL
{
    /// <summary>
    /// User
    /// </summary>
    public partial class User
    {
        private readonly Spread.DAL.User dal = new Spread.DAL.User();
        public User()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }
        public bool chkExists(string UserName)
        {
            return dal.chkExists(UserName);
        }
        /// <summary>
        /// 检查登录是否成功
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPwd"></param>
        /// <returns></returns>
        public bool chkUserLogin(string userName, string userPwd)
        {
            return dal.chkUserLoign(userName, DESEncrypt.Encrypt(userPwd, Param.EncCode));
        }

        public bool UpdatePassword(string userName, string Password)
        {
            return dal.UpdatePassword(userName, DESEncrypt.Encrypt(Password, Param.EncCode));
        }
        public bool UpdateQQ(string userName, string qq)
        {
            return dal.UpdateQQ(userName, qq);
        }
        public bool UpdatePhone(string userName, string phone)
        {
            return dal.UpdatePhone(userName, phone);
        }
        public bool UpdateEmail(string Name, string Email)
        {
            return dal.UpdateEmail(Name, Email);
        }
        public bool UpdatePayinfo(string Name, string PayCode, string TureName)
        {
            return dal.UpdatePayinfo(Name, PayCode, TureName);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Spread.Model.User model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Spread.Model.User model)
        {
            return dal.Update(model);
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
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Spread.Model.User GetModel(int ID)
        {
            //Model.User model = new Model.User();
            //model = dal.GetModel(ID);
            //model.Password = DESEncrypt.Decrypt(model.Password);
            return dal.GetModel(ID);
        }
        public Spread.Model.User GetModelByName(string name)
        {
            return dal.GetModelByName(name);
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
        public List<Spread.Model.User> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Spread.Model.User> DataTableToList(DataTable dt)
        {
            List<Spread.Model.User> modelList = new List<Spread.Model.User>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Spread.Model.User model;
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
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetPageList(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            return dal.GetPageList(pageSize, currentPage, strWhere, filedOrder);
        }
        public void UpdateField(int Id, string strValue)
        {
            dal.UpdateField(Id, strValue);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod

        public Model.User GetModel(int? nullable)
        {
            throw new NotImplementedException();
        }
    }
}


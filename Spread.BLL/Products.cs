using System;
using System.Data;
using System.Collections.Generic;
using Spread.Model;
namespace Spread.BLL
{
	/// <summary>
	/// ҵ���߼���Products ��ժҪ˵����
	/// </summary>
	public class Products
	{
		private readonly Spread.DAL.Products dal=new Spread.DAL.Products();
        Spread.BLL.Log logbll = new Spread.BLL.Log();
		public Products()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int Id)
		{
			return dal.Exists(Id);
		}

        /// <summary>
        /// ���ز�ѯ������������ҳ�õ���
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

        /// <summary>
        /// �޸�һ������
        /// </summary>
        public void UpdateField(int Id, string strField)
        {
            dal.UpdateField(Id, strField);
        }

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(Spread.Model.Products model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Spread.Model.Products model)
		{
			dal.Update(model);
		}

        /// <summary>
        /// ������Ʒ���
        /// </summary>
        public void UpdateBrand(Spread.Model.Products model)
        {
            this.dal.UpdateBrand(model);
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
		public Spread.Model.Products GetModel(int Id)
		{
			
			return dal.GetModel(Id);
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
        /// ��ò�ѯ��ҳ����
        /// </summary>
        public DataSet GetPageList(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            return dal.GetPageList(pageSize, currentPage, strWhere, filedOrder);
        }

        /// <summary>
        /// ���������ӵ�ID
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public int GetLastProID(string ID, string TableName)
        {
            return this.dal.GetLastProID(ID, TableName);
        }

         /// <summary>
        /// ��ò�Ʒ������ı��
        /// </summary>
        /// <param name="TypeID"></param>
        /// <returns></returns>
        public string GetClassID(int TypeID)
        {
            return this.dal.GetClassID(TypeID);
        }

        /// <summary>
        /// ȡ����������¼
        /// </summary>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        public int GetMaxSortID(int ClassId)
        {
            return this.dal.GetMaxSortID(ClassId);
        }
		#endregion  ��Ա����
	}
}


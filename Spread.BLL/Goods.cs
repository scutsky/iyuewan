using System;
using System.Data;
using System.Collections.Generic;
using Spread.Model;
namespace Spread.BLL
{
	/// <summary>
	/// ҵ���߼���Goods ��ժҪ˵����
	/// </summary>
	public class Goods
	{
		private readonly Spread.DAL.Goods dal=new Spread.DAL.Goods();
		public Goods()
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
        /// ���س���ѯ��������
        /// </summary>
        /// <param name="strWhere">����</param>
        /// <returns></returns>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

        /// <summary>
        /// ���ظ�����µ����м�¼����
        /// </summary>
        /// <param name="strWhere">����</param>
        /// <param name="classId">���</param>
        /// <param name="kindId">����</param>
        /// <returns></returns>
        public int GetCount(string strWhere, int classId, int kindId)
        {
            return dal.GetCount(strWhere, classId, kindId);
        }

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(Spread.Model.Goods model)
		{
			dal.Add(model);
		}

        /// <summary>
        /// �޸�һ������
        /// </summary>
        public void UpdateField(int Id, string strValue)
        {
            dal.UpdateField(Id, strValue);
        }

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Spread.Model.Goods model)
		{
			dal.Update(model);
		}

        /// <summary>
		/// ��������
		/// </summary>
        public void UpdateContent(Spread.Model.Goods model)
        {
            this.dal.UpdateContent(model);
        }

        /// <summary>
        /// ���µ����
        /// </summary>
        public void UpdateClick(int Id)
        {
            this.dal.UpdateClick(Id);
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
		public Spread.Model.Goods GetModel(int Id)
		{			
			return dal.GetModel(Id);
		}

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Spread.Model.Goods GetUpDownModel(int Id, bool UpOrDown)
        {
            return dal.GetUpDownModel(Id, UpOrDown);
        }
         /// <summary>
        /// ��������µ���������
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

		/// <summary>
		/// ��������б�
		/// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
		{
			return dal.GetList(Top, strWhere, filedOrder);
		}

		/// <summary>
		/// ���ָ������µ�ǰ��������
		/// </summary>
        public DataSet GetList(int classId, int kindId, int Top, string strWhere, string filedOrder)
		{
			return dal.GetList(classId, kindId, Top, strWhere, filedOrder);
		}

        /// <summary>
        /// ��ò�ѯ��ҳ����
        /// </summary>
        public DataSet GetPageList(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            return dal.GetPageList(pageSize, currentPage, strWhere, filedOrder);
        }

		#endregion  ��Ա����
	}
}


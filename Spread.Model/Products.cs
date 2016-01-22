using System;
namespace Spread.Model
{
	/// <summary>
	/// ��Ʒʵ����Products
	/// </summary>
	[Serializable]
	public class Products
	{
		public Products()
		{}
		#region Model
		private int _id;
        private string _brand;
        private string _title;
		private int _classid;
        private int _sort;
        private DateTime _addtime;
        private string _url;
        private string _imgUrl;
        private string _addUser;       
        private string _keyword;
        private bool _istop = false;
        private bool _islock = false;
		/// <summary>
		/// ����ID
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// Ʒ������
		/// </summary>
        public string Brand
		{
            set { _brand = value; }
            get { return _brand; }
		}
        /// <summary>
        /// Ʒ������
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
		/// <summary>
		/// ��������
		/// </summary>
		public int ClassId
		{
			set{ _classid=value;}
			get{return _classid;}
		}
        /// <summary>
        /// ����
        /// </summary>
        public int Sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
        /// <summary>
        /// ���ӵ�ַ
        /// </summary>
        public string Url
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// ͼƬ���ӵ�ַ
        /// </summary>
        public string ImgUrl
        {
            set { _imgUrl = value; }
            get { return _imgUrl; }
        }
        /// <summary>
        /// ����û�
        /// </summary>
        public string AddUser
        {
            set { _addUser = value; }
            get { return _addUser; }
        }
        /// <summary>
        /// �ؽ���
        /// </summary>
        public string Keyword
        {
            set { _keyword = value; }
            get { return _keyword; }
        }
        /// <summary>
        /// �Ƿ��ö�
        /// </summary>
        public bool IsTop
        {
            set { _istop = value; }
            get { return _istop; }
        }
        /// <summary>
        /// �Ƿ���ʾ
        /// </summary>
        public bool IsLock
        {
            set { _islock = value; }
            get { return _islock; }
        }
		#endregion Model

	}
}


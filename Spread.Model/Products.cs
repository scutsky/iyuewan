using System;
namespace Spread.Model
{
	/// <summary>
	/// 产品实体类Products
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
		/// 自增ID
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 品牌名称
		/// </summary>
        public string Brand
		{
            set { _brand = value; }
            get { return _brand; }
		}
        /// <summary>
        /// 品牌名称
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
		/// <summary>
		/// 所属分类
		/// </summary>
		public int ClassId
		{
			set{ _classid=value;}
			get{return _classid;}
		}
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
		/// <summary>
		/// 发布时间
		/// </summary>
		public DateTime AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
        /// <summary>
        /// 连接地址
        /// </summary>
        public string Url
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// 图片连接地址
        /// </summary>
        public string ImgUrl
        {
            set { _imgUrl = value; }
            get { return _imgUrl; }
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        public string AddUser
        {
            set { _addUser = value; }
            get { return _addUser; }
        }
        /// <summary>
        /// 关健字
        /// </summary>
        public string Keyword
        {
            set { _keyword = value; }
            get { return _keyword; }
        }
        /// <summary>
        /// 是否置顶
        /// </summary>
        public bool IsTop
        {
            set { _istop = value; }
            get { return _istop; }
        }
        /// <summary>
        /// 是否不显示
        /// </summary>
        public bool IsLock
        {
            set { _islock = value; }
            get { return _islock; }
        }
		#endregion Model

	}
}


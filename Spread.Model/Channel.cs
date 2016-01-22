using System;
namespace Spread.Model
{
	/// <summary>
	/// 实体类Channel 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Channel
	{
		public Channel()
		{}
		#region Model
		private int _id;
        private string _catalogid;
        private string _title = "";
		private int? _parentid=0;
        private string _classlist = "";
		private int? _classlayer=0;
		private int? _userID=0;
		private bool _isshow=false;
		private bool _islock=false;
		private bool _ismenu=false;
		private string _name="";
		private string _url="";
        private string _bak1 = "";
        private string _bak2 = "";
        private string _bak3 = "";
        private string _bak4 = "";
        private int _status = 1;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
        public string CatalogID
		{
			set{ _catalogid=value;}
			get{return _catalogid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ParentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ClassList
		{
			set{ _classlist=value;}
			get{return _classlist;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ClassLayer
		{
			set{ _classlayer=value;}
			get{return _classlayer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UserID
		{
			set{ _userID=value;}
			get{return _userID;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsShow
		{
			set{ _isshow=value;}
			get{return _isshow;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsLock
		{
			set{ _islock=value;}
			get{return _islock;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsMenu
		{
			set{ _ismenu=value;}
			get{return _ismenu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Url
		{
			set{ _url=value;}
			get{return _url;}
		}
        /// <summary>
        /// 
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Bak1
        {
            set { _bak1 = value; }
            get { return _bak1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Bak2
        {
            set { _bak2 = value; }
            get { return _bak2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Bak3
        {
            set { _bak3 = value; }
            get { return _bak3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Bak4
        {
            set { _bak4 = value; }
            get { return _bak4; }
        }
		#endregion Model

	}
}


using System;
namespace Spread.Model
{
	/// <summary>
	/// ʵ����Goods ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Goods
	{
        public Goods()
		{}
		#region Model
		private int _id;
        private string _title;
		private string _form;
		private int _classid;
		private string _imgurl;
        private bool _ismsg=false;
        private bool _istop = false;
        private bool _isred = false;
        private bool _ishot = false;
        private bool _isslide = false;
        private bool _islock = false;
        private DateTime _addtime = DateTime.Now;
        private string _Zhaiyao;
        private string _gtype;
        private string _gfactory;
        private string _gbrand;
        private string _code1;
        private string _code2;
        private string _bak1;
        private string _bak2;
        private string _bak3;
        private string _bak4;
        private string _bak5;
		/// <summary>
		/// ����ID
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ���±���
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
	
		/// <summary>
		/// ��Դ
		/// </summary>
		public string Form
		{
			set{ _form=value;}
			get{return _form;}
		}
	
		/// <summary>
		/// �������
		/// </summary>
		public int ClassId
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		/// <summary>
		/// ����ͼƬ
		/// </summary>
		public string ImgUrl
		{
			set{ _imgurl=value;}
			get{return _imgurl;}
		}
		

		/// <summary>
		/// �Ƿ���������
		/// </summary>
        public bool IsMsg
		{
			set{ _ismsg=value;}
			get{return _ismsg;}
		}
		/// <summary>
		/// �Ƿ��ö�
		/// </summary>
        public bool IsTop
		{
			set{ _istop=value;}
			get{return _istop;}
		}
		/// <summary>
		/// �Ƿ��Ƽ�
		/// </summary>
        public bool IsRed
		{
			set{ _isred=value;}
			get{return _isred;}
		}
		/// <summary>
		/// �Ƿ�����
		/// </summary>
        public bool IsHot
		{
			set{ _ishot=value;}
			get{return _ishot;}
		}
		/// <summary>
		/// �Ƿ�õ�Ƭ
		/// </summary>
        public bool IsSlide
		{
			set{ _isslide=value;}
			get{return _isslide;}
		}
		/// <summary>
		/// �Ƿ���ʾ
		/// </summary>
        public bool IsLock
		{
			set{ _islock=value;}
			get{return _islock;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
        public string Zhaiyao
        {
            set { _Zhaiyao = value; }
            get { return _Zhaiyao; }
        }
        public string GType
        {
            set { _gtype = value; }
            get { return _gtype; }
        }
        public string GFactory
        {
            set { _gfactory = value; }
            get { return _gfactory; }
        }
       
        public string GBrand
        {
            set { _gbrand = value; }
            get { return _gbrand; }
        }
        public string Code1
        {
            set { _code1 = value; }
            get { return _code1; }
        }
        public string Code2
        {
            set { _code2 = value; }
            get { return _code2; }
        }
        public string Bak1
        {
            set { _bak1 = value; }
            get { return _bak1; }
        }
        public string Bak2
        {
            set { _bak2 = value; }
            get { return _bak2; }
        }
        public string Bak3
        {
            set { _bak3 = value; }
            get { return _bak3; }
        }
        public string Bak4
        {
            set { _bak4 = value; }
            get { return _bak4; }
        }
        public string Bak5
        {
            set { _bak5 = value; }
            get { return _bak5; }
        }
		#endregion Model

	}
}


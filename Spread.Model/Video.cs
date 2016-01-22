using System;

namespace Spread.Model
{
    public class Video
    {
        public Video()
		{}
        #region Model
        private int _id;
        private string _title;
        private string _form;
        private int _classid;
        private string _imgurl;
        private bool _ismsg = false;
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
        private string _languagetype;
        /// <summary>
        /// 自增ID
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 文章标题
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }

        /// <summary>
        /// 来源
        /// </summary>
        public string Form
        {
            set { _form = value; }
            get { return _form; }
        }

        /// <summary>
        /// 所属类别
        /// </summary>
        public int ClassId
        {
            set { _classid = value; }
            get { return _classid; }
        }
        /// <summary>
        /// 文章图片
        /// </summary>
        public string ImgUrl
        {
            set { _imgurl = value; }
            get { return _imgurl; }
        }


        /// <summary>
        /// 是否允许评论
        /// </summary>
        public bool IsMsg
        {
            set { _ismsg = value; }
            get { return _ismsg; }
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
        /// 是否推荐
        /// </summary>
        public bool IsRed
        {
            set { _isred = value; }
            get { return _isred; }
        }
        /// <summary>
        /// 是否热门
        /// </summary>
        public bool IsHot
        {
            set { _ishot = value; }
            get { return _ishot; }
        }
        /// <summary>
        /// 是否幻灯片
        /// </summary>
        public bool IsSlide
        {
            set { _isslide = value; }
            get { return _isslide; }
        }
        /// <summary>
        /// 是否不显示
        /// </summary>
        public bool IsLock
        {
            set { _islock = value; }
            get { return _islock; }
        }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
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
        public string LanguageType
        {
            set { _languagetype = value; }
            get { return _languagetype; }
        }
        #endregion Model
    }
}

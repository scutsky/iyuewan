using System;
using System.Collections.Generic;
using System.Text;

namespace Spread.Model
{
    /// <summary>
    /// 实体类MenuDirectory 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class MenuDirectory
    {
        public MenuDirectory()
        { }
        #region Model
        private int _id;
        private long _Menuid;
        private string _title;
        private int _parentid;
        private string _classlist;
        private int _classlayer;
        private int _classorder;
        private bool _isshow;
        private bool _islock;
        private bool _ismenu;
        private string _imgurl;
        private string _languageType;
        /// <summary>
        /// 自增ID
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 映射分类编号
        /// </summary>
        public long MenuID
        {
            set { _Menuid = value; }
            get { return _Menuid; }
        }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 父类ID
        /// </summary>
        public int ParentId
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 类别ID列表
        /// </summary>
        public string ClassList
        {
            set { _classlist = value; }
            get { return _classlist; }
        }
        /// <summary>
        /// 类别深度
        /// </summary>
        public int ClassLayer
        {
            set { _classlayer = value; }
            get { return _classlayer; }
        }
        /// <summary>
        /// 类别排序
        /// </summary>
        public int ClassOrder
        {
            set { _classorder = value; }
            get { return _classorder; }
        }
        /// <summary>
        /// 前台是否展示
        /// </summary>
        public bool IsShow
        {
            set { _isshow = value; }
            get { return _isshow; }
        }
        /// <summary>
        /// 是否锁定
        /// </summary>
        public bool IsLock
        {
            set { _islock = value; }
            get { return _islock; }
        }
        /// <summary>
        /// 是否为菜单
        /// </summary>
        public bool IsMenu
        {
            set { _ismenu = value; }
            get { return _ismenu; }
        }

        /// <summary>
        /// 图片目录
        /// </summary>
        public string ImgUrl
        {
            set { _imgurl = value; }
            get { return _imgurl; }
        }

        /// <summary>
        /// 语言类型
        /// </summary>
        public string LanguageType
        {
            set { _languageType = value; }
            get { return _languageType; }
        }
        #endregion Model
    }
}

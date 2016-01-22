using System;
using System.Collections.Generic;
using System.Text;

namespace Spread.Model
{
    public class Article_type
    {
        public Article_type() { }
        #region Model
        private int _id;
        private string _title;
        private int _parentid;
        private string _classlist;
        private int _classlayer;
        private int _classorder;
        private string _pageurl;
        private int _kindid;
        private string _keyword;
     

        /// <summary>
        /// 自增ID
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
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
        /// 页面导航
        /// </summary>
        public string PageUrl
        {
            set { _pageurl = value; }
            get { return _pageurl; }
        }
        /// <summary>
        /// 类别种类
        /// </summary>
        public int KindId
        {
            set { _kindid = value; }
            get { return _kindid; }
        }

        /// <summary>
        /// 关健字
        /// </summary>
        public string Keyword
        {
            set { _keyword = value; }
            get { return _keyword; }
        }
    
       
        #endregion Model
    }
}

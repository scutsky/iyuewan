using System;
using System.Web;
using System.Collections.Generic;
using System.Text;


namespace Spread.Common
{
    public class PageParam
    {
        private int _totalCount = -1;
        private int _pageSize = 20;
        private int _page = 1;

        /// <summary>
        /// HttpRequest对象
        /// </summary>
        protected HttpRequest _request;

        public PageParam(System.Web.UI.Page webPage)
        {
            this._request = webPage.Request;
            DecodeDefaultParameter();
        }

        /// <summary>
        /// 解析基本查询参数
        /// </summary>
        public void DecodeDefaultParameter()
        {
            try
            {
                this._page = int.Parse(this._request["page"]);
            }
            catch { }

            try
            {
                this._pageSize = int.Parse(this._request["pagesize"]);
            }
            catch { }
        }

        #region 基本属性
        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalCount
        {
            get { return _totalCount; }
            set
            {
                _totalCount = value;
            }
        }

        

        /// <summary>
        /// 当前页码，从1开始编码
        /// </summary>
        public int Page
        {
            get { return _page; }
            set
            {
                _page = value;
            }
        }

        /// <summary>
        /// 每一页的记录数
        /// </summary>
        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = value;
            }
        }

        /// <summary>
        /// 获取总页数
        /// </summary>
        public int TotalPages
        {
            get
            {
                return ((this.TotalCount - 1) / this.PageSize + 1);
            }
        }
        #endregion
    }
}
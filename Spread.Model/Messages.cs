using System;
using System.Collections.Generic;
using System.Text;

namespace Spread.Model
{
    /// <summary>
    /// 实体类Messages 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Messages
    {
        public Messages()
		{}
        #region Model
        private int _id;
        private string _subject;
        private string _fullname;
        private string _mail;
        private string _address;
        private string _zipcode;
        private string _province;
        private string _city;
        private string _phone;
        private string _fax;
        private string _question;
        private DateTime _addtime = DateTime.Now;
        private string _type;
        /// <summary>
        /// 自增ID
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 留言主题
        /// </summary>
        public string Subject
        {
            set { _subject = value; }
            get { return _subject; }
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string FullName
        {
            set { _fullname = value; }
            get { return _fullname; }
        }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Mail
        {
            set { _mail = value; }
            get { return _mail; }
        }
        
        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }


        /// <summary>
        /// 邮编
        /// </summary>
        public string ZipCode
        {
            set { _zipcode = value; }
            get { return _zipcode; }
        }
        
        /// <summary>
        /// 省份
        /// </summary>
        public string Province
        {
            set { _province = value; }
            get { return _province; }
        }
        
        /// <summary>
        /// 城市
        /// </summary>
        public string City
        {
            set { _city = value; }
            get { return _city; }
        }
        
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        
        /// <summary>
        /// 传真
        /// </summary>
        public string Fax
        {
            set { _fax = value; }
            get { return _fax; }
        }
       
       
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        public string Type
        {
            set { _type = value; }
            get { return _type; }
        }
        public string Question
        {
            set { _question = value; }
            get { return _question; }
        }
        
        #endregion Model
    }


}

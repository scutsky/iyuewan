using System;
using System.Collections.Generic;
using System.Text;

namespace Spread.Model
{
    public class Log
    {
        public Log()
        { }
        #region Model
        private int _id = 0;
        private string _description="";
        private int? _userid=0;
        private string _username="";
        private DateTime? _logtime;
        private string _ipaddress="";
        private string _logtype = "";
        private string _isread = "";
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? UserId
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LogTime
        {
            set { _logtime = value; }
            get { return _logtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IpAddress
        {
            set { _ipaddress = value; }
            get { return _ipaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LogType
        {
            set { _logtype = value; }
            get { return _logtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IsRead
        {
            set { _isread = value; }
            get { return _isread; }
        }
        #endregion Model

    }
}


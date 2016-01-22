using System;
using System.Collections.Generic;
using System.Text;

namespace Spread.Model
{
    public class Pgame
    {
        public Pgame()
        { }
        #region Model
        private int _id;
        private string _name = "";
        private string _version = "";
        private string _platform = "";
        private string _status = "";
        private string _updatetype = "";
        private DateTime? _updatedate;
        private DateTime? _ontime;
        private string _firstletter = "";
        private bool _islock = false;
        private string _bak1 = "";
        private string _bak2 = "";
        private string _bak3 = "";
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
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string version
        {
            set { _version = value; }
            get { return _version; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Platform
        {
            set { _platform = value; }
            get { return _platform; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UpdateType
        {
            set { _updatetype = value; }
            get { return _updatetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdateDate
        {
            set { _updatedate = value; }
            get { return _updatedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? OnTime
        {
            set { _ontime = value; }
            get { return _ontime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FirstLetter
        {
            set { _firstletter = value; }
            get { return _firstletter; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsLock
        {
            set { _islock = value; }
            get { return _islock; }
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
        #endregion Model
    }
}

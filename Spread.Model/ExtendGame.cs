using System;
using System.Collections.Generic;
using System.Text;

namespace Spread.Model
{
    public  class ExtendGame
    {
        public ExtendGame()
        { }
        #region Model
        private int _id;
        private int? _gameid;
        private string _gamename = "";
        private int? _chanelid;
        private string _chanelname = "";
        private int? _userid;
        private string _version="";
        private string _status = "";
        private string _updatetype = "";
        private DateTime? _updatedate;
        private DateTime? _ontime;
        private string _bak1 = "";
        private string _bak2 = "";
        private string _bak3 = "";
        private string _bak4 = "";
        private string _bak5 = "";
        private string _verifycode = "";
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
        public int? gameID
        {
            set { _gameid = value; }
            get { return _gameid; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string gameName
        {
            set { _gamename = value; }
            get { return _gamename; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int? ChanelID
        {
            set { _chanelid = value; }
            get { return _chanelid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ChanelName
        {
            set { _chanelname = value; }
            get { return _chanelname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? UserID
        {
            set { _userid = value; }
            get { return _userid; }
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
        /// <summary>
        /// 
        /// </summary>
        public string Bak5
        {
            set { _bak5 = value; }
            get { return _bak5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Verifycode
        {
            set { _verifycode = value; }
            get { return _verifycode; }
        }
        #endregion Model

    }
}


using System;
using System.Collections.Generic;
using System.Text;

namespace Spread.Model
{
    /// <summary>
    /// Report:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Report
    {
        public Report()
        { }
        #region Model
        private int _id;
        private string _sumdate;
        private int? _channelid;
        private string _channelname;
        private int? _gameid;
        private string _gamename;
        private decimal? _registervalue;
        private decimal? _consumptionvalue;
        private decimal? _income;
        private DateTime? _adddate;
        private int? _userid;
        private string _username;
        private string _bak1;
        private string _bak2;
        private string _bak3;
        private string _bak4;
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
        public string SumDate
        {
            set { _sumdate = value; }
            get { return _sumdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ChannelID
        {
            set { _channelid = value; }
            get { return _channelid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ChannelName
        {
            set { _channelname = value; }
            get { return _channelname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? GameID
        {
            set { _gameid = value; }
            get { return _gameid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GameName
        {
            set { _gamename = value; }
            get { return _gamename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? RegisterValue
        {
            set { _registervalue = value; }
            get { return _registervalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ConsumptionValue
        {
            set { _consumptionvalue = value; }
            get { return _consumptionvalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Income
        {
            set { _income = value; }
            get { return _income; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? AddDate
        {
            set { _adddate = value; }
            get { return _adddate; }
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
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
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


using System;
using System.Collections.Generic;
using System.Text;

namespace Spread.Model
{
    public class ReportAccounts
    {
        public ReportAccounts()
        { }
        #region Model
        private int _id;
        private DateTime? _applytime;
        private string _settlementcycle = "";
        private decimal? _recharge=0;
        private decimal? _income = 0;
        private decimal? _settlement = 0;
        private string _status = "";
        private decimal? _actualplay = 0;
        private int? _userid = 0;
        private string _username="";
        private string _bak1="";
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
        public DateTime? ApplyTime
        {
            set { _applytime = value; }
            get { return _applytime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SettlementCycle
        {
            set { _settlementcycle = value; }
            get { return _settlementcycle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Recharge
        {
            set { _recharge = value; }
            get { return _recharge; }
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
        public decimal? Settlement
        {
            set { _settlement = value; }
            get { return _settlement; }
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
        public decimal? ActualPlay
        {
            set { _actualplay = value; }
            get { return _actualplay; }
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
        #endregion Model
    }
}


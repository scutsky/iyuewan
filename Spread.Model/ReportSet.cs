using System;
using System.Collections.Generic;
using System.Text;

namespace Spread.Model
{
    public class ReportSet
    {
        public ReportSet()
        { }
        #region Model
        private int _id;
        private string _sumdate;
        private string _channelname;
        private string _gamename;
        private string _registervalue;
        private string _consumptionvalue;
        private string _income;
        private string _bak1;
        private string _bak2;
        private string _bak3;
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
        public string ChannelName
        {
            set { _channelname = value; }
            get { return _channelname; }
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
        public string RegisterValue
        {
            set { _registervalue = value; }
            get { return _registervalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ConsumptionValue
        {
            set { _consumptionvalue = value; }
            get { return _consumptionvalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Income
        {
            set { _income = value; }
            get { return _income; }
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


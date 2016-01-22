using System;
using System.Collections.Generic;
using System.Text;

namespace Spread.Model
{
    public class CardGame
    {
        #region Model
        private int _id;
        private int? _gameid;
        private string _cardname = "";
        private string _cardtype = "";
        private string _status = "";
        private DateTime? _updatedate;
        private int? _chanelid;
        private string _chanelname = "";
        private int? _userid;
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
        public int? GameID
        {
            set { _gameid = value; }
            get { return _gameid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CardName
        {
            set { _cardname = value; }
            get { return _cardname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CardType
        {
            set { _cardtype = value; }
            get { return _cardtype; }
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
        public DateTime? UpdateDate
        {
            set { _updatedate = value; }
            get { return _updatedate; }
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



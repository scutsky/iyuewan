using System;
using System.Collections.Generic;
using System.Text;

namespace Spread.Model
{
    public class User
    {
        public User()
        { }
        #region Model
        private int _id;
        private string _name = "";
        private string _password="";
        private DateTime? _regdate;
        private string _email = "";
        private bool _sex;
        private string _identitycard = "";
        private string _truename = "";
        private bool _islock;
        private string _tel = "";
        private string _phone = "";
        private string _qq = "";
        private int? _usertype = 1;
        private DateTime? _lastlogin;
        private string _companyname = "";
        private string _companyaddress = "";
        private string _registrationmark = "";
        private string _corporatename = "";
        private string _applicationdesc = "";
        private string _paypalaccount = "";
        private string _salesman = "";
        private string _salesphone = "";
        private string _salesqq = "";
        private string _bak1 = "";
        private string _bak2 = "";
        private string _bak3 = "";
        private string _bak4 = "";
        private string _bak5 = "";
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
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? RegDate
        {
            set { _regdate = value; }
            get { return _regdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IdentityCard
        {
            set { _identitycard = value; }
            get { return _identitycard; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TrueName
        {
            set { _truename = value; }
            get { return _truename; }
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
        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QQ
        {
            set { _qq = value; }
            get { return _qq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? UserType
        {
            set { _usertype = value; }
            get { return _usertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LastLogin
        {
            set { _lastlogin = value; }
            get { return _lastlogin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CompanyName
        {
            set { _companyname = value; }
            get { return _companyname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CompanyAddress
        {
            set { _companyaddress = value; }
            get { return _companyaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RegistrationMark
        {
            set { _registrationmark = value; }
            get { return _registrationmark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CorporateName
        {
            set { _corporatename = value; }
            get { return _corporatename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Applicationdesc
        {
            set { _applicationdesc = value; }
            get { return _applicationdesc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PaypalAccount
        {
            set { _paypalaccount = value; }
            get { return _paypalaccount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Salesman
        {
            set { _salesman = value; }
            get { return _salesman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SalesPhone
        {
            set { _salesphone = value; }
            get { return _salesphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SalesQQ
        {
            set { _salesqq = value; }
            get { return _salesqq; }
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
        #endregion Model

    }
}

using System;
using System.Collections.Generic;

using System.Text;

namespace Spread.Model
{
    public class Tag
    {
        private int _daysearchcount;
        private int _modeltype;
        private string _name;
        private int _tagcategoryid;
        private long _Id;
        private int _totalsearchcount;
        private int _userid;
        private string _username;
        private int _yesterdaysearchcount;
        private DateTime _countTime;

        public int DaySearchCount
        {
            get
            {
                return this._daysearchcount;
            }
            set
            {
                this._daysearchcount = value;
            }
        }

        public int ModelType
        {
            get
            {
                return this._modeltype;
            }
            set
            {
                this._modeltype = value;
            }
        }

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        public int TagCategoryId
        {
            get
            {
                return this._tagcategoryid;
            }
            set
            {
                this._tagcategoryid = value;
            }
        }

        public long ID
        {
            get
            {
                return this._Id;
            }
            set
            {
                this._Id = value;
            }
        }

        public int TotalSearchCount
        {
            get
            {
                return this._totalsearchcount;
            }
            set
            {
                this._totalsearchcount = value;
            }
        }

        public int UserID
        {
            get
            {
                return this._userid;
            }
            set
            {
                this._userid = value;
            }
        }

        public string UserName
        {
            get
            {
                return this._username;
            }
            set
            {
                this._username = value;
            }
        }

        public int YesterdaySearchCount
        {
            get
            {
                return this._yesterdaysearchcount;
            }
            set
            {
                this._yesterdaysearchcount = value;
            }
        }

        public DateTime CountTime
        {
            get
            {
                return this._countTime;
            }
            set
            {
                this._countTime = value;
            }
        }

    }
}

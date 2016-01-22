using System;
using System.Collections.Generic;

using System.Text;

namespace Spread.Model
{
    public class TagCategory
    {
        private string _desc;
        private string _name;
        private int _Id;

        public string Desc
        {
            get
            {
                return this._desc;
            }
            set
            {
                this._desc = value;
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

        public int ID
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
    }
}

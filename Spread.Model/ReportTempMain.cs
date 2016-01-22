using System;
using System.Collections.Generic;
using System.Text;

namespace Spread.Model
{
    public class ReportTempMain
    {
        public ReportTempMain()
        { }
        #region Model
        private int _id;
        private string _name;
        private string _num;
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
        public string Num
        {
            set { _num = value; }
            get { return _num; }
        }
        #endregion Model

    }
}


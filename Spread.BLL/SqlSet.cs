using System;
using System.Collections.Generic;

using System.Text;

using System.Data;
using Spread.DAL;
namespace Spread.BLL
{
    public class SqlSet
    {
        private readonly Spread.DAL.SqlSet dal = new Spread.DAL.SqlSet();
        public void DoSql(string strSql)
        {
            this.dal.DoSql(strSql);
        }

        public DataSet GetListBySql(string strSql)
        {
            return this.dal.GetListBySql(strSql);
        }
    }
}

using System;
using System.Collections.Generic;

using System.Text;


using Spread.Model;
using Spread.DBUtility;

using System.Data;
using System.Data.OleDb;

namespace Spread.DAL
{
    public class SqlSet
    {
        public void DoSql(string strSql)
        {
            DbHelper.GetSingle( strSql, null);
        }

        public DataSet GetListBySql(string strSql)
        {
            return DbHelper.Query( strSql, null);
        }
    }
}

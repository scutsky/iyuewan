using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Spread.Web.User
{
    public partial class Eprotocol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                info();
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void info()
        {
            Spread.BLL.Products bllProducts = new Spread.BLL.Products();
            DataTable dt = bllProducts.GetList(0, "IsLock=0 ", "ID ASC").Tables[0];
            Products = dt;
        }
        /// <summary>
        ///  产品
        /// </summary>
        protected DataTable Products
        {
            get;
            set;
        }

    }
}
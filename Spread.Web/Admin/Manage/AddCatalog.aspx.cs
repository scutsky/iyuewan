using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Spread.Web.Admin.Manage
{
    public partial class AddCatalog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
              //ddddd();
           // SS();
        }

     

        private bool isisis(long cid)
        {
           DataTable dt= new Spread.BLL.Catalog().GetList(1, string.Format("CatalogId='{0}'", cid), "Id").Tables[0];

           if (dt != null && dt.Rows.Count > 0)
           {
               return true;
           }
           else { return false; }
        }

        private int addcata(long cid, string title, int parentid)
        {
            int calssid = 0;
            int classLayer = 1;                                         //栏目深度
            string classList = "";



            int sort = new Spread.BLL.Catalog().GetMaxSortID(parentid);

            Spread.BLL.Catalog bll = new Spread.BLL.Catalog();

            Spread.Model.Catalog model = new Spread.Model.Catalog();
            model.CatalogID = cid;
            model.Title = title;
            model.ParentId = parentid;
            model.ClassList = "";
            model.ClassOrder = sort;
            model.IsShow = true;
            model.IsLock = false;
            model.IsMenu = false;


            //添加栏目
            calssid = bll.Add(model);
            //修改栏目的下属栏目ID列表
            if (parentid > 0)
            {
                DataSet ds = bll.GetCatalogListByClassId(parentid);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    classList = dr["ClassList"].ToString().Trim() + calssid + ",";
                    classLayer = Convert.ToInt32(dr["ClassLayer"]) + 1;
                }
            }
            else
            {
                classList = "," + calssid + ",";
                classLayer = 1;
            }
            model.Id = calssid;
            model.ClassList = classList;
            model.ClassLayer = classLayer;
            new Spread.BLL.Catalog().Update(model);

            return calssid;
        }
    }
}

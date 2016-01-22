using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spread.Web.UI;
namespace Spread.Web.Admin.Article
{
    public partial class List_type : ManagePage
    {
        public int kindId; //栏目种类
        Spread.BLL.Article_type bll = new Spread.BLL.Article_type();
        protected void Page_Load(object sender, EventArgs e)
        {
           
                if (!Page.IsPostBack)
                {
                    chkLoginLevel("viewChannel");
                    BindData();
                }
          
        }
        private void BindData()
        {

            DataTable tb = new DataTable();
            tb = bll.Getlist().Tables[0];
            this.rptClassList.DataSource = tb;
            this.rptClassList.DataBind();
          
        }
      



        protected void rptClassList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Del":
                 Label id =(Label)e.Item.FindControl("lalelid");
                 int ID = int.Parse(id.Text);
                  bll.dalete(ID);
                    BindData();
                 break;
            } 

           
        }

        protected void rptClassList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
           
            

        }
    }
}

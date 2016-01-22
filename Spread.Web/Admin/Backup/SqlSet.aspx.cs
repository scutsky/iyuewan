using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Spread.BLL;
using Spread.Model;
using Spread.Web.UI;
using Spread.Common;
namespace Spread.Web.Admin.Backup
{
    public partial class SqlSet : ManagePage
    {
        Spread.BLL.SqlSet bll = new Spread.BLL.SqlSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                chkLoginLevel("viewSql");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtSql.Text != "")
            {
                string str = this.txtSql.Text.Substring(0, 6);
                if (str == "select" || str == "SELECT")
                {
                    chkLoginLevel("selectSql");
                    try
                    {
                        this.GridView1.DataSource = bll.GetListBySql(this.txtSql.Text.ToString());
                        this.GridView1.DataBind();
                    }
                    catch (Exception ex) { this.Label1.Text = ex.Message; }
                }
                else
                {
                    chkLoginLevel("aduSql");
                    string sql = "" + txtSql.Text + "";
                    bll.DoSql(sql);
                    this.Label1.Text = "操作完成！";
                }
            }
            else
            {
                this.Label1.Text = "内容不能为空！";
            }
        }
    }
}

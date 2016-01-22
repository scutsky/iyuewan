using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using Spread.Web.UI;
using Spread.Common;

namespace Spread.Web.Admin.Keyword
{
    public partial class Add : Spread.Web.UI.ManagePage
    {
        Spread.BLL.Tag bll = new Spread.BLL.Tag();
        Spread.Model.Tag model = new Spread.Model.Tag();

        Spread.BLL.Article Artbll = new Spread.BLL.Article();
        Spread.Model.Article Artmoel = new Spread.Model.Article();

        Spread.BLL.Products Probll = new Spread.BLL.Products();
        Spread.Model.Products Promodel = new Spread.Model.Products();

        Spread.BLL.WebSet Webbll = new Spread.BLL.WebSet();
        Spread.Model.WebSet Webmodel = new Spread.Model.WebSet();

        private string keyword = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                chkLoginLevel("addKeyword");
                BindClass();
            }
        }

        /// <summary>
        /// 绑定Tag类别
        /// </summary>
        public void BindClass()
        {
            Spread.BLL.TagCategory bll = new Spread.BLL.TagCategory();
            string strWhere = "";
            DataTable dt = bll.GetList(strWhere).Tables[0];

            this.ddlClass.Items.Clear();
            this.ddlClass.Items.Add(new ListItem("请选择类别...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["ID"].ToString().Trim();
                string Title = dr["Name"].ToString().Trim();

                this.ddlClass.Items.Add(new ListItem(Title, Id));
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region 添加关键字
            model.Name= keyword = this.txtName.Text.Trim();
            model.TagCategoryId = int.Parse(this.ddlClass.SelectedValue);
            model.ModelType = 1;
            model.DaySearchCount = 0;
            model.YesterdaySearchCount = 0;
            model.TotalSearchCount = model.DaySearchCount + model.YesterdaySearchCount;
            model.UserID = int.Parse(Session["AdminNo"].ToString());
            model.UserName = Session["AdminName"].ToString();
            model.CountTime = System.DateTime.Now;

            bll.Add(model);
            #endregion

            JscriptPrint("添加成功！", "Add.aspx", "Success");
        }
    }
}

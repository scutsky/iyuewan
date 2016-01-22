using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace Spread.Web.User
{
    public partial class Info : System.Web.UI.Page
    {
        BLL.ExtendGame extbll = new BLL.ExtendGame();
        Model.ExtendGame extmodel = new Model.ExtendGame();
        public Spread.Model.User modeluser = new Model.User();
        Spread.BLL.User blluser = new BLL.User();
        Model.Channel cModel = new Model.Channel();
        BLL.Channel cbll = new BLL.Channel();
        private string uid = "";
        private string pwd = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!getUserCookies())
                {
                    Response.Redirect("~/Index.aspx");
                }
                else
                {
                    modeluser = blluser.GetModelByName(uid);
                    hduid.Value = modeluser.ID.ToString();

                }
                
                if (Request.Params["cooperateModelId"] != null)
                {
                    DataTable dt = cbll.GetList(" UserID='" + modeluser.ID + "'  AND c.id='" + Request.Params["cooperateModelId"] + "'").Tables[0]; 
                    if (dt.Rows.Count > 0)
                    {
                        lbTitle.Text = dt.Rows[0]["Title"].ToString();
                        lbBrand.Text = dt.Rows[0]["Brand"].ToString();
                        lbPtitle.Text = dt.Rows[0]["Ptitle"].ToString();
                    }
                    cModel = cbll.GetModel(int.Parse(Request.Params["cooperateModelId"].ToString()));
                    if (cModel.ID > 0)
                    {
                        hdcid.Value = cModel.ID.ToString();
                        hdcname.Value = cModel.Name;
                        RptBind(" ChanelID='" + cModel.ID.ToString() + "'");
                        //this.rptList.DataSource = extbll.GetList(" e.ChanelID='" + cModel.ID.ToString() + "'").Tables[0];
                        //this.rptList.DataBind();
                    }
                }

            }
        }
        private bool getUserCookies()
        {

            if (Request.Cookies["UserPage_UID"] != null)
            {
                uid = Request.Cookies["UserPage_UID"].Value.ToString();
            }
            //获取登录时的PWD(MD5加密后)
            if (Request.Cookies["UserPage_PWD"] != null)
            {
                pwd = Request.Cookies["UserPage_PWD"].Value.ToString();
            }
            //当用户名UID或者密码PWD有一项为空时
            if (string.IsNullOrEmpty(uid) || string.IsNullOrEmpty(pwd))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        protected void lbdownall_Click(object sender, EventArgs e)
        {

        }

        #region 数据列表绑定
        private void RptBind(string strWhere)
        {
            DataTable dt = extbll.GetList(strWhere).Tables[0];
            lbCount.Text = dt.Rows.Count.ToString();
            this.rptList.DataSource = dt;
            this.rptList.DataBind();
        }
        #endregion

        

        protected void searchbtn_Click(object sender, EventArgs e)
        {
            RptBind(" ChanelID='" + hdcid.Value + "'" + this.CombSqlTxt(this.hdPlatform.Value, this.searchinput.Value));
        }
        #region 组合查询语句
        protected string CombSqlTxt(string _classId, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_classId))
            {
                strTemp.Append(" and g.Platform='" + _classId + "'");
            }
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and g.Name like '%" + _keywords + "%'");
            }
            return strTemp.ToString();
        }
        #endregion

    }

}
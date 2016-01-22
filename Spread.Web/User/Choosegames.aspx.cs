using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using Spread.Common;

namespace Spread.Web.User
{
   
    public partial class Choosegames : System.Web.UI.Page
    {
        BLL.Game bll = new BLL.Game();
        Model.Game model = new Model.Game();
        BLL.ExtendGame extbll = new BLL.ExtendGame();
        Model.ExtendGame extmodel = new Model.ExtendGame();

        Model.Channel cModel = new Model.Channel();
        BLL.Channel cbll = new BLL.Channel();
        public Spread.Model.User modeluser = new Model.User();
        Spread.BLL.User blluser = new BLL.User();

        Spread.BLL.Menu bllMenu = new Spread.BLL.Menu();

        private string uid = "";
        private string pwd = "";
        private string cid = "";
        private string cooperateId = "";
        private string key = "";
        private string cname = "";
        public string platformId = "";
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
                if (Request.Params["cooperateId"] != null)
                {
                    DataTable dt = cbll.GetList(" UserID='" + modeluser.ID + "'  AND c.id='" + Request.Params["cooperateId"] + "'").Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        lbTitle.Text = dt.Rows[0]["Title"].ToString();
                        lbBrand.Text = dt.Rows[0]["Brand"].ToString();
                        lbPtitle.Text = dt.Rows[0]["Ptitle"].ToString();
                    }

                    cModel = cbll.GetModel(int.Parse(Request.Params["cooperateId"].ToString()));
                    if (cModel.ID > 0)
                    {
                        hdcid.Value = cModel.ID.ToString();
                        hdcname.Value = cModel.Title;
                        chooseGame=extbll.GetList(" e.ChanelID='" + cModel.ID.ToString() + "'").Tables[0];
                    }
                    else
                    {
                        string myScript = @"alertRedirectMsg('参数错误!','error.gif','Channel.aspx');";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                    }
                }
                else
                {
                    string myScript = @"alertRedirectMsg('参数错误!','error.gif','Channel.aspx');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                }
                InfoView();
            }
        }

        private void InfoView()
        {
            StringBuilder strWhere = new StringBuilder();
            if (Request.Params["cname"] != null && Request.Params["cname"] != "")
            {
                strWhere.Append(" and Platform='" + Request.Params["cname"].ToString() + "' ");
                platformId = Request.Params["cname"].ToString();
                hdPlatform.Value= Request.Params["cname"].ToString();
            }
            else
            {
                platformId = "所有平台";
            }
            if (Request.Params["key"] != null && Request.Params["key"] != "")
            {
                this.searchinput.Value = Request.Params["key"].ToString();
                strWhere.Append(" and name like '%" + Request.Params["key"].ToString() + "%' ");
            }
            GameDataAE = bll.GetList(" FirstLetter in('A-E') " + strWhere.ToString() + " ").Tables[0];
            GameDataFJ = bll.GetList(" FirstLetter in('F-J') " + strWhere.ToString() + "").Tables[0];
            GameDataKO = bll.GetList(" FirstLetter in('K-O') " + strWhere.ToString() + "").Tables[0];
            GameDataPT = bll.GetList(" FirstLetter in('P-T') " + strWhere.ToString() + "").Tables[0];
            GameDataUZ = bll.GetList(" FirstLetter in('U-Z') " + strWhere.ToString() + "").Tables[0];
            GameDataQT = bll.GetList(" FirstLetter in('其他') " + strWhere.ToString() + "").Tables[0];
            MenuData=bllMenu.GetList("").Tables[0];
        }
        public DataTable MenuData
        {
            get;
            set;
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
        #region DataTable
        public DataTable chooseGame
        {
            get;
            set;
        }
        public DataTable GameDataAE
        {
            get;
            set;
        }
        public DataTable GameDataFJ
        {
            get;
            set;
        }
        public DataTable GameDataKO
        {
            get;
            set;
        }
        public DataTable GameDataPT
        {
            get;
            set;
        }
        public DataTable GameDataUZ
        {
            get;
            set;
        }
        public DataTable GameDataQT
        {
            get;
            set;
        }
        #endregion


        protected void btnSave_Click(object sender, EventArgs e)
        {
            int dbcount=0;
            BLL.ExtendGame extgame = new BLL.ExtendGame();
            Model.ExtendGame model = new Model.ExtendGame();
            try
            {
                string str = this.hdValue.Value;
                string[] strArr = str.Split(',');
                StringBuilder sqlWehere = new StringBuilder();
                sqlWehere.Append(" UserID='" + hduid.Value + "' and ChanelID='" + hdcid.Value + "' ");
                if (strArr.Length > 1)
                {
                    sqlWehere.Append(" and gameName not in (");
                    for (int i = 0; i < strArr.Length - 1; i++)
                    {
                        if(i==0){
                            sqlWehere.Append("'"+strArr[i]+"'");
                        }else{
                            sqlWehere.Append(",'"+strArr[i]+"'");
                        }
                    }
                    sqlWehere.Append(") ");
                }
                extgame.Delete(sqlWehere.ToString());


                if (this.hdValue.Value != "")//计算提交打包数量
                {
                    dbcount = 0;
                    model.Status = "正在打包";
                    model.UpdateType = "N/A";
                    model.UserID = int.Parse(hduid.Value);
                    model.ChanelID = int.Parse(hdcid.Value);
                    model.ChanelName = hdcname.Value;
                    for (int i = 0; i < strArr.Length - 1; i++)
                    {
                        model.UpdateDate = DateTime.Now;
                        model.OnTime = DateTime.Now;
                        model.gameID = 0;
                        model.gameName = strArr[i].Trim();
                        model.Verifycode = VerifycodeUtils.genVerifycode(6);
                        if (!extgame.Exists(int.Parse(hduid.Value), int.Parse(hdcid.Value), model.gameName))
                        {
                            dbcount++;
                        }
                    }
                }

                string countwhere = "[Status] ='正在打包' and ChanelID  ='" + hdcid.Value + "' "; //计算正在打包数量

                if (extgame.GetCount(countwhere) + dbcount > 5)
                {
                    Model.Log modLog = new Model.Log();
                    modLog.UserId = int.Parse(hdcid.Value);
                    modLog.UserName = hdcname.Value;
                    InsertLog(modLog);
                    string myScript = @"alertRedirectMsg('打包序列不能超过5个，请耐心等待!','error.gif','Channel.aspx');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                }
                else
                {
                    if (this.hdValue.Value != "")
                    {
                        model.Status = "正在打包";
                        model.UpdateType = "N/A";
                        model.UserID = int.Parse(hduid.Value);
                        model.ChanelID = int.Parse(hdcid.Value);
                        model.ChanelName = hdcname.Value;
                        for (int i = 0; i < strArr.Length - 1; i++)
                        {
                            model.UpdateDate = DateTime.Now;
                            model.OnTime = DateTime.Now;
                            model.gameID = 0;
                            model.gameName = strArr[i].Trim();
                            model.Verifycode = VerifycodeUtils.genVerifycode(6);
                            if (!extgame.Exists(int.Parse(hduid.Value), int.Parse(hdcid.Value), model.gameName))
                            {
                                extgame.Add(model);
                            }
                        }
                    }


                    Model.Log modLog = new Model.Log();
                    modLog.UserId = int.Parse(hdcid.Value);
                    modLog.UserName = hdcname.Value;
                    InsertLog(modLog);
                    string myScript = @"alertRedirectMsg('保存成功,系统正为您准备推广包，等待时间约为几分钟......','success.gif','Downloadgames.aspx?cooperateModelId= " + Request.Params["cooperateId"].ToString() + "');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                }

            }
            catch
            {
                string myScript = @"alertRedirectMsg('保存错误!','error.gif','Channel.aspx');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
            }
        }

        protected void searchbtn_Click(object sender, EventArgs e)
        {

            Response.Redirect("Choosegames.aspx?cooperateId=" + Request.Params["cooperateId"].ToString() + "&cname=" + hdPlatform.Value + "&key=" + searchinput.Value + "");
            //GameDataAE = bll.GetList(" FirstLetter in('A-E') " + strWhere + " ").Tables[0];
            //GameDataFJ = bll.GetList(" FirstLetter in('F-J') " + strWhere + " ").Tables[0];
            //GameDataKO = bll.GetList(" FirstLetter in('K-O') " + strWhere + " ").Tables[0];
            //GameDataPT = bll.GetList(" FirstLetter in('P-T') " + strWhere + " ").Tables[0];
            //GameDataUZ = bll.GetList(" FirstLetter in('U-Z') " + strWhere + " ").Tables[0];
            //GameDataQT = bll.GetList(" FirstLetter in('其他') " + strWhere + " ").Tables[0];
            //MenuData = bllMenu.GetList("").Tables[0];
        }
        private void InsertLog(Model.Log model)
        {
            BLL.Log bllLog = new BLL.Log();
            model.LogType = "添加游戏";
            model.Description = "添加游戏成功";
            model.LogTime = DateTime.Now;
            model.IsRead = "未阅读";
            bllLog.Add(model);
        }

        protected void btnSave2_Click(object sender, EventArgs e)
        {
            int dbcount=0;
            BLL.ExtendGame extgame = new BLL.ExtendGame();
            Model.ExtendGame model = new Model.ExtendGame();
            try
            {
                string str = this.hdValue.Value;
                string[] strArr = str.Split(',');
                StringBuilder sqlWehere = new StringBuilder();
                sqlWehere.Append(" UserID='" + hduid.Value + "' and ChanelID='" + hdcid.Value + "' ");
                if (strArr.Length > 1)
                {
                    sqlWehere.Append(" and gameName not in (");
                    for (int i = 0; i < strArr.Length - 1; i++)
                    {
                        if (i == 0)
                        {
                            sqlWehere.Append("'" + strArr[i] + "'");
                        }
                        else
                        {
                            sqlWehere.Append(",'" + strArr[i] + "'");
                        }
                    }
                    sqlWehere.Append(") ");
                }
                extgame.Delete(sqlWehere.ToString());

                if (this.hdValue.Value != "")//计算提交打包数量
                {
                    dbcount = 0;
                    model.Status = "正在打包";
                    model.UpdateType = "N/A";
                    model.UserID = int.Parse(hduid.Value);
                    model.ChanelID = int.Parse(hdcid.Value);
                    model.ChanelName = hdcname.Value;
                    for (int i = 0; i < strArr.Length - 1; i++)
                    {
                        model.UpdateDate = DateTime.Now;
                        model.OnTime = DateTime.Now;
                        model.gameID = 0;
                        model.gameName = strArr[i].Trim();
                        if (!extgame.Exists(int.Parse(hduid.Value), int.Parse(hdcid.Value), model.gameName))
                        {
                            dbcount++;
                        }
                    }
                }

                string countwhere = "[Status] ='正在打包' and ChanelID  ='" + hdcid.Value + "' "; //计算正在打包数量

                if (extgame.GetCount(countwhere) + dbcount > 5)
                {
                    Model.Log modLog = new Model.Log();
                    modLog.UserId = int.Parse(hdcid.Value);
                    modLog.UserName = hdcname.Value;
                    InsertLog(modLog);
                    string myScript = @"alertRedirectMsg('打包序列不能超过5个，请耐心等待!','error.gif','Channel.aspx');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                }
                else 
                {
                    if (this.hdValue.Value != "")
                    {
                        model.Status = "正在打包";
                        model.UpdateType = "N/A";
                        model.UserID = int.Parse(hduid.Value);
                        model.ChanelID = int.Parse(hdcid.Value);
                        model.ChanelName = hdcname.Value;
                        for (int i = 0; i < strArr.Length - 1; i++)
                        {
                            model.UpdateDate = DateTime.Now;
                            model.OnTime = DateTime.Now;
                            model.gameID = 0;
                            model.gameName = strArr[i].Trim();
                            model.Verifycode = VerifycodeUtils.genVerifycode(6);
                            if (!extgame.Exists(int.Parse(hduid.Value), int.Parse(hdcid.Value), model.gameName))
                            {
                                extgame.Add(model);
                            }
                        }
                    }
               

                    Model.Log modLog = new Model.Log();
                    modLog.UserId = int.Parse(hdcid.Value);
                    modLog.UserName = hdcname.Value;
                    InsertLog(modLog);
                    string myScript = @"alertRedirectMsg('保存成功,系统正为您准备推广包，等待时间约为几分钟......','success.gif','Downloadgames.aspx?cooperateModelId= " + Request.Params["cooperateId"].ToString() + "');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true); 
                }
           

                
            }
            catch
            {
                string myScript = @"alertRedirectMsg('保存错误!','error.gif','Channel.aspx');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
            }
        }
    }
}
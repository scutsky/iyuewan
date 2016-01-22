using System;
using System.Data;
using System.Web;
using Spread.Web.UI;
using System.Web.UI.WebControls;

namespace Spread.Web.Admin.Channel
{
    public partial class GameEdit : ManagePage
    {
        private Spread.BLL.ExtendGame bll = new Spread.BLL.ExtendGame();
        private Spread.Model.ExtendGame model = new Spread.Model.ExtendGame();
        public int id;    //ID
        public int cid;
        protected void Page_Load(object sender, EventArgs e)
        {
            chkLoginLevel("editChannel");
            //取得栏目传参
            if (int.TryParse(Request.Params["id"], out id) && int.TryParse(Request.Params["cid"], out cid))
            {
                model = bll.GetModel(id);
                if (!Page.IsPostBack)
                {
                    TreeBind();
                    PChanelBind("");
                    PgameBind(model.gameName,"");
                    ShowInfo();
                }
            }
            else
            {
                JscriptMsg(350, 230, "错误提示", "<b>出现错误啦！</b>您要修改主键不明确或参数不正确。", "back", "Error");
            }
        }


        //绑定数据
        private void ShowInfo()
        {

            Model.User userMod = new Model.User();
            BLL.User userBll = new BLL.User();
            Model.Game gMod = new Model.Game();
            BLL.Game gBll = new BLL.Game();
            //gMod = gBll.GetModel(Convert.ToInt32(model.gameID));
            this.lbChanel.Text = model.ChanelName;
            this.lbGameName.Text = model.gameName;
            this.ddlStatus.SelectedValue = model.Status;
            this.ddlUpdateType.SelectedValue = model.UpdateType;
            this.txtBak1.Text = model.Bak1;
            this.txtVersion.Text = model.version;
            if (model.Bak2 != "")
            {
                this.ddlMenu.SelectedValue = model.Bak2;
                this.ddlChanel.SelectedValue = model.Bak3;
                this.ddlGame.SelectedValue = model.Bak4;
            }
            this.txtScale.Text = model.Bak5;
        }

        //绑定平台
        private void TreeBind()
        {
            Spread.BLL.Menu cbll = new Spread.BLL.Menu();
            DataTable dt = cbll.GetList("").Tables[0];
            ddlMenu.DataSource = dt;
            ddlMenu.DataTextField = "Title";
            ddlMenu.DataValueField = "Title";
            ddlMenu.DataBind();
            ListItem item = new ListItem("请选择所属平台...", "0");
            ddlMenu.Items.Insert(0, item);
        }
        //绑定渠道
        private void PChanelBind(string menu)
        {
            Spread.BLL.Pchannel cbll = new Spread.BLL.Pchannel();
            string strWhere = "";
            if (menu != "")
            {
                strWhere = " c.ParentId=" + menu + " ";
            }
            DataTable dt = cbll.GetList(strWhere).Tables[0];
            ddlChanel.DataSource = dt;
            ddlChanel.DataTextField = "Title";
            ddlChanel.DataValueField = "Title";
            ddlChanel.DataBind();
            ListItem item = new ListItem("请选择所属渠道...", "0");
            ddlChanel.Items.Insert(0, item);
        }

        //绑定游戏
        private void PgameBind(string game, string menu)
        {
            game = game.Replace(" ", "|").Replace("-", "|").Replace("-", "|");
            string[] gameArr = game.Split('|');
            string strWhere = "";
            if (menu != "")
            {
                strWhere = " and Platform='" + menu + "' ";
            }
            Spread.BLL.Pgame cbll = new Spread.BLL.Pgame();
            DataTable dt = cbll.GetList(" Name like '%" + gameArr[0].ToString().Trim() + "%'" + strWhere).Tables[0];
            ddlGame.DataSource = dt;
            ddlGame.DataTextField = "Name";
            ddlGame.DataValueField = "Name";
            ddlGame.DataBind();
            ListItem item = new ListItem("请选择所属游戏...", "0");
            ddlGame.Items.Insert(0, item);
        }

        //保存修改
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int _id = 0;
            int _cid = 0;
            if (this.ddlMenu.SelectedValue == "0")
            {
                JscriptMsg(350, 230, "错误提示", "<b>请选择所属平台！</b>", "back", "Error");
                return;
            }
            if (this.ddlChanel.SelectedValue == "0")
            {
                JscriptMsg(350, 230, "错误提示", "<b>请选择所属渠道！</b>", "back", "Error");
                return;
            }
            if (this.ddlGame.SelectedValue == "0")
            {
                JscriptMsg(350, 230, "错误提示", "<b>请选择所属游戏！</b>", "back", "Error");
                return;
            }
            try
            {
               Decimal Scale=Decimal.Parse(this.txtScale.Text);
               if (Scale <= 0)
               {
                   JscriptMsg(350, 230, "错误提示", "<b>分成比例有误！</b>", "back", "Error");
                   return;
               }
            }
            catch
            {
                JscriptMsg(350, 230, "错误提示", "<b>分成比例有误！</b>", "back", "Error");
                return;
            }
            if (int.TryParse(Request.Params["id"], out _id))
            {
                _cid = int.Parse(Request.Params["cid"]);
                //修改栏目
                model.Status = this.ddlStatus.SelectedValue;
                model.UpdateDate = DateTime.Now;
                model.UpdateType = this.ddlUpdateType.SelectedValue;
                model.version = this.txtVersion.Text;
                model.Bak1 = this.txtBak1.Text;
                model.Bak2 = this.ddlMenu.SelectedValue;
                model.Bak3 = this.ddlChanel.SelectedValue;
                model.Bak4 = this.ddlGame.SelectedValue;
                model.Bak5 = this.txtScale.Text;
                if (bll.checkrepeat(model.Bak2, model.Bak3, model.Bak4)) JscriptPrint("渠道重复，请检查！", "GameList.aspx?id=" + _cid + "", "Error");
                else if (bll.checkURL(model.Bak1)) JscriptPrint("网址重复，请检查！", "GameList.aspx?id=" + _cid + "", "Error");
                else  
                {
                    bll.UpdateStatus(model);               
                    JscriptPrint("修改成功啦！", "GameList.aspx?id=" + _cid + "", "Success");
                }
            }
            else
            {
                JscriptPrint("修改错误！", "GameList.aspx?id=" + _cid + "", "Error");
            }


        }

        protected void ddlMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string menu = ddlMenu.SelectedValue;
            Spread.BLL.Menu cbll = new Spread.BLL.Menu();
            Spread.Model.Menu modelMenu = new Spread.Model.Menu();
            modelMenu = cbll.GetModelByName(menu);
            if (modelMenu != null)
            {
                PChanelBind(modelMenu.Id.ToString());
                PgameBind(model.gameName, menu);
            }

        }
    }
}

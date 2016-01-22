using System;
using System.Data;
using System.Web;
using Spread.Web.UI;

namespace Spread.Web.Admin.Channel
{
    public partial class CardEdit : ManagePage
    {
        private Spread.BLL.CardGame bll = new Spread.BLL.CardGame();
        private Spread.Model.CardGame model = new Spread.Model.CardGame();

        private Spread.BLL.ExtendGame bllExtend = new Spread.BLL.ExtendGame();
        private Spread.Model.ExtendGame modelExtend = new Spread.Model.ExtendGame();
        public int id;    //ID
        public int cid;
        protected void Page_Load(object sender, EventArgs e)
        {
            chkLoginLevel("editCardGame");
            //取得栏目传参
            if (int.TryParse(Request.Params["id"], out id) && int.TryParse(Request.Params["cid"], out cid))
            {
                modelExtend = bllExtend.GetModel(id);
                model = bll.GetModelbyChanelID(int.Parse(modelExtend.ChanelID.ToString()), int.Parse(modelExtend.gameID.ToString()));
                
                if (!Page.IsPostBack)
                {
                    ShowInfo();
                    if (model != null)
                    {
                        hdID.Value = model.ID.ToString();
                        this.txtCardName.Text = model.CardName;
                        this.ddlCardType.SelectedValue = model.CardType;
                        this.ddlStatus.Text = model.Status;
                    }
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
            //gMod = gBll.GetModel(Convert.ToInt32(modelExtend.gameID));
            this.lbChanelName.Text = modelExtend.ChanelName;
            this.lbgamename.Text = modelExtend.gameName;

        }

        //保存修改
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int _id = 0;
            int _cid = 0;
            if (hdID.Value != "")
            {
                if (int.TryParse(Request.Params["id"], out _id))
                {
                    try
                    {
                        _cid = int.Parse(Request.Params["cid"]);
                        //修改栏目  
                        Spread.Model.CardGame newmodel = new Spread.Model.CardGame();
                        newmodel.Status = this.ddlStatus.SelectedValue;
                        newmodel.UpdateDate = DateTime.Now;
                        newmodel.CardType = this.ddlCardType.SelectedValue;
                        newmodel.CardName = this.txtCardName.Text;
                        newmodel.ID = int.Parse(hdID.Value);
                        bll.Update(newmodel);
                        JscriptPrint("修改成功啦！", "GameList.aspx?id=" + _cid + "", "Success");
                    }
                    catch
                    {
                        JscriptPrint("修改错误！", "GameList.aspx?id=" + _cid + "", "Error");
                    }
                }
                else
                {
                    JscriptPrint("修改错误！", "GameList.aspx?id=" + _cid + "", "Error");
                }
            }
            else
            {
                try
                {
                    _cid = int.Parse(Request.Params["cid"]);
                    Spread.Model.CardGame newmodel = new Spread.Model.CardGame();
                    newmodel.UserID = modelExtend.UserID;
                    newmodel.CardName = this.txtCardName.Text;
                    newmodel.ChanelID = modelExtend.ChanelID;
                    newmodel.ChanelName = modelExtend.ChanelName;
                    newmodel.GameID = modelExtend.gameID;
                    newmodel.Status = this.ddlStatus.SelectedValue;
                    newmodel.UpdateDate = DateTime.Now;
                    newmodel.CardType = this.ddlCardType.SelectedValue;
                    bll.Add(newmodel);
                    JscriptPrint("新增成功啦！", "GameList.aspx?id=" + _cid + "", "Success");
                }
                catch
                {
                    JscriptPrint("新增错误！", "GameList.aspx?id=" + _cid + "", "Error");
                }
            }
        }
    }
}

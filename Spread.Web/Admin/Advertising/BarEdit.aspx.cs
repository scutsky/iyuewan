using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spread.Common;

namespace Spread.Web.Admin.Advertising
{
    public partial class BarEdit : Spread.Web.UI.ManagePage
    {
        public int pid;
        public int Id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.Params["id"] as string, out this.Id))
            {
                JscriptMsg(350, 230, "错误提示", "<b>出现错误啦！</b>您要修改的信息不存在或参数不正确。", "back", "Error");
                return;
            }
            if (!Page.IsPostBack)
            {
                chkLoginLevel("editAdvertising");
                ShowInfo(this.Id);
            }
        }

        #region 绑定初始数据
        private void ShowInfo(int _id)
        {
            Spread.BLL.Adbanner bll = new Spread.BLL.Adbanner();
            Spread.Model.Adbanner model = bll.GetModel(_id);

            this.pid = model.Aid;
            this.lblAdTitle.Text = model.Aid.ToString();
            this.txtTitle.Text = model.Title;
            this.txtStartTime.Text = model.StartTime.ToString("yyyy-MM-dd");
            this.txtEndTime.Text = model.EndTime.ToString("yyyy-MM-dd");
            this.txtImgUrl.Text = model.AdUrl;
            this.txtLinkUrl.Text = model.LinkUrl;
            this.txtAdRemark.Text = StringPlus.ToTxt(model.AdRemark);
            this.rblIsLock.SelectedValue = model.IsLock.ToString();

            //显示所属广告位
            GetAdType(this.pid);
        }
        #endregion

        #region 查询所属的广告位
        private void GetAdType(int _pid)
        {
            //显示所属的广告位
            Spread.BLL.Advertising aBll = new Spread.BLL.Advertising();
            Spread.Model.Advertising aModel = aBll.GetModel(_pid);
            lblAdTitle.Text = "【" + aModel.Id + "】" + aModel.Title + "（" + GetAdTypeName(aModel.AdType.ToString()) + "）";
        }
        #endregion

        #region 返回广告位类型名称
        private string GetAdTypeName(string strId)
        {
            switch (strId)
            {
                case "1":
                    return "文字";
                case "2":
                    return "图片";
                case "3":
                    return "幻灯片";
                case "4":
                    return "动画";
                case "5":
                    return "FLV视频";
                case "6":
                    return "代码";
                default:
                    return "其它";
            }
        }
        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Spread.BLL.Adbanner bll = new Spread.BLL.Adbanner();
            Spread.Model.Adbanner model = bll.GetModel(this.Id);

            model.Title = this.txtTitle.Text.Trim();
            model.StartTime = DateTime.Parse(this.txtStartTime.Text.Trim());
            model.EndTime = DateTime.Parse(this.txtEndTime.Text.Trim());
            model.AdUrl = this.txtImgUrl.Text.Trim();
            model.LinkUrl = this.txtLinkUrl.Text.Trim();
            model.AdRemark = StringPlus.ToHtml(this.txtAdRemark.Text);
            model.IsLock =Convert.ToBoolean(this.rblIsLock.SelectedValue);
            bll.Update(model);
            JscriptPrint("广告修改成功啦！", "BarList.aspx?Pid=" + model.Aid, "Success");
        }
    }
}

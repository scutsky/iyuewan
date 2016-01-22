using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spread.Common;

namespace Spread.Web.Admin.Advertising
{
    public partial class BarAdd : Spread.Web.UI.ManagePage
    {
        public int pid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.Params["Pid"] as string, out this.pid))
            {
                JscriptMsg(350, 230, "错误提示", "<b>出现错误啦！</b>对不起，广告位不存在或者已经被删除了。", "back", "Error");
                return;
            }
            if (!Page.IsPostBack)
            {
                chkLoginLevel("addAdvertising");
                ShowInfo(this.pid);
            }
        }

        #region 查询所属的广告位
        private void ShowInfo(int sId)
        {
            //显示所属的广告位
            Spread.BLL.Advertising aBll = new Spread.BLL.Advertising();
            Spread.Model.Advertising aModel = aBll.GetModel(this.pid);
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

        //保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Spread.Model.Adbanner model = new Spread.Model.Adbanner();
            Spread.BLL.Adbanner bll = new Spread.BLL.Adbanner();
            model.Aid = this.pid;
            model.Title = this.txtTitle.Text.Trim();
            model.StartTime = DateTime.Parse(this.txtStartTime.Text.Trim());
            model.EndTime = DateTime.Parse(this.txtEndTime.Text.Trim());
            model.AdUrl = this.txtImgUrl.Text.Trim();
            model.LinkUrl = this.txtLinkUrl.Text.Trim();
            model.AdRemark = StringPlus.ToHtml(this.txtAdRemark.Text);
            model.IsLock =Convert.ToBoolean(this.rblIsLock.SelectedValue);
            model.AddTime = DateTime.Now;
            bll.Add(model);
            JscriptPrint("广告发布成功啦！", "BarAdd.aspx?Pid=" + this.pid, "Success");
        }
    }
}

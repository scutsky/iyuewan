using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Spread.Web.Admin.Advertising
{
    public partial class AdvAdd : Spread.Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            chkLoginLevel("addAdvertising");
        }

        //保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Spread.Model.Advertising model = new Spread.Model.Advertising();
            Spread.BLL.Advertising bll = new Spread.BLL.Advertising();
            model.Title = this.txtTitle.Text.Trim();
            model.AdType = int.Parse(this.rblAdType.SelectedValue);
            model.AdRemark = this.txtAdRemark.Text;
            model.AdNum = int.Parse(this.txtAdNum.Text.Trim());
            model.AdPrice = decimal.Parse(this.txtAdPrice.Text);
            model.AdWidth = int.Parse(this.txtAdWidth.Text);
            model.AdHeight = int.Parse(this.txtAdHeight.Text);
            model.AdTarget = this.rblAdTarget.SelectedValue;
            bll.Add(model);
            JscriptPrint("广告位增加成功啦！", "AdvAdd.aspx", "Success");
        }
    }
}

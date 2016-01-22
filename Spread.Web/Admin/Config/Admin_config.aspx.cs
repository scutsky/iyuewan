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
using System.Data.SqlClient;


namespace Spread.Web.Admin.Config
{
    public partial class admin_config : ManagePage
    {
        private Spread.BLL.WebSet bll = new Spread.BLL.WebSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                chkLoginLevel("editConfig");
                LoadWevSet();
            }
        }

        public void LoadWevSet()
        {
            //取得配置信息
            Spread.Model.WebSet model = new Spread.Model.WebSet();
            //bll.Get_Config(rwc);
            string pathurl = Server.MapPath(ConfigurationManager.AppSettings["WebSetpath"].ToString());
            model = bll.loadConfig(pathurl);
            //赋值给对应的控件
            txtWebName.Text = model.WebName;
            txtWebUrl.Text = model.WebUrl;
            txtWebPath.Text = model.WebPath;
            txtWebLogPath.Text = model.WeblogPath;
            txtWebTel.Text = model.WebTel;
            txtWebFax.Text = model.WebFax;
            txtWebQQ1.Text = model.WebQQ1;
            txtWebQQ2.Text = model.WebQQ2;
            txtSettlementCycle.Text = model.SettlementCycle;
            txtChannelNum.Text = model.ChannelNum;
            txtWebEmail.Text = model.WebEmail;
            txtWebCrod.Text = model.WebCrod;
            txtWebCopyright.Text = model.WebCopyright;
            txtWebKeywords.Text = model.WebKeywords.ToString();
            txtWebDescription.Text = model.WebDescription.ToString();
            rblWebLogStatus.SelectedValue = model.WebLogStatus.ToString();
            txtWebKillKeywords.Text = model.WebKillKeywords.ToString();
            txtWebProSize.Text = model.WebProSize.ToString();
            txtWebNewsSize.Text = model.WebNewsSize.ToString();
            txtWebFilePath.Text = model.WebFilePath.ToString();
            txtWebFileType.Text = model.WebFileType.ToString();
            txtWebFileSize.Text = model.WebFileSize.ToString();
            rblIsThumbnail.SelectedValue = model.IsThumbnail.ToString();
            txtProWidth.Text = model.ProWidth.ToString();
            txtProHight.Text = model.ProHight.ToString();
            rblIsWatermark.SelectedValue = model.IsWatermark.ToString();
            rblWatermarkStatus.SelectedValue = model.WatermarkStatus.ToString();
            txtImgQuality.Text = model.ImgQuality.ToString();
            txtImgWaterPath.Text = model.ImgWaterPath.ToString();
            txtImgWaterTransparency.Text = model.ImgWaterTransparency.ToString();
            txtWaterText.Text = model.WaterText.ToString();
            ddlWaterFont.SelectedValue = model.WaterFont.ToString();
            txtFontSize.Text = model.FontSize.ToString();
            txtArtModelUrl.Text = model.ArtModelUrl.ToString();
            txtProModelUrl.Text = model.ProModelUrl.ToString();
            txtDownModelUrl.Text = model.DownModelUrl.ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //赋值给MODEL
                Spread.Model.WebSet model = new Spread.Model.WebSet();
                model.WebName = txtWebName.Text;
                model.WebUrl = txtWebUrl.Text;
                model.WebPath = txtWebPath.Text;
                model.WeblogPath = txtWebLogPath.Text;
                model.WebTel = txtWebTel.Text;
                model.WebFax = txtWebFax.Text;
                model.WebQQ1 = txtWebQQ1.Text;
                model.WebQQ2 = txtWebQQ2.Text;
                model.SettlementCycle = txtSettlementCycle.Text;
                model.ChannelNum = txtChannelNum.Text;
                model.WebEmail = txtWebEmail.Text;
                model.WebCrod = txtWebCrod.Text;
                model.WebCopyright = txtWebCopyright.Text;

                model.WebKeywords = txtWebKeywords.Text.Trim();
                model.WebDescription = txtWebDescription.Text.Trim();
                model.WebLogStatus = int.Parse(rblWebLogStatus.SelectedValue);
                model.WebKillKeywords = txtWebKillKeywords.Text.Trim();

                model.WebProSize = int.Parse(txtWebProSize.Text.Trim());
                model.WebNewsSize = int.Parse(txtWebNewsSize.Text.Trim());
                model.WebFilePath = txtWebFilePath.Text;
                model.WebFileType = txtWebFileType.Text;
                model.WebFileSize = int.Parse(txtWebFileSize.Text.Trim());
                model.IsThumbnail = int.Parse(rblIsThumbnail.SelectedValue);
                model.ProWidth = int.Parse(txtProWidth.Text.Trim());
                model.ProHight = int.Parse(txtProHight.Text.Trim());
                model.IsWatermark = int.Parse(rblIsWatermark.SelectedValue.Trim());
                model.WatermarkStatus = int.Parse(rblWatermarkStatus.SelectedValue.Trim());
                model.ImgQuality = int.Parse(txtImgQuality.Text.Trim());
                model.ImgWaterPath = txtImgWaterPath.Text.Trim();
                model.ImgWaterTransparency = int.Parse(txtImgWaterTransparency.Text.Trim());
                model.WaterText = txtWaterText.Text.Trim();
                model.WaterFont = ddlWaterFont.SelectedValue;
                model.FontSize = int.Parse(txtFontSize.Text.Trim());
                model.ArtModelUrl = this.txtArtModelUrl.Text.Trim();
                model.ProModelUrl = this.txtProModelUrl.Text.Trim();
                model.DownModelUrl = this.txtDownModelUrl.Text.Trim();

                ////修改配置信息
                bll.saveConifg(model, Server.MapPath(Spread.Common.Param.WebSetpath));
                JscriptPrint("系统设置成功啦！", "admin_config.aspx", "Success");
            }
            catch(Exception ex)
            {

                JscriptMsg(350, 280, "错误提示", "<b>文件写入失败！</b>请检查是否有写入权限，如果没有，请联系管理员开启写入该文件的权限！" + ex.Message, "admin_config.aspx", "Error");
            }
        }
    }
}

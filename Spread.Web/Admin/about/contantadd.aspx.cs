using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Spread.Common;
using Spread.BLL;



namespace Spread.Web.Admin.about
{
    public partial class contantadd : Spread.Web.UI.ManagePage
    {
        public Spread.BLL.contant bll = new Spread.BLL.contant();
        public Model.contant modle = new Spread.Model.contant();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                chkLoginLevel("contantadd");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            modle.ContName = this.Textname.Text;
            modle.ContAddres = this.txtaddres.Text;
            modle.ContImage = this.txtImgUrl.Text;
            modle.Contcont = this.FCKeditor.Value;

            bll.Add(modle);

            Response.Write("<script>alert('发布成功啦！!!!')</script>");
            //JscriptPrint("公司信息添加成功啦！", "contantadd.aspx", "Success");
         
            
        }
    }
}

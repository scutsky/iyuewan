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
    public partial class contant : Spread.Web.UI.ManagePage
    {
 
        Spread.BLL.contant bll = new Spread.BLL.contant();
     
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                chkLoginLevel("contant");

                BindData();
            }
        }

        /// <summary>
        /// 查询绑定公司的信息
        /// </summary>
        /// <param name="model"></param>
        public  void BindData( )
        {
            Spread.Model.contant model = new Spread.Model.contant();
            model = bll.model();
            this.TextName.Text = model.ContName;
            this.txtaddres.Text = model.ContAddres;
            this.txtImgUrl.Text = model.ContImage;
            this.FCKeditor.Value = model.Contcont;
        }


        public int getid()
        {
            Spread.Model.contant model = new Spread.Model.contant();

            int id;
            model = bll.model();
            id = model.ID;
            return id;
           
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Spread.Model.contant model = new Spread.Model.contant();
            //修改公司信息
            model.ContName = this.TextName.Text;
            model.ContAddres = this.txtaddres.Text;
            model.ContImage = this.txtImgUrl.Text;
            model.Contcont = FCKeditor.Value;
            model.ID = getid ();
            bll.update(model);

            Response.Write("<script>alert('更新信息成功！！')</script>");

        }
        
     
    }
}

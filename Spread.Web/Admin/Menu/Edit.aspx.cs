using System;
using System.Data;
using System.Web;
using Spread.Web.UI;

namespace Spread.Web.Admin.Menu
{
    public partial class Edit : ManagePage
    {
        private Spread.BLL.Menu bll = new Spread.BLL.Menu();
        private Spread.Model.Menu model = new Spread.Model.Menu();
        public int classId;    //ID
        protected void Page_Load(object sender, EventArgs e)
        {
            chkLoginLevel("editMenu");
            //取得栏目传参
            if (int.TryParse(Request.Params["classId"], out classId))
            {
                model = bll.GetModel(classId);
                if (!Page.IsPostBack)
                {
                    ShowInfo();
                }
            }
            else
            {
                JscriptMsg(350, 230, "错误提示", "<b>出现错误啦！</b>您要修改类别的编号不明确或参数不正确。", "back", "Error");
            }
        }

        //绑定数据
        private void ShowInfo()
        {
          
            this.txtTitle.Text = model.Title;
        }

        //保存修改
        protected void btnSave_Click(object sender, EventArgs e)
        {
            model.Title = txtTitle.Text.Trim();
            //修改栏目
            bll.Update(model);
            JscriptPrint("商品分类修改成功啦！", "List.aspx", "Success");
        }

    }
}
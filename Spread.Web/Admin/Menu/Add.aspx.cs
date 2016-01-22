using System;
using System.Data;
using System.Web;
using Spread.Web.UI;

namespace Spread.Web.Admin.Menu
{
    public partial class Add : ManagePage
    {
        private Spread.BLL.Menu bll = new Spread.BLL.Menu();
        private Spread.Model.Menu model = new Spread.Model.Menu();
        public int pId;    //栏目父ID
        public string pTitle = "顶级商品分类";
        protected void Page_Load(object sender, EventArgs e)
        {
            chkLoginLevel("addMenu");
            if (int.TryParse(Request.Params["classId"], out pId))
            {
                pTitle = bll.GetMenuTitle(pId);
            }
            else
            {
                pId = 0;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int classId;
            int classLayer = 1;                                         //栏目深度
            string classList = "";
            model.MenuID = 0;
            model.Title = this.txtTitle.Text.Trim();
            model.ParentId = 0;
            model.ClassList = "";
            model.ClassOrder = 0;
            model.IsShow = false;
            model.IsLock = false;
            model.IsMenu = false;
            //添加栏目
            classId = bll.Add(model);
            
            model.Id = classId;
            model.ClassList = classList;
            model.ClassLayer = classLayer;
            bll.Update(model);

            JscriptPrint("增加栏目成功啦！", "List.aspx", "Success");
        }
    }
}

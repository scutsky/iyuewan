using System;
using System.Data;
using System.Web;
using Spread.Web.UI;

namespace Spread.Web.Admin.Article
{
    public partial class AddArticle_type : ManagePage
    {
        private Spread.BLL.Article_type bll = new Spread.BLL.Article_type();
        private Spread.Model.Article_type model = new Spread.Model.Article_type();
        public int kindId; //栏目种类
        public int pId;    //栏目父ID
        public string pTitle = "顶级类别";
        protected void Page_Load(object sender, EventArgs e)
        {
            chkLoginLevel("Article_type");
            //取得栏目传参
            if (int.TryParse(Request.Params["kindId"], out kindId))
            {
                if (int.TryParse(Request.Params["classId"], out pId))
                {
                    pTitle = bll.GetChannelTitle(pId);
                }
                else
                {
                    pId = 0;
                }
                lblPid.Text = pId.ToString();
                lblPname.Text = pTitle;
                switch (kindId)
                {
                    case 1:
                        txtPageUrl.Text = "/Admin/Goods/List.aspx";
                        break;
                    case 2:
                        txtPageUrl.Text = "/Admin/Goods/List.aspx";
                        break;
                    case 3:
                        txtPageUrl.Text = "/Admin/Goods/List.aspx";
                        break;

                }
            }
            else
            {
                JscriptMsg(350, 230, "错误提示", "<b>出现错误啦！</b>您要增加类别的种类不明确或参数不正确。", "back", "Error");
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           
            int parentId = int.Parse(this.lblPid.Text.Trim());          //上一级目录
            string classList = "";
            int classId;
            int classLayer = 1;  


            model.Title = this.txtTitle.Text.Trim();
            model.ParentId = parentId;
            model.PageUrl = this.txtPageUrl.Text.Trim();
            model.ClassList = "";
            model.ClassOrder = int.Parse(this.txtClassOrder.Text.Trim());
            model.KindId = this.kindId;
            model.Keyword = "";
            
            //添加栏目
            classId = bll.Add(model);
           
            JscriptPrint("增加栏目成功啦！", "List_type.aspx", "Success");
        }
    }
}

using System;
using System.Data;
using System.Web;
using Spread.Web.UI;

namespace Spread.Web.Admin.Channel
{
    public partial class Add : ManagePage
    {
        private Spread.BLL.Channel bll = new Spread.BLL.Channel();
        private Spread.Model.Channel model = new Spread.Model.Channel();
        public int kindId; //栏目种类
        public int pId;    //栏目父ID
        public string pTitle = "顶级类别";
        protected void Page_Load(object sender, EventArgs e)
        {
            chkLoginLevel("addChannel");
            //取得栏目传参
            if (int.TryParse(Request.Params["kindId"], out kindId))
            {
                
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
            int classId;
            int parentId = int.Parse(this.lblPid.Text.Trim());          //上一级目录
            int classLayer = 1;                                         //栏目深度
            string classList = "";


            //model.Title = this.txtTitle.Text.Trim();
            //model.ParentId = parentId;
            //model.PageUrl = this.txtPageUrl.Text.Trim();
            //model.ClassList = "";
            //model.ClassOrder = int.Parse(this.txtClassOrder.Text.Trim());
            //model.KindId = this.kindId;
            //model.Keyword = this.txtKeyword.Text.Trim();
            //model.Zhaiyao = this.txtZhaiyao.Text.Trim();
            //model.ImgUrl1 = this.txtImgUrl.Text.Trim();
            //model.ImgUrl2 = this.txtImgUrl2.Text.Trim();
            //if (cblItem.Items[0].Selected == true)
            //{
            //    model.IsHot = true;
            //}
            //添加栏目
            classId = bll.Add(model);
            //修改栏目的下属栏目ID列表
            //if (parentId > 0)
            //{
            //    DataSet ds = bll.GetChannelListByClassId(parentId);

            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        DataRow dr = ds.Tables[0].Rows[0];
            //        classList = dr["ClassList"].ToString().Trim() + classId + ",";
            //        classLayer = Convert.ToInt32(dr["ClassLayer"]) + 1;
            //    }
            //}
            //else
            //{
            //    classList = "," + classId + ",";
            //    classLayer = 1;
            //}
            //model.Id = classId;
            //model.ClassList = classList;
            //model.ClassLayer = classLayer;
            //bll.Update(model);

            JscriptPrint("增加栏目成功啦！", "List.aspx?kindId=" + kindId, "Success");
        }
    }
}

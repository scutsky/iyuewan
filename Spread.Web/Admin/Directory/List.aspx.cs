using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spread.Web.UI;

namespace Spread.Web.Admin.Directory
{
    public partial class List : ManagePage
    {
        public int kindId; //栏目种类
        Spread.BLL.MenuDirectory bll = new Spread.BLL.MenuDirectory();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                chkLoginLevel("viewMenuDirectory");
                BindData();
            }
        }

        //数据绑定
        private void BindData()
        {
            int pid = 0;

            try
            {
                pid = int.Parse(Request["pid"]);
            }
            catch { }
            DataTable dt = bll.GetList(0, string.Format(" ParentId={0} and LanguageType='zh'", pid), "ClassOrder").Tables[0];

            this.rptClassList.DataSource = dt;
            this.rptClassList.DataBind();

            GetProductMenu(pid);
        }

        //设置删除操作
        protected void rptClassList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField txtClassId = (HiddenField)e.Item.FindControl("txtClassId");
            int id = Convert.ToInt32(txtClassId.Value);
            switch (e.CommandName.ToLower())
            {
                case "btndel":
                    bll.Delete(id);
                    BindData();
                    JscriptPrint("批量删除成功啦！", "", "Success");
                    break;
                case "ibtnshow":
                    Spread.Model.MenuDirectory model = bll.GetModel(id);
                    if (model.IsShow == true)
                        bll.UpdateField(id, "IsShow=false");
                    else
                        bll.UpdateField(id, "IsShow=true");
                    BindData();
                    break;
                case "ibtnmenu":
                    Spread.Model.MenuDirectory model1 = bll.GetModel(id);
                    if (model1.IsMenu == true)
                        bll.UpdateField(id, "IsMenu=false");
                    else
                        bll.UpdateField(id, "IsMenu=true");
                    BindData();
                    break;
                case "ibtnlock":
                    Spread.Model.MenuDirectory model2 = bll.GetModel(id);
                    if (model2.IsLock == true)
                        bll.UpdateField(id, "IsLock=false");
                    else
                        bll.UpdateField(id, "IsLock=true");
                    BindData();
                    break;
            }
        }

        //美化列表
        protected void rptClassList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                Literal LitFirst = (Literal)e.Item.FindControl("LitFirst");
                HiddenField txtClassLayer = (HiddenField)e.Item.FindControl("txtClassLayer");
                string LitStyle = "<span style=width:{0}px;text-align:right;display:inline-block;>{1}{2}</span>";
                string LitImg1 = "<img src=../images/folder_open.gif align=absmiddle />";
                string LitImg2 = "<img src=../images/t.gif align=absmiddle />";

                int classLayer = Convert.ToInt32(txtClassLayer.Value);
                if (classLayer == 1)
                {
                    LitFirst.Text = LitImg1;
                }
                else
                {
                    LitFirst.Text = string.Format(LitStyle, classLayer * 18, LitImg2, LitImg1);
                }
            }
        }

        /// <summary>
        /// 获取子节点连接
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        protected string getSubLink(object id, object title, object layer)
        {
            int classLayer = Convert.ToInt32(layer.ToString());
            if (classLayer >= 3)
            {
                return title.ToString();
            }
            else
            {
                return string.Format("<a href=\"List.aspx?pid={0}\" title=\"查看子分类\">{1}</a>", id, title);
            }
        }

        /// <summary>
        /// 获取商品类目
        /// </summary>
        private void GetProductMenu(int id)
        {
            DataTable dt = new Spread.BLL.MenuDirectory().GetList(1, " ClassList ", string.Format(" id={0} ", id), " ClassOrder ").Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                string catapath = dt.Rows[0][0].ToString().TrimStart(',').TrimEnd(',');
                if (catapath.Length > 0)
                {
                    this.MenuPath = new Spread.BLL.MenuDirectory().GetList(0, "Id,ParentID ,Title ", string.Format(" id in ({0})", catapath), "Id").Tables[0];
                }
            }
        }

        /// <summary>
        /// 分类路径
        /// </summary>
        protected DataTable MenuPath
        {
            get;
            set;
        }
    }
}

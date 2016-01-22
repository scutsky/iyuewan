using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Spread.Web.Admin.Keyword
{
    public partial class TagCateList :Spread.Web.UI.ManagePage
    {
        public int pcount { get; set; } //总条数
        public int page { get; set; } //当前页
        public readonly int pagesize = 15; //设置每页显示的大小
      

        Spread.BLL.TagCategory Tbll = new Spread.BLL.TagCategory();
        Spread.Model.TagCategory Tmodel = new Spread.Model.TagCategory();
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!this.IsPostBack)
            {
                chkLoginLevel("viewKeyClass");
                if (Request["ID"] != null)
                {
                    chkLoginLevel("updateTagCate");
                    int ID = int.Parse(Request["ID"].ToString());
                    btnSubmit.Text = "修改关键字类别";
                    Tmodel = Tbll.GetModel(ID);
                    this.txtName.Text = Tmodel.Name;
                    this.txtDesc.Text = Tmodel.Desc;
                }
                RptBind();
            }
        }

        //绑定数据
        void RptBind()
        {
            string where = "";
            if (Request.QueryString["page"] != null && Convert.ToInt32(Request.QueryString["page"]) > 0)
            {
                page = Convert.ToInt32(Request.QueryString["page"]);
            }
            else
            {
                page = 0;
            }
            //利用PAGEDDAGASOURCE类来分页
            PagedDataSource pg = new PagedDataSource();
            pg.DataSource = Tbll.GetList(where).Tables[0].DefaultView;
            pg.AllowPaging = true;
            pg.PageSize = pagesize;
            pg.CurrentPageIndex = page;
            //获得总条数
            pcount = Tbll.GetCount(where);
            //绑定数据
            rptList.DataSource = pg;
            rptList.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int ID = 0;
            if (Request["ID"] != null)
            {
               ID=int.Parse(Request["ID"].ToString());
            }
            string name = txtName.Text.Trim();
            string desc = txtDesc.Text.Trim();
            if (name.Length == 0 || name.Length > 20)
            {
                JscriptPrint("Tag类别名称必须填写", "", "Error");
                return;
            }
            if (desc.Length > 100)
            {
                JscriptPrint("Tag类别描述不能超过100个字", "", "Error");
                return;
            }
            Tmodel.ID = ID;
            Tmodel.Name = name;
            Tmodel.Desc = desc;
            if (ID == 0)
            {
                chkLoginLevel("addKeyClass");
                Tbll.Add(Tmodel);
                JscriptPrint("添加成功啦！", "", "Success");                
            }
            else
            {
                chkLoginLevel("editKeyClass");
                Tbll.Update(Tmodel);
                JscriptPrint("修改成功啦！", "", "Success"); 
            }
            txtName.Text = "";
            txtDesc.Text = "";
            Response.Redirect("TagCateList.aspx");
        }

        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            chkLoginLevel("delKeyClass");
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((Label)rptList.Items[i].FindControl("lb_id")).Text);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cb_id");
                if (cb.Checked)
                {
                    Tbll.Delete(id);
                }
            }
            JscriptPrint("批量删除成功啦！", "", "Success");
            RptBind();
        }
    }
}

﻿using System;
using System.Data;
using System.Web;
using Spread.Web.UI;

namespace Spread.Web.Admin.Directory
{
    public partial class Add : ManagePage
    {
        private Spread.BLL.MenuDirectory bll = new Spread.BLL.MenuDirectory();
        private Spread.Model.MenuDirectory model = new Spread.Model.MenuDirectory();
        public int pId;    //栏目父ID
        public string pTitle = "顶级应用分类";
        protected void Page_Load(object sender, EventArgs e)
        {
            chkLoginLevel("addMenuDirectory");

            if (int.TryParse(Request.Params["classId"], out pId))
            {
                pTitle = bll.GetMenuTitle(pId);
            }
            else
            {
                pId = 0;
            }
            lblPid.Text = pId.ToString();
            lblPname.Text = pTitle;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int classId;
            int parentId = int.Parse(this.lblPid.Text.Trim());          //上一级目录
            long MenuId = long.Parse(this.lblCatalodId.Text.Trim());
            int classLayer = 1;                                         //栏目深度
            string classList = "";


            model.MenuID = MenuId;
            model.Title = this.txtTitle.Text.Trim();
            model.ParentId = parentId;
            model.ClassList = "";
            model.ClassOrder = int.Parse(this.txtClassOrder.Text.Trim());
            model.IsShow = false;
            model.IsLock = false;
            model.IsMenu = false;
            model.ImgUrl = this.txtImgUrl.Text;
            model.LanguageType = "zh";
            if (cblItem.Items[0].Selected == true)
            {
                model.IsShow = true;
            }
            if (cblItem.Items[1].Selected == true)
            {
                model.IsMenu = true;
            }
            if (cblItem.Items[2].Selected == true)
            {
                model.IsLock = true;
            }

            //添加栏目
            classId = bll.Add(model);
            //修改栏目的下属栏目ID列表
            if (parentId > 0)
            {
                DataSet ds = bll.GetMenuListByClassId(parentId);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    classList = dr["ClassList"].ToString().Trim() + classId + ",";
                    classLayer = Convert.ToInt32(dr["ClassLayer"]) + 1;
                }
            }
            else
            {
                classList = "," + classId + ",";
                classLayer = 1;
            }
            model.Id = classId;
            model.ClassList = classList;
            model.ClassLayer = classLayer;
            bll.Update(model);

            JscriptPrint("增加应用栏目成功啦！", "List.aspx", "Success");
        }
    }
}

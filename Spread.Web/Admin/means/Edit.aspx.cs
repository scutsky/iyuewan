﻿using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spread.Common;

namespace Spread.Web.Admin.means
{
    public partial class Edit : Spread.Web.UI.ManagePage
    {
        public int Id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.Params["id"] as string, out this.Id))
            {
                JscriptMsg(350, 230, "错误提示", "<b>出现错误啦！</b>您要修改的信息不存在或参数不正确。", "back", "Error");
                return;
            }
            if (!Page.IsPostBack)
            {
                chkLoginLevel("editMeans");             
                ShowInfo(this.Id);
            }
        }

        
        
        //赋值操作
        private void ShowInfo(int _id)
        {
            Spread.BLL.Means bll = new Spread.BLL.Means();
            Spread.Model.Means model = bll.GetModel(_id);
            txtTitle.Text = model.Title;
            txtForm.Text = model.Form;
            ddlClassId.SelectedValue = model.ClassId.ToString();
            txtImgUrl.Text = model.ImgUrl;
            lbFile.Text = model.Zhaiyao;
        }

        //保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Spread.BLL.Means bll = new Spread.BLL.Means();
            Spread.Model.Means model = bll.GetModel(this.Id);
            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(Server.MapPath("~/UpLoadFiles/Files/") + FileUpload1.FileName);

            } 
            model.Title = txtTitle.Text.Trim();
            model.Form = txtForm.Text.Trim();
            model.ClassId = int.Parse(ddlClassId.SelectedValue);
            model.ImgUrl = txtImgUrl.Text.Trim();
            model.AddTime = DateTime.Now;
            if (FileUpload1.HasFile)
            {
                model.Zhaiyao = "/UpLoadFiles/Files/" + FileUpload1.FileName;
            }
            else
            {
                model.Zhaiyao = lbFile.Text;
            }
            model.IsMsg = false;
            model.IsTop = false;
            model.IsRed = false;
            model.IsHot = false;
            model.IsSlide = false;
            model.LanguageType = "zh";

            model.IsMsg = false;
            model.IsTop = false;
            model.IsRed = false;
            model.IsHot = false;
            model.IsSlide = false;

            bll.Update(model);
            JscriptPrint("应用编辑成功啦！", "List.aspx", "Success");
        }

    }
}



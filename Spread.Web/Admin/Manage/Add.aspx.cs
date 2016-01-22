using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Spread.Web.Admin.Manage
{
    public partial class add : Spread.Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                chkLoginLevel("addManage");
            
            }
        }

        //保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Spread.Model.Admin model = new Spread.Model.Admin();
            Spread.BLL.Admin bll = new Spread.BLL.Admin();
            string userLevel = string.Empty;
            string userName = txtUserName.Text.Trim();
            string userPwd = Spread.Common.DESEncrypt.Encrypt(txtUserPwd.Text.Trim(), Spread.Common.Param.EncCode);
            string readName = txtReadName.Text.Trim();
            string userEmail = txtUserEmail.Text.Trim();
            int userType = 1;// Convert.ToInt32(rblUserType.SelectedValue);
            bool isLock = Convert.ToBoolean(rblIsLock.SelectedValue);
            if (bll.Exists(userName))
            {
                JscriptMsg(350, 230, "错误提示", "<b>出现错误了！</b>用户名已存在，请输入别的管理帐号吧！", "", "Error");
                return;
            }
            if (userType > 1)
            {
                userLevel = "," + Request.Form["cbLevel"].Trim() + ",";
            }

            model.UserName = userName;
            model.UserPwd = userPwd;
            model.ReadName = readName;
            model.UserEmail = userEmail;
            model.UserType = userType;
            model.IsLock = isLock;
            model.UserLevel = userLevel;

            bll.Add(model);
            JscriptPrint("添加管理员成功啦！", "list.aspx", "Success");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Web;

namespace Shannon.Web.Admin.Tools
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    public class AjaxTool : IHttpHandler
    {
        string type;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string _results = "";
            try
            {
                type = Convert.ToString(context.Request["type"]);
                switch (type)
                {
                    #region 商品推广相关
                    case "addtuguang": _results = AddTuGuang(context); break;//新增推广商品
                    #endregion
                }
            }
            catch (Exception ex)
            {
                _results = "";
                context.Response.Write(ex.Message + ex.ToString());
            }
            finally
            {
                context.Response.Write(_results);
                context.Response.End();
            }

        }

        #region 商品推广相关
        /// <summary>
        /// 新增推广商品
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string AddTuGuang(HttpContext context)
        {
            string result = "false";

            string numid = ""; 
            int channel = 0; 
            try
            {
                numid = context.Request["numid"].ToString();
                channel = int.Parse(context.Request["channel"]);
            }
            catch { }

            if (numid > 0 && channel > 0)
            {
                Shannon.Model.Products mod = new Shannon.Model.Products();
                mod.AddTime = System.DateTime.Now;
                mod.ClassId = channel;
                mod.Brand = numid;
                mod.Sort = new Shannon.BLL.Products().GetMaxSortID(channel);
                try
                {
                    new Shannon.BLL.Products().Add(mod);
                    result = "true";
                }
                catch { }
            }
            return result;
        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}

<%@ WebHandler Language="C#" Class="SendPhoneVerify" %>

using System;
using System.Data;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;
using System.Web;
using Spread.Common;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.SqlServer;
public class SendPhoneVerify : IHttpHandler {
    private string strMsg = "";
    private string rndstr = string.Empty;    //验证码
    public void ProcessRequest (HttpContext context) {
       
        try
        {
            string phone = context.Request.QueryString["phone"];
            Regex r = new Regex(@"(13[0-9]|18[0-9]|15[0-9]|147)\d{8}");
            if (!r.IsMatch(phone))
            {
                context.Response.Write("FALSE|手机号码有误");
                context.Response.End();
                return;
            }
            Random rnd = new Random();                          //随机发生器
           
            //测试时，将验证码统一设为0000
            rndstr = rnd.Next(111111, 999999).ToString();
            string msg = "您好，您收到安久手游推广平台的手机验证信息，验证码为：" + rndstr + "";
            bool isSend = SendMobileMsg(msg, phone);
            if (isSend)
            {
                HttpCookie VerifyCode = null;
                VerifyCode = new HttpCookie("MSMVerifyCode", rndstr.Trim());
                HttpContext.Current.Response.Cookies.Add(VerifyCode);
            }

        }
        catch
        {
            context.Response.Write("FALSE|发送错误");
            context.Response.End();
        }
        if (strMsg.Length > 0)
        {
            context.Response.Write(strMsg);
        }
        else
        {
            context.Response.Write("TRUE|" + rndstr + "");
        }

        context.Response.End();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

    public bool SendMobileMsg(string msgContent, string strPhones)
    {
        try
        {
            Spread.BLL.WebSet bll = new Spread.BLL.WebSet();
            Spread.Model.WebSet webset = new Spread.Model.WebSet();
            System.Web.HttpServerUtility httpmod = new HttpServerUtility();
            //string pathurl = httpmod.MapPath(System.Configuration.ConfigurationManager.AppSettings["WebSetpath"].ToString());
            //webset = bll.loadConfig(pathurl);
            string strUID = "500941270003";
            string strPWD = Function.MD5Encrypt("8281241214");
            string strSMSURL = "http://dxhttp.c123.cn/tx/";

            bool result = false;
            //string strPhones = string.Join(";", destListPhones.ToArray());
            //strPhones += ";";
            Encoding encoding = System.Text.Encoding.GetEncoding("UTF-8");

            string postData = string.Format("uid={0}&pwd={1}&mobile={2}&content={3}", strUID, strPWD, strPhones, msgContent);

            byte[] data = encoding.GetBytes(postData);

            // 定义 WebRequest
            HttpWebRequest myRequest =
           (HttpWebRequest)WebRequest.Create(strSMSURL);

            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = data.Length;

            Stream newStream = myRequest.GetRequestStream();

            //发送数据
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            // 得到 Response
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.Default);
            string content = reader.ReadToEnd();
          
            if (content == "100")
            { 
                result = true;
            }
            else
            {
                if (content == "101")
                {
                    strMsg = "FALSE|验证失败!";
                    result = false;
                }
                else if (content == "102")
                {
                    strMsg = "FALSE|短信不足!";
                    result = false;
                }
                else if (content == "103")
                {
                    strMsg = "FALSE|操作失败!";
                    result = false;
                }
                else if (content == "104")
                {
                    strMsg = "FALSE|非法字符!"; 
                    result = false;
                }
                else if (content == "105")
                {
                    strMsg = "FALSE|内容过多!"; 
                    result = false;
                }
                else if (content == "106")
                {
                    strMsg = "FALSE|号码过多!"; 
                    result = false;
                }
                else if (content == "107")
                {
                    strMsg = "FALSE|频率过快!";
                    result = false;
                }
                else if (content == "108")
                {
                    strMsg = "FALSE|号码内容空!";
                    result = false;
                }
                else if (content == "109")
                {
                    strMsg = "FALSE|账号冻结!"; 
                    result = false;
                }
                else if (content == "110")
                {
                    strMsg = "FALSE|禁止频繁单条发送!";
                    result = false;
                }
                else if (content == "111")
                {
                    strMsg = "FALSE|系统暂定发送!"; 
                    result = false;
                }
                else if (content == "112")
                {
                    strMsg = "FALSE|号码错误!"; 
                    result = false;
                }
                else if (content == "113")
                {
                    strMsg = "FALSE|定时时间格式不对!"; 
                    result = false;
                }
                else if (content == "114")
                {
                    strMsg = "FALSE|账号被锁，10分钟后登录!"; 
                    result = false;
                }
                else if (content == "115")
                {
                    strMsg = "FALSE|连接失败!";
                    result = false;
                }
                else if (content == "116")
                {
                    strMsg = "FALSE|禁止接口发送!"; 
                    result = false;
                }
                else if (content == "117")
                {
                    strMsg = "FALSE|绑定IP不正确!"; 
                    result = false;
                }
                else if (content == "120")
                {
                    strMsg = "FALSE|系统升级!"; 
                    result = false;
                }
                else
                {
                    strMsg = "发送失败!";
                    result = false;
                }
            }
            return result;
        }
        catch
        {
            return false;
        }

    }

}
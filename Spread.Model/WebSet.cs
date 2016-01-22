﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Spread.Model
{
    public class WebSet
    {
        private string _webname = "";
        private string _weburl = "";
        private string _webpath = "";
        private string _weblogpath = "";
        private string _webtel = "";
        private string _webfax = "";
        private string _webemail = "";
        private string _webqq1 = "";
        private string _webqq2 = "";
        private string _settlementCycle = "";
        private string _channelNum = "";
        private string _webcrod = "";
        private string _webcopyright = "";
        private string _webkeywords = "";
        private string _webdescription = "";
        private int _weblogstatus = 0;
        private string _webkillkeywords = "";
        private int _webprosize = 20;
        private int _webnewssize = 20;
        private string _webfilepath = "";
        private string _webfiletype = "";
        private int _webfilesize = 0;
        private int _isthumbnail = 0;
        private int _prowidth = 0;
        private int _prohight = 0;
        private int _iswatermark = 0;
        private int _watermarkstatus = 0;
        private int _imgquality = 80;
        private string _imgwaterpath = "";
        private int _imgwatertransparency = 0;
        private string _watertext = "";
        private string _waterfont = "";
        private int _fontsize = 12;
        private string _artmodelurl = "";
        private string _promodelurl = "";
        private string _downmodelurl = "";
        private string _uid = "";
        private string _pwd = "";
        private string _smsurl = "";
        /// <summary>
        ///  网站名称
        /// </summary>
        public string WebName
        {
            set { _webname = value; }
            get { return _webname; }
        }

        /// <summary>
        ///  网站地址
        /// </summary>
        public string WebUrl
        {
            set { _weburl = value; }
            get { return _weburl; }
        }

        /// <summary>
        ///  网站路径
        /// </summary>
        public string WebPath
        {
            set { _webpath = value; }
            get { return _webpath; }
        }

        /// <summary>
        ///  日志路径
        /// </summary>
        public string WeblogPath
        {
            set { _weblogpath = value; }
            get { return _weblogpath; }
        }

        /// <summary>
        ///  联系电话
        /// </summary>
        public string WebTel
        {
            set { _webtel = value; }
            get { return _webtel; }
        }

        /// <summary>
        ///  传真地址
        /// </summary>
        public string WebFax
        {
            set { _webfax = value; }
            get { return _webfax; }
        }

        /// <summary>
        ///  联系邮箱
        /// </summary>
        public string WebEmail
        {
            set { _webemail = value; }
            get { return _webemail; }
        }

        /// <summary>
        ///  联系QQ1
        /// </summary>
        public string WebQQ1
        {
            set { _webqq1 = value; }
            get { return _webqq1; }
        }

        /// <summary>
        ///  联系QQ2
        /// </summary>
        public string WebQQ2
        {
            set { _webqq2 = value; }
            get { return _webqq2; }
        }
        /// <summary>
        ///  结算周期
        /// </summary>
        public string SettlementCycle
        {
            set { _settlementCycle = value; }
            get { return _settlementCycle; }
        }
        /// <summary>
        ///  结算周期
        /// </summary>
        public string ChannelNum
        {
            set { _channelNum = value; }
            get { return _channelNum; }
        }
        /// <summary>
        ///  ICP备案
        /// </summary>
        public string WebCrod
        {
            set { _webcrod = value; }
            get { return _webcrod; }
        }

        /// <summary>
        ///  公司版权
        /// </summary>
        public string WebCopyright
        {
            set { _webcopyright = value; }
            get { return _webcopyright; }
        }

        /// <summary>
        /// 网站关健字
        /// </summary>
        public string WebKeywords
        {
            set { _webkeywords = value; }
            get { return _webkeywords; }
        }

        /// <summary>
        ///  网站描述
        /// </summary>
        public string WebDescription
        {
            set { _webdescription = value; }
            get { return _webdescription; }
        }

        /// <summary>
        /// 管理日志状态
        /// </summary>
        public int WebLogStatus
        {
            set { _weblogstatus = value; }
            get { return _weblogstatus; }
        }

        /// <summary>
        ///  脏话过滤
        /// </summary>
        public string WebKillKeywords
        {
            set { _webkillkeywords = value; }
            get { return _webkillkeywords; }
        }

        /// <summary>
        /// 网站产品分页数量
        /// </summary>
        public int WebProSize
        {
            set { _webprosize = value; }
            get { return _webprosize; }
        }

        /// <summary>
        /// 网站新闻分页数量
        /// </summary>
        public int WebNewsSize
        {
            set { _webnewssize = value; }
            get { return _webnewssize; }
        }

        /// <summary>
        /// 文件上传目录
        /// </summary>
        public string WebFilePath
        {
            set { _webfilepath = value; }
            get { return _webfilepath; }
        }

        /// <summary>
        /// 允许文件上传类型
        /// </summary>
        public string WebFileType
        {
            set { _webfiletype = value; }
            get { return _webfiletype; }
        }

        /// <summary>
        /// 允许文件上传大小
        /// </summary>
        public int WebFileSize
        {
            set { _webfilesize = value; }
            get { return _webfilesize; }
        }

        /// <summary>
        /// 是否生成产品缩略图
        /// </summary>
        public int IsThumbnail
        {
            set { _isthumbnail = value; }
            get { return _isthumbnail; }
        }

        /// <summary>
        /// 产品缩略图宽
        /// </summary>
        public int ProWidth
        {
            set { _prowidth = value; }
            get { return _prowidth; }
        }

        /// <summary>
        /// 产品缩略图高
        /// </summary>
        public int ProHight
        {
            set { _prohight = value; }
            get { return _prohight; }
        }

        /// <summary>
        /// 是否开启图片水印
        /// </summary>
        public int IsWatermark
        {
            set { _iswatermark = value; }
            get { return _iswatermark; }
        }

        /// <summary>
        /// 图片水印位置
        /// </summary>
        public int WatermarkStatus
        {
            set { _watermarkstatus = value; }
            get { return _watermarkstatus; }
        }

        /// <summary>
        /// 图片生成质量
        /// </summary>
        public int ImgQuality
        {
            set { _imgquality = value; }
            get { return _imgquality; }
        }

        /// <summary>
        /// 图片型水印文件
        /// </summary>
        public string ImgWaterPath
        {
            set { _imgwaterpath = value; }
            get { return _imgwaterpath; }
        }

        /// <summary>
        /// 图片水印透明度
        /// </summary>
        public int ImgWaterTransparency
        {
            set { _imgwatertransparency = value; }
            get { return _imgwatertransparency; }
        }

        /// <summary>
        /// 文字水印内容
        /// </summary>
        public string WaterText
        {
            set { _watertext = value; }
            get { return _watertext; }
        }

        /// <summary>
        /// 文字水印字体
        /// </summary>
        public string WaterFont
        {
            set { _waterfont = value; }
            get { return _waterfont; }
        }

        /// <summary>
        /// 文字水印字体大小
        /// </summary>
        public int FontSize
        {
            set { _fontsize = value; }
            get { return _fontsize; }
        }

        /// <summary>
        /// 文章模型链接地址
        /// </summary>
        public string ArtModelUrl
        {
            set { _artmodelurl = value; }
            get { return _artmodelurl; }
        }

        /// <summary>
        /// 产品模型链接地址
        /// </summary>
        public string ProModelUrl
        {
            set { _promodelurl = value; }
            get { return _promodelurl; }
        }

        /// <summary>
        /// 下载模型链接地址
        /// </summary>
        public string DownModelUrl
        {
            set { _downmodelurl = value; }
            get { return _downmodelurl; }
        }

        public string Uid
        {
            set { _uid = value; }
            get { return _uid; }
        }
        public string Pwd
        {
            set { _pwd = value; }
            get { return _pwd; }
        }
        public string Smsurl
        {
            set { _smsurl = value; }
            get { return _smsurl; }
        }
    }
}

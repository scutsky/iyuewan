using System;
using System.Collections.Generic;
using System.Text;

namespace Spread.Model
{
    /// <summary>
    /// 公司信息实体类
    /// </summary>
   ///
    [Serializable]
   public class contant
    {
        public contant()
        {
            // 构造函数
        }

        #region Model
        private int id;
        private int hits;
        private string name;
        private string adress;
        private string imgurl;
        private string contcont;

        /// <summary>
        /// id值
        /// 
        /// </summary>
        public int ID
        {
            set { id = value;}
            get { return id;}
        }
        /// <summary>
        /// id值
        /// 
        /// </summary>
        public int Hits
        {
            set { hits = value; }
            get { return hits; }
        }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string ContName
        {
            set { name = value; }
            get { return name; }
        }
        /// <summary>
        /// 公司网站
        /// </summary>
        public string ContAddres
        {
            set { adress = value; }
            get { return adress; }
        }
        /// <summary>
        /// 公司图片地址
        /// </summary>
        public string ContImage
        {
            set { imgurl = value;}
            get { return imgurl;}
        }
        /// <summary>
        /// 公司简介
        /// </summary>
        public string Contcont
        {
            set { contcont = value; }
            get { return contcont; }
        }
        #endregion Model
    }
}

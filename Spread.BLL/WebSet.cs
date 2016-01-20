using System;
using System.Collections.Generic;
using System.Text;
using cmsDal = Spread.DAL;
using cmsModel = Spread.Model;

namespace Spread.BLL
{
    public class WebSet
    {
        private readonly cmsDal.WebSet dal = new cmsDal.WebSet();

        /// <summary>
        ///  读取配置文件
        /// </summary>
        /// <param name="configFilePath"></param>
        /// <returns></returns>
        public cmsModel.WebSet loadConfig(string configFilePath)
        {
            return dal.loadConfig(configFilePath);
        }

        /// <summary>
        ///  保存配置文件
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="configFilePath"></param>
        /// <returns></returns>
        public cmsModel.WebSet saveConifg(cmsModel.WebSet mode, string configFilePath)
        {
            return dal.saveConifg(mode, configFilePath);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Spread.Common;
using cmsModel = Spread.Model;

namespace Spread.DAL
{
    public class WebSet
    {
        private static object lockHelper = new object();

        /// <summary>
        ///  读取配置文件
        /// </summary>
        /// <param name="configFilePath"></param>
        /// <returns></returns>
        public cmsModel.WebSet loadConfig(string configFilePath)
        {
            return (cmsModel.WebSet)SerializationHelper.Load(typeof(cmsModel.WebSet), configFilePath);
        }

        public cmsModel.WebSet saveConifg(cmsModel.WebSet mode, string configFilePath)
        {
            lock (lockHelper)
            {
                SerializationHelper.Save(mode, configFilePath);
                //Spread.Dal.Providers.webSetProvider.SetInstance(mode);
            }
            return mode;
        }
    }
}

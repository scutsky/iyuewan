using System;
using System.Collections.Generic;
using System.Text;
using Spread.DAL;
using Spread.Model;

namespace Spread.BLL
{
  
  public class contant
    {

      private readonly Spread.DAL.contant dal = new Spread.DAL.contant();  
      public contant()
      {
          // 构造函数
      }
        #region 成员方法
     /// <summary>
     /// 添加企业信息
     /// </summary>
     /// <param name="model"></param>
      public void Add(Spread.Model.contant model)
      {
          dal.Add(model);
      }
      /// <summary>
      /// 获取公司信息返回实体
      /// </summary>
      /// <returns></returns>
      public Spread.Model.contant model()
      {
          return dal.GetModel();
      }
      /// <summary>
      /// 修改公司信息
      /// </summary>
      /// <param name="modle"></param>
      public void update(Spread.Model.contant modle)
      {
          dal.update(modle);
      }
      /// <summary>
      /// 修改点击量
      /// </summary>
      /// <param name="modle"></param>
      public void updateHits()
      {
          dal.updateHits();
      }
      
        #endregion 成员方法

    }
}

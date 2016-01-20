using System;
using System.Collections.Generic;
using System.Text;
using Spread.DAL;
using Spread.Model;

namespace Spread.BLL
{
  public class theme
    {

      Spread.DAL.theme dal = new Spread.DAL.theme();
      public theme()
      {
          //
      }

      /// <summary>
      /// 添加联系方式
      /// </summary>
      /// <param name="model"></param>
      public void Add(Spread.Model.theme model)
      {
          dal.Add(model);
      }

      /// <summary>
      /// 查询返回实体类
      /// </summary>
      /// <returns></returns>
      public  Spread.Model.theme getmodel()
      {
          return dal.getmodel();
      }
      /// <summary>
      /// 修改企业信息
      /// </summary>
      /// <param name="model"></param>
      public void UPTADE(Spread.Model.theme model)
      {
          dal.update(model);
      }
      
    }
}

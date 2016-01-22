using System;
using System.Collections.Generic;
using System.Text;

namespace Spread.Model
{
  public  class theme
    {
      public theme()
      {
          //
      }

        #region Model
      private int id;
      private string contacts;
      private string postal;
      private string phone;
      private string tel;
      private string Fax;
      private string mail;
      private string adress;

      /// <summary>
      /// ID 值
      /// </summary>
      public int ID
      {
          set { id = value; }
          get { return id; }
      }

      /// <summary>
      /// 联系人
      /// </summary>
      public string Contacts
      {
          set { contacts = value; }
          get { return contacts; }
      }
      /// <summary>
      /// 邮编
      /// </summary>
      public string Postal
      {
          set { postal = value; }
          get { return postal; }
 
      }
      /// <summary>
      /// 联系手机
      /// </summary>
      public string Phone
      {
          set { phone = value; }
          get { return phone; }
      }
      /// <summary>
      /// 联系电话
      /// </summary>
      public string Tel
      {
          set { tel = value; }
          get { return tel; }
      }
      /// <summary>
      /// 传真
      /// </summary>
      public string fax
      {
          set { Fax = value; }
          get { return Fax; }
 
      } 
      /// <summary>
      ///邮箱
      /// </summary>
      public string Mail
      {
          set { mail = value; }
          get { return mail; }
      }
      /// <summary>
      /// 联系地址
      /// </summary>
      public string Adress
      {
          set { adress = value; }
          get { return adress; }
      }

    
        #endregion  Model



    }
}

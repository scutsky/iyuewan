using System.Text;
using System;
using System.Collections.Generic;

namespace Spread.Common
{
    public class HtmlPager
    {
        #region Url分页
        /// <summary>
        /// 前台构建分页样式A
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pages"></param>
        /// <param name="Url">注:Page由{page}代替</param>
        /// <returns></returns>
        public static string webPageHtmlA(int page, int pages,int total, string Url)
        {

            if (page < 1) page = 1;
            if (page > pages) page = pages;
            StringBuilder sb = new StringBuilder();

            if (pages > 1)
            {

                sb.AppendFormat("<a href=\"{0}\" >上一页</a>", Url.Replace("{page}", (page <= 1 ? 1 : page - 1).ToString()));

                if (pages > 10)
                {
                    if (page < 11)
                    {
                        for (int i = 1; i < 11; i++)
                        {
                            if (i == page)
                            {
                                sb.AppendFormat("<span>{0}</span>", i);
                            }
                            else
                            {
                                sb.AppendFormat("<a href=\"{0}\" >{1}</a>", Url.Replace("{page}", i.ToString()), i);
                            }
                        }
                        if (page == 10)
                        {
                            sb.AppendFormat("<a href=\"{0}\" >{1}</a>", Url.Replace("{page}", "11"), 11);
                        }
                        sb.Append("...");
                        sb.AppendFormat("<a href=\"{0}\" >{1}</a>", Url.Replace("{page}", pages.ToString()), pages);
                    }
                    else if (page < pages - 9 && page > 10)
                    {
                        sb.AppendFormat("<a href=\"{0}\" >{1}</a>", Url.Replace("{page}", "1"), 1);
                        sb.Append("...");
                        for (int i = -4; i < 5; i++)
                        {
                            if (i == 0)
                            {
                                sb.AppendFormat("<span>{0}</span>", page);
                            }
                            else
                            {
                                sb.AppendFormat("<a href=\"{0}\" >{1}</a>", Url.Replace("{page}", (page + i).ToString()), page + i);
                            }
                        }
                        sb.Append("...");
                        sb.AppendFormat("<a href=\"{0}\" >{1}</a>", Url.Replace("{page}", (pages).ToString()), pages);
                    }
                    else
                    {
                        sb.AppendFormat("<a href=\"{0}\" >{1}</a>", Url.Replace("{page}", "1"), 1);
                        sb.Append("...");
                        if (page == pages - 9)
                        {
                            sb.AppendFormat("<a href=\"{0}\" >{1}</a>", Url.Replace("{page}", (pages - 10).ToString()), pages - 10);
                        }
                        for (int i = -9; i < 1; i++)
                        {
                            if (pages + i == page)
                            {
                                sb.AppendFormat("<span>{0}</span>", page);
                            }
                            else
                            {
                                sb.AppendFormat("<a href=\"{0}\">{1}</a>", Url.Replace("{page}", (page + i).ToString()), page + i);
                            }
                        }
                    }
                   
                }
                else
                {
                    if (pages > 1)
                    {
                        for (int i = 1; i < pages + 1; i++)
                        {
                            if (i == page)
                            {
                                sb.AppendFormat("<span>{0}</span>", i);
                            }
                            else
                            {
                                sb.AppendFormat("<a href=\"{0}\">{1}</a>", Url.Replace("{page}", (i).ToString()), i);
                            }
                        }
                    }
                }
                sb.AppendFormat("<a href=\"{0}\">下一页</a>", Url.Replace("{page}", (page >= pages ? pages : page + 1).ToString()));
            }

            return sb.ToString();
        }

        public static string AdminPageHtmlB(int page, int pages, int total, string Url)
        {

            if (page < 1) page = 1;
            if (page > pages) page = pages;
            StringBuilder sb = new StringBuilder();

            if (pages > 1)
            {
                sb.AppendFormat("<span class=\"disabled\">总共有 {0} 条</span>", total);
               
                if (pages > 10)
                {
                    if (page > 1)
                    {
                        sb.AppendFormat("<a href=\"{0}\" class=\"disabled\">{1}</a>", Url.Replace("{page}", (page <= 1 ? 1 : page - 1).ToString()), "« 上一页");
                    }
                    else
                    {
                        sb.Append("<span class=\"disabled\">« 上一页</span>");
                    }
                    if (page < 11)
                    {
                        for (int i = 1; i < 11; i++)
                        {

                            if (i == page)
                            {
                                sb.AppendFormat("<span class=\"current\">{0}</span>", i);
                            }
                            else
                            {
                                sb.AppendFormat("<a href=\"{0}\" class=\"current\">{1}</a>", Url.Replace("{page}", i.ToString()), i);
                            }
                        }
                        if (page == 10)
                        {
                            sb.AppendFormat("<a href=\"{0}\" class=\"current\">{1}</a>", Url.Replace("{page}", "11"), 11);
                        }
                        sb.Append("<span>...</span>");
                        sb.AppendFormat("<a href=\"{0}\" class=\"current\">{1}</a>", Url.Replace("{page}", pages.ToString()), pages);
                    }
                    else if (page < pages - 9 && page > 10)
                    {
                        sb.AppendFormat("<a href=\"{0}\" class=\"current\">{1}</a>", Url.Replace("{page}", "1"), 1);
                        sb.Append("<span>...</span>");
                        for (int i = -4; i < 5; i++)
                        {
                            if (i == 0)
                            {
                                sb.AppendFormat("<span class=\"current\">{0}</span>", page);
                            }
                            else
                            {
                                sb.AppendFormat("<a href=\"{0}\" class=\"current\">{1}</a>", Url.Replace("{page}", (page + i).ToString()), page + i);
                            }
                        }
                        sb.Append("<span>...</span>");
                        sb.AppendFormat("<a href=\"{0}\" class=\"current\">{1}</a>", Url.Replace("{page}", (pages).ToString()), pages);
                    }
                    else
                    {
                        sb.AppendFormat("<a href=\"{0}\" class=\"current\">{1}</a>", Url.Replace("{page}", "1"), 1);
                        sb.Append("<span>...</span>");
                        if (page == pages - 9)
                        {
                            sb.AppendFormat("<a href=\"{0}\" class=\"current\">{1}</a>", Url.Replace("{page}", (pages - 10).ToString()), pages - 10);
                        }
                        for (int i = -9; i < 1; i++)
                        {
                            if (pages + i == page)
                            {
                                sb.AppendFormat("<span class=\"current\">{0}</span>", page);
                            }
                            else
                            {
                                sb.AppendFormat("<a href=\"{0}\" class=\"current\">{1}</a>", Url.Replace("{page}", (page + i).ToString()), page + i);
                            }
                        }
                    }

                    if (page < pages)
                    {
                        sb.AppendFormat("<a href=\"{0}\" class=\"disabled\">{1}</a>", Url.Replace("{page}", (page >= pages ? pages : page + 1).ToString()), "下一页 »");
                    }
                    else
                    {
                        sb.Append("<span class=\"disabled\">下一页 »</span>");
                    }
                }
                else
                {
                    if (pages > 1)
                    {
                        if (page > 1)
                        {
                            sb.AppendFormat("<a href=\"{0}\" class=\"disabled\">{1}</a>", Url.Replace("{page}", (page <= 1 ? 1 : page - 1).ToString()), "« 上一页");
                        }
                        else
                        {
                            sb.Append("<span class=\"disabled\">« 上一页</span>");
                        }
                        for (int i = 1; i < pages + 1; i++)
                        {
                            if (i == page)
                            {
                                sb.AppendFormat("<span class=\"current\">{0}</span>", i);
                            }
                            else
                            {
                                sb.AppendFormat("<a href=\"{0}\" class=\"current\">{1}</a>", Url.Replace("{page}", (i).ToString()), i);
                            }
                        }

                        if (page < pages)
                        {
                            sb.AppendFormat("<a href=\"{0}\" class=\"disabled\">{1}</a>", Url.Replace("{page}", (page >= pages ? pages : page + 1).ToString()), "下一页 »");
                        }
                        else
                        {
                            sb.Append("<span class=\"disabled\">下一页 »</span>");
                        }
                    }
                }
               
                sb.AppendFormat("<span  class=\"disabled\">{0}/{1}</span>", page, pages);
            }

            return sb.ToString();
        }
        #endregion
    }
}

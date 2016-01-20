using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;
namespace Spread.Common
{
    public class ReplaceString
    {
        /// <summary>
        /// 替换字符串中的字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="findPattern">用于查找的字符串</param>
        /// <param name="replacedBy">用于替换的字符串</param>
        public static string strReplace(string str, string findPattern, string replacedBy)
        {
            string result = string.Empty;
            string inputText = string.Empty;
            string replacement = replacedBy;
            string pat = findPattern;
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);

            try
            {
                inputText = str;
                if (r.IsMatch(inputText))
                {
                    result = r.Replace(inputText, replacement);
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
            return result;
        }

          /// <summary>
         /// 替换单个文件中字符串
         /// </summary>
         /// <param name="fileFullName">文件全名</param>
         ///<param name="findPattern">用于查找的字符串</param>
         /// <param name="replacedBy">用于替换的字符串</param>
         /// <param name="isBackup">是否备份文件</param>
         /// <call>Replacee.FileReplace("E:\\ttt\\ttt.html", textBox1.Text, textBox2.Text, true);</call>
         public static void FileReplace(string fileFullName, string findPattern, string replacedBy, bool isBackup)
         {
             string result = string.Empty;
             string inputText = string.Empty;
             string replacement = replacedBy;
             string pat = findPattern;
             Regex r = new Regex(pat, RegexOptions.IgnoreCase);

             try
             {
                 using (StreamReader sr = new StreamReader(fileFullName))
                 {
                     inputText = sr.ReadToEnd();
                 }

                 // Compile the regular expression.
                 if (r.IsMatch(inputText))
                 {
                     if (isBackup == true)
                     {
                         try
                         {
                             File.Copy(fileFullName, fileFullName + ".bak");
                         }
                         catch (System.IO.IOException ex)
                         {
                             File.Copy(fileFullName, fileFullName + ".bak", true);
                             Console.WriteLine(ex.Message);
                         }
                     }
                     result = r.Replace(inputText, replacement);

                     // Add some text to the file.
                     using (StreamWriter sw = new StreamWriter(fileFullName))
                     {
                         sw.Write(result);
                     }
                 }
                 Console.WriteLine(fileFullName);
             }
             catch (Exception e)
             {

                 Console.WriteLine("The process failed: {0}", e.ToString());
                 //throw(e);
             }
         }

         /// <summary>
         /// 遍历目录（替换整个目录下的文件中的字符串）
         /// </summary>
         /// <param name="path">起始路径</param>        
         /// <param name="findPattern">用于查找的字符串</param>
         /// <param name="replacedBy">用于替换的字符串</param>
         /// <param name="isBackup">是否备份文件</param>
         /// <param name="isGetSubFloder">是否获取子文件夹</param>
         /// <param name="type">要替换的文件的类型</param>
         /// <call>Replacee.PathReplace(@"E:\ttt", textBox1.Text, textBox2.Text, true, true, "*.html");</call>
         public static void PathReplace(string path, string findPattern, string replacedStr, bool isBackup, bool isGetSubFloder, string type)
         {
             Queue queue = new Queue();
             DirectoryInfo di = null;
             string subPath = string.Empty;
             string currentPath = string.Empty;
             FileSystemInfo[] dirs = null;

             queue.Enqueue(path);
             while (queue.Count > 0)
             {
                 currentPath = (string)queue.Dequeue();
                 di = new DirectoryInfo(currentPath);

                 //get files under current directiory
                 FileSystemInfo[] files = di.GetFiles(type);
                 foreach (FileSystemInfo f in files)
                 {
                     FileReplace(f.FullName, findPattern, replacedStr, isBackup);
                 }

                 // Get only subdirectories
                 if (isGetSubFloder == true)
                 {
                     dirs = di.GetDirectories();
                     foreach (FileSystemInfo d in dirs)
                     {
                         subPath = d.FullName;
                         queue.Enqueue(subPath);
                         Console.WriteLine(subPath);
                     }
                 }
             }
         }
    }
}

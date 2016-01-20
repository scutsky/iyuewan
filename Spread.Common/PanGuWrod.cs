using System;
using System.Collections.Generic;
using System.Text;
using PanGu;
using System.Diagnostics;

namespace Spread.Common
{
    /// <summary>
    /// 盘古分词
    /// </summary>
    public class PanGuWrod
    {
        private static PanGu.Match.MatchOptions _Options=new PanGu.Match.MatchOptions();
        private static PanGu.Match.MatchParameter _Parameters=new PanGu.Match.MatchParameter();
        /// <summary>
        /// 盘古分词
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string StrSplit(string str)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                Segment segment = new Segment();

                ICollection<WordInfo> words = segment.DoSegment(str, _Options, _Parameters);

                watch.Stop();

                StringBuilder wordsString = new StringBuilder();
                foreach (WordInfo wordInfo in words)
                {
                    if (wordInfo == null || wordInfo.Word.Length <= 1)
                    {
                        continue;
                    }
                    wordsString.AppendFormat("{0},", wordInfo.Word);
                }

                return wordsString.ToString().TrimEnd(',');
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

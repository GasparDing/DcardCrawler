using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace DcardCrawler.App
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpWebRequest request = WebRequest.Create("https://www.dcard.tw/f/sex") as HttpWebRequest;
            var response = request.GetResponse();
            string responseString = null;
            using (var stream = response.GetResponseStream())
            {
                using (var streamReader = new StreamReader(stream))
                    responseString = streamReader.ReadToEnd();
            }

            // html 跟 scripts 裡面都有, 但是scripts的好像比較好解

            MatchCollection TitleMatchs = Regex.Matches(responseString, @"(^<scripts>*$</scripts>)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            foreach (Match NextMatch in TitleMatchs)
            {
                //s = “< br >” NextMatch.Groups[1].Value;
                //TextBox1.Text = “\n” NextMatch.Groups[1].Value;
            }
        }
    }
}

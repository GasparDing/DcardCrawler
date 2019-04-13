using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace DcardCrawler.App.Data.Service
{
    public class ReadService : IReadService
    {
        public string ReadFromCategory()
        {
            HttpWebRequest request = WebRequest.Create("https://www.dcard.tw/f/sex?latest=true") as HttpWebRequest;
            var response = request.GetResponse();
            string responseString = null;
            using (var stream = response.GetResponseStream())
            {
                using (var streamReader = new StreamReader(stream))
                    responseString = streamReader.ReadToEnd();
            }

            //宣告 Regex 忽略大小寫
            Regex regex = new Regex("\"posts\":{\"store\".*\"anonymousDepartment\":.*}]", RegexOptions.IgnoreCase);
            //將比對後集合傳給 MatchCollection
            var match = regex.Matches(responseString).FirstOrDefault();
            if (match != null)
            {
                var json = match.ToString();
                if (json.Contains("\"posts\":{\"store\":"))
                {
                    // 只取出posts 底下的store陣列 也就是我們要的文章資訊
                    json = json.Replace("\"posts\":{\"store\":", "");
                    return json;
                }
            }

            return null;
        }
    }
}

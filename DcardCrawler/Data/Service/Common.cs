using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace DcardCrawler.App.Data.Service
{
    public static class Common
    {
        public static string GetWebResponseString(string url)
        {
            var request = WebRequest.Create(url) as HttpWebRequest;

            WebResponse response = null;
            try
            {
                response = request.GetResponse();
            }
            catch (Exception e)
            {
                //todo: 錯誤處理
            }

            if (response == null)
                return null;

            string responseString = null;
            using (var stream = response.GetResponseStream())
            {
                using (var streamReader = new StreamReader(stream))
                    responseString = streamReader.ReadToEnd();
            }

            return responseString;
        }
    }
}
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
            HttpWebRequest request = WebRequest.Create("https://www.dcard.tw/_api/forums/sex/posts?popular=false&limit=30") as HttpWebRequest;
            //HttpWebRequest request = WebRequest.Create("https://www.dcard.tw/_api/posts/231223641") as HttpWebRequest;

            WebResponse response = null;
            try
            {
                response = request.GetResponse();
            }
            catch(Exception e)
            {

            }

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
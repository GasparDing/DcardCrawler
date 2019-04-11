﻿using System;
using System.IO;
using System.Net;

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
        }
    }
}
using DcardCrawler.Data;
using DcardCrawler.Model;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcardCrawler.Test
{
    [TestFixture]
    public class MapperTest
    {
        private string Json;
        public MapperTest()
        {
            this.Json = File.ReadAllText("../../../PostJson.txt");
            Initial.AutoMapper();
        }

        [Test]
        public void GGGTset()
        {
            var model = JsonConvert.DeserializeObject<PostViewModel>(this.Json);
            var topic = Initial.Mapper.Map<Post>(model);
        }

    }
}

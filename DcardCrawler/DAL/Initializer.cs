using DcardCrawler.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcardCrawler.DAL
{
    public class Initializer : DropCreateDatabaseIfModelChanges<CrawlerDbContext>
    {
        protected override void Seed(CrawlerDbContext context)
        {
            var students = new List<Post>
            {
            new Post{Id="Carson"},
            new Post{Id="Mereth"},
            new Post{Id="Arturo"},
            new Post{Id="Gytis" },
            new Post{Id="Yan"   },
            new Post{Id="Peggy" },
            new Post{Id="Laura" },
            new Post{Id="Nino"  }
            };

            students.ForEach(s => context.Posts.Add(s));
            context.SaveChanges();
        }
    }
}

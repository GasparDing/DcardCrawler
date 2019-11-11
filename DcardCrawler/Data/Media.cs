using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DcardCrawler.Data
{
    public class Media
    {
        [Key]
        public int Id { get; set; }

        public string PostId { get; set; }

        public string Url { get; set; }
    }
}
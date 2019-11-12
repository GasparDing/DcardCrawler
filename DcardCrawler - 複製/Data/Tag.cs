using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DcardCrawler.Data
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        public string Value { get; set; }
    }
}

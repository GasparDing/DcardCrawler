using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DcardCrawler.Data
{
    public class MediaMeta
    {
        [Key]
        public string Id { get; set; }

        public string PostId { get; set; }

        public string Url { get; set; }
        public string NormalizedUrl { get; set; }
        public string Thumbnail { get; set; }
        public string Type { get; set; }


        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
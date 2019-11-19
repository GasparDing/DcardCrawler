namespace DcardCrawler.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Medium
    {
        public int Id { get; set; }

        [StringLength(128)]
        public string PostId { get; set; }

        public string Url { get; set; }

        public virtual Post Post { get; set; }
    }
}

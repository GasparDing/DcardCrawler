namespace DcardCrawler.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Topic")]
    public partial class Topic
    {
        public int Id { get; set; }

        public string Value { get; set; }

        [StringLength(128)]
        public string Post_Id { get; set; }

        public virtual Post Post { get; set; }
    }
}

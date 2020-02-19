namespace DcardCrawler.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PostHistory")]
    public partial class PostHistory
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string PostId { get; set; }

        public string Content { get; set; }

        public virtual Post Post { get; set; }
    }
}

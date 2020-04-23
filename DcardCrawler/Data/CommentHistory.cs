namespace DcardCrawler.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CommentHistory")]
    public partial class CommentHistory
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CommentId { get; set; }

        public string Cotent { get; set; }

        public virtual Comment Comment { get; set; }
    }
}

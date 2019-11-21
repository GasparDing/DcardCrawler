namespace DcardCrawler.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Meta")]
    public partial class Meta
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string PostId { get; set; }

        [StringLength(50)]
        public string CommentId { get; set; }

        public string Layout { get; set; }

        public virtual Comment Comment { get; set; }

        public virtual Post Post { get; set; }
    }
}

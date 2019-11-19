namespace DcardCrawler.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tag")]
    public partial class Tag
    {
        public int Id { get; set; }

        public string Value { get; set; }

        [StringLength(128)]
        public string MediaMeta_Id { get; set; }

        [StringLength(128)]
        public string Post_Id { get; set; }

        public virtual MediaMeta MediaMeta { get; set; }

        public virtual Post Post { get; set; }
    }
}

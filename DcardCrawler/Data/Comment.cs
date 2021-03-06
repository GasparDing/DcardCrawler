namespace DcardCrawler.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Comment()
        {
            CommentHistories = new HashSet<CommentHistory>();
            MediaMetas = new HashSet<MediaMeta>();
            Metas = new HashSet<Meta>();
        }

        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string PostId { get; set; }

        public bool Anonymous { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int Floor { get; set; }

        public string Content { get; set; }

        public int LikeCount { get; set; }

        public bool WithNickname { get; set; }

        public bool HiddenByAuthor { get; set; }

        public string Gender { get; set; }

        public string School { get; set; }

        public bool Host { get; set; }

        public string ReportReason { get; set; }

        public bool Hidden { get; set; }

        public bool InReview { get; set; }

        public string ReportReasonText { get; set; }

        public string PostAvatar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommentHistory> CommentHistories { get; set; }

        public virtual Post Post { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MediaMeta> MediaMetas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Meta> Metas { get; set; }
    }
}

namespace DcardCrawler.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Post")]
    public partial class Post
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Post()
        {
            Comments = new HashSet<Comment>();
            Media = new HashSet<Medium>();
            MediaMetas = new HashSet<MediaMeta>();
            Metas = new HashSet<Meta>();
            Tags = new HashSet<Tag>();
            Topics = new HashSet<Topic>();
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Excerpt { get; set; }

        public bool AnonymousSchool { get; set; }

        public bool AnonymousDepartment { get; set; }

        public bool Pinned { get; set; }

        public string ForumId { get; set; }

        public int? ReplyId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int CommentCount { get; set; }

        public int LikeCount { get; set; }

        public string SupportedReactions { get; set; }

        public bool WithNickname { get; set; }

        public string ReportReason { get; set; }

        public bool HiddenByAuthor { get; set; }

        public string ForumName { get; set; }

        public string ForumAlias { get; set; }

        public string Gender { get; set; }

        public string ReplyTitle { get; set; }

        public bool PersonaSubscriptable { get; set; }

        public bool Hidden { get; set; }

        public string CustomStyle { get; set; }

        public string Layout { get; set; }

        public bool WithImages { get; set; }

        public bool WithVideos { get; set; }

        public string ReportReasonText { get; set; }

        public string PostAvatar { get; set; }

        public string Reacted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medium> Media { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MediaMeta> MediaMetas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Meta> Metas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tag> Tags { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Topic> Topics { get; set; }
    }
}

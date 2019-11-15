using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DcardCrawler.Data
{
    public class Comment
    {
        [Key]
        public string Id { get; set; }
        public string PostId { get; set; }

        public bool Anonymous { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Floor { get; set; }
        public string Content { get; set; }
        public int LikeCount { get; set; }
        public bool WithNickname { get; set; }
        public bool HiddenByAuthor { get; set; }
        public string Gender { get; set; } //M, F
        public string School { get; set; }
        public bool Host { get; set; }
        public string ReportReason { get; set; }
        public bool Hidden { get; set; }
        public bool InReview { get; set; }
        public string ReportReasonText { get; set; }
        public string PostAvatar { get; set; }

        public virtual Meta Meta { get; set; }

        public virtual ICollection<MediaMeta> MediaMeta { get; set; }
    }
}

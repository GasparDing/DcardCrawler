using System;
using System.Collections.Generic;
using System.Text;

namespace DcardCrawler.Model
{
    public class CommentViewModel
    {
        public string Id { get; set; }

        public bool Anonymous { get; set; }

        public int PostId { get; set; }

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

        public bool Liked { get; set; }

        public string ReportReason { get; set; }

        public ICollection<MediaMetaViewModel> MediaMeta { get; set; }

        public bool CurrentMember { get; set; }

        public bool Hidden { get; set; }

        public bool InReview { get; set; }

        public string PostAvatar { get; set; }
    }
}

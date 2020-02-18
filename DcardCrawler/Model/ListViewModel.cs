using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DcardCrawler.Model
{
    public class MediaViewModel
    {
        public int Id { get; set; }
        
        public string PostId { get; set; }

        public string Url { get; set; }
    }

    public class ReactionViewModel
    {
        public string Id { get; set; }

        public int Count { get; set; }
    }

    public class MediaMetaViewModel
    {
        public string Id { get; set; }

        public string PostId { get; set; }

        public string CommentId { get; set; }

        public string Url { get; set; }

        public string NormalizedUrl { get; set; }

        public string Type { get; set; }

        public ICollection<string> Tags { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }

    public class ListViewModel
    {
        // url: https://www.dcard.tw/_api/posts/231084653

        [Key]
        public string Id { get; set; }

        public string Title { get; set; }

        public string Excerpt { get; set; }

        // 隱藏學校
        public bool AnonymousSchool { get; set; }

        public bool AnonymousDepartment { get; set; }

        public bool Pinned { get; set; }

        public string ForumId { get; set; }

        public string ReplyId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int CommentCount { get; set; }

        public int LikeCount { get; set; }

        public bool WithNickname { get; set; }

        public ICollection<string> Tags { get; set; }

        public ICollection<string> Topics { get; set; }

        public string ForumName { get; set; }

        public string ForumAlias { get; set; }

        // M男 F女 D管理者
        public string Gender { get; set; }

        public string ReplyTitle { get; set; }

        public string ReportReason { get; set; }

        public ICollection<MediaMetaViewModel> MediaMeta { get; set; }

        public ICollection<ReactionViewModel> Reactions { get; set; }

        public bool Hidden { get; set; }

        // 目前有的都是贊助文章
        public object CustomStyle { get; set; }

        public bool WithImages { get; set; }

        public bool WithVideos { get; set; }

        public ICollection<MediaViewModel> Media { get; set; }

        public string PostAvatar { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DcardCrawler.App.Data.Model
{
    public class MediaViewModel
    {
        private string url { get; set; }
        public string Url
        {
            get { return url; }
            set { this.url = Regex.Unescape(value); }
        }
    }

    public class MediaMetaViewModel
    {
        public string Id { get; set; }

        private string url { get; set; }
        public string Url
        {
            get { return this.url; }
            set { this.url = Regex.Unescape(value); }
        }

        private string normalizedUrl { get; set; }
        public string NormalizedUrl
        {
            get { return this.normalizedUrl; }
            set { this.normalizedUrl = Regex.Unescape(value); }
        }

        private string type { get; set; }
        public string Type
        {
            get { return this.type; }
            set { this.type = Regex.Unescape(value); }
        }

        public ICollection<string> Tags { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }

    public class ReactionViewModel
    {
        public string Id { get; set; }

        public int Count { get; set; }
    }

    public class StoreViewModel
    {
        public string CustomStyle { get; set; }

        // 摘要
        public string Excerpt { get; set; }

        // 隱藏學校
        public bool AnonymousSchool { get; set; }

        // M男 F女 D管理者
        public string Gender { get; set; }

        public ICollection<string> Topics { get; set; }

        public ICollection<MediaViewModel> Media { get; set; }

        public int? ReplyId { get; set; }

        public ICollection<MediaMetaViewModel> MediaMeta { get; set; }

        public bool Hidden { get; set; }

        public ICollection<ReactionViewModel> Reactions { get; set; }

        public string ForumName { get; set; }

        public string ReplyTitle { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string ForumAlias { get; set; }

        public int CommentCount { get; set; }

        public bool WithNickname { get; set; }

        public string Title { get; set; }

        public int LikeCount { get; set; }

        public bool Pinned { get; set; }

        public ICollection<string> Tags { get; set; }

        public string PostAvatar { get; set; }

        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string ForumId { get; set; }

        public bool WithImages { get; set; }

        public bool WithVideos { get; set; }

        public bool AnonymousDepartment { get; set; }
    }
}

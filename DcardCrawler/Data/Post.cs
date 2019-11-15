using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DcardCrawler.Data
{
    // todo: code first entity
    // https://docs.microsoft.com/zh-tw/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Excerpt { get; set; }

        // 隱藏學校
        public bool AnonymousSchool { get; set; }

        public bool AnonymousDepartment { get; set; }

        public bool Pinned { get; set; }

        public string ForumId { get; set; }

        public int? ReplyId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int CommentCount { get; set; }

        public int LikeCount { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }

        public string SupportedReactions { get; set; }

        public bool WithNickname { get; set; }

        public string ReportReason { get; set; }

        public bool HiddenByAuthor { get; set; }

        public virtual ICollection<Meta> Meta { get; set; }

        public string ForumName { get; set; }

        public string ForumAlias { get; set; }

        // M男 F女 D管理者
        public string Gender { get; set; }

        public string ReplyTitle { get; set; }

        public bool PersonaSubscriptable { get; set; }

        public bool Hidden { get; set; }

        public string CustomStyle { get; set; }

        public string Layout { get; set; } // classic

        public bool WithImages { get; set; }

        public bool WithVideos { get; set; }

        public virtual ICollection<Media> Media { get; set; }

        public string ReportReasonText { get; set; }

        public virtual ICollection<MediaMeta> MediaMeta { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public string PostAvatar { get; set; }

        public string Reacted { get; set; }

        //public bool Liked { get; set; }

        //public bool Subscribed { get; set; }

        //public bool Collected { get; set; }

        //public bool PersonaSubscribed { get; set; }

        //public bool Read { get; set; }

        //public bool NewComment { get; set; }

        //public bool CurrentMember { get; set; }

        //public virtual ICollection<ReactionViewModel> Reactions { get; set; }
    }
}

namespace DcardCrawler.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CrawlerDbContext : DbContext
    {
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<CommentHistory> CommentHistories { get; set; }
        public virtual DbSet<Medium> Media { get; set; }
        public virtual DbSet<MediaMeta> MediaMetas { get; set; }
        public virtual DbSet<Meta> Metas { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostHistory> PostHistories { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<Comment>()
                .Property(e => e.PostId)
                .IsUnicode(false);

            modelBuilder.Entity<CommentHistory>()
                .Property(e => e.CommentId)
                .IsUnicode(false);

            modelBuilder.Entity<Medium>()
                .Property(e => e.PostId)
                .IsUnicode(false);

            modelBuilder.Entity<MediaMeta>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<MediaMeta>()
                .Property(e => e.PostId)
                .IsUnicode(false);

            modelBuilder.Entity<MediaMeta>()
                .Property(e => e.CommentId)
                .IsUnicode(false);

            modelBuilder.Entity<Meta>()
                .Property(e => e.PostId)
                .IsUnicode(false);

            modelBuilder.Entity<Meta>()
                .Property(e => e.CommentId)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.PostHistories)
                .WithRequired(e => e.Post)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.Topics)
                .WithMany(e => e.Posts)
                .Map(m => m.ToTable("PostTopic").MapLeftKey("PostId").MapRightKey("TopicId"));

            modelBuilder.Entity<PostHistory>()
                .Property(e => e.PostId)
                .IsUnicode(false);

            modelBuilder.Entity<Tag>()
                .Property(e => e.PostId)
                .IsUnicode(false);

            modelBuilder.Entity<Tag>()
                .Property(e => e.MediaMetaId)
                .IsUnicode(false);

            modelBuilder.Entity<Topic>()
                .Property(e => e.Id)
                .IsUnicode(false);
        }
    }
}

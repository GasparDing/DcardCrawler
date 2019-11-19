namespace DcardCrawler.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CrawlerDbContext : DbContext
    {
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Medium> Media { get; set; }
        public virtual DbSet<MediaMeta> MediaMetas { get; set; }
        public virtual DbSet<Meta> Metas { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .HasMany(e => e.MediaMetas)
                .WithOptional(e => e.Comment)
                .HasForeignKey(e => e.Comment_Id);

            modelBuilder.Entity<MediaMeta>()
                .HasMany(e => e.Tags)
                .WithOptional(e => e.MediaMeta)
                .HasForeignKey(e => e.MediaMeta_Id);

            modelBuilder.Entity<Meta>()
                .HasMany(e => e.Comments)
                .WithOptional(e => e.Meta)
                .HasForeignKey(e => e.Meta_Id);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.Tags)
                .WithOptional(e => e.Post)
                .HasForeignKey(e => e.Post_Id);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.Topics)
                .WithOptional(e => e.Post)
                .HasForeignKey(e => e.Post_Id);
        }
    }
}

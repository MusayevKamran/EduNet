using AppEntity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace AppEntity
{
    public class EntityContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public virtual DbSet<ArticleCategory> ArticleCategories { get; set; }
        public virtual DbSet<ArticleImages> ArticleImages { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<AppUser> AppUsers { get; set; }


        public EntityContext(DbContextOptions<EntityContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppUser>()
               .HasMany<Article>(a => a.Article)
               .WithOne(b => b.AppUser)
               .HasPrincipalKey(c => c.Id);

            builder.Entity<AppUser>()
                .HasMany<Comment>(a => a.Comment)
                .WithOne(b => b.AppUser)
                .HasPrincipalKey(c => c.Id);


            builder.Entity<Article>()
                .HasMany<Comment>(a => a.Comment)
                .WithOne(b => b.Article)
                .HasPrincipalKey(c => c.Id);


            builder.Entity<ArticleCategory>()
                .HasKey(a => new { a.ArticleId, a.CategoryId });

            builder.Entity<ArticleCategory>()
                .HasOne(a => a.Article)
                .WithMany(b => b.ArticleCategory)
                .HasForeignKey(a => a.ArticleId);

            builder.Entity<ArticleCategory>()
                .HasOne(a => a.Category)
                .WithMany(b => b.ArticleCategory)
                .HasForeignKey(a => a.CategoryId);

            //Images relationship
            builder.Entity<ArticleImages>()
                   .HasKey(a => new { a.ArticleId, a.ImageId });

            builder.Entity<ArticleImages>()
                .HasOne(a => a.Article)
                .WithMany(b => b.Images)
                .HasForeignKey(a => a.ArticleId);

            base.OnModelCreating(builder);
        }
    }
}

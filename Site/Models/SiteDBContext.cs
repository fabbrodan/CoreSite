using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Site.Models
{
    public partial class SiteDBContext : DbContext
    {
        public SiteDBContext()
        {
        }

        public SiteDBContext(DbContextOptions<SiteDBContext> options)
            : base(options)
        {
        }

        public string ConnectionString { get; set; }

        public SiteDBContext(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }

        public virtual DbSet<Configuration> Configuration { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<FileCategories> FileCategories { get; set; }
        public virtual DbSet<Folders> Folders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Configuration>(entity =>
            {
                entity.HasKey(e => e.ConfigId)
                    .HasName("PK_Config");

                entity.Property(e => e.ConfigId).HasColumnName("ConfigID");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Value).HasMaxLength(100);
            });

            modelBuilder.Entity<Files>(entity =>
            {
                entity.HasKey(e => e.FileId).HasName("PK_File");
                entity.Property(e => e.FileName).HasMaxLength(100);
                entity.Property(e => e.UploadedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<FileCategories>(entity =>
            {
                entity.HasKey(e => e.CategoryId).HasName("PK_Category");
                entity.Property(e => e.CategoryLabel).HasMaxLength(50);
            });

            modelBuilder.Entity<Images>(entity =>
            {
                entity.HasKey(e => e.ImageId);

                entity.Property(e => e.ImgFileName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PublishedDate).HasColumnType("datetime");

                entity.Property(e => e.UploadedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Folders>(entity =>
            {
                entity.HasKey(e => e.FolderId);
                entity.Property(e => e.FolderName).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(80);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PasswordSalt)
                    .HasMaxLength(255);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserRootPath).HasMaxLength(100);
            });
        }
    }
}

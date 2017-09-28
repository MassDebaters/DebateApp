using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DebateApp.db
{
    public partial class DebateAppDBContext : DbContext
    {
        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"data source = sqlweeklenny1.database.windows.net; initial catalog = DebateAppDB; user id = lennylopez; password = ThisIsATemp42!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.ToTable("Accounts", "DebateApp");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Role).HasMaxLength(100);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.HasKey(e => e.PostId);

                entity.ToTable("Posts", "DebateApp");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_posts_accountId");
            });
        }
    }
}

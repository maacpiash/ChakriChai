using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace A4A.Data
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BusinessAgents> BusinessAgents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=master;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<BusinessAgents>(entity =>
            {
                entity.HasKey(e => e.BusinessId)
                    .HasName("PK_dbo.BusinessEntities");

                entity.Property(e => e.Balance).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.City).HasMaxLength(150);

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(150);

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.CurrentBalance).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.ReferredBy).HasMaxLength(50);

                entity.Property(e => e.SecurityCode).HasMaxLength(50);

                entity.Property(e => e.Smtppassword)
                    .HasColumnName("SMTPPassword")
                    .HasMaxLength(50);

                entity.Property(e => e.Smtpport).HasColumnName("SMTPPort");

                entity.Property(e => e.Smtpserver)
                    .HasColumnName("SMTPServer")
                    .HasMaxLength(50);

                entity.Property(e => e.Smtpusername)
                    .HasColumnName("SMTPUsername")
                    .HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(150);

                entity.Property(e => e.UpdatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.Zip).HasMaxLength(50);
            });
        }
    }
}

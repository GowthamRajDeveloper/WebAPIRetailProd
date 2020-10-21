using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPIRetailProduct.Model
{
    public partial class RetailProductsDataContext : DbContext
    {
        public RetailProductsDataContext()
        {
        }

        public RetailProductsDataContext(DbContextOptions<RetailProductsDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblProductDetails> TblProductDetails { get; set; }
        public virtual DbSet<TblProductOrderEntry> TblProductOrderEntry { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite(Startup.Connectionstring);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblProductDetails>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("tbl_productDetails");

                entity.Property(e => e.IsActive)
                    .HasColumnType("Boolean")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ProductName).IsRequired();

                entity.Property(e => e.Weight).HasColumnType("NUMERIC");
            });

            modelBuilder.Entity<TblProductOrderEntry>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("tbl_ProductOrderEntry");

                entity.Property(e => e.OrderDate).HasDefaultValueSql("current_timestamp");

                entity.Property(e => e.OrderStatus).HasDefaultValueSql("'Created'");

                entity.Property(e => e.ProductId).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

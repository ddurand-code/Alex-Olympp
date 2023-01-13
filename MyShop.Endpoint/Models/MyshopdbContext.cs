using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyShop.Endpoint.Models;

public partial class MyshopdbContext : DbContext
{
    public MyshopdbContext()
    {
    }

    public MyshopdbContext(DbContextOptions<MyshopdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Price> Prices { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost:2023;Database=myshopdb;Username=postgres;Password=password");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Price>(entity =>
        {
            entity.HasKey(e => e.Priceid).HasName("price_pkey");

            entity.ToTable("price");

            entity.Property(e => e.Priceid).HasColumnName("priceid");
            entity.Property(e => e.Pricevalue).HasColumnName("pricevalue");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Productid).HasName("product_pkey");

            entity.ToTable("product");

            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Priceid).HasColumnName("priceid");
            entity.Property(e => e.Productbrand)
                .HasMaxLength(40)
                .HasColumnName("productbrand");
            entity.Property(e => e.Productname)
                .HasMaxLength(40)
                .HasColumnName("productname");
            entity.Property(e => e.Productsize)
                .HasMaxLength(10)
                .HasColumnName("productsize");
            entity.Property(e => e.Quantityid).HasColumnName("quantityid");

            entity.HasOne(d => d.Price).WithMany(p => p.Products)
                .HasForeignKey(d => d.Priceid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product_priceid_fkey");

            entity.HasOne(d => d.Quantity).WithMany(p => p.Products)
                .HasForeignKey(d => d.Quantityid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product_quantityid_fkey");
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => e.Stockid).HasName("stock_pkey");

            entity.ToTable("stock");

            entity.Property(e => e.Stockid).HasColumnName("stockid");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

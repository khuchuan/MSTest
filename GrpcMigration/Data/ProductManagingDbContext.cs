using GrpcMigration.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;


namespace GrpcMigration.Data;


public class ProductManagingDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public const string DEFAULT_SCHEMA = "productconfig";

    public DbSet<Product> Products { get; set; }

    public ProductManagingDbContext(DbContextOptions<ProductManagingDbContext> options) : base(options) { }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.HasDefaultSchema(ProductManagingDbContext.DEFAULT_SCHEMA);

    //    modelBuilder.Entity<Product>(campaign =>
    //    {
    //        campaign.ToTable(nameof(Product));
    //        campaign.Property(x => x.ProductId).ValueGeneratedOnAdd();
    //        campaign.Property(x => x.ProductCode).HasMaxLength(128).IsRequired();
    //        campaign.Property(x => x.ProductName).HasMaxLength(512).IsRequired();
    //        campaign.Property(x => x.CreateTime).IsRequired();

    //        campaign.HasKey(x => x.ProductId);
    //    });

    //    base.OnModelCreating(modelBuilder);
    //}



}

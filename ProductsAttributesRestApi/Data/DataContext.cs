using Microsoft.EntityFrameworkCore;
using ProductsAttributesRestApi.Models.Entities;

namespace ProductsAttributesAPI.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasMany(a => a.Attributes)
            .WithMany(p => p.Products)
            .UsingEntity<ProductAttribute>(
                pa => pa.HasOne(prop => prop.Attribute).WithMany().HasForeignKey(prop => prop.AttributeId),
                pa => pa.HasOne(prop => prop.Product).WithMany().HasForeignKey(prop => prop.ProductId),
                pa => {
                    pa.HasKey(prop => new { prop.ProductId, prop.AttributeId });
                }
            );

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Attribute> Attributes { get; set; }
    public DbSet<ProductAttribute> ProductAttributes { get; set; }
}

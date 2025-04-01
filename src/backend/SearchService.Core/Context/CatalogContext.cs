using Microsoft.EntityFrameworkCore;
using SearchService.Core.Models;

public class CatalogContext : DbContext
{
    public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
    {
    }

    public DbSet<CategoryModel> Categories { get; set; }
    public DbSet<ProductModel> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CategoryModel>(entity =>
        {
            entity.ToTable("category");
            entity.HasKey(c => c.Id);

            entity.Property(c => c.Id).HasColumnName("id");
            entity.Property(c => c.Name).IsRequired().HasMaxLength(255).HasColumnName("name");
            entity.Property(c => c.Description).HasColumnType("TEXT").HasColumnName("description");
            entity.Property(c => c.Active).IsRequired().HasColumnName("active");
            entity.Property(c => c.CreatedAt).IsRequired().HasColumnType("TIMESTAMP").HasColumnName("createdat");
            entity.Property(c => c.UpdatedAt).IsRequired().HasColumnType("TIMESTAMP").HasColumnName("updatedat");
        });

        modelBuilder.Entity<ProductModel>(entity =>
        {
            entity.ToTable("product");
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Id).HasColumnName("id");
            entity.Property(p => p.Name).IsRequired().HasMaxLength(255).HasColumnName("name");
            entity.Property(p => p.Description).HasColumnType("TEXT").HasColumnName("description");
            entity.Property(p => p.Brand).HasMaxLength(255).HasColumnName("brand");
            entity.Property(p => p.Model).HasMaxLength(255).HasColumnName("model");
            entity.Property(p => p.Price).IsRequired().HasColumnType("DECIMAL(10, 2)").HasColumnName("price");
            entity.Property(p => p.Stock).IsRequired().HasColumnName("stock");
            entity.Property(p => p.Active).IsRequired().HasColumnName("active");
            entity.Property(p => p.CreatedAt).IsRequired().HasColumnType("TIMESTAMP").HasColumnName("createdat");
            entity.Property(p => p.UpdatedAt).IsRequired().HasColumnType("TIMESTAMP").HasColumnName("updatedat");
            entity.Property(p => p.CategoryId).HasColumnName("categoryid");

            entity.HasOne(p => p.Category)
                  .WithMany(c => c.Products)
                  .HasForeignKey(p => p.CategoryId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
    }
}

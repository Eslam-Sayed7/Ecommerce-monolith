
namespace Catalog.Data;

public class CatalogDbContext : DbContext
{
    public CatalogDbContext( DbContextOptions<CatalogDbContext> options)
        : base(options)
    {
    }

    private DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Catalog");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
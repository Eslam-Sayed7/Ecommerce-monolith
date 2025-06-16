namespace Catalog.Data.Seed;

public static class InitialData
{
    public static IEnumerable<Product> Products => new List<Product>
    {
        Product.Create(new Guid("d1b2c3f4-5e6f-7a8b-9c0d-e1f2g3h4i5j6"), 
                        "Apple iPhone 14", 
                       new List<string> { "Smartphones", "Electronics" }, 
                       "Latest model of Apple iPhone with advanced features.", 
                       999.99m, 
                       "iphone14.jpg"),
        Product.Create(new Guid("a1b2c3d4-e5f6-7g8h-9i0j-k1l2m3n4o5p6"), 
                        "Samsung Galaxy S23",
                          new List<string> { "Smartphones", "Electronics" },
                        "Latest model of Samsung Galaxy with advanced features.",
                        800.00m,
                        "galaxys23.jpg"),
        Product.Create(new Guid("f1e2d3c4-b5a6-7b8c-9d0e-f1g2h3i4j5k6"),
                        "Google Pixel 7",
                        new List<string> { "Smartphones", "Electronics" },
                        "Latest model of Google Pixel with advanced features.",
                        699.99m,
                        "pixel7.jpg")
    };
}
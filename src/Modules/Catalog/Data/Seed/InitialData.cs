namespace Catalog.Data.Seed;

public static class InitialData
{
    public static IEnumerable<Product> Products => new List<Product>
    {
        Product.Create(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61"), 
                        "Apple iPhone 14", 
                       new List<string> { "Smartphones", "Electronics" }, 
                       "Latest model of Apple iPhone with advanced features.", 
                       999.99m, 
                       "iphone14.jpg"),
        Product.Create(new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914"), 
                        "Samsung Galaxy S23",
                          new List<string> { "Smartphones", "Electronics" },
                        "Latest model of Samsung Galaxy with advanced features.",
                        800.00m,
                        "galaxys23.jpg"),
        Product.Create(new Guid("4f136e9f-ff8c-4c1f-9a33-d12f689bdab8"),
                        "Google Pixel 7",
                        new List<string> { "Smartphones", "Electronics" },
                        "Latest model of Google Pixel with advanced features.",
                        699.99m,
                        "pixel7.jpg")
    };
}
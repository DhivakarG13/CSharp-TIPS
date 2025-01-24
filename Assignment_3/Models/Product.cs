using Inventory.Helpers;

public class Product
{
    public string? ProductName { get; }
    public int ProductId { get; }
    public int Quantity { get; private set; }

    public Product(string? productName, int productQuantity,
              List<Product> ExistingProducts)
    {
        ProductName = productName;
        ProductId = IdGenerator.ProductIdGenerator(ExistingProducts); ;
        AddProducts(productQuantity);
    }

    internal void PrintProductData()
    {
        Console.WriteLine($"\nPRODUCT NAME       : {ProductName}");
        Console.WriteLine($"PRODUCT ID         : {ProductId}");
        Console.WriteLine($"AVAILABLE QUANTITY : {Quantity}\n");
    }

    public void AddProducts(int quantity)
    {
        Quantity += quantity;
    }

    public void FetchProducts(int quantity)
    {
        Quantity -= quantity;
    }
}
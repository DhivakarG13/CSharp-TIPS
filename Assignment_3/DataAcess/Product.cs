
using System.Collections.Generic;
using Inventory.Helpers;

public class Product
{
    private string? _productName;
    private int _productId;
    private int _quantity = 0;


    public Product(string? productName, int productQuantity,
        List<Product> ExistingProducts)
    {
        _productName = productName;
        _productId = IdGenerator.ProductIdGenerator(ExistingProducts); ;
        AddProducts(productQuantity);
    }

    public string? GetProductName() => _productName;
    public int GetProductId() => _productId;
    public int GetQuantity() => _quantity;

    public void AddProducts(int quantity)
    {
        _quantity += quantity;
    }
    public void FetchProducts(int quantity)
    {
        _quantity -= quantity;
    }

}
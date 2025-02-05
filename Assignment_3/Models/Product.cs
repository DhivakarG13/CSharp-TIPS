public class Product
{
    public string? ProductName { get; private set; }
    public int ProductId { get; private set; }
    public decimal? ProductPrice { get; private set; }
    public int Quantity { get; private set; } = 0;
    public DateOnly ExpiryDate { get; private set; }

    public Product(string? productName, int productQuantity,
              decimal productPrice ,int productId, DateOnly expiryDate)
    {
        SetProductName(productName);
        SetProductPrice(productPrice);
        SetProductQuantity(productQuantity);
        SetProductId(productId);
        SetProductExpiryDate(expiryDate);
    }

    public void SetProductName(string? productName)
    {
        ProductName = productName;
    }

    public void SetProductPrice(decimal productPrice)
    {
        ProductPrice = productPrice;
    }

    public void SetProductQuantity(int productQuantity)
    {
        Quantity = productQuantity; 
    }

    public void SetProductId(int productId)
    {
        ProductId = productId;
    }
    public void SetProductExpiryDate(DateOnly expiryDate)
    {
        ExpiryDate = expiryDate; 
    }
}
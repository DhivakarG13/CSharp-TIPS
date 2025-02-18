public class Product
{
    public string? ProductName { get; set; }
    public int ProductId { get; set; }
    public decimal? ProductPrice { get; set; }
    public int Quantity { get; set; } = 0;
    public DateOnly ExpiryDate { get; set; }

    public Product(string? productName, int productQuantity,
              decimal productPrice ,int productId, DateOnly expiryDate)
    {
        ProductName = productName;
        ProductPrice = productPrice;
        Quantity = productQuantity;
        ProductId = productId;
        ExpiryDate = expiryDate;
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
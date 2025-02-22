namespace Task_1
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public ProductCategory Category { get; set; }
        public Product(int productId , string productName, int productPrice, ProductCategory category)
        {
            ProductId = productId;
            ProductName = productName;
            ProductPrice = productPrice;
            Category = category;
        }
    }
        

}

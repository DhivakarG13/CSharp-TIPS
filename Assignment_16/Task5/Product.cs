namespace Task5
{
    public class Product
    {
        public string Name { get; set; }

        public ProductCategories Category { get; set; }

        public decimal Price { get; set; }

        public Product(string name, ProductCategories category, decimal price)
        {
            Name = name;
            Category = category;
            Price = price;
        }
        public static int CompareByName(Product product1, Product product2)
        {
            return product1.Name.CompareTo(product2.Name);
        }
        public static int CompareByCategory(Product product1, Product product2)
        {
            return product1.Category.CompareTo(product2.Category);
        }
        public static int CompareByPrice(Product product1, Product product2)
        {
            return product1.Price.CompareTo(product2.Price);
        }
    }
}

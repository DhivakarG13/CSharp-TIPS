namespace Task5
{
    public delegate int SortDelegate(Product product1, Product product2);
    public class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>() {
            new Product("Laptop", ProductCategories.Electronics, 500),
            new Product("T-Shirt", ProductCategories.Clothing, 20),
            new Product("Apple", ProductCategories.Food, 2)};
            SortDelegate sortDelegate = new SortDelegate(Product.CompareByName);
            products.Sort((product1, product2) => sortDelegate(product1, product2));

            foreach (Product product in products)
            {
                Console.WriteLine(product.Name);
            }
            Console.WriteLine();

            sortDelegate = Product.CompareByCategory;
            products.Sort((product1, product2) => sortDelegate(product1, product2));

            foreach (Product product in products)
            {
                Console.WriteLine(product.Name);
            }
            Console.WriteLine();

            sortDelegate -= Product.CompareByCategory;
            sortDelegate += Product.CompareByPrice;
            products.Sort((product1, product2) => sortDelegate(product1, product2));

            foreach (var product in products)
            {
                Console.WriteLine(product.Name);
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}

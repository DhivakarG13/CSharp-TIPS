namespace Task5
{
    public delegate int SortDelegate(Product product1, Product product2);
    public class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            products.Add(new Product("Laptop", ProductCategories.Electronics, 500));
            products.Add(new Product("T-Shirt", ProductCategories.Clothing, 20));
            products.Add(new Product("Apple", ProductCategories.Food, 2));

            SortDelegate sortDelegate = new SortDelegate(Product.CompareByName);
            products.Sort((product1, product2) => sortDelegate(product1, product2));
            foreach (var product in products)
            {
                Console.WriteLine(product.Name);
            }
            Console.WriteLine();
            sortDelegate = new SortDelegate(Product.CompareByCategory);
            products.Sort((product1, product2) => sortDelegate(product1, product2));
            foreach (var product in products)
            {
                Console.WriteLine(product.Name);
            }
            Console.WriteLine();
            sortDelegate = new SortDelegate(Product.CompareByPrice);
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

using System.ComponentModel;
using System.Diagnostics;

namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>() {
                new Product(1000, "Product1", 300, ProductCategory.Book) ,
                new Product(1001, "Product2", 400, ProductCategory.Electronics) ,
                new Product(1002, "Product3", 500, ProductCategory.Toys) ,
                new Product(1003, "Product4", 600, ProductCategory.Book) ,
                new Product(1004, "Product5", 700, ProductCategory.Electronics) ,
                new Product(1005, "Product6", 800, ProductCategory.Toys)
            }; 
            var newQueriedList = products
                .Where(product => product.Category == ProductCategory.Electronics && product.ProductPrice >= 500)
                .Select(newProduct => new { Name = newProduct.ProductName, Price = newProduct.ProductPrice });
            foreach (var product in newQueriedList)
            {
                Console.WriteLine($"ProductName : {product.Name} , ProductPrice : {product.Price}");
            }
            Console.ReadKey();
        }
    }
}

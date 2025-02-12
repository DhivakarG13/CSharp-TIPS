using Task_1;

namespace Task_2
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

            var groupedProductList = products
            .GroupBy(product => product.Category);


            foreach (var groupedProducts in groupedProductList)
            {
                foreach (var product in groupedProducts)
                {
                    Console.WriteLine($"ProductName : {product.ProductName} , ProductCategory : {product.Category}");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n\n");

            List<Supplier> suppliers = new List<Supplier>() { 
                new Supplier(2000 , "Supplier1" , 1005),
                new Supplier(2001 , "Supplier2" , 1004),
                new Supplier(2002 , "Supplier3" , 1003),
                new Supplier(2003 , "Supplier4" , 1002),
                new Supplier(2004 , "Supplier5" , 1000),
                new Supplier(2005 , "Supplier6" , 1000),
                new Supplier(2005 , "Supplier7" , 1002)
            };

            var JoinedSupplierList = suppliers.Join(products,
                supplier => supplier.ProductId,
                product => product.ProductId,
                (supplier, product) => new { SupplierName = supplier.SupplierName , 
                    SupplierId =supplier.SupplierId , ProductName = product.ProductName,
                    SupplierProductID = supplier.ProductId , ProductId = product.ProductId
                });

            Console.WriteLine("{0,15}  {1,15} {2,15} {3,15} {4,15}", "SupplierName", "SupplierId", "ProductName", "SupplierProductID", "ProductId");

            foreach (var item in JoinedSupplierList)
            {
                Console.WriteLine($"{item.SupplierName,15}  {item.SupplierId,15} {item.ProductName,15} {item.SupplierProductID,15} {item.ProductId,15}");
            }
            Console.ReadKey();
        }

    }

}
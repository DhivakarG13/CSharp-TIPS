using System.Collections.Generic;
using System.Linq;
using Task_1;
using Task_2;

namespace Task_5
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
            List<Supplier> suppliers = new List<Supplier>() {
                new Supplier(2000 , "Supplier1" , 1005),
                new Supplier(2001 , "Supplier2" , 1004),
                new Supplier(2002 , "Supplier3" , 1003),
                new Supplier(2003 , "Supplier4" , 1002),
                new Supplier(2004 , "Supplier5" , 1000),
                new Supplier(2005 , "Supplier6" , 1000),
                new Supplier(2005 , "Supplier7" , 1002)
            };

            var query = new QueryBuilder(products, suppliers);
        }
    }
    public class QueryBuilder
    {
        public List<Product> toBeOperatedProductList {  get; set; }
        public List<Supplier> toBeOperatedSupplierList {  get; set; }
        public List<Product> operatedList { get; set;}
        public QueryBuilder(List<Product> listOfProducts, List<Supplier> listOfSuppliers)
        {
            toBeOperatedProductList = listOfProducts;
            toBeOperatedSupplierList = listOfSuppliers;
            operatedList = new List<Product>();
        }
        public QueryBuilder Filter(Func<Product,bool> func)   // (p=>p.price>0)
        {
            operatedList = toBeOperatedProductList.Where(func).ToList();
            return this;
        }
        public QueryBuilder SortBy(Func<Product, decimal> func)
        {
            operatedList = operatedList.OrderBy(func).ToList();
            return this;
        }
        public QueryBuilder Join(Func<int ,bool> func1 , Func<int , bool> func2)
        {
            operatedList = operatedList.Join(toBeOperatedSupplierList, func1, func2, new List<Product> { new Product(0, null, 0, 0) });
            return this;
        }
        public List<Task_1.Product> Execute()
        {
            return operatedList;
        }
    }
}
//Implement a class called QueryBuilder with the following methods: 

//Filter: Accepts a lambda expression that represents a filter condition and adds it to the query. 

//SortBy: Accepts a lambda expression that represents the property to sort by and adds it to the query. 

//Join: Accepts a lambda expression that represents a join condition and adds it to the query. 

//Execute: Executes the constructed LINQ query and returns the result. 
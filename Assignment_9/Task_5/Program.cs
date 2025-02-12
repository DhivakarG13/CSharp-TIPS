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
        }
    }
    public class QueryBuilders
    {
        public List<Product> toBeOperatedList {  get; set; }
        public List<Product> operatedList { get; set;}

        

        public QueryBuilders(List<Product> listOfEntities)
        {
            toBeOperatedList = listOfEntities;
            operatedList = new List<Product>();
        }
        public QueryBuilders Filter(Func<Product,bool> func)   // (p=>p.price>0)
        {
            operatedList = toBeOperatedList.Where(func).ToList();
            return this;
        }
        public QueryBuilders SortBy(Func<Product, decimal> func)
        {
            operatedList = operatedList.OrderBy(func).ToList();
            return this;
        }
        public QueryBuilders Join(Func<Product, Supplier, bool> func)
        {
            return this;
        }
        public List<Task_1.Product> Execute()
        {
            return new List<Task_1.Product>();
        }
    }
}
//Implement a class called QueryBuilder with the following methods: 

//Filter: Accepts a lambda expression that represents a filter condition and adds it to the query. 

//SortBy: Accepts a lambda expression that represents the property to sort by and adds it to the query. 

//Join: Accepts a lambda expression that represents a join condition and adds it to the query. 

//Execute: Executes the constructed LINQ query and returns the result. 
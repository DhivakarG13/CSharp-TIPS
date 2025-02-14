using System.Linq;
using Task_1;
using Task_2;

namespace Task_5
{
    public class Program
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

            var query = new QueryBuilder<Product, Supplier>(products, suppliers);
        }
    }
    public class QueryBuilder<T1, T2> where T1 : class where T2 : class
    {
        public List<T1> toBeOperatedProductList { get; set; }
        public List<T2> toBeOperatedSupplierList { get; set; }
        public IEnumerable<T1> operatedList { get; set; }

        public QueryBuilder(List<T1> listOfProducts, List<T2> listOfSuppliers)
        {
            toBeOperatedProductList = listOfProducts;
            toBeOperatedSupplierList = listOfSuppliers;
            operatedList = new List<T1>();
        }

        public QueryBuilder<T1, T2> Filter(Func<T1, bool> func)
        {
            operatedList = toBeOperatedProductList.Where(func);
            return this;
        }

        public QueryBuilder<T1, T2> SortBy<T3>(Func<T1, T3> func)
        {
            operatedList = operatedList.OrderBy(func).ToList();
            return this;
        }

        public QueryBuilder<T1, T2> Join<T3>(Func<T3, T3, bool> func)
        {
            var resultList = from product in operatedList
                             join supplier in toBeOperatedSupplierList
                            on func()
                            select new { product, supplier };

            return this;
        }
        public IEnumerable<T1> Execute()
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
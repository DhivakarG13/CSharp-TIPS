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
            QueryBuilder<Product, Supplier> queryBuilder = new QueryBuilder<Product, Supplier>(products, suppliers);
            IEnumerable<object>? resultList = queryBuilder
                .Filter(product => product.ProductId > 1002)
                .SortBy(product => product.ProductPrice)
                .Filter(product => product.ProductPrice < 800)
                .Join((supplier, product) => supplier.SupplierProductId == product.ProductId)
                .Execute();

            foreach (var result in resultList)
            {
                var obj = result as dynamic; // Dynamic type to access anonymous properties
                Console.WriteLine($"{obj.Product.ProductName} supplied by {obj.Supplier.SupplierName}");
            }
            Console.ReadKey();
        }
    }
    public class QueryBuilder<T, TJoin>
    {
        private IEnumerable<object>? _result;
        private IEnumerable<T> _primaryList;
        private IEnumerable<TJoin> _joinList;

        public QueryBuilder(IEnumerable<T> primaryList, IEnumerable<TJoin> joinList)
        {
            _primaryList = primaryList;
            _joinList = joinList;
        }

        public QueryBuilder<T, TJoin> Filter(Func<T, bool> filter)
        {
            IEnumerable<T>? temp = _result as IEnumerable<T>;
            _result = _primaryList.Where(filter) as IEnumerable<object>;
            return this;
        }

        public QueryBuilder<T, TJoin> SortBy(Func<T, object> sortColumn)
        {
            IEnumerable<T>? temp = _result as IEnumerable<T>;
            _result = temp.OrderBy(sortColumn) as IEnumerable<object>;
            return this;
        }

        public QueryBuilder<T, TJoin> Join(Func<TJoin, T, bool> joinCondition)
        {
            var filteredPrimary = _result as IEnumerable<T>;
            _result = filteredPrimary
                .SelectMany(p => _joinList
                    .Where(s => joinCondition(s, p))
                    .Select(s => new { Product = p, Supplier = s })) as IEnumerable<object>;
            return this;
        }

        public IEnumerable<object>? Execute()
        {
            return _result;
        }

    }
}
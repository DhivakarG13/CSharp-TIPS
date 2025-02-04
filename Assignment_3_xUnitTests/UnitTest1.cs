using System.Collections.Generic;

namespace Assignment_3_xUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }
    }
}
namespace InventoryOptionsTests
{
    public class SearchByProductNameTests
    {
        [Fact]
        public void SearchByProductName_GetsListOfProductAndProductToSearch_ReturnsListMatchingProducts()
        {
            //Assign
            List<Product> testProducts = new List<Product>();
            testProducts.AddRange(new Product[] { new Product("Joey", 2004, 200, 10, DateOnly.MinValue),
                                                  new Product("Jake", 2004, 200, 10, DateOnly.MinValue),
                                                  new Product("John", 2004, 200, 10, DateOnly.MinValue),
                                                  new Product("Josh", 2004, 200, 10, DateOnly.MinValue),
                                                  new Product("Jester", 2004, 200, 10, DateOnly.MinValue),
                                                  new Product("Lester", 2004, 200, 10, DateOnly.MinValue)
                                                });
            List<Product> ExpectedProducts = new List<Product>();
            testProducts.AddRange(new Product[] { new Product("Jester", 2004, 200, 10,DateOnly.MinValue),
                                                  new Product("Lester", 2004, 200, 10, DateOnly.MinValue)
                                                });
            string? productNameToSearch = "ester";
            //Act
            List<Product> ActualProducts = InventoryOperations.SearchByProductName(testProducts, productNameToSearch);
            //Assert
            Assert.Equal(ActualProducts, ExpectedProducts);
        }
        [Fact]
        public void SearchByProductName_GetsListOfProductAndProductToSearch_ReturnsEmptyListIfNoSearchMatches()
        {
            //Assign
            List<Product> testProducts = new List<Product>();
            testProducts.AddRange(new Product[] { new Product("Joey", 2004, 200, 10, new DateOnly()),
                                                  new Product("Jake", 2004, 200, 10, new DateOnly()),
                                                  new Product("John", 2004, 200, 10, new DateOnly()),
                                                  new Product("Josh", 2004, 200, 10, new DateOnly()),
                                                  new Product("Jester", 2004, 200, 10, new DateOnly()),
                                                  new Product("Lester", 2004, 200, 10, new DateOnly())
                                                });
            List<Product> ExpectedProducts = new List<Product>();
            ExpectedProducts.Clear();
            List<Product> ActualProducts = new List<Product>();
            ActualProducts.Clear();
            string? productNameToSearch = "Shawn";

            //Act
            ActualProducts = InventoryOperations.SearchByProductName(testProducts, productNameToSearch);

            //Assert
            Assert.Equal(ActualProducts, ExpectedProducts);
        }
    }
}

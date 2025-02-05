namespace Assignment_3_xUnitTests.InventoryOperationsTests
{
    public class SearchByProductIdTests
    {
        [Fact]
        public void SearchByProductId_GetsListOfProductAndProductId_ReturnsListOfProductsWithMatchingProductID()
        {
            //Assign
            List<Product> testProducts = new List<Product>();
            testProducts.AddRange(new Product[] { new Product("Joey", 24, 200, 2004, DateOnly.MinValue),
                                                  new Product("Jake", 25, 200, 2005, DateOnly.MinValue),
                                                  new Product("John", 26, 200, 2006, DateOnly.MinValue),
                                                  new Product("Josh", 27, 200, 2007, DateOnly.MinValue),
                                                  new Product("Jester", 28, 200, 2008, DateOnly.MinValue),
                                                  new Product("Lester", 29, 200, 2009, DateOnly.MinValue)
                                                });
            List<Product> expectedProducts = new List<Product>();
            int productIDToSearch = 2008;

            expectedProducts.AddRange(new Product[] { testProducts[4] }); //new Product("Jester", 28, 200, 2008, DateOnly.MinValue),

            //Act
            List<Product> actualProducts = new List<Product>();
            actualProducts= InventoryOperations.SearchByProductId(testProducts, productIDToSearch);

            //Assert
            Assert.Equal(expectedProducts,actualProducts);

        }

        [Fact]
        public void SearchByProductId_GetsListOfProductAndProductId_ReturnsEmptyListOfProductsIfNoMatchingProductID()
        {
            //Assign
            List<Product> testProducts = new List<Product>();
            testProducts.AddRange(new Product[] { new Product("Joey", 24, 200, 2004, DateOnly.MinValue),
                                                  new Product("Jake", 25, 200, 2005, DateOnly.MinValue),
                                                  new Product("John", 26, 200, 2006, DateOnly.MinValue),
                                                  new Product("Josh", 27, 200, 2007, DateOnly.MinValue),
                                                  new Product("Jester", 28, 200, 2008, DateOnly.MinValue),
                                                  new Product("Lester", 29, 200, 2009, DateOnly.MinValue)
                                                });

            int productIDToSearch = 2018;

            int expectedProductsCount = 0;

            //Act
            List<Product> actualProducts = InventoryOperations.SearchByProductId(testProducts, productIDToSearch);

            //Assert
            Assert.Equal( expectedProductsCount , actualProducts.Count());

        }
    }
}

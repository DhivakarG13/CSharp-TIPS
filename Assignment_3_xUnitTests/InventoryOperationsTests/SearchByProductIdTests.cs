namespace Assignment_3_xUnitTests.InventoryOperationsTests
{
    public class SearchByProductIdTests
    {
        [Fact]
        public void SearchByProductId_GetsListOfProductAndProductId_ReturnsListOfProductsWithMatchingProductID()
        {
            //Assign
            List<Product> testProducts = new List<Product>();
            testProducts.AddRange(new Product[] { new Product("Joey", 2004, 200, 10, DateOnly.MinValue),
                                                  new Product("Jake", 2005, 200, 10, DateOnly.MinValue),
                                                  new Product("John", 2006, 200, 10, DateOnly.MinValue),
                                                  new Product("Josh", 2007, 200, 10, DateOnly.MinValue),
                                                  new Product("Jester", 2008, 200, 10, DateOnly.MinValue),
                                                  new Product("Lester", 2009, 200, 10, DateOnly.MinValue)
                                                });
            List<Product> expectedProducts = new List<Product>();
            int productIDToSearch = 2008;

            expectedProducts.AddRange(new Product[] { 
                                                  new Product("Jester", 2008, 200, 10, DateOnly.MinValue) 
                                                    });

            //Act
            List<Product> actualProducts = new List<Product>();
            actualProducts= InventoryOperations.SearchByProductId(testProducts, productIDToSearch);

            //Assert
            Assert.Equal(expectedProducts.Count(),actualProducts.Count());

        }

        [Fact]
        public void SearchByProductId_GetsListOfProductAndProductId_ReturnsEmptyListOfProductsIfNoMatchingProductID()
        {
            //Assign
            List<Product> testProducts = new List<Product>();
            testProducts.AddRange(new Product[] { new Product("Joey", 2004, 200, 10, DateOnly.MinValue),
                                                  new Product("Jake", 2005, 200, 10, DateOnly.MinValue),
                                                  new Product("John", 2006, 200, 10, DateOnly.MinValue),
                                                  new Product("Josh", 2007, 200, 10, DateOnly.MinValue),
                                                  new Product("Jester", 2008, 200, 10, DateOnly.MinValue),
                                                  new Product("Lester", 2009, 200, 10, DateOnly.MinValue)
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

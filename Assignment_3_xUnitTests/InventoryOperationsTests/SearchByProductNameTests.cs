namespace Assignment_3_xUnitTests.InventoryOperationsTests
{
    public class SearchByProductNameTests
    {
        [Fact]
        public void SearchByProductName_GetsListOfProductAndProductToSearch_ReturnsListMatchingProducts()
        {
            //Assign
            List<Product> testProducts = new List<Product>();
            testProducts.AddRange(new Product[] { new Product("Joey", 20, 200, 2004, DateOnly.MinValue),
                                                  new Product("Jake", 20, 200, 2005, DateOnly.MinValue),
                                                  new Product("John", 20, 200, 2005, DateOnly.MinValue),
                                                  new Product("Josh", 20, 200, 2005, DateOnly.MinValue),
                                                  new Product("Jester", 20, 200, 2008, DateOnly.MinValue),
                                                  new Product("Lester", 20, 200, 2009, DateOnly.MinValue)
                                                });

            string productNameToSearch = "ester";

            List<Product> expectedProducts = new List<Product>();
            expectedProducts.AddRange(new Product[] { new Product("Jester", 20, 200, 2008, DateOnly.MinValue),    
                                                  new Product("Lester", 20, 200, 2009, DateOnly.MinValue)
                                                });

            //Act
            List<Product> actualProducts = new List<Product>();
            actualProducts = InventoryOperations.SearchByProductName(testProducts, productNameToSearch);

            //Assert
            Assert.Equal(actualProducts.Count(), expectedProducts.Count());
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

            string? productNameToSearch = "Shawn";
            List<Product> expectedProducts = new List<Product>();

            //Act
            List<Product> actualProducts = InventoryOperations.SearchByProductName(testProducts, productNameToSearch);

            //Assert
            Assert.Equal(actualProducts.Count(), expectedProducts.Count());
        }
    }
}

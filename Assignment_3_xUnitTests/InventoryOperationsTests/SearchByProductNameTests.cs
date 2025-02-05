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
            expectedProducts.AddRange(new Product[] { testProducts[4],   //  new Product("Jester", 20, 200, 2008, DateOnly.MinValue)
                                                      testProducts[5]   //  new Product("Lester", 20, 200, 2009, DateOnly.MinValue)
                                                    });



            //Act
            List<Product> actualProducts = new List<Product>();
            actualProducts = InventoryOperations.SearchByProductName(testProducts, productNameToSearch);

            //Assert
            Assert.Equal(actualProducts, expectedProducts);
        }

        [Fact]
        public void SearchByProductName_GetsListOfProductAndProductToSearch_ReturnsEmptyListIfNoSearchMatches()
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

            string? productNameToSearch = "Shawn";
            List<Product> expectedProducts = new List<Product>();

            //Act
            List<Product> actualProducts = InventoryOperations.SearchByProductName(testProducts, productNameToSearch);

            //Assert
            Assert.Equal(actualProducts.Count(), expectedProducts.Count());
        }
    }
}

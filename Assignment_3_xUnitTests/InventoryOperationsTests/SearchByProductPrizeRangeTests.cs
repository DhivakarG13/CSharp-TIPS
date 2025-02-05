namespace Assignment_3_xUnitTests.InventoryOperationsTests
{
    public class SearchByProductPrizeRangeTests
    {
        [Fact]
        public void SearchByProductPrizeRange_GetsListOfProductMinAndMaxOfRange_ReturnsListOfProductsInTheRange()
        {
            //Assign
            List<Product> testProducts = new List<Product>();
            testProducts.AddRange(new Product[] { new Product("Joey", 20, 100, 2004, DateOnly.MinValue),
                                                  new Product("Jake", 20, 300, 2005, DateOnly.MinValue),
                                                  new Product("John", 20, 100, 2005, DateOnly.MinValue),
                                                  new Product("Josh", 20, 100, 2005, DateOnly.MinValue),
                                                  new Product("Jester", 20, 300, 2008, DateOnly.MinValue),
                                                  new Product("Lester", 20, 350, 2009, DateOnly.MinValue)
                                                });

            int minValue = 200;
            int maxValue = 400;

            List<Product> expectedProducts = new List<Product>();
            expectedProducts.AddRange(new Product[] { testProducts[1],    //  new Product("Jake", 20, 300, 2005, DateOnly.MinValue),
                                                      testProducts[4],   //  new Product("Jester", 20, 300, 2008, DateOnly.MinValue),
                                                      testProducts[5]   //  new Product("Lester", 20, 350, 2009, DateOnly.MinValue)
                                                    });    
                                                


            //Act
            List<Product> actualProducts = InventoryOperations.SearchByProductPrizeRange(testProducts, minValue, maxValue);

            //Assert
            Assert.Equal(actualProducts, expectedProducts);
        }

        [Fact]
        public void SearchByProductPrizeRange_GetsListOfProductMinAndMaxOfRange_ReturnsEmptyListOfProductsIfNoProductInTheRange()
        {
            //Assign
            List<Product> testProducts = new List<Product>();
            testProducts.AddRange(new Product[] { new Product("Joey", 20, 500, 2004, DateOnly.MinValue),
                                                  new Product("Jake", 20, 500, 2005, DateOnly.MinValue),
                                                  new Product("John", 20, 500, 2005, DateOnly.MinValue),
                                                  new Product("Josh", 20, 500, 2005, DateOnly.MinValue),
                                                  new Product("Jester", 20, 500, 2008, DateOnly.MinValue),
                                                  new Product("Lester", 20, 500, 2009, DateOnly.MinValue)
                                                });
            
            int minValue = 200;
            int maxValue = 400;

            List<Product> expectedProducts = new List<Product>();

            //Act
            List<Product> actualProducts = InventoryOperations.SearchByProductPrizeRange(testProducts, minValue, maxValue);

            //Assert
            Assert.Equal(actualProducts.Count(), expectedProducts.Count());
        }
    }
}

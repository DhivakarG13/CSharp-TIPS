namespace Assignment_3_xUnitTests.InventoryOperationsTests
{
    public class SearchByProductPrizeRangeTests
    {
        [Fact]
        public void SearchByProductPrizeRange_GetsListOfProductMinAndMaxOfRange_ReturnsListOfProductsInTheRange()
        {
            //Assign
            List<Product> testProducts = new List<Product>();
            testProducts.AddRange(new Product[] { new Product("Joey", 2004, 199, 10, DateOnly.MinValue),
                                                  new Product("Jake", 2005, 300, 10, DateOnly.MinValue),
                                                  new Product("John", 2006, 100, 10, DateOnly.MinValue),
                                                  new Product("Josh", 2007, 100, 10, DateOnly.MinValue),
                                                  new Product("Jester", 2009, 300, 10, DateOnly.MinValue),
                                                  new Product("Lester", 2010, 350, 10, DateOnly.MinValue)
                                                });

            int minValue = 200;
            int maxValue = 400;

            List<Product> expectedProducts = new List<Product>();
            testProducts.AddRange(new Product[] { testProducts[1],    //new Product("Jake", 2005, 300, 10, DateOnly.MinValue)
                                                  testProducts[4],    //new Product("Jester", 2009, 300, 10, DateOnly.MinValue)
                                                  testProducts[5] }); //new Product("Lester", 2010, 350, 10, DateOnly.MinValue)


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
            testProducts.AddRange(new Product[] { new Product("Joey", 2004, 500, 10, DateOnly.MinValue),
                                                  new Product("Jake", 2004, 500, 10, DateOnly.MinValue),
                                                  new Product("John", 2004, 500, 10, DateOnly.MinValue),
                                                  new Product("Josh", 2004, 500, 10, DateOnly.MinValue),
                                                  new Product("Jester", 2004, 500, 10, DateOnly.MinValue),
                                                  new Product("Lester", 2004, 500, 10, DateOnly.MinValue)
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

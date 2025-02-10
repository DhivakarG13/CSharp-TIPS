namespace Assignment_3_xUnitTests.InventoryOperationsTests
{
    public class SearchOperationsTests
    {
        [Theory]
        [InlineData(2004, 0)]
        [InlineData(2005, 1)]
        [InlineData(2006, 2)]
        [InlineData(2007, 3)]
        [InlineData(2008, 4)]
        [InlineData(2009, 5)]
        public void GivenProductsAndProductId_WhenSearchByProductId_ThenReturnsListOfMatchingProducts(int productIDToSearch, int matchingIndex)
        {
            List<Product> testProducts = GenerateProducts(6);
            List<Product> expectedProducts = new List<Product>();
            expectedProducts.AddRange(new Product[] { testProducts[matchingIndex] }); //new Product("Jester", 28, 200, 2008, DateOnly.MinValue),

            List<Product> actualProducts = new List<Product>();
            actualProducts = InventoryOperations.SearchByProductId(testProducts, productIDToSearch);

            Assert.Equal(expectedProducts, actualProducts);
        }

        [Theory]
        [InlineData(2014)]
        [InlineData(2025)]
        [InlineData(2035)]
        [InlineData(2046)]
        [InlineData(2557)]
        [InlineData(2078)]
        public void GivenProductsAndProductId_WhenSearchByProductId_ThenReturnsEmptyListIfNoMatchingProducts(int productIDToSearch)
        {
            List<Product> testProducts = GenerateProducts(5);
            List<Product> actualProducts = new List<Product>();

            actualProducts = InventoryOperations.SearchByProductId(testProducts, productIDToSearch);

            Assert.Empty(actualProducts);
        }

        [Theory]
        [InlineData(200, 201)]
        public void GivenProductsAndMinAndMaxOfRange_WhenSearchByProductPrizeRange_ThenReturnsListOfProductsInTheRange(int minValue = 200, int maxValue = 400)
        {
            List<Product> testProducts = GenerateProducts(11);
            List<Product> expectedProducts = new List<Product>();
            expectedProducts.AddRange(new Product[] { testProducts[0],
                                                      testProducts[1]   
                                                    });

            List<Product> actualProducts = InventoryOperations.SearchByProductPrizeRange(testProducts, minValue, maxValue);

            Assert.Equal(actualProducts, expectedProducts);
        }

        [Theory]
        [InlineData(2000, 4000)]
        [InlineData(3000, 4000)]
        [InlineData(9000, 10000)]
        public void GivenProductsAndMinAndMaxOfRange_WhenSearchByProductPrizeRange_ThenReturnsEmptyListIfNoProductsInTheRange(int minValue = 200, int maxValue = 400)
        {
            List<Product> testProducts = GenerateProducts(11);

            List<Product> actualProducts = InventoryOperations.SearchByProductPrizeRange(testProducts, minValue, maxValue);

            Assert.Empty(actualProducts);
        }

        [Theory]
        [InlineData("Product1")]
        public void GivenProductsAndProductName_WhenSearchByProductName_ThenReturnsListMatchingProducts(string productNameToSearch)
        {
            List<Product> testProducts = GenerateProducts(11);

            List<Product> expectedProducts = new List<Product>();
            expectedProducts.AddRange(new Product[] { testProducts[1],   
                                                      testProducts[10]   
                                                    });

            List<Product> actualProducts = new List<Product>();
            actualProducts = InventoryOperations.SearchByProductName(testProducts, productNameToSearch);

            Assert.Equal(actualProducts, expectedProducts);
        }

        [Theory]
        [InlineData("Comet")]
        public void GivenProductsAndProductName_WhenSearchByProductName_ThenReturnsEmptyListIfNoMatchingProducts(string productNameToSearch)
        {
            List<Product> testProducts = GenerateProducts(10);

            List<Product> actualProducts = new List<Product>();
            actualProducts = InventoryOperations.SearchByProductName(testProducts, productNameToSearch);

            Assert.Empty(actualProducts);
        }
        private List<Product> GenerateProducts(int countOfProducts)
        {
            List<Product> testProducts = new List<Product>();
            for (int index = 0; index < countOfProducts; index++)
            {
                testProducts.AddRange(new Product[] { new Product($"Product{index}", 20 + index, 200 + index, 2004 + index, DateOnly.MinValue) });
            }
            return testProducts;
        }

    }
}

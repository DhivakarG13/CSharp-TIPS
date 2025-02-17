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
        public void ProductsAndProductId_SearchByProductId_ReturnsListOfMatchingProducts(int productIDToSearch, int matchingIndex)
        {
            List<Product> testProducts = GenerateProducts(6);
            List<Product> expectedProducts = new List<Product>();
            expectedProducts.AddRange(new Product[] { testProducts[matchingIndex] });

            List<Product> actualProducts;
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
        public void ProductsAndProductId_SearchByProductId_ReturnsEmptyListIfNoMatchingProducts(int productIDToSearch)
        {
            List<Product> testProducts = GenerateProducts(5);
            List<Product> actualProducts;

            actualProducts = InventoryOperations.SearchByProductId(testProducts, productIDToSearch);

            Assert.Empty(actualProducts);
        }

        [Theory]
        [InlineData(2014)]
        [InlineData(2025)]
        [InlineData(2035)]
        [InlineData(2046)]
        [InlineData(2557)]
        [InlineData(2078)]
        public void ProductsAndProductId_SearchByProductId_ReturnsEmptyListIfRepositoryEmpty(int productIDToSearch)
        {
            List<Product> testProducts = GenerateProducts(0);
            List<Product> actualProducts;

            actualProducts = InventoryOperations.SearchByProductId(testProducts, productIDToSearch);

            Assert.Empty(actualProducts);
        }

        [Theory]
        [InlineData(200, 201)]
        public void ProductsAndMinAndMaxOfRange_SearchByProductPriceRange_ReturnsListOfProductsInTheRange(int minValue, int maxValue)
        {
            List<Product> testProducts = GenerateProducts(11);
            List<Product> expectedProducts = new List<Product>();
            expectedProducts.AddRange(new Product[] { testProducts[0],
                                                      testProducts[1]
                                                    });

            List<Product> actualProducts = InventoryOperations.SearchByProductPriceRange(testProducts, minValue, maxValue);

            Assert.Equal(expectedProducts, actualProducts);
        }

        [Theory]
        [InlineData(2000, 4000)]
        [InlineData(3000, 4000)]
        [InlineData(9000, 10000)]
        public void ProductsAndMinAndMaxOfRange_SearchByProductPriceRange_ReturnsEmptyListIfNoProductsInTheRange(int minValue = 200, int maxValue = 400)
        {
            List<Product> testProducts = GenerateProducts(11);

            List<Product> actualProducts = InventoryOperations.SearchByProductPriceRange(testProducts, minValue, maxValue);

            Assert.Empty(actualProducts);
        }

        [Theory]
        [InlineData(2000, 4000)]
        public void ProductsAndMinAndMaxOfRange_SearchByProductPriceRange_ReturnsEmptyListIfRepositoryEmpty(int minValue = 200, int maxValue = 400)
        {
            List<Product> testProducts = GenerateProducts(0);

            List<Product> actualProducts = InventoryOperations.SearchByProductPriceRange(testProducts, minValue, maxValue);

            Assert.Empty(actualProducts);
        }

        [Theory]
        [InlineData("Product1")]
        public void ProductsAndProductName_SearchByProductName_ReturnsListMatchingProducts(string productNameToSearch)
        {
            List<Product> testProducts = GenerateProducts(11);

            List<Product> expectedProducts = new List<Product>();
            expectedProducts.AddRange(new Product[] { testProducts[1],
                                                      testProducts[10]
                                                    });

            List<Product> actualProducts;
            actualProducts = InventoryOperations.SearchByProductName(testProducts, productNameToSearch);

            Assert.Equal(expectedProducts, actualProducts);
        }

        [Theory]
        [InlineData("Comet")]
        [InlineData("")]
        public void ProductsAndProductName_SearchByProductName_ReturnsEmptyListIfNoMatchingProducts(string productNameToSearch)
        {
            List<Product> testProducts = GenerateProducts(10);

            List<Product> actualProducts;
            actualProducts = InventoryOperations.SearchByProductName(testProducts, productNameToSearch);

            Assert.Empty(actualProducts);
        }

        [Theory]
        [InlineData("Product1")]
        public void ProductsAndProductName_SearchByProductName_ReturnsEmptyListIfRepositoryEmpty(string productNameToSearch)
        {
            List<Product> testProducts = GenerateProducts(0);

            List<Product> actualProducts;
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

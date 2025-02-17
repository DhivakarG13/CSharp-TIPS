using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Helpers;

namespace Assignment_3_xUnitTests.Utilities
{
    public class IdGenerateServiceTests
    {
        [Theory]
        [InlineData(2004)]
        [InlineData(2005)]
        [InlineData(2006)]
        public void Products_ProductIdGenerator_ReturnsUniqueId(int oldId)
        {
            List<Product> testProducts = GenerateProducts(3);

            int actualId = IdGenerateService.ProductIdGenerator(testProducts);

            Assert.DoesNotContain(actualId, testProducts.Select(p => p.ProductId));
            Assert.NotEqual(oldId, actualId);
            Assert.InRange(actualId, 1000, 10000);
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

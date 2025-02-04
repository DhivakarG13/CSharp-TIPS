namespace Assignment_3_xUnitTests.ModelsTest.ProductMethodsTests
{
    public class SetProductIdTests
    {
        [Fact]
        public void SetProductName_GetsAString_AssignsValueToProductName()
        {
            //Assign
            int productId = 4004;
            Product TestProduct = new Product("Joe", 2004, 200, 10, new DateOnly());
            //Act
            TestProduct.SetProductId(productId);
            //Assert
            Assert.Equal(productId, TestProduct.ProductId);
        }
    }

}

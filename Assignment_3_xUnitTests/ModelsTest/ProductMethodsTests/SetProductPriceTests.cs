namespace Assignment_3_xUnitTests.ModelsTest.ProductMethodsTests
{
    public class SetProductPriceTests
    {
        [Fact]
        public void SetProductPrice_GetsAString_AssignsValueToProductPrice()
        {
            //Assign
            int productPrice = 5000;
            Product TestProduct = new Product("Joe", 2004, 200, 10, new DateOnly());
            //Act
            TestProduct.SetProductPrice(productPrice);
            //Assert
            Assert.Equal(productPrice, TestProduct.ProductPrice);
        }
    }

}

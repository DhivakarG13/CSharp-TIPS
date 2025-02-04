namespace Assignment_3_xUnitTests.ModelsTest.ProductMethodsTests
{
    public class SetProductQuantityTests
    {
        [Fact]
        public void SetProductName_GetsAString_AssignsValueToProductName()
        {
            //Assign
            int productQuantity = 20;
            Product TestProduct = new Product("Joe", 2004, 200, 10, new DateOnly());
            //Act
            TestProduct.SetProductQuantity(productQuantity);
            //Assert
            Assert.Equal(productQuantity, TestProduct.Quantity);
        }
    }

}

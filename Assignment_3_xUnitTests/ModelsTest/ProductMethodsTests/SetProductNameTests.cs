namespace Assignment_3_xUnitTests.ModelsTest.ProductMethodsTests
{
    public class SetProductNameTests
    {
        [Fact]
        public void SetProductName_GetsAString_AssignsValueToProductName()
        {
            //Assign
            string productName = "Jack";
            Product TestProduct = new Product("Joe", 2004, 200, 10, new DateOnly());
            //Act
            TestProduct.SetProductName(productName);
            //Assert
            Assert.Equal(productName, TestProduct.ProductName);
        }
    }

}

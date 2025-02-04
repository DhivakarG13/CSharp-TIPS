namespace Assignment_3_xUnitTests.ModelsTest.ProductMethodsTests
{
    public class SetProductExpiryDateTests
    {
        [Fact]
        public void SetProductName_GetsAString_AssignsValueToProductName()
        {
            //Assign
            DateOnly productExpiryDate = new DateOnly();
            DateOnly.TryParse("10/12/2024", out productExpiryDate);

            Product TestProduct = new Product("Joe", 2004, 200, 10, new DateOnly());
            //Act
            TestProduct.SetProductExpiryDate(productExpiryDate);
            //Assert
            Assert.Equal(productExpiryDate, TestProduct.ExpiryDate);
        }
    }

}

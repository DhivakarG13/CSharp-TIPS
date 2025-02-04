namespace Assignment_3_xUnitTests.ValidationServiceTests
{
    public class ValidatePriceTests
    {
        [Fact]
        public void ValidatePrice_GetsPrice_ReturnsTrueForPositiveNumber()
        {
            //Assign
            string priceValue = "2000 ";

            //Act
            bool expectedResult = ValidationService.ValidatePrice(priceValue);

            //Assign
            Assert.True(expectedResult);

        }
        [Fact]
        public void ValidatePrice_GetsPrice_ReturnsFalseForNegativeNumber()
        {
            //Assign
            string priceValue = "-2000";

            //Act
            bool expectedResult = ValidationService.ValidatePrice(priceValue);

            //Assign
            Assert.False(expectedResult);

        }
        [Fact]
        public void ValidatePrice_GetsPrice_ReturnsFalseForInValidNumber()
        {
            //Assign
            string priceValue = "-2AB0";

            //Act
            bool expectedResult = ValidationService.ValidatePrice(priceValue);

            //Assign
            Assert.False(expectedResult);

        }
    }
}
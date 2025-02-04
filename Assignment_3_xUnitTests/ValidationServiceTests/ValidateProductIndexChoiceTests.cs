namespace Assignment_3_xUnitTests.ValidationServiceTests
{
    public class ValidateProductIndexChoiceTests
    {
        [Fact]
        public void ValidateProductIndexChoice_GetsChoiceAndTotalChoices_ReturnsTrueIfChoiceInRangeOfTotalElements()
        {
            //Arrange
            int totalElements = 5;
            string userChoice = "4";

            //Act
            bool actualResult = ValidationService.ValidateProductIndexChoice(userChoice, totalElements);

            //Assert
            Assert.True(actualResult);
        }
        [Fact]
        public void ValidateProductIndexChoice_GetsChoiceAndTotalChoices_ReturnsFalseForOutOfRangeChoice()
        {
            //Arrange
            int totalElements = 5;
            string userChoice = "10";

            //Act
            bool actualResult = ValidationService.ValidateProductIndexChoice(userChoice, totalElements);

            //Assert
            Assert.False(actualResult);
        }
        [Fact]
        public void ValidateProductIndexChoice_GetsChoiceAndTotalChoices_ReturnsFalseForNonNumericalValues()
        {
            //Arrange
            int totalElements = 5;
            string userChoice = "Hello";

            //Act
            bool actualResult = ValidationService.ValidateProductIndexChoice(userChoice, totalElements);

            //Assert
            Assert.False(actualResult);
        }
    }
}
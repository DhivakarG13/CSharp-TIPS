namespace Assignment_3_xUnitTests.ValidationServiceTests
{
    public class ValidateChoiceTests
    {
        [Fact]
        public void ValidateChoice_GetsChoiceAndListOfChoices_ReturnsTrueIfChoiceIsInChoices()
        {

            //Arrange
            List<int> choiceRange = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            string userChoice = "10";

            //Act
            bool actualResult = ValidationService.ValidateChoice(userChoice, choiceRange);

            //Assert
            Assert.True(actualResult);
        }
        [Fact]
        public void ValidateChoice_GetsChoiceAndAvailableChoice_ReturnsFalseForInValidChoice()
        {

            //Arrange
            List<int> choiceRange = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            string userChoice = "11";

            //Act
            bool actualResult = ValidationService.ValidateChoice(userChoice, choiceRange);

            //Assert
            Assert.False(actualResult);
        }
    }
}
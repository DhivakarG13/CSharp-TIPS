namespace Assignment_3_xUnitTests.ValidationServiceTests
{
    public class ValidateStringValueTests
    {
        [Fact]
        public void ValidateStringValue_GetsStringValue_ReturnsTrueForValidStringWithLengthGreaterThan2()
        {
            //Assign
            string stringValue = "Jack";
            //Act
            bool ExpectedValue = ValidationService.ValidateStringValue(stringValue);
            //Assert
            Assert.True(ExpectedValue);
        }
        [Fact]
        public void ValidateStringValue_GetsStringValue_ReturnsFalseForStringWithLengthLesserThan3()
        {
            //Assign
            string stringValue = "Is";
            //Act
            bool ExpectedValue = ValidationService.ValidateStringValue(stringValue);
            //Assert
            Assert.False(ExpectedValue);
        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ValidateStringValue_GetsStringValue_ReturnsFalseForNullAndEmptyString(string stringValue)
        {
            //Assign

            //Act
            bool ExpectedValue = ValidationService.ValidateStringValue(stringValue);
            //Assert
            Assert.False(ExpectedValue);
        }
    }
}
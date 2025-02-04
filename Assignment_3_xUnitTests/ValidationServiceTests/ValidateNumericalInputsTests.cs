namespace Assignment_3_xUnitTests.ValidationServiceTests
{
    public class ValidateNumericalInputsTests
    {

        [Fact]
        public void ValidateNumericalInputs_GetsNumericalValueAsString_ReturnsTrueIfValidNumber()
        {
            //Assign
            string numericalValue = "2000 ";

            //Act
            bool expectedResult = ValidationService.ValidateNumericalInputs(numericalValue);

            //Assign
            Assert.True(expectedResult);

        }

        [Fact]
        public void ValidateNumericalInputs_GetsNumericalValueAsString_ReturnsFalseIfNegativeInput()
        {
            //Assign
            string numericalValue = "-2000";

            //Act
            bool expectedResult = ValidationService.ValidatePrice(numericalValue);

            //Assign
            Assert.False(expectedResult);

        }

        [Fact]
        public void ValidateNumericalInputs_GetsNumericalValueAsString_ReturnsFalseIfNotANumber()
        {
            //Assign
            string numericalValue = "-2AB0";

            //Act
            bool expectedResult = ValidationService.ValidatePrice(numericalValue);

            //Assign
            Assert.False(expectedResult);

        }
    }
}
using System.Collections.Generic;

namespace Assignment_3_xUnitTests.Utilities
{
    public class ValidationServiceTests
    {
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("3")]
        [InlineData("4")]
        [InlineData("5")]
        [InlineData("6")]
        public void GivenChoiceAndListOfChoices_WhenValidateChoice_ThenReturnsTrueIfCorrectChoice(string userChoice)
        {

            List<int> choiceRange = new List<int>() { 1, 2, 3, 4, 5, 6 };

            bool actualResult = ValidationService.ValidateChoice(userChoice, choiceRange);

            Assert.True(actualResult);
        }

        [Theory]
        [InlineData("0")]
        [InlineData("7")]
        [InlineData("8")]
        [InlineData("9")]
        [InlineData("10")]
        [InlineData("11")]
        public void GivenChoiceAndListOfChoices_WhenValidateChoice_ThenReturnsFalseIfOutOfRangeChoice(string userChoice)
        {
            List<int> choiceRange = new List<int>() { 1, 2, 3, 4, 5, 6 };

            bool actualResult = ValidationService.ValidateChoice(userChoice, choiceRange);

            Assert.False(actualResult);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("8qw")]
        [InlineData("9 9")]
        [InlineData("1*1")]
        [InlineData("a")]
        public void GivenChoiceAndListOfChoices_WhenValidateChoice_ThenReturnsFalseIfInvalidNumber(string userChoice)
        {
            List<int> choiceRange = new List<int>() { 1, 2, 3, 4, 5, 6 };

            bool actualResult = ValidationService.ValidateChoice(userChoice, choiceRange);

            Assert.False(actualResult);
        }

        [Theory]
        [InlineData("0")]
        [InlineData("700")]
        [InlineData("823000")]
        [InlineData("009")]
        [InlineData("010")]
        public void GivenString_WhenValidateNumericalInputs_ThenReturnsTrueIfPositiveNumber(string numericalValue)
        {
            bool expectedResult = ValidationService.ValidateNumericalInputs(numericalValue);

            Assert.True(expectedResult);
        }

        [Theory]
        [InlineData("-700")]
        [InlineData("-823000")]
        [InlineData("-9")]
        [InlineData("-10")]
        public void GivenString_WhenValidateNumericalInputs_ThenReturnsFalseIfNegativeNumber(string numericalValue)
        {
            bool expectedResult = ValidationService.ValidatePrice(numericalValue);

            Assert.False(expectedResult);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("Ab0")]
        [InlineData("1*!")]
        [InlineData("Hello")]
        [InlineData("--1")]
        [InlineData("++100")]
        public void GivenString_WhenValidateNumericalInputs_ThenReturnsFalseIfParseFail(string numericalValue)
        {
            bool expectedResult = ValidationService.ValidatePrice(numericalValue);

            Assert.False(expectedResult);
        }

        [Theory]
        [InlineData("0")]
        [InlineData("700")]
        [InlineData("823000")]
        [InlineData("009")]
        [InlineData("010")]
        public void GivenString_WhenValidatePrice_ThenReturnsTrueIfValidPrice(string numericalValue)
        {
            bool expectedResult = ValidationService.ValidatePrice(numericalValue);

            Assert.True(expectedResult);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("Ab0")]
        [InlineData("1*!")]
        [InlineData("Hello")]
        [InlineData("--1")]
        [InlineData("++100")]
        public void GivenString_WhenValidatePrice_ThenReturnsFalseIfNotParseAble(string numericalValue)
        {
            bool expectedResult = ValidationService.ValidatePrice(numericalValue);

            Assert.False(expectedResult);
        }

        [Theory]
        [InlineData("-700")]
        [InlineData("-823000")]
        [InlineData("-9")]
        [InlineData("-10")]
        public void GivenString_WhenValidatePrice_ThenReturnsFalseIfNegativeNumber(string numericalValue)
        {
            bool expectedResult = ValidationService.ValidatePrice(numericalValue);

            Assert.False(expectedResult);
        }

        [Theory]
        [InlineData(5, "4")]
        [InlineData(6, "5")]
        [InlineData(1, "0")]
        [InlineData(100, "99")]
        public void GivenChoiceAndTotalChoices_WhenValidateProductIndexChoice_ThenReturnsTrueIfChoiceInRange(int totalElements, string userChoice)
        {
            bool actualResult = ValidationService.ValidateProductIndexChoice(userChoice, totalElements);

            Assert.True(actualResult);
        }

        [Theory]
        [InlineData(5, "5")]
        [InlineData(6, "-10")]
        [InlineData(1, "100")]
        [InlineData(100, "199")]
        public void GivenChoiceAndTotalChoices_WhenValidateProductIndexChoice_ThenReturnsFalseIfChoiceOutOfRange(int totalElements, string userChoice)
        {
            bool actualResult = ValidationService.ValidateProductIndexChoice(userChoice, totalElements);

            Assert.False(actualResult);
        }

        [Theory]
        [InlineData(6, "")]
        [InlineData(100, null)]
        [InlineData(5, "Hello")]
        [InlineData(1, "0*1")]
        [InlineData(100, "9 9")]
        [InlineData(100, "9_")]
        public void GivenChoiceAndTotalChoices_WhenValidateProductIndexChoice_ThenReturnsFalseIfChoiceNotParseAble(int totalElements, string userChoice)
        {
            bool actualResult = ValidationService.ValidateProductIndexChoice(userChoice, totalElements);

            Assert.False(actualResult);
        }

        [Theory]
        [InlineData("Hello")]
        [InlineData("0*1")]
        [InlineData("9 9")]
        [InlineData("Jack")]
        [InlineData("*****")]
        public void GivenStringValue_WhenValidateStringValue_ThenReturnsTrueIfStringLengthGreaterThan2(string stringValue)
        {
            bool ExpectedValue = ValidationService.ValidateStringValue(stringValue);

            Assert.True(ExpectedValue);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("Hi")]
        [InlineData("0")]
        [InlineData(" 9 ")]
        public void GivenStringValue_WhenValidateStringValue_ThenReturnsFalseIfStringLengthLesserThan3(string stringValue)
        {
            bool ExpectedValue = ValidationService.ValidateStringValue(stringValue);

            Assert.False(ExpectedValue);
        }

        [Theory]
        [InlineData("Jack")]
        [InlineData("  Joey  ")]
        [InlineData("Hunter")]
        public void GivenStringValue_WhenValidateProductName_ThenReturnsTrueIfValidName(string productName)
        {
            bool ExpectedValue = ValidationService.ValidateProductName(productName);

            Assert.True(ExpectedValue);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("Ja ck")]
        [InlineData("D")]
        [InlineData("1234")]
        public void GivenStringValue_WhenValidateProductName_ThenReturnsFalseIfInvalidName(string productName)
        {
            bool ExpectedValue = ValidationService.ValidateProductName(productName);

            Assert.False(ExpectedValue);
        }

        [Theory]
        [InlineData(1000)]
        [InlineData(2000)]
        [InlineData(3000)]
        [InlineData(4009)]
        [InlineData(5010)]
        public void GivenNewIdAndProducts_WhenValidateNewProductId_ThenReturnsTrueIfNewIdNotFoundInProducts(int NewId)
        {
            List<Product> testProducts = GenerateProducts(10);

            bool expectedResult = ValidationService.ValidateNewProductId(NewId, testProducts);

            Assert.True(expectedResult);
        }

        [Theory]
        [InlineData(2004)]
        [InlineData(2005)]
        [InlineData(2006)]
        [InlineData(2007)]
        [InlineData(2008)]
        [InlineData(2009)]
        public void GivenNewIdAndProducts_WhenValidateNewProductId_ThenReturnsFalseIfNewIdFoundInProducts(int NewId)
        {
            List<Product> testProducts = GenerateProducts(10);

            bool expectedResult = ValidationService.ValidateNewProductId(NewId, testProducts);

            Assert.False(expectedResult);
        }
        private List<Product> GenerateProducts(int countOfProducts)
        {
            List<Product> testProducts = new List<Product>();
            for(int index = 0;index < countOfProducts; index++)
            {
                testProducts.AddRange(new Product[] { new Product($"User{index}", 20 + index, 200 + index, 2004 + index, DateOnly.MinValue) });
            }
            return testProducts;
        }

    }
}
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
        [InlineData("6 ")]
        [InlineData(" 6")]
        public void ChoiceAndListOfChoices_ValidateChoice_ReturnsTrueIfChoiceInRange(string userChoice)
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
        public void ChoiceAndListOfChoices_ValidateChoice_ReturnsFalseIfOutOfRangeChoice(string userChoice)
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
        public void ChoiceAndListOfChoices_ValidateChoice_ReturnsFalseIfInvalidNumber(string userChoice)
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
        public void NumberAsStringToValidate_ValidateNumericalInputs_ReturnsTrueIfPositiveNumber(string numericalValue)
        {
            bool ActualResult = ValidationService.ValidateNumericalInputs(numericalValue);

            Assert.True(ActualResult);
        }

        [Theory]
        [InlineData("-700")]
        [InlineData("-823000")]
        [InlineData("-9")]
        [InlineData("-10")]
        public void NumberAsStringToValidate_ValidateNumericalInputs_ReturnsFalseIfNegativeNumber(string numericalValue)
        {
            bool actualResult = ValidationService.ValidateNumericalInputs(numericalValue);

            Assert.False(actualResult);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("Ab0")]
        [InlineData("1*!")]
        [InlineData("Hello")]
        [InlineData("--1")]
        [InlineData("++100")]
        public void NumberAsStringToValidate_ValidateNumericalInputs_ReturnsFalseIfParseFail(string numericalValue)
        {
            bool actualResult = ValidationService.ValidateNumericalInputs(numericalValue);

            Assert.False(actualResult);
        }

        [Theory]
        [InlineData("0")]
        [InlineData("700")]
        [InlineData("823000")]
        [InlineData("009")]
        [InlineData("010")]
        public void PriceAsStringToValidate_ValidatePrice_ReturnsTrueIfValidPrice(string numericalValue)
        {
            bool actualResult = ValidationService.ValidatePrice(numericalValue);

            Assert.True(actualResult);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("Ab0")]
        [InlineData("1*!")]
        [InlineData("Hello")]
        [InlineData("--1")]
        [InlineData("++100")]
        public void PriceAsStringToValidate_ValidatePrice_ReturnsFalseIfInvalidPrice(string numericalValue)
        {
            bool actualResult = ValidationService.ValidatePrice(numericalValue);

            Assert.False(actualResult);
        }

        [Theory]
        [InlineData("-700")]
        [InlineData("-823000")]
        [InlineData("-9")]
        [InlineData("-10")]
        public void PriceAsStringToValidate_ValidatePrice_ReturnsFalseIfNegativeNumber(string numericalValue)
        {
            bool actualResult = ValidationService.ValidatePrice(numericalValue);

            Assert.False(actualResult);
        }

        [Theory]
        [InlineData(5, "4")]
        [InlineData(6, "5")]
        [InlineData(1, "0")]
        [InlineData(100, "99")]
        public void ChoiceAndTotalChoices_ValidateProductIndexChoice_ReturnsTrueIfChoiceInRange(int totalElements, string userChoice)
        {
            bool actualResult = ValidationService.ValidateProductIndexChoice(userChoice, totalElements);

            Assert.True(actualResult);
        }

        [Theory]
        [InlineData(5, "5")]
        [InlineData(6, "-10")]
        [InlineData(1, "100")]
        [InlineData(100, "199")]
        public void ChoiceAndTotalChoices_ValidateProductIndexChoice_ReturnsFalseIfChoiceOutOfRange(int totalElements, string userChoice)
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
        public void ChoiceAndTotalChoices_ValidateProductIndexChoice_ReturnsFalseIfInvalidChoice(int totalElements, string userChoice)
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
        [InlineData("a**b*")]
        public void StringValueToValidate_ValidateStringValue_ReturnsTrueIfStringLengthGreaterThan2(string stringValue)
        {
            bool actualResult = ValidationService.ValidateStringValue(stringValue);

            Assert.True(actualResult);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("Hi")]
        [InlineData("0")]
        [InlineData(" 9 ")]
        public void StringValueToValidate_ValidateStringValue_ReturnsFalseIfStringLengthLesserThan3(string stringValue)
        {
            bool actualResult = ValidationService.ValidateStringValue(stringValue);

            Assert.False(actualResult);
        }

        [Theory]
        [InlineData("Jack")]
        [InlineData("  Joey  ")]
        [InlineData("Hunter")]
        public void ProductNameToValidate_ValidateProductName_ReturnsTrueIfValidName(string productName)
        {
            bool actualResult = ValidationService.ValidateProductName(productName);

            Assert.True(actualResult);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("Ja ck")]
        [InlineData("D")]
        [InlineData("1234")]
        public void ProductNameToValidate_ValidateProductName_ReturnsFalseIfInvalidName(string productName)
        {
            bool actualResult = ValidationService.ValidateProductName(productName);

            Assert.False(actualResult);
        }

        [Theory]
        [InlineData(1000)]
        [InlineData(2000)]
        [InlineData(3000)]
        [InlineData(4009)]
        [InlineData(5010)]
        public void NewIdAndProducts_ValidateNewProductId_ReturnsTrueIfNewIdNotFoundInProducts(int NewId)
        {
            List<Product> testProducts = GenerateProducts(10);

            bool actualResult = ValidationService.ValidateNewProductId(NewId, testProducts);

            Assert.True(actualResult);
        }

        [Theory]
        [InlineData(2004)]
        [InlineData(2005)]
        [InlineData(2006)]
        [InlineData(2007)]
        [InlineData(2008)]
        [InlineData(2009)]
        public void NewIdAndProducts_ValidateNewProductId_ReturnsFalseIfNewIdFoundInProducts(int NewId)
        {
            List<Product> testProducts = GenerateProducts(10);

            bool actualResult = ValidationService.ValidateNewProductId(NewId, testProducts);

            Assert.False(actualResult);
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
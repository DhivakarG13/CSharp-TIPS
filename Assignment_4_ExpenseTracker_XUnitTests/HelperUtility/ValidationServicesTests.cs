using Assignment_4_ExpenseTracker.HelperUtility;
using Assignment_4_ExpenseTracker.Models;
using Constants.Enumerations;
using Models;

namespace Assignment_4_ExpenseTracker_XUnitTests.HelperUtility
{
    internal class ValidationServicesTests
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

                bool actualResult = ValidationServices.ValidateChoice(userChoice, choiceRange);

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

                bool actualResult = ValidationServices.ValidateChoice(userChoice, choiceRange);

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

                bool actualResult = ValidationServices.ValidateChoice(userChoice, choiceRange);

                Assert.False(actualResult);
            }

            [Theory]
            [InlineData("Jacky")]
            [InlineData("  Joshua  ")]
            [InlineData("Hunter")]
            public void GivenStringValue_WhenValidateOtherSource_ThenReturnsTrueIfValidSourceName(string otherSource)
            {
                bool ExpectedValue = ValidationServices.ValidateOtherSource(otherSource);

                Assert.True(ExpectedValue);
            }

            [Theory]
            [InlineData("")]
            [InlineData(null)]
            [InlineData("Ja ck")]
            [InlineData("D")]
            [InlineData("1234")]
            public void GivenStringValue_WhenValidateOtherSource_ThenReturnsFalseIfInvalidSourceName(string otherSource)
            {
                bool ExpectedValue = ValidationServices.ValidateOtherSource(otherSource);

                Assert.False(ExpectedValue);
            }

            [Theory]
            [InlineData("-700")]
            [InlineData("-823000")]
            [InlineData("-9")]
            [InlineData("-10")]
            public void GivenString_WhenValidateAmount_ThenReturnsFalseIfNegativeNumber(string numericalValue)
            {
                bool expectedResult = ValidationServices.ValidateAmount(numericalValue);

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
            public void GivenString_WhenValidateValidateAmount_ThenReturnsFalseIfParseFail(string numericalValue)
            {
                bool expectedResult = ValidationServices.ValidateAmount(numericalValue);

                Assert.False(expectedResult);
            }

            [Theory]
            [InlineData("0")]
            [InlineData("700")]
            [InlineData("823000")]
            [InlineData("009")]
            [InlineData("010")]
            public void GivenString_WhenValidateAmount_ThenReturnsTrueIfValidAmount(string numericalValue)
            {
                bool expectedResult = ValidationServices.ValidateAmount(numericalValue);

                Assert.True(expectedResult);
            }

            [Theory]
            [InlineData("0")]
            [InlineData("700")]
            [InlineData("823000")]
            [InlineData("009")]
            [InlineData("010")]
            public void GivenString_WhenValidateNumericalInputs_ThenReturnsTrueIfPositiveNumber(string numericalValue)
            {
                bool expectedResult = ValidationServices.ValidateNumericalInputs(numericalValue);

                Assert.True(expectedResult);
            }

            [Theory]
            [InlineData("-700")]
            [InlineData("-823000")]
            [InlineData("-9")]
            [InlineData("-10")]
            public void GivenString_WhenValidateNumericalInputs_ThenReturnsFalseIfNegativeNumber(string numericalValue)
            {
                bool expectedResult = ValidationServices.ValidateNumericalInputs(numericalValue);

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
                bool expectedResult = ValidationServices.ValidateNumericalInputs(numericalValue);

                Assert.False(expectedResult);
            }

            [Theory]
            [InlineData("Hello")]
            [InlineData("0*1")]
            [InlineData("9 9")]
            [InlineData("Jack")]
            [InlineData("*****")]
            public void GivenStringValue_WhenValidateStringValue_ThenReturnsTrueIfStringLengthGreaterThan2(string stringValue)
            {
                bool expectedValue = ValidationServices.ValidateStringValue(stringValue);

                Assert.True(expectedValue);
            }

            [Theory]
            [InlineData("")]
            [InlineData(null)]
            [InlineData("Hi")]
            [InlineData("0")]
            [InlineData(" 9 ")]
            public void GivenStringValue_WhenValidateStringValue_ThenReturnsFalseIfStringLengthLesserThan3(string stringValue)
            {
                bool expectedValue = ValidationServices.ValidateStringValue(stringValue);

                Assert.False(expectedValue);
            }

            [Theory]
            [InlineData(2004)]
            [InlineData(2005)]
            [InlineData(2006)]
            [InlineData(2007)]
            [InlineData(2008)]
            [InlineData(2009)]
            [InlineData(2010)]
            [InlineData(2011)]
            public void GivenNewIdAndListOfIFinance_WhenValidateNewTransactionId_ThenReturnsFalseIfNotUniqueNewIdNumber(int newId)
            {
                List<IFinance> testFinancialRecord = new List<IFinance>(){
                new Expense(ExpenseOptions.Grocery , "",100,2004,DateOnly.MinValue),
                new Expense(ExpenseOptions.Gadgets , "",100,2005,DateOnly.MinValue),
                new Expense(ExpenseOptions.Food , "",100,2006,DateOnly.MinValue),
                new Expense(ExpenseOptions.Clothing , "",100,2007,DateOnly.MinValue),
                new Income (IncomeOptions.FreeLancing , "",100,2008,DateOnly.MinValue),
                new Income (IncomeOptions.Loan , "",100,2009,DateOnly.MinValue),
                new Income(IncomeOptions.Salary , "",100,2010,DateOnly.MinValue),
                new Income(IncomeOptions.Other , "Sales",100,2011,DateOnly.MinValue)
            };
                bool expectedResult = ValidationServices.ValidateNewTransactionId(newId, testFinancialRecord);

                Assert.False(expectedResult);
            }

            [Theory]
            [InlineData(2024)]
            [InlineData(2045)]
            [InlineData(2076)]
            [InlineData(2067)]
            [InlineData(2048)]
            [InlineData(2029)]
            [InlineData(2050)]
            [InlineData(2081)]
            public void GivenNewIdAndListOfIFinance_WhenValidateNewTransactionId_ThenReturnsTrueIfUniqueNewIdNumber(int newId)
            {
                List<IFinance> testFinancialRecord = new List<IFinance>(){
                new Expense(ExpenseOptions.Grocery , "",100,2004,DateOnly.MinValue),
                new Expense(ExpenseOptions.Gadgets , "",100,2005,DateOnly.MinValue),
                new Expense(ExpenseOptions.Food , "",100,2006,DateOnly.MinValue),
                new Expense(ExpenseOptions.Clothing , "",100,2007,DateOnly.MinValue),
                new Income (IncomeOptions.FreeLancing , "",100,2008,DateOnly.MinValue),
                new Income (IncomeOptions.Loan , "",100,2009,DateOnly.MinValue),
                new Income(IncomeOptions.Salary , "",100,2010,DateOnly.MinValue),
                new Income(IncomeOptions.Other , "Sales",100,2011,DateOnly.MinValue)
            };
                bool expectedResult = ValidationServices.ValidateNewTransactionId(newId, testFinancialRecord);

                Assert.True(expectedResult);
            }

            [Theory]
            [InlineData("10/10/2024")]
            [InlineData("10-10-2024")]
            [InlineData("29-2-2024")]
            public void GivenStringValue_WhenValidateDateInputs_ThenReturnsTrueIfValidDate(string otherSource)
            {
                bool expectedValue = ValidationServices.ValidateDateInputs(otherSource);

                Assert.True(expectedValue);
            }

            [Theory]
            [InlineData("")]
            [InlineData(null)]
            [InlineData("30/02/2024")]
            [InlineData("10-10/-2024")]
            [InlineData("  Abcd  ")]
            [InlineData("  10/10/2024  ")]
            public void GivenStringValue_WhenValidateDateInputs_ThenReturnsFalseIfInValidDate(string otherSource)
            {
                bool expectedValue = ValidationServices.ValidateDateInputs(otherSource);

                Assert.False(expectedValue);
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_4_ExpenseTracker.HelperUtility;
using Assignment_4_ExpenseTracker.MessageServices;
using Constants;
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
                bool ExpectedValue = ValidationServices.ValidateStringValue(stringValue);

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
                bool ExpectedValue = ValidationServices.ValidateStringValue(stringValue);

                Assert.False(ExpectedValue);
            }

            [Theory]
            [InlineData("0")]
            [InlineData("700")]
            [InlineData("823000")]
            [InlineData("009")]
            [InlineData("010")]
            public void GivenNewIdAndListOfIFinance_WhenValidateNewTransactionId_ThenReturnsTrueIfUniqueNewIdNumber(string numericalValue)
            {
                bool expectedResult = ValidationServices.ValidateNumericalInputs(numericalValue);

                Assert.True(expectedResult);
            }

            //[Theory]
            //[InlineData("0")]
            //[InlineData("700")]
            //[InlineData("823000")]
            //[InlineData("009")]
            //[InlineData("010")]
            //public void GivenNewIdAndListOfIFinance_WhenValidateNewTransactionId_ThenReturnsTrueIfUniqueNewIdNumber(string numericalValue)
            //{
            //    bool expectedResult = ValidationServices.ValidateNumericalInputs(numericalValue);

            //    Assert.True(expectedResult);
            //}


        }

    }
}
//public static bool ValidateNewTransactionId(int newId, List<IFinance> financialRecord)
//{
//    if (financialRecord.Count == 0)
//    {
//        return true;
//    }
//    foreach (IFinance Action in financialRecord)
//    {
//        if (Action.TransactionId == newId)
//        {
//            return false;
//        }
//    }
//    return true;
//}

//public static bool ValidateDateInputs(string? ActionDate)
//{
//    if (DateTime.TryParse(ActionDate, out DateTime userDateTime))
//    {
//        return true;
//    }
//    else
//    {
//        ConsoleWriter.PrintWarning(ConstantStrings.userInputInvalidDate);
//        return false;
//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_4_ExpenseTracker.Models;
using Constants.Enumerations;

namespace Assignment_4_ExpenseTracker_XUnitTests.Model
{
    public class IncomeTests
    {
        [Fact]
        public void Given_WhenGetType_ThenReturnsIncome()
        {
            Income testIncome = new Income(IncomeOptions.FreeLancing, "", 100, 2004, DateOnly.MinValue);

            string expectedValue = "Income";

            string actualValue = testIncome.GetType();

            Assert.Equal(expectedValue, actualValue);
        }
        [Fact]
        public void Given_WhenGetSource_ThenReturnsIncome()
        {
            Income testIncome = new Income(IncomeOptions.Other, "Bottle", 100, 2004, DateOnly.MinValue);
            string expectedValue = "Bottle";

            string actualValue = testIncome.GetSource();

            Assert.Equal(expectedValue, actualValue);
        }
        [Fact]
        public void GivenTupleOfIncomeOptionIndexAndSource_WhenSetSource_ThenSetsIncomeSource()
        {
            Income testIncome = new Income(IncomeOptions.Other, "Laptop", 100, 2004, DateOnly.MinValue);
            (int, string) value = ((int)IncomeOptions.Other, "Bottle");
            testIncome.SetSource(value);
            string expectedValue = "Bottle";

            string actualValue = testIncome.GetSource();

            Assert.Equal(expectedValue, actualValue);
        }
    }
}

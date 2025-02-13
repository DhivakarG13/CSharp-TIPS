﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Constants.Enumerations;
using Assignment_4_ExpenseTracker.Models;

namespace Assignment_4_ExpenseTracker_XUnitTests.Model
{
    public class ExpenseTests
    {
        [Fact]
        public void Given_WhenGetType_ThenReturnsExpense()
        {
            Expense testExpense = new Expense(ExpenseOptions.Grocery, "", 100, 2004, DateOnly.MinValue);
         
            string expectedValue = "Expense";

            string actualValue = testExpense.GetType();

            Assert.Equal(expectedValue, actualValue);
        }
        [Fact]
        public void Given_WhenGetSource_ThenReturnsExpense()
        {
            Expense testExpense = new Expense(ExpenseOptions.Other, "Bottle", 100, 2004, DateOnly.MinValue);

            string expectedValue = "Bottle";

            string actualValue = testExpense.GetSource();

            Assert.Equal(expectedValue, actualValue);
        }
        [Fact]
        public void GivenTupleOfExpenseOptionIndexAndSource_WhenSetSource_ThenSetsExpenseSource()
        {
            Expense testExpense = new Expense(ExpenseOptions.Other, "Laptop", 100, 2004, DateOnly.MinValue);
            (int, string) value = ((int)ExpenseOptions.Other, "Bottle");

            testExpense.SetSource(value);

            string Bottle = "Bottle";
            string actualValue = testExpense.GetSource();

            Assert.Equal(Bottle, actualValue);
        }
    }
}
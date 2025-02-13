using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_4_ExpenseTracker.Models;
using Models;
using Constants.Enumerations;
using Assignment_4_ExpenseTracker.RepositoryManager;

namespace Assignment_4_ExpenseTracker_XUnitTests.RepositoryManager
{
    public class SearchRepositoryServicesTests
    {
        [Theory]
        [InlineData("Grocery", 0)]
        [InlineData("Gadgets", 1)]
        [InlineData("Food", 2)]
        [InlineData("Clothing", 3)]
        [InlineData("FreeLancing", 4)]
        [InlineData("Loan", 5)]
        [InlineData("Salary", 6)]
        [InlineData("Sales", 7)]
        public void GivenSourceAndListOfActions_WhenSearchBySource_ThenReturnsListOfOneMatchingProduct(string stringToSearch, int resultIndex)
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

            List<IFinance> expectedValue = new List<IFinance>() {
                testFinancialRecord[resultIndex],
            };

            List<IFinance> actualValue = SearchRepositoryServices.SearchBySource(stringToSearch, testFinancialRecord);

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GivenSourceAndListOfActions_WhenSearchBySource_ThenReturnsListOfMatchingProducts()
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
            string stringToSearch = "Sal";

            List<IFinance> expectedValue = new List<IFinance>() {
                testFinancialRecord[6],
                testFinancialRecord[7]
            };

            List<IFinance> actualValue = SearchRepositoryServices.SearchBySource(stringToSearch, testFinancialRecord);

            Assert.Equal(expectedValue, actualValue);
        }

        [Theory]
        [InlineData("Chair")]
        [InlineData("Jewel")]
        [InlineData("Hello")]
        [InlineData("Water")]
        [InlineData("Bottle")]
        [InlineData("Laptop")]
        [InlineData("Book")]
        [InlineData("1234")]
        public void GivenSourceAndListOfActions_WhenSearchBySource_ThenReturnsEmptyListIfNoMatchingProducts(string stringToSearch)
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

            List<IFinance> actualValue = SearchRepositoryServices.SearchBySource(stringToSearch, testFinancialRecord);

            Assert.Empty(actualValue);
        }

        [Theory]
        [InlineData(2004, 0)]
        [InlineData(2005, 1)]
        [InlineData(2006, 2)]
        [InlineData(2007, 3)]
        [InlineData(2008, 4)]
        [InlineData(2009, 5)]
        [InlineData(2010, 6)]
        [InlineData(2011, 7)]
        public void GivenTransactionIdAndListOfActions_WhenSearchByTransactionId_ThenReturnsListOfMatchingProducts(int transactionIdToSearch, int MatchingIndex)
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

            List<IFinance> expectedValue = new List<IFinance>() {
                testFinancialRecord[MatchingIndex],
            };

            List<IFinance> actualValue = SearchRepositoryServices.SearchByTransactionId(transactionIdToSearch, testFinancialRecord);

            Assert.Equal(expectedValue, actualValue);
        }

        [Theory]
        [InlineData(1000)]
        [InlineData(2000)]
        [InlineData(3000)]
        [InlineData(4000)]
        [InlineData(5000)]
        [InlineData(6000)]
        [InlineData(7000)]
        [InlineData(0000)]
        public void GivenTransactionIdAndListOfActions_WhenSearchByTransactionId_ThenReturnsEmptyListIfNoMatchingProducts(int transactionIdToSearch)
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


            List<IFinance> actualValue = SearchRepositoryServices.SearchByTransactionId(transactionIdToSearch, testFinancialRecord);

            Assert.Empty(actualValue);
        }

        [Fact]
        public void GivenTransactionIdAndListOfActions_WhenSearchByAction_ThenReturnsListOfIncome()
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
            string searchByActionChoice = "Income";
            List<IFinance> expectedValue = new List<IFinance>() {
                testFinancialRecord[4],
                testFinancialRecord[5],
                testFinancialRecord[6],
                testFinancialRecord[7],
            };

            List<IFinance> actualValue = SearchRepositoryServices.SearchByAction(searchByActionChoice, testFinancialRecord);

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GivenTransactionIdAndListOfActions_WhenSearchByAction_ThenReturnsEmptyListOfExpense()
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
            string searchByActionChoice = "Expense";

            List<IFinance> expectedValue = new List<IFinance>() {
                testFinancialRecord[0],
                testFinancialRecord[1],
                testFinancialRecord[2],
                testFinancialRecord[3],
            };

            List<IFinance> actualValue = SearchRepositoryServices.SearchByAction(searchByActionChoice, testFinancialRecord);

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GivenTransactionIdAndListOfActions_WhenSearchByAction_ThenReturnsEmptyListIfNoMatchingProduct()
        {
            List<IFinance> testFinancialRecord = new List<IFinance>(){
                new Income (IncomeOptions.FreeLancing , "",100,2008,DateOnly.MinValue),
                new Income (IncomeOptions.Loan , "",100,2009,DateOnly.MinValue),
                new Income(IncomeOptions.Salary , "",100,2010,DateOnly.MinValue),
                new Income(IncomeOptions.Other , "Sales",100,2011,DateOnly.MinValue)
            };
            string searchByActionChoice = "Expense";

            List<IFinance> actualValue = SearchRepositoryServices.SearchByAction(searchByActionChoice, testFinancialRecord);

            Assert.Empty(actualValue);
        }

        [Fact]
        public void GivenTransactionIdAndListOfActions_WhenGetSummary_ThenReturnsTupleOfTotalExpenseAndIncome()
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
            (int, int) expectedValue = new(400, 400);

            (int, int) actualValue = SearchRepositoryServices.GetSummary(testFinancialRecord);

            Assert.Equal(expectedValue, actualValue);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Assignment_4_ExpenseTracker.Models;
using Constants.Enumerations;
using Models;
using Assignment_4_ExpenseTracker.HelperUtility;
namespace Assignment_4_ExpenseTracker_XUnitTests.HelperUtility
{
    public class IdGeneratorTests
    {
        [Fact]

        public void GivenListOfActions_WhenTransactionIdGenerator_ReturnsUniqueId()
        {
            List<IFinance> testFinancialRecord = new List<IFinance>(){
                new Expense(ExpenseOptions.Grocery , "",100,20004,DateOnly.MinValue),
                new Expense(ExpenseOptions.Gadgets , "",100,20005,DateOnly.MinValue),
                new Expense(ExpenseOptions.Food , "",100,20006,DateOnly.MinValue),
                new Expense(ExpenseOptions.Clothing , "",100,20007,DateOnly.MinValue),
                new Income (IncomeOptions.FreeLancing , "",100,20008,DateOnly.MinValue),
                new Income (IncomeOptions.Loan , "",100,20009,DateOnly.MinValue),
                new Income(IncomeOptions.Salary , "",100,20100,DateOnly.MinValue),
                new Income(IncomeOptions.Other , "Sales",1000,20011,DateOnly.MinValue)
            };
            List<int> oldTransactionIds = new List<int>() { 20004, 20005, 20006, 20007, 20008, 20009, 20100, 20011 };

            int actualId = IdGenerator.TransactionIdGenerator(testFinancialRecord);

            Assert.DoesNotContain(actualId, oldTransactionIds);
            Assert.InRange(actualId, 10000, 100000);
        }
    }
}

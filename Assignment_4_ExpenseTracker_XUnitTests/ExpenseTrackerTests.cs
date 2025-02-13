using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Assignment4ExpenseTracker;
using Constants.Enumerations;
using Models;

namespace Assignment_4_ExpenseTracker_XUnitTests
{
    public class ExpenseTrackerTests
    {
        [Theory]
        [InlineData(MainMenu.Close_App)]
        public void GivenMainDialogChoice_WhenRun_ThenReturnsTrueIfCloseChoice(MainMenu mainMenuChoice)
        {
            ExpenseTracker expenseTracker = new ExpenseTracker(new List<IFinance>());

            bool actualValue = expenseTracker.Run(mainMenuChoice);

            Assert.True(actualValue);
        }
    }
}

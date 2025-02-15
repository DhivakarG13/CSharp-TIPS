using Assignment4ExpenseTracker;
using Constants.Enumerations;
using Models;

namespace Assignment_4_ExpenseTracker_XUnitTests
{
    public class ExpenseTrackerTests
    {
        [Fact]
        public void GivenMainDialogChoice_WhenRun_ThenReturnsTrueIfCloseChoice()
        {
            ExpenseTracker expenseTracker = new ExpenseTracker(new List<IFinance>());
            MainMenu mainMenuChoice = MainMenu.Close_App;

            bool actualValue = expenseTracker.Run(mainMenuChoice);

            Assert.True(actualValue);
        }
    }
}

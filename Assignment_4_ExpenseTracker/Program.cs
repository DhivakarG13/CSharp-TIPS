using System;
using Assignment_4_ExpenseTracker.HelperUtility;
using Assignment_4_ExpenseTracker.MessageServices;
using Assignment_4_ExpenseTracker.Models;
using Constants.Enumerations;
using Repository;

namespace Assignment4ExpenseTracker
{
    public class Program
    {
        static void Main(string[] args)
        {
            var repo = new FinanceRepository();
            ExpenseTracker expenseTrackerApp = new ExpenseTracker(repo);
            bool closeAppFlag = false;
            const int totalActionsToPrintInMainDialog = 2;
            
            while (!closeAppFlag)
            {
                ConsoleWriter.PrintRecentlyAddedActions(totalActionsToPrintInMainDialog, repo.GetFinanceData());
                ConsoleWriter.PrintDialog(new MainMenu());
                MainMenu mainMenuChoice = (MainMenu)GetUserData.GetDialogChoice(Enum.GetNames(typeof(MainMenu)).Length);
                Console.Clear();
                closeAppFlag = expenseTrackerApp.Run(mainMenuChoice);
            }
        }
    }
}

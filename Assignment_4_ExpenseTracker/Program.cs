using System;
using Assignment_4_ExpenseTracker.HelperUtility;
using Assignment_4_ExpenseTracker.MessageServices;
using Assignment_4_ExpenseTracker.Models;
using Constants.Enumerations;

namespace Assignment4ExpenseTracker
{
    public class Program
    {
        static void Main(string[] args)
        {
            ExpenseTracker expenseTrackerApp = new ExpenseTracker();
            bool closeAppFlag = false;

            while (!closeAppFlag)
            {
                ConsoleWriter.PrintDialog(new MainMenu());
                MainMenu mainMenuChoice = (MainMenu)GetUserData.GetDialogChoice(Enum.GetNames(typeof(MainMenu)).Length);
                Console.Clear();
                closeAppFlag = expenseTrackerApp.Run(mainMenuChoice);
            }
        }
    }
}

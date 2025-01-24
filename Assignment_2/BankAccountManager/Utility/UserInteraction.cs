using System;
using System.Collections.Generic;

public static class UserInteraction
{
    /// <summary>
    /// Prints The Main Page Dialog.
    /// Gets the user choice and validates
    /// </summary>
    /// <returns>User's Choice</returns>
    public static int MainPage()
    {
        PrintMainDialog();
        PrintUserDetailsFetcher("Choice");
        bool IsValidInput = false;
        string? Choice = "0";
        while (!IsValidInput)
        {
            Choice = Console.ReadLine();
            IsValidInput = ValidateUserChoice.ChoiceValidate(Choice, 6);
        }
        return int.Parse(Choice);
    }

    /// <summary>
    /// Gets and Validates User data One by one.
    /// </summary>
    /// <returns>An object of type CustomerData , with user data</returns>
    public static CustomerData CreateNewAccount(List<CustomerData> customerList)
    {
        string? CustomerName = AccountUtility.GetUserName();
        string? AccountNumber = AccountUtility.GetNewAccountNumber(customerList);
        string? SavingsAccount = AccountUtility.GetDepositAmount("Savings Account ");
        string? CheckingAccount = AccountUtility.GetDepositAmount("Checking Account ");

        Console.WriteLine("-----Creating a new Account For you-----");

        //Fetching and validating Account Number.

        return new CustomerData(CustomerName, int.Parse(AccountNumber), int.Parse(SavingsAccount), int.Parse(CheckingAccount));
    }
    /// <summary>
    /// Gets User choice for search by [1] Name or [2] Account Number.
    /// </summary>
    /// <param name="customerList"> List with all Customer Data.</param>
    /// <returns>User's Choice ( 1/2 )</returns>
    internal static int SearchAccountDialog(List<CustomerData> customerList)
    {
        PrintSearchDialog();
        Console.WriteLine("Enter Your Choice:");
        bool IsValidInput = false;
        string? Choice = "0";
        while (!IsValidInput)
        {
            Choice = Console.ReadLine();
            IsValidInput = ValidateUserChoice.ChoiceValidate(Choice, 2);
        }
        return int.Parse(Choice);
    }
    /// <summary>
    /// Prints the dialog of Type of Account [1]Savings Account [2]Checking Account.
    /// Gets the choice and validates it.
    /// </summary>
    /// <returns>User chosen Account type ( 1/2) </returns>
    internal static int GetAccountType()
    {
        PrintAccountTypeDialog();
        PrintUserDetailsFetcher("Choice");
        bool IsValidInput = false;
        string? Choice = "0";
        while (!IsValidInput)
        {
            Choice = Console.ReadLine();
            IsValidInput = ValidateUserChoice.ChoiceValidate(Choice, 2);
        }
        return int.Parse(Choice);
    }
    /// <summary>
    /// gets the amount from User and Validates.
    /// </summary>
    /// <returns>Amount (int)</returns>
    internal static int GetAmount()
    {
        string? DepositAmount = "";
        bool IsValidInput = false;
        while (!IsValidInput)
        {
            PrintUserDetailsFetcher("Amount");
            DepositAmount = Console.ReadLine();
            IsValidInput = ValidateUserData.AmountValidation(DepositAmount);
        }
        return int.Parse(DepositAmount);
    }

    public static void PrintMainDialog()
    {
        Console.Clear();
        Console.WriteLine("------- XYZ Bank -------");
        Console.WriteLine();
        Console.WriteLine("[1] Create a New Account");
        Console.WriteLine("[2] Check Your Account Details");
        Console.WriteLine("[3] DepositCash");
        Console.WriteLine("[4] WithDraw Cash");
        Console.WriteLine("[5] DeleteBankAccount");
        Console.WriteLine("[6] CloseApp");
        Console.WriteLine();
    }
    public static void PrintUserDetailsFetcher(string TypeOfData)
    {
        Console.Write($"Enter Your {TypeOfData} : ");
    }

    internal static void PrintAccountTypeDialog()
    {
        Console.WriteLine("Choose Account To Handle");
        Console.WriteLine("[1]SavingsAccount [2]CheckingAccount ");
    }

    internal static void PrintSearchDialog()
    {
        Console.WriteLine("Search by [1]Name  [2]AccountNumber");
    }

}

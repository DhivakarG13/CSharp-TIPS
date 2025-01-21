

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
        ConsoleWriter.PrintMainDialouge();
        ConsoleWriter.PrintUserDetailsFetcher("Choice");
        bool IsValidInput = false;
        string? Choice = "0";
        while (!IsValidInput)
        {
            Choice = ConsoleReader.ReadInput();
            IsValidInput = UserChoiceValidators.ChoiceValidate(Choice,6);
        }
        return int.Parse(Choice);
    }
    /// <summary>
    /// Gets and Validates User data One by one.
    /// </summary>
    /// <returns>An object of type CustomerData , with user data</returns>
    public static CustomerData CreateNewAccount(List<CustomerData> customerList)
    {
        string? CustomerName = "";
        string? AccountNumber = "";
        string? SavingsAccount = "";
        string? CheckingAccount = "";

        Console.WriteLine("-----Creating a new Account For you-----");

        //Fetching and validating User Name.
        bool IsValidInput = false;
        while (!IsValidInput)
        {
            ConsoleWriter.PrintUserDetailsFetcher("Name");
            CustomerName = ConsoleReader.ReadInput();
            IsValidInput = UserDataValidators.UserNameValidation(CustomerName);
            
        }
        //Fetching and validating Account Number.
        IsValidInput = false;
        while (!IsValidInput)
        {
            Console.WriteLine(" ---Should be a 4 Digit number---");
            ConsoleWriter.PrintUserDetailsFetcher("Account Number");
            AccountNumber = ConsoleReader.ReadInput();
            IsValidInput = UserDataValidators.AccountNumberValidation(AccountNumber);
            if (IsValidInput)
            {
                IsValidInput = UserDataValidators.AccountNumberCreateValidation(int.Parse(AccountNumber), customerList);
            }
        }
        //Fetching and validating Savings Account Deposit.
        IsValidInput = false;
        while (!IsValidInput)
        {
            ConsoleWriter.PrintUserDetailsFetcher("SavingsAccountDeposit");
            SavingsAccount = ConsoleReader.ReadInput();
            IsValidInput = UserDataValidators.SavingsAmountValidation(SavingsAccount);
        }
        //Fetching and validating Checking Account Deposit.
        IsValidInput = false;
        while (!IsValidInput)
        {
            ConsoleWriter.PrintUserDetailsFetcher("CheckingAccountDeposit");
            CheckingAccount = ConsoleReader.ReadInput();
            IsValidInput = UserDataValidators.CheckingAmountValidation(CheckingAccount);
        }
        return new CustomerData(CustomerName, int.Parse(AccountNumber), int.Parse(SavingsAccount), int.Parse(CheckingAccount));
    }
    /// <summary>
    /// Gets User choice for search by [1] Name or [2] Account Number.
    /// </summary>
    /// <param name="customerList"> List with all Customer Data.</param>
    /// <returns>User's Choice ( 1/2 )</returns>
    internal static int SearchAccountDialog(List<CustomerData> customerList)
    {
        ConsoleWriter.PrintSearchDialog();
        Console.WriteLine("Enter Your Choice:");
        bool IsValidInput = false;
        string? Choice = "0";
        while (!IsValidInput)
        {
            Choice = ConsoleReader.ReadInput();
            IsValidInput = UserChoiceValidators.ChoiceValidate(Choice,2);
        }
        return int.Parse(Choice);
    }
    /// <summary>
    /// Gets User Name and Validates.
    /// Initiates the search If Valid input is provided.
    /// </summary>
    /// <param name="CustomerList">List with all Customer Data.</param>
    /// <returns>An Integer List of Indexes of matching results.</returns>
    public static List<int> SearchByName(List<CustomerData> CustomerList)
    {
        List<int> foundList = new List<int>();
        string? CustomerName = default(string);
        bool IsValidInput = false;
        while (!IsValidInput)
        {
            ConsoleWriter.PrintUserDetailsFetcher("Name");
            CustomerName = ConsoleReader.ReadInput();
            IsValidInput = UserDataValidators.UserNameValidation(CustomerName);
        }
        foundList.AddRange(AccountOperations.SearchName(CustomerList, CustomerName));
        return foundList;
    }
    /// <summary>
    /// Gets User Account Number and Validates.
    /// Initiates the search If Valid input is provided.
    /// </summary>
    /// <param name="CustomerList">List with all Customer Data.</param>
    /// <returns>An Integer List of Indexes of matching results.</returns>
    internal static List<int> SearchByAccountNumber(List<CustomerData> CustomerList)
    {
        List<int> foundList = new List<int>();
        string? AccountNumber = default(string);
        bool IsValidInput = false;
        while (!IsValidInput)
        {
            ConsoleWriter.PrintUserDetailsFetcher("Account Number");
            AccountNumber = ConsoleReader.ReadInput();
            IsValidInput = UserDataValidators.AccountNumberValidation(AccountNumber);
        }
        foundList.AddRange(AccountOperations.SearchAccNumber(CustomerList, int.Parse(AccountNumber)));
        return foundList;
    }
    /// <summary>
    /// Prints the Matching Indexes and gets a Index from User and validates.
    /// </summary>
    /// <param name="matchingIndeces">List of Indexes of all matching values in the search Operation</param>
    /// <returns> Index(Integer) Chosen by user to operate.</returns>
    internal static int GetIndexToOperate(List<int> matchingIndeces)
    {
        Console.WriteLine("Choose an Index To Edit:");
        foreach (int index in matchingIndeces)
        {
            Console.Write($"[{index}]  ");
        }
        bool IsValidInput = false;
        string? ChosenIndex = "-1";
        while (!IsValidInput)
        {
            ChosenIndex = ConsoleReader.ReadInput();
            IsValidInput = UserChoiceValidators.ChoiceValidateInList(ChosenIndex, matchingIndeces);
        }
        return int.Parse(ChosenIndex);
    }
    /// <summary>
    /// Prints the dialog of Type of Account [1]Savings Account [2]Checking Account.
    /// Gets the choice and validates it.
    /// </summary>
    /// <returns>User chosen Account type ( 1/2) </returns>
    internal static int GetAccountType()
    {
        ConsoleWriter.PrintAccountTypeDialog();
        ConsoleWriter.PrintUserDetailsFetcher("Choice");
        bool IsValidInput = false;
        string? Choice = "0";
        while (!IsValidInput)
        {
            Choice = ConsoleReader.ReadInput();
            IsValidInput = UserChoiceValidators.ChoiceValidate(Choice, 2);
        }
        return int.Parse(Choice);
    }
    /// <summary>
    /// gets the amount from User and Validates.
    /// </summary>
    /// <returns>Amount (int)</returns>
    internal static int GetAmount()
    {
        string DepositAmount = "";
        bool IsValidInput = false;
        while (!IsValidInput)
        {
            ConsoleWriter.PrintUserDetailsFetcher("Amount");
            DepositAmount = ConsoleReader.ReadInput();
            IsValidInput = UserDataValidators.SavingsAmountValidation(DepositAmount);
        }
        return int.Parse(DepositAmount);
    }

}

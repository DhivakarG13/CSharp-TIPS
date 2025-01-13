

using System.Collections.Generic;

public static class UserInteraction
{
    public static int MainPage()
    {
        ConsoleWriter.PrintMainDialouge();
        Console.WriteLine("Enter Your Choice:");
        bool IsValidInput = false;
        string? Choice = "0";
        while (!IsValidInput)
        {
            Choice = ConsoleReader.ReadInput();
            IsValidInput = UserChoiceValidators.ChoiceValidate(Choice,6);
        }
        return int.Parse(Choice);
    }
    public static CustomerData CreateNewAccount()
    {
        string? CustomerName = "";
        string? AccountNumber = "";
        string? SavingsAccount = "";
        string? CheckingAccount = "";

        bool IsValidInput = false;
        while (!IsValidInput)
        {
            ConsoleWriter.PrintUserDetailsFetcher("Name");
            CustomerName = ConsoleReader.ReadInput();
            IsValidInput = UserDataValidators.UserNameValidation(CustomerName);
        }
        IsValidInput = false;
        while (!IsValidInput)
        {
            ConsoleWriter.PrintUserDetailsFetcher("Account Number");
            AccountNumber = ConsoleReader.ReadInput();
            IsValidInput = UserDataValidators.AccountNumberValidation(AccountNumber);
        }
        IsValidInput = false;
        while (!IsValidInput)
        {
            ConsoleWriter.PrintUserDetailsFetcher("SavingsAccountDeposit");
            SavingsAccount = ConsoleReader.ReadInput();
            IsValidInput = UserDataValidators.SavingsAmountValidation(SavingsAccount);
        }
        IsValidInput = false;
        while (!IsValidInput)
        {
            ConsoleWriter.PrintUserDetailsFetcher("CheckingAccountDeposit");
            CheckingAccount = ConsoleReader.ReadInput();
            IsValidInput = UserDataValidators.CheckingAmountValidation(CheckingAccount);
        }
        return new CustomerData(CustomerName, int.Parse(AccountNumber), int.Parse(SavingsAccount), int.Parse(CheckingAccount));
    }

    internal static int SearchAccountDialog(List<CustomerData> customerList)
    {
        ConsoleWriter.PrintSearchDialouge();
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

    internal static List<int> SearchByName(List<CustomerData> CustomerList)
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
        foundList = AccountOperations.SearchName(CustomerList, CustomerName);
        return foundList;
    }

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
        foundList = AccountOperations.SearchAccNumber(CustomerList, int.Parse(AccountNumber));
        return foundList;
    }
    internal static int GetIndexToOperate(List<int> matchingIndeces)
    {
        Console.WriteLine("Choose an Index To Edit:");
        foreach (int index in matchingIndeces)
        {
            Console.Write($"[{index}]  ");
        }
        bool IsValidInput = false;
        string? ChosenIndex = "0";
        while (!IsValidInput)
        {
            ChosenIndex = ConsoleReader.ReadInput();
            IsValidInput = UserChoiceValidators.ChoiceValidateInList(ChosenIndex, matchingIndeces);
        }
        return int.Parse(ChosenIndex);
    }
    internal static int GetAccountType()
    {
        ConsoleWriter.PrintAccountTypeDialouge();
        Console.WriteLine("Enter Your Choice:");
        bool IsValidInput = false;
        string? Choice = "0";
        while (!IsValidInput)
        {
            Choice = ConsoleReader.ReadInput();
            IsValidInput = UserChoiceValidators.ChoiceValidate(Choice, 2);
        }
        return int.Parse(Choice);
    }

    internal static int GetAmount()
    {
        string DepositAmount = "";
        bool IsValidInput = false;
        while (!IsValidInput)
        {
            ConsoleWriter.PrintUserDetailsFetcher("SavingsAccountDeposit");
            DepositAmount = ConsoleReader.ReadInput();
            IsValidInput = UserDataValidators.SavingsAmountValidation(DepositAmount);
        }
        return 0;
    }

}

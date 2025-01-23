using System;
using System.Collections.Generic;

public static class AccountUtility
{
    public static string? GetUserName()
    {
        string? CustomerName = "";
        bool IsValidInput = false;
        while (!IsValidInput)
        {
            UserInteraction.PrintUserDetailsFetcher("Name");
            CustomerName = Console.ReadLine();
            IsValidInput = ValidateUserData.UserNameValidation(CustomerName);

        }
        return CustomerName;
    }

    public static string? GetDepositAmount(string AccountType)
    {
        string? DepositAmount = "";
        bool IsValidInput = false;
        while (!IsValidInput)
        {
            UserInteraction.PrintUserDetailsFetcher($"{AccountType}Deposit");
            DepositAmount = Console.ReadLine();
            IsValidInput = ValidateUserData.AmountValidation(DepositAmount);
        }
        IsValidInput = ValidateUserData.AmountValidation(DepositAmount);
        return DepositAmount;
    }

    internal static string? GetAccountNumber()
    {
        string? AccountNumber = "";
        bool IsValidInput = false;
        while (!IsValidInput)
        {
            Console.WriteLine(" ---Should be a 4 Digit number---");
            UserInteraction.PrintUserDetailsFetcher("Account Number");
            AccountNumber = Console.ReadLine();
            IsValidInput = ValidateUserData.AccountNumberValidation(AccountNumber);

        }
        return AccountNumber;
    }

    internal static string? GetNewAccountNumber(List<CustomerData> customerList)
    {
        string? AccountNumber = "";
        bool IsValidInput = false;
        while (!IsValidInput)
        {
            AccountNumber = GetAccountNumber();
            IsValidInput = ValidateUserData.AccountNumberCreateValidation(int.Parse(AccountNumber), customerList);
        }
        return AccountNumber;
    }
}

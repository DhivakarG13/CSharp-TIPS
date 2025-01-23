using System;
using System.Collections.Generic;

public static class AccountOperations
{
    public static List<int> SearchName(List<CustomerData> customerList, string? CustomerName)
    {
        int index = 0;
        List<int> foundList = new List<int>();
        foreach (CustomerData customer in customerList)
        {
            if (customer.CustomerName != null && CustomerName != null && customer != null)
            {
                if (customer.CustomerName.Contains(CustomerName))
                {
                    foundList.Add(index);
                    //ConsoleWriter.PrintUserData(customer, index);
                }
            }
            index++;
        }
        if(foundList.Count > 1)
        {
            Console.WriteLine();
            Console.WriteLine("There are more than 1 matches For Users privacy please Enter your Account Number.");
            foundList.Clear();
            foundList.AddRange(AccountOperations.SearchByAccountNumber(customerList));
        }
        else if(foundList.Count == 1)
        {
            CustomerData.PrintUserData(customerList[foundList[0]], 0);
        }
        return foundList;
    }
    public static List<int> SearchAccountNumber(List<CustomerData> customerList, int AccountNumber)
    {
        int index = 0;
        List<int> foundList = new List<int>();
        foreach (CustomerData customer in customerList)
        {
            if(customer.AccountNumber == AccountNumber)
            {
                foundList.Add(index);
                CustomerData.PrintUserData(customer, index);
            }
            index++;
        }
        return foundList;
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
        string? CustomerName = AccountUtility.GetUserName();
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
        string? AccountNumber = AccountUtility.GetAccountNumber();
        foundList.AddRange(AccountOperations.SearchAccountNumber(CustomerList, int.Parse(AccountNumber)));
        return foundList;
    }
}
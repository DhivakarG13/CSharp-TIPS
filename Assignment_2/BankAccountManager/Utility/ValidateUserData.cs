﻿using System;
using System.Collections.Generic;
using System.Linq;

public class ValidateUserData
{
    internal static bool UserNameValidation(string? customerName)
    {
        if (customerName != null)
        {
            if (!customerName.Any(char.IsDigit) && !String.IsNullOrEmpty(customerName))
            {
                return true;
            }
        }
        Console.WriteLine("UserName should not be empty and Should not contain any Digits");
        return false;
    }
    internal static bool AccountNumberValidation(string? accountNumber)
    {
        int parsedAccountNumber = default(int);
        try
        {
            if (accountNumber != null)
            {
                parsedAccountNumber = int.Parse(accountNumber);
            }
        }
        catch (ArgumentNullException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You should Enter an Account Number To Continue");
            Console.ResetColor();
            return false;
        }
        catch (InvalidCastException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter a valid Account Number to Continue");
            Console.ResetColor();
            return false;
        }
        catch (FormatException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter a valid Account Number to Continue");
            Console.ResetColor();
            return false;
        }
        if (parsedAccountNumber > 999 && parsedAccountNumber < 10000)
        {
            return true;
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Account Number Should be a 4 digit Number. Try Again");
        Console.ResetColor();
        return false;
    }

    internal static bool AmountValidation(string? savingsAccount)
    {
        int parsedSavingsAccount = default(int);
        try
        {
            if (savingsAccount != null)
            {
                parsedSavingsAccount = int.Parse(savingsAccount);
            }
        }
        catch (ArgumentNullException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You should Enter an Amount To Continue");
            Console.ResetColor();
            return false;
        }
        catch (InvalidCastException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter a valid Amount to Continue");
            Console.ResetColor();
            return false;
        }
        catch (FormatException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter a valid Number to Continue");
            Console.ResetColor();
            return false;
        }
        if (parsedSavingsAccount >= 0)
        {
            return true;
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Negative Numbers Not Allowed");
        Console.ResetColor();
        return false;
    }

    internal static bool AccountNumberCreateValidation(int accountNumber, List<CustomerData> customerList)
    {
        foreach (CustomerData customer in customerList)
        {
            if (customer.AccountNumber == accountNumber)
            {
                Console.WriteLine("Account number Already Exists");
                return false;
            }
        }
        return true;
    }
}
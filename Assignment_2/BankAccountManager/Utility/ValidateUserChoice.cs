using System;
using System.Collections.Generic;

public static class ValidateUserChoice
{
    internal static bool ChoiceValidate(string? Choice,int range)
    {
        int parsedChoice = default(int);
        try
        {
            parsedChoice = int.Parse(Choice);
        }
        catch(ArgumentNullException)
        {
            Console.WriteLine("You should Choose an Option To Continue");
            return false;
        }
        catch(InvalidCastException)
        {
            Console.WriteLine("Enter a valid Choice to Continue");
            return false;
        }
        catch(FormatException)
        {
            Console.WriteLine("Enter a valid Choice to Continue");
            return false;
        }
        if (parsedChoice > 0 && parsedChoice <= range)
        {
            return true;
        }
        Console.WriteLine("Enter a valid Choice to Continue");
        return false;
    }

    internal static bool ChoiceValidateInList(string? chosenIndex, List<int> matchingIndeces)
    {
        int parsedChoice = default(int);
        try
        {
            parsedChoice = int.Parse(chosenIndex);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("You should Choose an Option To Continue");
            return false;
        }
        catch (InvalidCastException)
        {
            Console.WriteLine("Enter a valid Choice to Continue");
            return false;
        }
        catch (FormatException)
        {
            Console.WriteLine("Enter a valid Choice to Continue");
            return false;
        }
        if (matchingIndeces.Contains(parsedChoice) && parsedChoice >= 0)
        {
            return true;
        }
        Console.WriteLine("Enter a valid Choice to Continue");
        return false;
    }
}

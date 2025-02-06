using Constants;
using Models;

namespace Assignment_4_ExpenseTracker.MessageServices
{
    public static class ConsoleWriter
    {
        public static void PrintDialog(Enum dialogType)
        {
            Console.WriteLine(ConstantStrings.availableOptions);
            int index = 1;
            foreach (string value in Enum.GetNames(dialogType.GetType()))
            {
                Console.WriteLine($":     [{index}] {value}   ");
                index++;
            }
            Console.WriteLine("\n\n");
        }
        public static void GetActionInfoWriter(string? TypeOfData)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{TypeOfData}");
            Console.ResetColor();
        }
        public static void PrintActionData(List<IFinance> actionsToPrint)
        {
            foreach (IFinance action in actionsToPrint)
            {
                Console.WriteLine(ConstantStrings.enclosureLines);
                Console.WriteLine($"Income Type      : {action.GetSource()}");
                Console.WriteLine($"Amount           : {action.Amount}");
                Console.WriteLine($"Transaction Id   : {action.TransactionId}");
                Console.WriteLine($"Transaction Date : {action.ActionDate}\n");
            }
        }
        public static void PrintWarning(string? WarningMessage)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"{WarningMessage}");
            Console.ResetColor();
        }
        public static void PrintActionComplete(string? Message)
        {
            Console.WriteLine(ConstantStrings.enclosureLines);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Message}");
            Console.ResetColor();
            Console.WriteLine("---------------------------\n\n\n");
            Console.WriteLine("Press Any Key to continue");
            Console.ReadKey();
        }

        internal static void PrintActionFailed(object Message)
        {
            Console.WriteLine(ConstantStrings.enclosureLines);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{Message}");
            Console.ResetColor();
            Console.WriteLine("---------------------------\n\n\n");
            Console.WriteLine("Press Any Key to continue");
            Console.ReadKey();
        }
    }
}
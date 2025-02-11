using System;
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
        public static void PrintListOfActionData(List<IFinance> actionsToPrint)
        {
            int actionIndex = 0;
            foreach (IFinance action in actionsToPrint)
            {
                PrintActionData(actionIndex, action);
                actionIndex++;
            }
        }
        public static void PrintSource(string source)
        {
            Console.WriteLine($"Source                : {source}");
        }
        public static void PrintTransactionId(int transactionId)
        {
            Console.WriteLine($"Your Transaction Id   : {transactionId}");
        }
        public static void PrintActionData(int actionIndex, IFinance actionToPrint)
        {
            Console.WriteLine(ConstantStrings.enclosureLines);
            Console.WriteLine($"Index[{actionIndex}]");
            Console.WriteLine($"Action Source    : {actionToPrint.GetSource()}");
            Console.WriteLine($"Amount           : {actionToPrint.Amount}");
            Console.WriteLine($"Transaction Id   : {actionToPrint.TransactionId}");
            Console.WriteLine($"Transaction Date : {actionToPrint.ActionDate}\n");
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
            Console.WriteLine($"--{Message}--");
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

        internal static void PrintSummary((int, int) summary)
        {
            int Balance = summary.Item1 - summary.Item2;
            Console.WriteLine($"Total Income : {summary.Item1}");
            Console.WriteLine($"Total Expense: {summary.Item2}");
            if (Balance < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Available Balance : {Balance}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Available Balance : {Balance}");
                Console.ResetColor();
            }
        }

        internal static void PrintRecentlyAddedActions(int totalActionsToPrintInMainDialog, List<IFinance> finances)
        {
            if (finances.Count() > 0)
            {
                Console.WriteLine("\n::: Recently added Actions :::\n");
                for (int index = 0; index < totalActionsToPrintInMainDialog && index < finances.Count(); index++)
                {
                    PrintActionData(index, finances[finances.Count() - 1]);
                }
            }
            else
            {
                Console.WriteLine("\n::: Add actions to Display Recently added actions here :::\n");
            }
        }
    }
}
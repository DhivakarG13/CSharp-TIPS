using ConsoleTables;
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

        public static void ActionTitleWriter(string actionTitle)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"-- {actionTitle} --");
            Console.ResetColor();
        }

        public static void ActionDescriptionWriter(string description)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"-- {description} --");
            Console.ResetColor();
        }

        public static void GetActionInfoWriter(string? typeOfData)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{typeOfData}");
            Console.ResetColor();
        }

        public static void PrintListOfActionData(List<IFinance> actionsToPrint)
        {
            ConsoleTable table = new ConsoleTable("Index", "Action Type", "Action Source", "Transaction Id", "Amount", "Transaction Date}");

            for (int actionIndex = 0; actionIndex < actionsToPrint.Count; actionIndex++)
            {
                table.AddRow($"{actionIndex}", actionsToPrint[actionIndex].GetType(), actionsToPrint[actionIndex].GetSource(),
                    actionsToPrint[actionIndex].TransactionId, actionsToPrint[actionIndex].Amount, actionsToPrint[actionIndex].ActionDate);

            }
            table.Write();
        }

        public static void PrintActionData(int actionIndex, IFinance actionToPrint)
        {
            ConsoleTable table = new ConsoleTable("Index", "Action Type", "Action Source", "Transaction Id", "Amount", "Transaction Date}");

            table.AddRow($"{actionIndex}", actionToPrint.GetType(), actionToPrint.GetSource(),
                actionToPrint.TransactionId, actionToPrint.Amount, actionToPrint.ActionDate);

            table.Write();
        }

        public static void PrintSource(string source)
        {
            Console.WriteLine($"Source                : {source}");
        }

        public static void PrintTransactionId(int transactionId)
        {
            Console.WriteLine($"Your Transaction Id   : {transactionId}");
        }

        public static void PrintWarning(string? warningMessage)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"{warningMessage}");
            Console.ResetColor();
        }

        public static void PrintActionComplete(string? message)
        {
            Console.WriteLine(ConstantStrings.enclosureLines);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"--{message}--");
            Console.ResetColor();
            Console.WriteLine("---------------------------\n\n\n");
            Console.WriteLine("Press Any Key to continue");
            Console.ReadKey();
        }

        public static void PrintActionFailed(string? message)
        {
            Console.WriteLine(ConstantStrings.enclosureLines);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{message}");
            Console.ResetColor();
            Console.WriteLine("---------------------------\n\n\n");
            Console.WriteLine("Press Any Key to continue");
            Console.ReadKey();
        }

        public static void PrintSummary((int, int) summary)
        {
            int balance = summary.Item1 - summary.Item2;
            Console.WriteLine($"Total Income : {summary.Item1}");
            Console.WriteLine($"Total Expense: {summary.Item2}");
            if (balance < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Available Balance : {balance}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Available Balance : {balance}");
                Console.ResetColor();
            }
        }

        public static void PrintRecentlyAddedActions(int totalActionsToPrintInMainDialog, List<IFinance> finances)
        {
            List<IFinance> recentlyAddedActions = new List<IFinance>();
            if (finances.Count() > 0)
            {
                Console.WriteLine("\n::: Recently added Actions :::\n");
                for (int index = 0; index < totalActionsToPrintInMainDialog && index < finances.Count(); index++)
                {
                    recentlyAddedActions.Add(finances[finances.Count() - index - 1]);
                }
                PrintListOfActionData(recentlyAddedActions);
            }
            else
            {
                Console.WriteLine("\n::: Add actions to Display Recently added actions here :::\n");
            }
        }
    }
}
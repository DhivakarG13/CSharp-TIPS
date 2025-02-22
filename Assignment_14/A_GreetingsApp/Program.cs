using B_MathApp;
using C_DisplayApp;
using D_UtilityApp;

namespace A_GreetingsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, User!");
            int number1 = UserDataFetchUtility.GetNumericalInput("Number 1");
            int number2 = UserDataFetchUtility.GetNumericalInput("Number 2");
            Console.Clear();
            DisplayUtility.PrintDialog(new MathOptions());
            MathOptions userChoice = (MathOptions)UserDataFetchUtility.GetChoice(Enum.GetNames(typeof(MathOptions)).Length);
            try
            {
                switch (userChoice)
                {
                    case MathOptions.Add:
                        {
                            DisplayUtility.PrintData(MathematicalOperations.Add(number1, number2));
                            break;
                        }
                    case MathOptions.Subtract:
                        {
                            DisplayUtility.PrintData(MathematicalOperations.Subtract(number1, number2));
                            break;
                        }
                    case MathOptions.Multiply:
                        {
                            DisplayUtility.PrintData(MathematicalOperations.Multiply(number1, number2));
                            break;
                        }
                    case MathOptions.Divide:
                        {
                            DisplayUtility.PrintData(MathematicalOperations.Divide(number1, number2));
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                DisplayUtility.PrintError(ex.Message);
            }
            Console.WriteLine("Press Any Key to close");
            Console.ReadKey();
        }
    }
}

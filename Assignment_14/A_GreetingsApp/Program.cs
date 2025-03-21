using B_MathApplication;
using C_DisplayApplication;
using D_UtilityApplication;

namespace A_GreetingsApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, User!");
            int firstNumber = UserDataFetchUtility.GetNumericalInput("First Number");
            int secondNumber = UserDataFetchUtility.GetNumericalInput("Second Number");
            Console.Clear();
            MathOptions mathOptions = new MathOptions();
            DisplayUtility.PrintDialog(mathOptions);
            MathOptions userChoice = (MathOptions)UserDataFetchUtility.GetChoice(Enum.GetNames(typeof(MathOptions)).Length);

            try
            {
                switch (userChoice)
                {
                    case MathOptions.Add:
                            DisplayUtility.PrintData(MathematicalOperations.Add(firstNumber, secondNumber));
                            break;

                    case MathOptions.Subtract:
                            DisplayUtility.PrintData(MathematicalOperations.Subtract(firstNumber, secondNumber));
                            break;

                    case MathOptions.Multiply:
                            DisplayUtility.PrintData(MathematicalOperations.Multiply(firstNumber, secondNumber));
                            break;

                    case MathOptions.Divide:
                            DisplayUtility.PrintData(MathematicalOperations.Divide(firstNumber, secondNumber));
                            break;
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

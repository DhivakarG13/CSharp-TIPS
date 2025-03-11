using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number1 = UserDataFetchUtility.GetNumberToCalculate("First Number");
            int number2 = UserDataFetchUtility.GetNumberToCalculate("Second Number");
            Console.WriteLine();
            Console.WriteLine("[1]Add [2]Subtract [3]Divide [4]Multiply");
            int choice = UserDataFetchUtility.GetDialogChoice(4);

            switch (choice)
            {
                case 1:
                    Console.WriteLine($"Result :{MathUtils.Add(number1, number2)}");
                    break;
                case 2:
                    Console.WriteLine($"Result :{MathUtils.Subtract(number1, number2)}");
                    break;
                case 3:
                    try
                    {
                        Console.WriteLine($"Result :{MathUtils.Divide(number1, number2)}");
                    }
                    catch (DivideByZeroException ex)
                    {
                        Console.WriteLine("A number cannot divide by zero");
                    }
                    break;
                case 4:
                    Console.WriteLine($"Result :{MathUtils.Multiply(number1, number2)}");
                    break;
            }
            Console.ReadLine();
        }
    }
}
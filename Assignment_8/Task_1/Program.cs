using CalculatorUtility;

namespace Error_Handling
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("|| Enter First Number as 1 to throw Out of range exception ||");
                Console.Write("Enter First Number :");
                decimal firstNumber;
                while (decimal.TryParse(Console.ReadLine(), out firstNumber) == false)
                {
                    Console.Write("Invalid Try Again :");
                }
                Console.Write("Enter Second Number :");
                decimal secondNumber;
                while (decimal.TryParse(Console.ReadLine(), out secondNumber) == false)
                {
                    Console.Write("Invalid Try Again :");
                }
                try
                {
                    Console.WriteLine(MathematicalOperations.DivideNumbers(firstNumber, secondNumber));
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("::::::: In Global Block :::::::");
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine("::::::: Finally Block Executed :::::::");
                    Console.WriteLine("\n\n-----Press Any Key to continue-----");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}

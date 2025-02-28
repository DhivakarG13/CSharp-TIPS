namespace Error_Handling

{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter Number1 as 1 to throw Out of range exception");
                Console.Write("Enter Number1 :");
                decimal number1;
                while (decimal.TryParse(Console.ReadLine(), out number1) == false)
                {
                    Console.Write("Invalid Try Again :");
                }
                Console.Write("Enter Number2 :");
                decimal number2;
                while (decimal.TryParse(Console.ReadLine(), out number2) == false)
                {
                    Console.Write("Invalid Try Again :");
                }
                try
                {
                    Console.WriteLine(MathematicalOperations.Division(number1, number2));
                }
                catch( DivideByZeroException ex)
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
    public class MathematicalOperations
    {
        public static decimal Division(decimal number1 , decimal number2)
        {
            if (number1 == 1)
            {
                throw new ArgumentOutOfRangeException("Argument out of range exception");
            }
            return number1 / number2;
        }
    }
}

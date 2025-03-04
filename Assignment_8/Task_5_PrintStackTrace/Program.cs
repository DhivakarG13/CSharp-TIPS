namespace Task_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += GlobalExceptionHandler;

            Console.WriteLine("|| Enter zero to throw error ||");
            Console.Write("Enter a number: ");
            int numericalInput = default;

            while (!int.TryParse(Console.ReadLine(), out numericalInput))
            {
                Console.WriteLine("Enter a valid number:");
            }
            try
            {
                Console.WriteLine(Calculator.MathematicalOperation(numericalInput));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                throw;
            }

            Console.ReadLine();
        }
        static void GlobalExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("::Inside GlobalExceptionHandler::");
            Console.WriteLine(e.ExceptionObject.ToString());
        }
    }
}

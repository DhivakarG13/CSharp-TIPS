namespace Task_4_GlobalException
{
    public class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += GlobalExceptionHandler;
            Console.WriteLine("|| Enter zero to throw error ||");
            Console.Write("Enter a number :");
            int numericalInput = default;
            while (!int.TryParse(Console.ReadLine(), out numericalInput))
            {
                Console.WriteLine("Enter a valid number:");
            }
            using (SimpleCalculator simpleCalculator = new SimpleCalculator())
            {
                Console.WriteLine(simpleCalculator.Divide10ByInput(numericalInput));
            }
            Console.ReadLine();
        }

        static void GlobalExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("An Unexpected error occurred");
        }
    }
}

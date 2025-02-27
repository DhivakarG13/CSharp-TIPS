namespace Task_4_GlobalException
{
    public class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionHandler);
            Console.Write("Enter a number :");
            int numericalInput = default;
            while (int.TryParse(Console.ReadLine(), out numericalInput) == false)
            {
                throw new InvalidUserInputException("Your value is Invalid");
            }
            if (numericalInput == 0)
            {
                throw new DivideByZeroException("Dividing by Zero is not allowed");
            }
            Console.WriteLine($"10 / {numericalInput} = " + 10 / numericalInput);
            Console.WriteLine("\n -- Finally Block --");
            Console.WriteLine($"Your Input : {numericalInput}");
            Console.ReadKey();
        }
        static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine($"Unhandled exception: {((Exception)e.ExceptionObject).Message}");
        }
    }
}

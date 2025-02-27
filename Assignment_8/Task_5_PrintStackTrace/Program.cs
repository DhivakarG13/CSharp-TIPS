namespace Task_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numericalInput = default;
            int numberToPrint = default;
            try
            {
                numericalInput = UserDataFetchUtility.GetUserInput();
                numberToPrint = Calculator.MathematicalOperation(numericalInput);
            }
            catch (Exception ex)
            {
                Console.WriteLine("::: In Global Block :::");
                Console.WriteLine(ex);
                Console.WriteLine(ex.Message);
                Console.WriteLine("::: Stack Trace :::");
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("::: In Finally Block :::");
                Console.WriteLine("Your Output :" + numberToPrint);
                Console.ReadKey();
            }
        }
    }
}

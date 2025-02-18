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
                numericalInput = GetUserInput();
                numberToPrint = MathematicalOperation(numericalInput);
            }
            catch (InvalidUserInputException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            catch (Exception ex)
            {
                Console.WriteLine("::: In Global Block :::");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("::: In Finally Block :::");
                Console.WriteLine("Your Output :" + numberToPrint);
                Console.ReadKey();
            }

        }

        private static int MathematicalOperation(int numericalInput)
        {
            if (numericalInput == 0)
            {
                throw new DivideByZeroException("Dividing by Zero is not allowed");
            }
            return ( 5 * 10 / numericalInput);
        }

        private static int GetUserInput()
        {
            Console.Write("Enter a number :");
            int numericalInput = default;
            while (int.TryParse(Console.ReadLine(), out numericalInput) == false)
            {
                throw new InvalidUserInputException("Your value is Invalid");
            }
            return numericalInput;
        }
    }

}

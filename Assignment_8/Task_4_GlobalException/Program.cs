namespace Task_4_GlobalException
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number :");
            int numericalInput = default;
            try
            {
                while (int.TryParse(Console.ReadLine(), out numericalInput) == false)
                {
                    throw new InvalidUserInputException("Your value is Invalid");
                }
                if(numericalInput == 0)
                {
                    throw new DivideByZeroException("Dividing by Zero is not allowed");
                }
                Console.WriteLine($"10 / {numericalInput} = " + 10/numericalInput);
            }
            catch (InvalidUserInputException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("::: In Global Block :::");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("\n -- Finally Block --");
                Console.WriteLine($"Your Input : {numericalInput}");
                Console.ReadKey();
            }

        }
    }
}

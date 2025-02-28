using CustomException;

namespace Task3_CustomException
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number :");
            int numericalInput = default;
            try
            {
                while (!int.TryParse(Console.ReadLine(), out numericalInput))
                {
                    throw new InvalidUserInputException("Your value is Invalid");
                }
            }
            catch (InvalidUserInputException ex)
            {
                Console.WriteLine(ex.Message + " It is Assigned to 0");
                numericalInput = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                numericalInput = 0;
            }
            finally
            {
                Console.WriteLine($"Your Input : {numericalInput}");
                Console.ReadKey();
            }
        }
    }
}

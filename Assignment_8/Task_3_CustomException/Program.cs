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
                while (int.TryParse(Console.ReadLine(), out numericalInput) == false)
                {
                    throw new InvalidUserInputException("Your value is Invalid It's Assigned to 0");
                }
            }

            catch (InvalidUserInputException ex)
            {
                Console.WriteLine(ex.Message);
                numericalInput = 0;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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

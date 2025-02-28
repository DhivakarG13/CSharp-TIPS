namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] listOfIntegers = { 1, 2, 3, 4, 5, 6 };
            Console.Write(" Available List of Integers : ");
            foreach (int number in listOfIntegers)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine("\n\n");
            Console.Write("Enter the index of number to print :");
            int indexToPrint = default;
            while (int.TryParse(Console.ReadLine(), out indexToPrint) == false)
            {
                Console.Write("Invalid Try Again :");
            }
            try
            {
                Console.WriteLine($"number in index{indexToPrint} is : {listOfIntegers[indexToPrint]}");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("::::::: In IndexOutOfRangeException Block :::::::");
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine("::::::: In Global Block :::::::");
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            Console.ReadLine();
        }
    }
}

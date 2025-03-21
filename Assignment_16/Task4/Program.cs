namespace Task4
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 5, 3, 8, 1, 9, 2, 7, 6, 4 };
            List<int> newList = numbers
                .Where(n => n % 2 == 1)
                .Select(n=> n*n)
                .ToList();

            foreach (int number in newList)
            {
                Console.WriteLine(number);
            }

            Console.ReadKey();
        }
    }
}

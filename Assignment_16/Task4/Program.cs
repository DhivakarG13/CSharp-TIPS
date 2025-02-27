namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 5, 3, 8, 1, 9, 2, 7, 6, 4 };
            var newList = numbers.Where(n => n % 2 == 1).Select(n=> n*n).ToList();
            foreach (var number in newList)
            {
                Console.WriteLine(number);
            }
            Console.ReadKey();
        }
    }
}

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 5, 3, 8, 1, 9, 2, 7, 6, 4 };

            Array.Sort(numbers, (int number1, int number2) =>
                {
                    Console.WriteLine("Hello");
                    //Internal logic of compare to method
                if (number1 < number2) return -1;
                if (number1 > number2) return 1;
                return 0;
            });

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
            Console.ReadKey();
        }
    }
}

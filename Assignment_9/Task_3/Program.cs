namespace Task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 9, 10, 8, 4, 5, 2, 3, 7, 6};
            int secondHighestNumber = numbers.OrderByDescending(x => x).ToArray()[1];
            Console.WriteLine(secondHighestNumber);
            Console.WriteLine("\n\n");

            var numberPairs = numbers.Distinct().SelectMany((x, index) => numbers.Skip(index + 1).Where(y => x + y == 10)).Select( (x,y) =>new {num1 = x,num2 =y});

            var numbersSumsTo10 = numbers.SelectMany(
                outer => numbers,
                ( num1,  num2) => new {Key = num1, Value = num2 })
                .Where( numberPairs => numberPairs.Key + numberPairs.Value == 10)
                .OrderBy(numberPairs => numberPairs.Key)
                .ToList();

            foreach ( var numberPair in numberPairs)
            {
                Console.WriteLine($"({numberPair.num1},{numberPair.num2})");
            }
            Console.ReadKey();
        }
    }
}

namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to create 10000000 LocalVariables ");
            Console.ReadKey();
            int sumOfLocalVariables = SumOfLocalVariables();
            Console.WriteLine("Press any key to create Integer array of size 10000000");
            Console.ReadKey();
            int sumOfIntegerArray = SumOfAllIntegersInArray();
            Console.WriteLine("Press any key close");
            Console.ReadKey();
            
        }

        /// <summary>
        /// Creates 10000000 Local variables adds all those integers.
        /// </summary>
        /// <returns>sum of 10000000 Local variables</returns>
        static int SumOfLocalVariables()
        {
            Console.WriteLine("creating 10000000 LocalVariables ");
            int sumOfAllIntegers = 0;

            for (int i = 0; i < 10000000; i++)
            {
                int integer1;
                integer1 = i + 1;
                sumOfAllIntegers += integer1;
            }
            Console.WriteLine("Created 10000000 Local Variables, Press Any key to close");
            Console.ReadKey();
            return sumOfAllIntegers;
        }

        /// <summary>
        /// Creates integer array of size 10000000 adds all the integers in the array.
        /// </summary>
        /// <returns>sum of integers in the array</returns>
        static int SumOfAllIntegersInArray()
        {
            Console.WriteLine("\ncreating integer array of size 10000000 ");
            int[] integerArray = new int[10000000];

            for (int i = 0; i < 10000000; i++)
            {
                integerArray[i] = i + 1;
            }
            Console.WriteLine("Created integer array of size 10000000");
            Console.ReadKey();

            int sumOfIntegers = 0;
            foreach (int integer in integerArray)
            {
                sumOfIntegers += integer;
            }
            Console.WriteLine("Checkpoint for exp ,Press Any key to close");
            Console.ReadKey();
            return sumOfIntegers;
        }
    }
}

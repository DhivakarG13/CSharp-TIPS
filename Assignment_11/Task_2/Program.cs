
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
            
            int SumOfLocalVariables()
            {
                Console.WriteLine("creating 10000000 LocalVariables ");
                int sumOfAllIntegers = 0;

                for (int i = 0; i < 10000000; i++)
                {
                    int integer1;
                    integer1 = i+1;
                    sumOfAllIntegers += integer1;
                    if (i == 10000000 - 1)
                    {
                        Console.WriteLine("Created 10000000 Local Variables, Press Any key to close");
                        Console.ReadKey();
                    }
                }
                return sumOfAllIntegers;
            }

            int SumOfAllIntegersInArray()
            {
                Console.WriteLine("\ncreating 10000000 LocalVariables ");
                int[] integerArray = new int[10000000];

                for (int i = 0; i < 10000000; i++)
                {
                    integerArray[i] = i + 1;
                }
                Console.WriteLine("Created 10000000 Local Variables, Press Any key to close");
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
}

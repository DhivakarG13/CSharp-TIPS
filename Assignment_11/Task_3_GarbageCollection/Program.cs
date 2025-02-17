namespace Task_3_GarbageCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to call CreateAndDestroyObjects method");
            CreateAndDestroyObjects();
            Console.WriteLine("Press any Key to trigger Garbage collector[2]");
            Console.ReadKey();
            GC.Collect();
            Console.WriteLine("Garbage collector[2] triggered");
            Console.WriteLine("Press any Key to close application");
            Console.ReadKey();

            void CreateAndDestroyObjects()
            {
                Console.WriteLine("Press any key: to create integer array of size 1000000");
                Console.ReadKey();
                int[] ints = new int[1000000];
                Console.WriteLine("Created Integer Array Of size 1000000");
                Console.WriteLine("Press any Key to trigger Garbage collector[1]");
                Console.ReadKey();
                GC.Collect();
                Console.WriteLine("Garbage collector[1] triggered");
                Console.WriteLine("Press any Key to continue");
                Console.ReadKey();
            }

        }
    }
}

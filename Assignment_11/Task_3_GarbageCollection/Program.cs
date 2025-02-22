namespace Task_3_GarbageCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to call CreateAndDestroyObjects method");
            CreateAndDestroyObjects();
            Console.WriteLine("Press any Key to close application");
            Console.ReadKey();
        }

        /// <summary>
        /// 
        /// </summary>
        static void CreateAndDestroyObjects()
        {
            Console.WriteLine("Press any key: to create integer array of size 1000000");
            Console.ReadKey();
            List<int[]>? ints = new List<int[]>();
            for (int i = 0; i < 10; i++)
            {
                ints.Add(new int[100000000]);
                Console.ReadKey();
            }

            Console.WriteLine("Press any Key to trigger Garbage collector[1]");
            ints.Clear();
            ints = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine("Garbage collector triggered");
        }
    }
}

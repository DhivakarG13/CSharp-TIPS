namespace Task_2_Alternate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MemoryEater me = new MemoryEater();
            me.Allocate();
            Console.ReadKey();
        }
    }

    public class MemoryEater
    {
        List<int[]> memAlloc = new List<int[]>();
        const int listLimit = 500;
        public void Allocate()
        {
            while (true)
            {
                if (memAlloc.Count() > listLimit)
                {
                    Console.WriteLine("Your limit is breached, (Limit : 500 Arrays)");
                    Console.WriteLine($"Your object is in generation{GC.GetGeneration(memAlloc)}");
                    memAlloc.Clear();
                    memAlloc = new List<int[]>();
                    Console.WriteLine("Triggering GC");
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    Thread.Sleep(3000);
                    GC.Collect();
                    Thread.Sleep(3000);
                }
                memAlloc.Add(new int[100000]);
                Thread.Sleep(30);
            }
        }
    }
}

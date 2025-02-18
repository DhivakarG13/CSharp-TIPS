namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MemoryEater me = new MemoryEater();
            while (true)
            {
                int countOfArraysToAdd;
                while (true)
                {
                    Console.Write("Enter the number of arrays to add [100 Maximum]:");
                    string? userInput = Console.ReadLine();
                    bool isValidInput = int.TryParse(userInput, out countOfArraysToAdd);
                    if (isValidInput && countOfArraysToAdd <= 100)
                    {
                        break;
                    }
                }
                me.Allocate(countOfArraysToAdd);
                Console.WriteLine("Press esc to close the application, press any other key to exit");
                ConsoleKey keyPressed = Console.ReadKey().Key;
                if(keyPressed == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }
    }

    public class MemoryEater
    {
        List<int[]> memAlloc = new List<int[]>();
        const int listLimit = 500;
        public void Allocate(int countOfArraysToAdd)
        {
            while (true)
            {
                if (memAlloc.Count() > listLimit)
                {
                    Console.WriteLine("Your limit is breached, (Limit : 500 Arrays)");
                    memAlloc.Clear();
                    memAlloc.Add(GC.AllocateUninitializedArray<int>(10000));
                    Console.WriteLine("Triggering GC");
                    GC.Collect();
                    break;
                }
                memAlloc.Add(GC.AllocateUninitializedArray<int>(10000));
                countOfArraysToAdd--;
                if (countOfArraysToAdd == 0)
                {
                    break;
                }
            }
        }
    }
}

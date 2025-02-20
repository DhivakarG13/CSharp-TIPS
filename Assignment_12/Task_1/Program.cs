namespace Assignment_12
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
        public void Allocate()
        {
            while(true)
            {
                memAlloc.Add(new int[100000]);
                Thread.Sleep(10);
            }
        }
    }
}

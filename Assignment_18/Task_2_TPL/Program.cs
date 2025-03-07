using System.Diagnostics;

namespace Task_2_TPL
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[10000];
            for(int index =0; index < numbers.Length; index++)
            {
                numbers[index] = index + 1;
            }
            Stopwatch sw = new Stopwatch();
            sw.Start();
            foreach(int number in numbers)
            {
                Console.WriteLine(number*number);
            }
            sw.Stop();
            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            Parallel.ForEach(numbers, (item) => {
                Console.WriteLine(item*item);
            });
            sw1.Stop();
            Console.WriteLine($"Time taken for For Loop : {sw.ElapsedMilliseconds} ms");
            Console.WriteLine($"Time taken for Parallel.ForEach : {sw1.ElapsedMilliseconds} ms");
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }
    }
}
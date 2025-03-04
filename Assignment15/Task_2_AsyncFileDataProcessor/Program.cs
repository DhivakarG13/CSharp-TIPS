using System.Diagnostics;
using FileDataProcessor;

namespace AsyncFileDataProcessor
{
    public class Program
    {
        static void Main(string[] args)
        {
            FileWriter fileWriter = new FileWriter();
            FileReader fileReader = new FileReader();
            Stopwatch stopWatch = new Stopwatch();
            Console.WriteLine("Executing.......");

            stopWatch.Start();
            Task t1 = fileWriter.CreateOrWriteFileAsync(Path.Combine("C:\\Users\\Dhivakar.gopi\\Downloads\\ExpData\\textAsync.txt"));
            t1.Wait();
            Task t2 = Task.Run(() => fileReader.ReadFileUsingFileStreamAsync(Path.Combine("C:\\Users\\Dhivakar.gopi\\Downloads\\ExpData\\textAsync.txt")));
            Task t3 = Task.Run(() => fileReader.ReadFileUsingBufferedStreamAsync(Path.Combine("C:\\Users\\Dhivakar.gopi\\Downloads\\ExpData\\textAsync.txt")));
            Task t4 = Task.Run(() => fileWriter.ProcessFileDataAsync(Path.Combine("C:\\Users\\Dhivakar.gopi\\Downloads\\ExpData\\textAsync.txt"), Path.Combine("C:\\Users\\Dhivakar.gopi\\Downloads\\ExpData\\ProcessedAsync.txt")));
            Task.WaitAll(t2, t3, t4);
            stopWatch.Stop();

            Console.WriteLine("Total Time taken: " + stopWatch.ElapsedMilliseconds + "ms");
            Console.ReadKey();
        }
    }
}
using System.Diagnostics;

namespace FileDataProcessor
{
    public class Program
    {
        static void Main(string[] args)
        {
            FileWriter writeFile = new FileWriter();
            FileReader readFile = new FileReader();
            Stopwatch mainStopWatch = new Stopwatch();
            Stopwatch subStopWatch = new Stopwatch();

            mainStopWatch.Start();

            subStopWatch.Start();
            writeFile.CreateOrWriteFile(Path.Combine("C:\\Users\\Dhivakar.gopi\\Downloads\\ExpData\\text.txt"));
            subStopWatch.Stop();
            Console.WriteLine("Time taken to create a 1GB file using FileStream: " + subStopWatch.ElapsedMilliseconds + "ms");
            subStopWatch.Reset();

            subStopWatch.Start();
            readFile.ReadFileUsingFileStream(Path.Combine("C:\\Users\\Dhivakar.gopi\\Downloads\\ExpData\\text.txt"));
            subStopWatch.Stop();
            Console.WriteLine("Time taken to read file using FileStream: " + subStopWatch.ElapsedMilliseconds + "ms");
            subStopWatch.Reset();

            subStopWatch.Start();
            readFile.ReadFileUsingBufferedStream(Path.Combine("C:\\Users\\Dhivakar.gopi\\Downloads\\ExpData\\text.txt"));
            subStopWatch.Stop();
            Console.WriteLine("Time taken to read file using BufferedStream: " + subStopWatch.ElapsedMilliseconds + "ms");
            subStopWatch.Reset();

            subStopWatch.Start();
            writeFile.ProcessFileData(Path.Combine("C:\\Users\\Dhivakar.gopi\\Downloads\\ExpData\\text.txt"), Path.Combine("C:\\Users\\Dhivakar.gopi\\Downloads\\ExpData\\processedCopy.txt"));
            subStopWatch.Stop();
            Console.WriteLine("Time taken to process the file: " + subStopWatch.ElapsedMilliseconds + "ms");

            mainStopWatch.Stop();
            Console.WriteLine("Total Time taken: " + mainStopWatch.ElapsedMilliseconds + "ms");

            Console.ReadKey();
        }
    }
}
using System.Diagnostics;

namespace FileDataProcessor
{
    public class Program
    {
        static void Main(string[] args)
        {
            FileWriter fileWriter = new FileWriter();
            FileReader fileReader = new FileReader();
            Stopwatch mainStopWatch = new Stopwatch();
            Stopwatch subStopWatch = new Stopwatch();

            mainStopWatch.Start();

            subStopWatch.Start();
            fileWriter.CreateOrWriteFile(Path.Combine("C:\\Users\\Dhivakar.gopi\\Downloads\\ExpData\\text.txt"));
            subStopWatch.Stop();
            Console.WriteLine("Time taken to create a 1GB file using FileStream: " + subStopWatch.ElapsedMilliseconds + "ms");
            subStopWatch.Reset();

            subStopWatch.Start();
            fileReader.ReadFileUsingFileStream(Path.Combine("C:\\Users\\Dhivakar.gopi\\Downloads\\ExpData\\text.txt"));
            subStopWatch.Stop();
            Console.WriteLine("Time taken to read file using FileStream: " + subStopWatch.ElapsedMilliseconds + "ms");
            subStopWatch.Reset();

            subStopWatch.Start();
            fileReader.ReadFileUsingBufferedStream(Path.Combine("C:\\Users\\Dhivakar.gopi\\Downloads\\ExpData\\text.txt"));
            subStopWatch.Stop();
            Console.WriteLine("Time taken to read file using BufferedStream: " + subStopWatch.ElapsedMilliseconds + "ms");
            subStopWatch.Reset();

            subStopWatch.Start();
            fileWriter.ProcessFileData(Path.Combine("C:\\Users\\Dhivakar.gopi\\Downloads\\ExpData\\text.txt"), Path.Combine("C:\\Users\\Dhivakar.gopi\\Downloads\\ExpData\\processedCopy.txt"));
            subStopWatch.Stop();
            Console.WriteLine("Time taken to process the file: " + subStopWatch.ElapsedMilliseconds + "ms");

            mainStopWatch.Stop();
            Console.WriteLine("Total Time taken: " + mainStopWatch.ElapsedMilliseconds + "ms");

            Console.ReadKey();
        }
    }
}
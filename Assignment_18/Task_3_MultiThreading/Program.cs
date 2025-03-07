using System.Diagnostics;

namespace Task_3_MultiThreading
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            WaitFor5Seconds();
            WaitFor3Seconds();
            WaitFor2Seconds();
            sw.Stop();
            Console.WriteLine($"Time taken to execute synchronously {sw.ElapsedMilliseconds}ms");
            Thread T1 = new Thread(WaitFor5Seconds);
            Thread T2 = new Thread(WaitFor3Seconds);
            Thread T3 = new Thread(WaitFor2Seconds);
            Stopwatch sw1 = Stopwatch.StartNew();
            T1.Start();
            T2.Start();
            T3.Start();
            T1.Join();
            T2.Join();
            T3.Join();
            sw.Stop();
            Console.WriteLine($"Time taken to execute synchronously {sw1.ElapsedMilliseconds}ms");
            Console.ReadKey();
        }
        public static void WaitFor5Seconds()
        {
            Thread.Sleep(5000);
        }
        public static void WaitFor3Seconds()
        {
            Thread.Sleep(3000);
        }
        public static void WaitFor2Seconds()
        {
            Thread.Sleep(2000);
        }
    }
}

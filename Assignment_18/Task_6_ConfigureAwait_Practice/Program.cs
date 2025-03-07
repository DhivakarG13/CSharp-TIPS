namespace Task_6_ConfigureAwait_Practice
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Thread Handling the Method [1]:" + Thread.CurrentThread.ManagedThreadId);
            string t1 = await DisplayTriangularNumbers(10000,3).ConfigureAwait(true);
            Console.WriteLine("Thread Handling the Method [2]:" + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Press Any Key To Exit");
            Console.ReadKey();
        }

        public static async Task<string> DisplayTriangularNumbers(int requiredCount, int indexToPrint)
        {
            Console.WriteLine("Thread Handling the Method [3]:" + Thread.CurrentThread.ManagedThreadId);
            int[] triangularNumbers = await CalculateTriangularNumbers(requiredCount).ConfigureAwait(true);
            Console.WriteLine("Thread Handling the Method [4]:" + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine($"The triangular number at {indexToPrint} is {triangularNumbers[indexToPrint - 1]}");
            return "";
        }

        public static async Task<int[]> CalculateTriangularNumbers(int requireCount)
        {
            Console.WriteLine("Thread Handling the Method [5]:" + Thread.CurrentThread.ManagedThreadId);
            return await Task.Run(() =>  {
            Console.WriteLine("Thread Handling the Method [6]:" + Thread.CurrentThread.ManagedThreadId);
                int[] triangularNumbers = new int[requireCount];
                for (int i = 1; i <= triangularNumbers.Length; i++)
                {
                    int triangularNumber = 0;
                    for (int j = 1; j <= i; j++)
                    {
                        triangularNumber += j;
                    }
                    triangularNumbers[i - 1] = triangularNumber;
                }
                return triangularNumbers;
            }).ConfigureAwait(true);
        }
    }
}
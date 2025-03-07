namespace Task_5_FixDeadLock
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            string result = await SomeAsyncOperation();
            Console.WriteLine(result);
            Console.ReadLine();
        }
        public static async Task<string> SomeAsyncOperation()
        {
            await Task.Delay(100000);
            return "Hello";
        }
    }
}

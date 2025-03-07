namespace Async_ErrorHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Task t = TaskMethod();
                VoidMethod();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public static async void VoidMethod()
        {
            throw new NotImplementedException();
        }

        public static async Task TaskMethod()
        {
            throw new NotImplementedException();

        }
    }
}

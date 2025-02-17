namespace Task_4_IDisposableDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            const string filePath = "file.txt";

            using (FileWriter writer = new FileWriter(filePath))
            {
                writer.Write("Hello");
                writer.Write("Jack");
            }

            using FileReader reader = new FileReader(filePath);
            Console.WriteLine(reader.ReadLineFromFile(1));
            Console.WriteLine(reader.ReadLineFromFile(0));

            Console.ReadKey();
        }
    }
}

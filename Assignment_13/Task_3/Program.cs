namespace Task_3
{
    public class Program
    {
        static void Main(string[] args)
        {
            QueueManager<string> peopleManager = new QueueManager<string>();

            peopleManager.AddItemToQueue("Jack");
            peopleManager.AddItemToQueue("Joe");
            peopleManager.AddItemToQueue("Jane");
            peopleManager.AddItemToQueue("Jester");
            peopleManager.AddItemToQueue("Jamal");
            peopleManager.PrintItemInQueue();
            Console.WriteLine(":: Remove Operation ::");
            peopleManager.RemoveItemsFromQueue(4);
            peopleManager.PrintItemInQueue();
            Console.ReadKey();
        }
    }
}

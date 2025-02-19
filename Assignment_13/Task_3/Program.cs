namespace Task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PeopleManager peopleManager = new PeopleManager();

            peopleManager.AddPersonToQueue("Jack");
            peopleManager.AddPersonToQueue("Joe");
            peopleManager.AddPersonToQueue("Jane");
            peopleManager.AddPersonToQueue("Jester");
            peopleManager.AddPersonToQueue("Jamal");
            peopleManager.PrintPeopleInQueue();
            Console.WriteLine(":: Remove Operation ::");
            peopleManager.RemovePersonFromQueue(10);
            peopleManager.PrintPeopleInQueue();
            Console.WriteLine(":: Remove Operation ::");
            peopleManager.RemovePersonFromQueue(4);
            peopleManager.PrintPeopleInQueue();
            Console.ReadKey();
        }

    }
}

namespace Task_3
{
    public class Program
    {
        static void Main(string[] args)
        {
            PeopleManager peopleManager = new PeopleManager();
            Console.WriteLine("\n:: Add Operation ::\n");
            peopleManager.AddPersonToQueue("Jack");
            peopleManager.AddPersonToQueue("Joe");
            peopleManager.AddPersonToQueue("Jane");
            peopleManager.AddPersonToQueue("Jester");
            peopleManager.AddPersonToQueue("Jamal");
            peopleManager.PrintPeopleInQueue();
            Console.WriteLine("\n:: Remove Operation ::\n");
            peopleManager.RemovePeopleFromQueue(3);
            peopleManager.PrintPeopleInQueue();
            Console.ReadKey();
        }
    }
}

namespace Task_4
{
    public class Program
    {
        static void Main(string[] args)
        {
            QueueManager<string,int> studentDetails = new QueueManager<string,int> ();
            studentDetails.AddItem("Jack" , 100);
            studentDetails.AddItem("Joe" , 200);
            studentDetails.AddItem("Julie" , 300);
            studentDetails.AddItem("Jamal" , 400);
            studentDetails.AddItem("Jack", 500);
            studentDetails.PrintItemDetails();
            Console.WriteLine(":: Remove Operations ::\n");
            studentDetails.RemoveItem("Jamie");
            studentDetails.RemoveItem("Jack");
            studentDetails.PrintItemDetails();
            Console.WriteLine("::Search Students::\n");
            studentDetails.SearchItem("Jamie");
            studentDetails.SearchItem("Jack");
            Console.ReadLine();
        }
    }
}
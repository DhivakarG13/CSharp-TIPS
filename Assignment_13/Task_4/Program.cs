namespace Task_4
{
    public class Program
    {
        static void Main(string[] args)
        {
            Student studentDetails = new Student();
            Console.WriteLine(":: Add operation in Dictionary ::\n");
            studentDetails.AddStudent("Jack" , 100);
            studentDetails.AddStudent("Joe" , 200);
            studentDetails.AddStudent("Julie" , 300);
            studentDetails.AddStudent("Jack", 500);
            studentDetails.AddStudent("Jamal" , 400);
            studentDetails.PrintStudentDetails();
            Console.WriteLine("\n:: Remove Operations in Dictionary::\n");
            studentDetails.RemoveStudent("Jamie");
            studentDetails.RemoveStudent("Jack");
            studentDetails.PrintStudentDetails();
            Console.WriteLine("\n::Search Students in Dictionary::\n");
            studentDetails.SearchStudent("Jamie");
            studentDetails.SearchStudent("Jamal");
            Console.ReadLine();
        }
    }
}
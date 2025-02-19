namespace Task_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student studentDetails = new Student();
            studentDetails.AddStudent("Jack" , 100);
            studentDetails.AddStudent("Joe" , 200);
            studentDetails.AddStudent("Julie" , 300);
            studentDetails.AddStudent("Jamal" , 400);
            studentDetails.AddStudent("Jack", 500);
            studentDetails.PrintStudentDetails();
            Console.WriteLine(":: Remove Operations ::\n");
            studentDetails.RemoveStudent("Jamie");
            studentDetails.RemoveStudent("Jack");
            studentDetails.PrintStudentDetails();
            Console.WriteLine("::Search Students::\n");
            studentDetails.SearchStudent("Jamie");
            studentDetails.SearchStudent("Jack");
            Console.ReadLine();
        }
    }
}
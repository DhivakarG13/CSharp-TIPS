using System.Security.Cryptography.X509Certificates;

namespace Assignment_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student(2003, "Student Jack");
            Employee employee = new Employee(2004, "Employee Jack");
            Console.WriteLine("::::: Before calling Edit Methods :::::\n");
            student.printDetails();
            employee.printDetails();
            EditEmployee(employee);
            EditStudent(student);
            //student.StudentName = "Hello";
            Console.WriteLine("\n::::: After calling Edit Methods :::::\n");
            student.printDetails();
            employee.printDetails();
            Console.WriteLine("\n\n--------------------------------------------------------------");
            Student newStudent = new Student(2003, "Student Jack");
            Console.WriteLine("\n::::: Before calling Edit Methods Inside the Struct :::::\n");
            newStudent.printDetails();
            Console.WriteLine("\n::::: After calling Edit Method 1 Inside the Struct :::::\n");
            newStudent.InsideStructEditStudent1();
            newStudent.printDetails();
            Console.WriteLine("\n::::: After calling Edit Method 2 Inside the Struct :::::\n");
            newStudent.InsideStructEditStudent2();
            newStudent.printDetails();
            Console.ReadKey();
        }

        public static void EditEmployee(Employee employeeToEdit)
        {
            employeeToEdit.EmployeeId = 0;
            employeeToEdit.EmployeeName = "Edited Employee Jack";
        }

        public static void EditStudent(Student studentToEdit)
        {
            studentToEdit.StudentId = 0;
            studentToEdit.StudentName = "Edited Student Jack outside struct";
        }
    }

}

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
            newStudent.InsideStructEditStudent();
            Console.WriteLine("\n::::: After calling Edit Methods Inside the Struct :::::\n");
            newStudent.printDetails();
            Console.ReadKey();

            void EditEmployee(Employee employeeToEdit)
            {
                employeeToEdit.EmployeeId = 0;
                employeeToEdit.EmployeeName = "Edited Employee Jack";
            }
            void EditStudent(Student studentToEdit)
            {
                studentToEdit.StudentId = 0;
                studentToEdit.StudentName = "Edited Student Jack";
            }
        }
    }

    public struct Student
    {
        public int StudentId;
        public string StudentName;
        public Student(int studentId, string name)
        {
            StudentId = studentId;
            StudentName = name;
        }
        public void InsideStructEditStudent()
        {
            StudentId = 0;
            StudentName = "Edited Student Jack";
        }
        public void printDetails()
        {
            Console.WriteLine("-- Student Details (Value Type : struct)--");
            Console.WriteLine($"StudentId   : {StudentId}");
            Console.WriteLine($"StudentName : {StudentName}\n");
        }
    }

    public class Employee
    {
        public int EmployeeId;
        public string EmployeeName;
        public Employee(int employeeId, string employeeName)
        {
            EmployeeId = employeeId;
            EmployeeName = employeeName;
        }
        public void printDetails()
        {
            Console.WriteLine("-- Employee details (Reference type : class)--");
            Console.WriteLine($"EmployeeId   : {EmployeeId}");
            Console.WriteLine($"EmployeeName : {EmployeeName}\n");
        }
    }

}

namespace Task_4
{
    public class Student
    {
        public Dictionary<String, int> StudentLog { get; set; }

        public Student()
        {
            StudentLog = new Dictionary<String, int>();
        }

        public void AddStudent(String studentName, int studentGrade)
        {
            if (StudentLog.ContainsKey(studentName))
            {
                Console.WriteLine($"Student named {studentName} is already in the StudentLog\n");
            }
            else
            {
                StudentLog.Add(studentName, studentGrade);
            }
        }

        public void RemoveStudent(string studentToRemove) 
        {
            if (! StudentLog.ContainsKey(studentToRemove))
            {
                Console.WriteLine($"{studentToRemove} is not in the StudentLog\n");
            }
            else
            {
                Console.WriteLine($"Removed {studentToRemove} from StudentLog\n");
            }
            StudentLog.Remove(studentToRemove);
        }

        public void SearchStudent(String studentName)
        {
            if(StudentLog.ContainsKey(studentName))
            {
                Console.WriteLine(StudentLog[studentName]);
            }
            else
            {
                Console.WriteLine($"{studentName} is not in the StudentLog\n");
            }
            Console.WriteLine();
        }

        public void PrintStudentDetails()
        {
            Console.WriteLine("StudentLog :");
            foreach(KeyValuePair<string, int> student in StudentLog)
            {
                Console.WriteLine(student.Key + " " + student.Value );
            }
            Console.WriteLine();
        }
    }
}
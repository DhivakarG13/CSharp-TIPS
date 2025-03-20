namespace Task_4
{
    public class Student
    {
        public Dictionary<String, int> StudentLog { get; set; }

        public Student()
        {
            StudentLog = new Dictionary<String, int>();
        }

        /// <summary>
        /// Adds new student details and update the student's grade.
        /// </summary>
        /// <param name="studentName"></param>
        /// <param name="studentGrade"></param>
        public void AddStudent(String studentName, int studentGrade)
        {
            if (StudentLog.ContainsKey(studentName))
            {
                Console.WriteLine($"\nStudent named {studentName} is already in the StudentLog\nUpdated the Grade\n");
                StudentLog[studentName] = studentGrade;
            }
            else
            {
                Console.WriteLine($"Adding {studentName}'s Details to Dictionary StudentLog");
                StudentLog.Add(studentName, studentGrade);
            }
        }

        /// <summary>
        /// Removes the student details from StudentLog.
        /// </summary>
        /// <param name="studentToRemove"></param>
        public void RemoveStudent(string studentToRemove)
        {
            if (StudentLog.ContainsKey(studentToRemove))
            {
                Console.WriteLine($"Removed {studentToRemove} from StudentLog\n");
            }
            else
            {
                Console.WriteLine($"{studentToRemove} is not in the StudentLog\n");
            }
                StudentLog.Remove(studentToRemove);
        }

        /// <summary>
        /// Gets the student name, searches for the student and prints the search result.
        /// </summary>
        /// <param name="studentName"></param>
        public void SearchStudent(String studentName)
        {
            if (StudentLog.ContainsKey(studentName))
            {
                Console.WriteLine($"{studentName} " + StudentLog[studentName]);
            }
            else
            {
                Console.WriteLine($"{studentName} is not in the StudentLog\n");
            }
        }

        /// <summary>
        /// Prints the details of all students in StudentLog.
        /// </summary>
        public void PrintStudentDetails()
        {
            Console.WriteLine("\nStudentLog :");
            foreach (KeyValuePair<string, int> student in StudentLog)
            {
                Console.WriteLine(student.Key + " " + student.Value);
            }
        }
    }
}
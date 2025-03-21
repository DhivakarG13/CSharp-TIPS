namespace ClassProvider
{
    public class Student
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public double GPA { get; set; }

        public Student(string name, int age, double gPA)
        {
            Name = name;
            Age = age;
            GPA = gPA;
        }

        public void PrintDetails()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"GPA: {GPA}");
        }

        public void SetName(string firstName, string secondName)
        {
            Name = firstName + secondName;
        }
    }
}
namespace Assignment_11
{
    public struct Student
    {
        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public Student(int studentId, string name)
        {
            StudentId = studentId;
            StudentName = name;
        }

        /// <summary>
        /// Edits the StudentId and StudentName and sets to the value 0 and "Edited Student Jack" respectively
        /// </summary>
        public void InsideStructEditStudent1()
        {
            StudentId = 0;
            StudentName = "Edited Student Jack inside struct";
        }

        /// <summary>
        /// Edits the fields by assigning a new student instance to the current instance.
        /// </summary>
        public void InsideStructEditStudent2()
        {
            this = new Student(0, "Edited Student Jack by creating new instance");
        }

        /// <summary>
        /// Prints the student Id and student Name for the current instance.
        /// </summary>
        public void printDetails()
        {
            Console.WriteLine("-- Student Details (Value Type : struct)--");
            Console.WriteLine($"StudentId   : {StudentId}");
            Console.WriteLine($"StudentName : {StudentName}\n");
        }
    }

}

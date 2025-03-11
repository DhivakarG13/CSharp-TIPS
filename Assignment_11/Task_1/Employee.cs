namespace Assignment_11
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public Employee(int employeeId, string employeeName)
        {
            EmployeeId = employeeId;
            EmployeeName = employeeName;
        }

        /// <summary>
        /// Prints the employee's ID and Name for the current instance.
        /// </summary>
        public void printDetails()
        {
            Console.WriteLine("-- Employee details (Reference type : class)--");
            Console.WriteLine($"EmployeeId   : {EmployeeId}");
            Console.WriteLine($"EmployeeName : {EmployeeName}\n");
        }
    }

}

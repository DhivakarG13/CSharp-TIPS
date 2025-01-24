public abstract class Employee
{
    public string Name { get; set; }

    public double Salary { get; set; }

    public Employee()
    {
        Console.WriteLine("Hello Employee");
    }

    public Employee(string name, double salary)
    {
        Console.WriteLine($"Your Name: {name} , Your Salary: {salary}");
        Name = name;
        Salary = salary;
    }

    public abstract double CalculateBonus();

    public abstract void PrintDetails();

}

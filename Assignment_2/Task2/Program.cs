
Employee E1 = new Developer("Name1",10000);
Console.WriteLine();
Employee E2 = new Developer("Name2", 20000);
Console.WriteLine();
Employee E3 = new Manager("Name3", 30000);
Console.WriteLine();
Employee E4 = new Manager("Name4", 40000);
Console.WriteLine();

E1.PrintDetails();
E2.PrintDetails();
E3.PrintDetails();
E4.PrintDetails();

Console.WriteLine();
Console.WriteLine(new Manager("Name1", 10000));
Console.WriteLine();
Console.WriteLine();
Console.ReadKey();

Employee E5 = new Manager("Name4", 40000);
Console.WriteLine();
Manager E6 = new Manager("Name4", 40000);
Console.WriteLine();
Employee E7 = new Employee();

Console.ReadKey();

public class Employee
{
    public Employee()
    {
        Console.WriteLine("Hello Employee");
    }
    public Employee(int x)
    {
        Console.WriteLine("base class constructor with one argument is called ");
    }
    public string Name { get; set; }
    public decimal Salary { get; set; }

    public virtual decimal CalculateBonus() => default(decimal);
    public virtual void PrintDetails() { }
}
public class Manager : Employee 
{
    public Manager()
    {
        Console.WriteLine("Hello Manager");
    }
    public Manager(string name, decimal salary ): base(10)
    {
        Console.WriteLine($"Your Name: {name} , Your Salary: {salary}");
        Name = name;
        Salary = salary;
    }
    public override decimal CalculateBonus() => (Salary/100) *10; //10% bonus
    public override void PrintDetails()
    {
        Console.WriteLine($"The {this.GetType().Name} {Name}, Receiving a Salary of {Salary} is awarded with a bonus of {CalculateBonus()}.\n SO the total amount is {Salary + CalculateBonus()}" );
    }
}
public class Developer : Employee 
{
    public Developer(string name, decimal salary)
    {
        Name = name;
        Salary = salary;
    }
    public override decimal CalculateBonus() => (Salary/100) *15;//15% bonus
    public override void PrintDetails()
    {
        Console.WriteLine($"The {this.GetType().Name} {Name}, Receiving a Salary of {Salary} is awarded with a bonus of {CalculateBonus()}.\n SO the total amount is {Salary + CalculateBonus()}");
    }
}
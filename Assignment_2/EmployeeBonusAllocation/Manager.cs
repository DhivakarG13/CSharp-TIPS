public class Manager : Employee
{
    public Manager()
    {
        Console.WriteLine("Hello Manager");
    }

    public Manager(string name, double salary) : base(name, salary) { }

    public override double CalculateBonus() => (Salary / 100) * 10; //10% bonus

    public override void PrintDetails()
    {
        Console.WriteLine($"The {this.GetType().Name} {Name}, Receiving a Salary of {Salary} is awarded with a bonus of {CalculateBonus()}.\n SO the total amount is {Salary + CalculateBonus()}");
    }

}

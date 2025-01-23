public class Developer : Employee
{
    public Developer(string name, double salary) : base(name, salary) { }

    public override double CalculateBonus() => (Salary / 100) * 15;//15% bonus

    public override void PrintDetails()
    {
        Console.WriteLine($"The {this.GetType().Name} {Name}, Receiving a Salary of {Salary} is awarded with" +
            $" a bonus of {CalculateBonus()}.\n SO the total amount is {Salary + CalculateBonus()}");
    }

}
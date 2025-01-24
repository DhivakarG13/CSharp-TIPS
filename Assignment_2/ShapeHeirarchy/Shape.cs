public abstract class Shape
{
    public string Color { get; set; } = "Green";

    public double Area { get; set; }

    public abstract double CalculateArea();

    public abstract string PrintDetails();

}

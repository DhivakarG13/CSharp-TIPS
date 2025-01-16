using System.Drawing;

Shape shape1 = new Rectangle(4,5);
Shape shape2 = new Circle(1);
//Shape shape3 = new shape(2);
Rectangle shape4 = new Rectangle(9, 10);

Console.WriteLine(shape1.PrintDetails());
Console.WriteLine(shape2.PrintDetails());
//Console.WriteLine(shape3.PrintDetails());
Console.WriteLine(shape4.PrintDetails());

List<Shape> shapes = new List<Shape> {
     new Rectangle(10, 11),
     new Circle(4),
     new Circle(8),
     new Rectangle(19, 10)
    };

foreach (Shape shape in shapes)
{
    Console.WriteLine(shape.PrintDetails());
}
Console.ReadKey();

public class Shape
{
    public string Color { get; set; }
    public int Area { get; set; }

    public virtual int CalculateArea() => 0;
    public virtual string PrintDetails() => "In Parent Class";
}

public class Rectangle: Shape
{
    public Rectangle(int length, int height)
    {
        Color = "Red";
        Length = length;
        Height = height;
    }
    public int Length;
    public int Height;

    public override int CalculateArea() => Length * Height;

    public override string PrintDetails() => $"The shape is:{this.GetType().Name} \n,The Colour is: {Color} \n, The Area is: {CalculateArea()}";
}

public class Circle: Shape
{
    public int Radius;

    /// <summary>
    /// constructor fir class "Circle"
    /// </summary>
    /// <param name="radius"></param>
    public Circle(int radius)
    {
        Color = "Blue";
        Radius = radius;
    }

    /// <summary>
    /// Overrides the virtual method in base class "Shape", Calculates Area of circle.
    /// </summary>
    /// <returns> Area of circle </returns>
    public override int CalculateArea()
    {
        //return base.CalculateArea();
        return 3 * Radius * Radius;
    }

    public override string PrintDetails() => $"The shape is:{this.GetType().Name} \n,The Colour is: {Color} \n, The Area is: {CalculateArea()}";

} 
Shape shape1 = new Rectangle(4, 5);
Shape shape2 = new Circle(1);

Rectangle shape3 = new Rectangle(9, 10);

Console.WriteLine(shape1.PrintDetails());
Console.WriteLine(shape2.PrintDetails());
Console.WriteLine(shape3.PrintDetails());

List<Shape> shapes = new List<Shape> {
     new Rectangle(10, 11),
     new Circle(4),
     new Circle(8),
     new Rectangle(19, 10)
    };

Console.WriteLine("Created A List of Different Shapes And printing its values:\n");

foreach (Shape shape in shapes)
{
    Console.WriteLine(shape.PrintDetails());
}
Console.ReadKey();

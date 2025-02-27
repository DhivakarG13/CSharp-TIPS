namespace Task7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Shape>? shapes = new List<Shape>();
            shapes.Add(new Circle(5));
            shapes.Add(new Rectangle(4, 5));
            shapes.Add(new Triangle(4, 5));
            shapes.Add(null);

            DisplayShapeDetails(shapes);
            Console.ReadLine();
        }
        static void DisplayShapeDetails(List<Shape> shapesToPrint)
        {
            foreach (Shape shape in shapesToPrint)
            {
                if (shape is Circle circle)
                {
                    Console.WriteLine($"Circle, Radius :{circle.Radius}, Area:{Math.Round(circle.CalculateArea()),5}");
                }
                else if (shape is Rectangle rectangle)
                {
                    Console.WriteLine($"Rectangle, length :{rectangle.Length}, Height :{rectangle.Height}, Area: {rectangle.CalculateArea()}");
                }
                else if (shape is Triangle triangle)
                {
                    Console.WriteLine($"Triangle, Base: {triangle.Base}, Height: {triangle.Height}, Area: {triangle.CalculateArea()}");
                }
                else
                {
                    Console.WriteLine("Null value");
                }
            }
        }
    }
    public class Shape
    {
        public double Area { get; set; }
    }
    public class Circle : Shape
    {
        public double Radius { get; set; }
        public Circle(double radius)
        {
            Radius = radius;
        }
        public double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
    public class Rectangle : Shape
    {
        public double Length { get; set; }
        public double Height { get; set; }
        public Rectangle(double length, double height)
        {
            Length = length;
            Height = height;
        }
        public double CalculateArea()
        {
            return Length * Height;
        }
    }
    public class Triangle : Shape
    {
        public double Base { get; set; }
        public double Height { get; set; }
        public Triangle(double @base, double height)
        {
            Base = @base;
            Height = height;
        }
        public double CalculateArea()
        {
            return 0.5 * Base * Height;
        }
    }
}
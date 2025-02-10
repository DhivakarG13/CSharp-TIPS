public class Rectangle : Shape
{
    public Rectangle(int length, int height)
    {
        Color = "Red";
        Length = length;
        Height = height;
    }

    public int Length { get; set; }

    public int Height { get; set; }

    public override double CalculateArea() => Length * Height;

    public override string PrintDetails() => $"The shape is:{this.GetType().Name} \n,The Color is: {Color} \n, The Area is: {CalculateArea()}";
}

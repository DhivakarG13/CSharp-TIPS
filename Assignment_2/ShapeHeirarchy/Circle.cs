public class Circle: Shape
{
    public double Radius { get; set; }

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
    public override double CalculateArea()
    {
        //return base.CalculateArea();
        return Math.PI * Radius * Radius;
    }

    public override string PrintDetails() => $"The shape is:{this.GetType().Name} \n,The Color is: {Color} \n, The Area is: {CalculateArea()}";

} 
namespace B_MathApplication
{
    public class MathematicalOperations
    {
        public static int Add(int x, int y) => x + y;

        public static int Subtract(int x, int y) => x - y;

        public static int Multiply(int x, int y) => x * y;

        public static int Divide(int x, int y)
        {
            if (y == 0)
            { 
                throw new DivideByZeroException("Divisor cannot be zero");
            }

            return x / y;
        }
    }
}

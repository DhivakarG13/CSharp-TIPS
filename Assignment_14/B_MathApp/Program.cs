using C_DisplayApp;

namespace B_MathApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MathematicalOperations mathematicalOperations = new MathematicalOperations();
            Display
        }
        public class MathematicalOperations
        {
            public int Add(int x, int y) => x + y;

            public int Substract(int x, int y) => x - y;

            public int Multiply(int x, int y) => x * y;

            public int Divide(int x, int y) => x / y;   
        }
    }
}

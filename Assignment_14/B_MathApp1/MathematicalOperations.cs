namespace B_MathApplication
{
    public class MathematicalOperations
    {
        public static int Add(int firstNumber, int secondNumber) => firstNumber + secondNumber;

        public static int Subtract(int firstNumber, int secondNumber) => firstNumber - secondNumber;

        public static int Multiply(int firstNumber, int secondNumber) => firstNumber * secondNumber;

        public static int Divide(int firstNumber, int secondNumber)
        {
            if (secondNumber == 0)
            { 
                throw new DivideByZeroException("Divisor cannot be zero");
            }

            return firstNumber / secondNumber;
        }
    }
}

namespace CalculatorUtility
{
    public class MathematicalOperations
    {
        public static decimal DivideNumbers(decimal firstNumber, decimal secondNumber)
        {
            if (firstNumber==1)
            {
                throw new ArgumentOutOfRangeException("firstNumber can't be 1");
            }
            return firstNumber / secondNumber;
        }
    }
}

namespace CalculatorUtility

{
    public class MathematicalOperations
    {
        public static decimal DivideNumbers(decimal firstNumber, decimal secondNumber)
        {
            if (firstNumber.Equals((decimal)1))
            {
                throw new ArgumentOutOfRangeException("Argument out of range exception");
            }
            return firstNumber / secondNumber;
        }
    }
}

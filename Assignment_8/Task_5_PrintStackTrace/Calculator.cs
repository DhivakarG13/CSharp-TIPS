namespace Task_5
{
    public static class Calculator
    {
        public static int MathematicalOperation(int numericalInput)
        {
            if (numericalInput == 0)
            {
                throw new DivideByZeroException("Dividing by Zero is not allowed");
            }
            return (5 * 10 / numericalInput);
        }
    }
}

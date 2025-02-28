namespace DynamicObjectInspector.Helpers
{
    public class ValidationUtility
    {
        public static bool ValidateInput(string input, Type typeOfInput)
        {
            if (typeOfInput == typeof(int))
            {
                if (int.TryParse(input, out _))
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    return false;
                }
            }
            else if (typeOfInput == typeof(double))
            {
                if (double.TryParse(input, out _))
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    return false;
                }
            }
            else if (typeOfInput == typeof(float))
            {
                if (float.TryParse(input, out _))
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    return false;
                }
            }
            else if (typeOfInput == typeof(string))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid Input");
                return false;
            }
        }
    }
}
namespace DynamicObjectInspector.Helpers
{
    public class ValidationUtility
    {
        public static bool ValidateInput(string userInput, Type typeOfInput)
        {
            if (typeOfInput == typeof(int))
            {
                if (int.TryParse(userInput, out _))
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
                if (double.TryParse(userInput, out _))
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
                if (float.TryParse(userInput, out _))
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
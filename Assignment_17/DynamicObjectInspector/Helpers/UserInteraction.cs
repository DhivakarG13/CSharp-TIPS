namespace DynamicObjectInspector.Helpers
{
    public class UserInteraction
    {
        public static dynamic GetNewValue(Type typeOfInput)
        {
            Console.Write($"Enter New value to change (Expected type {typeOfInput.Name}): ");
            bool isValidInput = false;
            string? userInput = string.Empty;
            while (!isValidInput)
            {
                userInput = Console.ReadLine();
                isValidInput = ValidationUtility.ValidateInput(userInput, typeOfInput);
            }
            return Convert.ChangeType(userInput, typeOfInput);
        }
    }
}
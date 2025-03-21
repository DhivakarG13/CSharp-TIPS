namespace DynamicObjectInspector.Helpers
{
    public class UserInteraction
    {
        public static dynamic GetNewValue(Type typeOfInput)
        {
            bool isValidInput;
            string? userInput;

            do
            {
                Console.Write($"Enter New value to change (Expected type {typeOfInput.Name}): ");
                userInput = Console.ReadLine();
                isValidInput = ValidationUtility.ValidateInput(userInput, typeOfInput);
            }
            while (!isValidInput);

            return Convert.ChangeType(userInput, typeOfInput);
        }
    }
}
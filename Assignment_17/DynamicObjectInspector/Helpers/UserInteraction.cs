namespace DynamicObjectInspector.Helpers
{
    public class UserInteraction
    {
        public static dynamic GetNewValue(Type typeOfInput)
        {
            Console.Write($"Enter New value to change (Expected type {typeOfInput.Name}): ");
            bool isValidInput = false;
            string? input = string.Empty;
            while (!isValidInput)
            {
                input = Console.ReadLine();
                isValidInput = ValidationUtility.ValidateInput(input, typeOfInput);
            }
            return Convert.ChangeType(input, typeOfInput);
        }
    }
}
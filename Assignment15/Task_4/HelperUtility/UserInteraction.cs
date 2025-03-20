namespace Task_4.HelperUtility
{
    public static class UserInteraction
    {
        public static void DisplayDialog(Enum dialogToDisplay)
        {
            int index = 0;
            foreach (string option in Enum.GetNames(dialogToDisplay.GetType()))
            {
                Console.WriteLine($"[{++index}] " + option);
            }
        }

        public static int GetUserChoice()
        {
            int userChoice = default;
            Console.Write("\nEnter your Choice : ");
            while (!int.TryParse(Console.ReadLine(), out userChoice))
            {
                Console.Write("Invalid input. Please try again. : ");
            }
            return userChoice;
        }
    }
}


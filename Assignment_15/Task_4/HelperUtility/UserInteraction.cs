namespace Task_4.HelperUtility
{
    public static class UserInteraction
    {
        /// <summary>
        /// Displays the values in enum provided.
        /// </summary>
        /// <param name="dialogToDisplay"></param>
        public static void DisplayDialog(Enum dialogToDisplay)
        {
            int optionIndex = 0;
            foreach (string option in Enum.GetNames(dialogToDisplay.GetType()))
            {
                Console.Write($"[{++optionIndex}]");
                foreach(char character in  option)
                {
                    if(char.IsUpper(character))
                    {
                        Console.Write(" ");
                    }
                    Console.Write(character);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Prompts the user for numerical input until a valid input is provided.
        /// </summary>
        /// <returns></returns>
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


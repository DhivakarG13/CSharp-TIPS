namespace C_DisplayApplication
{
    public static class DisplayUtility
    {
        public static void PrintInputTitle(string title)
        {
            Console.Write(title + " : ");
        }

        public static void PrintDialog(Enum dialogType)
        {
            int index = 1;
            foreach (string value in Enum.GetNames(dialogType.GetType()))
            {
                Console.Write($"[{index}]");
                foreach(char character in value)
                {
                    if(char.IsUpper(character))
                    {
                        Console.Write(" ");
                    }
                    Console.Write(character);
                }
                index++;
            }
            Console.WriteLine("\n\n");
        }

        public static void PrintData(object dataToPrint)
        {
            Console.WriteLine("Your Output :" + dataToPrint);
        }

        public static void PrintError(string errorMessage)
        {
            Console.WriteLine("Error : " + errorMessage);
        }
    }
}

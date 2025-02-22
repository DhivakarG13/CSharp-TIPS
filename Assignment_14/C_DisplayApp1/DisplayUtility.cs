namespace C_DisplayApp
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
                Console.WriteLine($":     [{index}] {value}   ");
                index++;
            }
            Console.WriteLine("\n\n");
        }

        public static void PrintData(object Data)
        {
            Console.WriteLine("Your Output :" + Data);
        }

        public static void PrintError(string errorMessage)
        {
            Console.WriteLine("Error : " + errorMessage);
        }
    }
}

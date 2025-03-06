using System.Reflection.Emit;
using System.Reflection;
using Constants;
using MainApp.Controllers;
using MainApp.Helpers;

namespace MainApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            while (true)
            {
                UserInteraction.PrintDialog(new MainMenu());
                MainMenu userChoice = (MainMenu)UserInteraction.GetUserChoice();
                if (userChoice == MainMenu.Exit)
                {
                    break;
                }
                controller.RunMainApp(userChoice);
            }
        }
    }
}

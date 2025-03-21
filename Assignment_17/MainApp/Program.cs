using Constants;
using MainApplication.Controllers;
using MainApplication.Helpers;

namespace MainApplication
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

                controller.RunMainApplication(userChoice);
            }
        }
    }
}

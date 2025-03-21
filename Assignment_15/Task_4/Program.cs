using System.Diagnostics;
using Task_4.HelperUtility;
using Task_4.HelperUtility.Enumerations;

namespace Task_4
{
    public class Program
    {
        static void Main(string[] args)
        {
            Logger jackLogger = new Logger("Jack", "001");
            Logger janeLogger = new Logger("Jane", "002");
            Logger jessLogger = new Logger("Jess", "003");
            Logger jonesLogger = new Logger("Jones", "004");
            bool canExit = false;

            while (!canExit)
            {
                MainDialog mainDialog = new MainDialog();
                UserInteraction.DisplayDialog(mainDialog);
                MainDialog choice = (MainDialog)UserInteraction.GetUserChoice();

                switch (choice)
                {
                    case MainDialog.LogInAsJack:
                        Task t1 = jackLogger.LogErrorAsync("Jack : An Error Occurred " + DateTime.Now);
                        break;

                    case MainDialog.LogInAsJane:
                        Task t2 = janeLogger.LogErrorAsync("Jane : An Error Occurred " + DateTime.Now);
                        break;

                    case MainDialog.LogInAsJess:
                        Task t3 = jessLogger.LogErrorAsync("Jess : An Error Occurred " + DateTime.Now);
                        break;

                    case MainDialog.LogInAsJones:
                        Task t4 = jonesLogger.LogErrorAsync("Jones : An Error Occurred " + DateTime.Now);
                        break;

                    case MainDialog.TestPerformanceForOneLogFileForAllUsers:
                        TestPerformanceForOneLogFileForAllUsers();
                        break;

                    case MainDialog.TestPerformanceForUniqueLogFileForEachUser:
                        TestPerformanceForUniqueLogFileForEachUser(jackLogger, janeLogger, jessLogger, jonesLogger);
                        break;

                    case MainDialog.Exit:
                        canExit = true;
                        break;

                }

                Console.WriteLine("\n\nPress any key to continue.");
                Console.ReadLine();
                Console.Clear();
            }
        }

        /// <summary>
        /// Creates one file and asynchronously tries to log four times at a same time in that single file.
        /// </summary>
        public static void TestPerformanceForOneLogFileForAllUsers()
        {
            Logger logger = new Logger("Test", "005");
            Task[] tasks = new Task[4];
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();

            for (int i = 0; i < 4; i++)
            {
                tasks[i] = logger.LogErrorAsync("Test : An Error Occurred ");
            }

            Task.WaitAll(tasks);
            stopwatch1.Stop();
            Console.WriteLine("Time taken to log errors for all users in a single File : " + stopwatch1.ElapsedMilliseconds + "ms");
        }

        /// <summary>
        /// Gets four fileLogger objects each has its own file and asynchronously logs on respective files.
        /// </summary>
        /// <param name="jackLogger"></param>
        /// <param name="janeLogger"></param>
        /// <param name="jessLogger"></param>
        /// <param name="jonesLogger"></param>
        public static void TestPerformanceForUniqueLogFileForEachUser(Logger jackLogger, Logger janeLogger, Logger jessLogger, Logger jonesLogger)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Task t2 = jonesLogger.LogErrorAsync("Jones : An Error Occurred ");
            Task t3 = jessLogger.LogErrorAsync("Jess : An Error Occurred ");
            Task t4 = janeLogger.LogErrorAsync("Jane : An Error Occurred ");
            Task t5 = jackLogger.LogErrorAsync("Jack : An Error Occurred ");
            Task.WaitAll(t2, t3, t4, t5);
            stopwatch.Stop();
            Console.WriteLine("Time taken to log errors for each user in respective Files : " + stopwatch.ElapsedMilliseconds + "ms");
        }
    }
}


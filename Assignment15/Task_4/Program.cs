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
            bool isExit = false;

            while (!isExit)
            {
                UserInteraction.DisplayDialog(new MainDialog());
                MainDialog choice = (MainDialog)UserInteraction.GetUserChoice();

                switch (choice)
                {
                    case MainDialog.Log_in_as_Jack:
                        {
                            Task T = Task.Run(() => jackLogger.LogErrorAsync("Jack : An Error Occurred " + DateTime.Now));
                            break;
                        }
                    case MainDialog.Log_in_as_Jane:
                        {
                            Task T = Task.Run(() => janeLogger.LogErrorAsync("Jane : An Error Occurred " + DateTime.Now));
                            break;
                        }
                    case MainDialog.Log_in_as_Jess:
                        {
                            Task T = Task.Run(() => jessLogger.LogErrorAsync("Jess : An Error Occurred " + DateTime.Now));
                            break;
                        }
                    case MainDialog.Log_in_as_Jones:
                        {
                            Task T = Task.Run(() => jonesLogger.LogErrorAsync("Jones : An Error Occurred " + DateTime.Now));
                            break;
                        }
                    case MainDialog.Test_Performance_for_OneLogFile_ForAllUsers:
                        {
                            Logger logger = new Logger("Test", "005");
                            Task[] tasks = new Task[4];
                            Stopwatch stopwatch1 = new Stopwatch();
                            stopwatch1.Start();
                            for (int i = 0; i < 4; i++)
                            {
                                tasks[i] = Task.Run(() => logger.LogErrorAsync("Test : An Error Occurred "));
                            }
                            Task.WaitAll(tasks);
                            stopwatch1.Stop();
                            Console.WriteLine("Time taken to log errors for all users in a single File : " + stopwatch1.ElapsedMilliseconds + "ms");
                            break;
                        }
                    case MainDialog.Test_Performance_for_UniqueLogFIle_ForEachUser:
                        {
                            Stopwatch stopwatch = new Stopwatch();
                            stopwatch.Start();
                            Task T2 = Task.Run(() => jonesLogger.LogErrorAsync("Jones : An Error Occurred "));
                            Task T3 = Task.Run(() => jessLogger.LogErrorAsync("Jess : An Error Occurred "));
                            Task T4 = Task.Run(() => janeLogger.LogErrorAsync("Jane : An Error Occurred "));
                            Task T5 = Task.Run(() => jackLogger.LogErrorAsync("Jack : An Error Occurred "));
                            Task.WaitAll(T2, T3, T4, T5);
                            stopwatch.Stop();
                            Console.WriteLine("Time taken to log errors for each user in respective Files : " + stopwatch.ElapsedMilliseconds + "ms");
                            break;
                        }
                    case MainDialog.Exit:
                        {
                            isExit = true;
                            break;
                        }
                }
                Console.WriteLine("\n\nPress any key to continue.");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}


namespace Task_4
{
    public class Logger
    {
        private string _userName;
        private string _userId;
        private string _logFilePath;

        public Logger(string userName, string userId)
        {
            _userName = userName;
            _userId = userId;
            _logFilePath = userName + userId + ".txt";
        }

        public void LogErrorAsync(string errorMessage)
        {
            lock (_logFilePath)
            {
                Thread.Sleep(1000);
                using (FileStream fileStream = new FileStream(_logFilePath, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter streamWriter = new StreamWriter(fileStream))
                    {
                        streamWriter.WriteLine(errorMessage + " " + DateTime.Now);
                    }
                }
            }
        }
    }
}


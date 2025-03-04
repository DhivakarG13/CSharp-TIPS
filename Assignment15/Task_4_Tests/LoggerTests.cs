using Task_4;

namespace Task_4_Tests
{
    public class LoggerTests
    {
        [Fact]
        public void ErrorMessage_LogErrorAsync_LogsTheErrorInUsersFile()
        {
            Logger testLogger = new Logger("TestUser","001");
            string expectedFileName = "TestUser001.txt";

            testLogger.LogErrorAsync("An error occurred");
            string fileData = File.ReadAllText(expectedFileName);

            Assert.True(File.Exists(expectedFileName));
            Assert.Contains("An error occurred", fileData);
        }

        [Fact]
        public void MultipleConcurrentLogInSingleFile_LogErrorAsync_LogsTheErrorInUsersFile()
        {
            Logger testLogger = new Logger("TestUser", "002");
            string expectedFileName = "TestUser002.txt";

            Task t1 = Task.Run(() => testLogger.LogErrorAsync("An error occurred 1"));
            Task t2 = Task.Run(() => testLogger.LogErrorAsync("An error occurred 2"));
            Task t3 = Task.Run(() => testLogger.LogErrorAsync("An error occurred 3"));
            Task t4 = Task.Run(() => testLogger.LogErrorAsync("An error occurred 4"));
            string fileData = File.ReadAllText(expectedFileName);

            Task.WaitAll(t1,t2, t3, t4);

            Assert.True(File.Exists($"C:\\Users\\Dhivakar.gopi\\Desktop\\Assignment15\\Task_4_Tests\\bin\\Debug\\net8.0\\{expectedFileName}"));
            Assert.Contains("An error occurred 1", fileData);
            Assert.Contains("An error occurred 2", fileData);
            Assert.Contains("An error occurred 3", fileData);
            Assert.Contains("An error occurred 4", fileData);
        }

        [Fact]
        public void MultipleUserConcurrentLogIn_LogErrorAsync_LogsTheErrorInRespectiveFile()
        {
            Logger testLogger1 = new Logger("TestUser", "003");
            Logger testLogger2 = new Logger("TestUser", "004");
            Logger testLogger3 = new Logger("TestUser", "005");
            Logger testLogger4 = new Logger("TestUser", "006");
            string expectedFileName1 = "TestUser003.txt";
            string expectedFileName2 = "TestUser004.txt";
            string expectedFileName3 = "TestUser005.txt";
            string expectedFileName4 = "TestUser006.txt";

            Task t1 = Task.Run(() => testLogger1.LogErrorAsync("An error occurred 1"));
            Task t2 = Task.Run(() => testLogger2.LogErrorAsync("An error occurred 2"));
            Task t3 = Task.Run(() => testLogger3.LogErrorAsync("An error occurred 3"));
            Task t4 = Task.Run(() => testLogger4.LogErrorAsync("An error occurred 4"));
            Task.WaitAll(t1, t2, t3, t4);
            string fileData1 = File.ReadAllText(expectedFileName1);
            string fileData2 = File.ReadAllText(expectedFileName2);
            string fileData3 = File.ReadAllText(expectedFileName3);
            string fileData4 = File.ReadAllText(expectedFileName4);
            string[] files = Directory.GetFiles("C:\\Users\\Dhivakar.gopi\\Desktop\\Assignment15\\Task_4_Tests\\bin\\Debug\\net8.0");

            Assert.Contains(expectedFileName1, files.Select(Path.GetFileName));
            Assert.Contains(expectedFileName2, files.Select(Path.GetFileName));
            Assert.Contains(expectedFileName3, files.Select(Path.GetFileName));
            Assert.Contains(expectedFileName4, files.Select(Path.GetFileName));
            Assert.Contains("An error occurred 1", fileData1);
            Assert.Contains("An error occurred 2", fileData2);
            Assert.Contains("An error occurred 3", fileData3);
            Assert.Contains("An error occurred 4", fileData4);
        }
    }
}
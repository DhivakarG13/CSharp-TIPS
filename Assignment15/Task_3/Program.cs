namespace Task3
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filePath = "newFile.txt";
            string dataToWrite = "This is some test data";
            using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.Write(dataToWrite);
                    streamWriter.Flush();
                    fileStream.Flush();
                }
            }
            using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    string? lineData;
                    while ((lineData = streamReader.ReadLine()) != null)
                    {
                        Console.WriteLine(lineData);
                    }
                }
            }
        }
    }
}

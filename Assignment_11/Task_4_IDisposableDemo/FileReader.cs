namespace Task_4_IDisposableDemo
{
    public class FileReader : IDisposable
    {
        StreamReader _streamReader;
        string? FilePath;
        List<string>? fileData;

        public FileReader(string filePath)
        {
            _streamReader = new StreamReader(filePath);
            FilePath = filePath;
            fileData = File.ReadAllLines(FilePath).ToList();
        }

        public string? ReadLineFromFile(int lineNumber)
        {
            if (fileData.Count() == 0 || lineNumber >= fileData.Count())
                return null;
            return fileData[lineNumber];
        }

        public void Dispose()
        {
            _streamReader.Dispose();
        }
    }
}

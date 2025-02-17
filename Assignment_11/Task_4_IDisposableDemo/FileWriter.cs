namespace Task_4_IDisposableDemo
{
    public class FileWriter : IDisposable
    {
        StreamWriter _streamWriter;

        public FileWriter(string filePath)
        {
            _streamWriter = new StreamWriter(filePath);
        }

        public void Write(string text)
        {
            _streamWriter.WriteLine(text);
        }

        public void Dispose()
        {
            _streamWriter.Dispose();
        }
    }
}

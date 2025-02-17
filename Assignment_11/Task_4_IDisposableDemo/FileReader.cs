namespace Task_4_IDisposableDemo
{
    public class FileReader : IDisposable
    {
        StreamReader _streamReader;

        public FileReader(string filePath)
        {
            _streamReader = new StreamReader(filePath);
        }       
        
        public string? ReadLineFromFile(int lineNumber)
        {
            _streamReader.DiscardBufferedData();
            _streamReader.BaseStream.Seek(0, SeekOrigin.Begin);

            for(int i=0;i<lineNumber; i++)
            {
                _streamReader.ReadLine();
            }
            return _streamReader.ReadLine();
        }

        public void Dispose()
        {
            _streamReader.Dispose();
        }
    }
}

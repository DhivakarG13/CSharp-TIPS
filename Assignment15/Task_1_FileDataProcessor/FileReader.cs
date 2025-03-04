namespace FileDataProcessor
{
    public class FileReader
    {

        public void ReadFileUsingFileStream(string fileName)
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    string? lineData;
                    while ((lineData = streamReader.ReadLine()) != null) { }
                }
            }
        }

        public void ReadFileUsingBufferedStream(string fileName)
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (BufferedStream bufferedStream = new BufferedStream(fileStream))
                {
                    using (StreamReader streamReader = new StreamReader(bufferedStream))
                    {
                        string? lineData;
                        while ((lineData = streamReader.ReadLine()) != null) { }
                    }
                }
            }
        }
    }
}
namespace FileDataProcessor
{
    public class FileReader
    {
        /// <summary>
        /// Gets the file name and reads the file completely using FileStream.
        /// </summary>
        /// <param name="fileName"></param>
        public void ReadFileUsingFileStream(string fileName)
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    string? lineData;
                    while ((lineData = streamReader.ReadLine()) != null) { }
                }
            }
        }

        /// <summary>
        /// Gets the file name and reads the file completely using BufferedStream.
        /// </summary>
        /// <param name="fileName"></param>
        public void ReadFileUsingBufferedStream(string fileName)
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read))
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
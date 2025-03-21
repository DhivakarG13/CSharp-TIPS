namespace FileDataProcessor
{
    public class FileReader
    {
        /// <summary>
        /// Gets the file name and reads the file using FileStream.
        /// </summary>
        /// <param name="fileToRead"></param>
        /// <returns></returns>
        public async Task ReadFileUsingFileStreamAsync(string fileToRead)
        {
            using (FileStream fileStream = new FileStream(fileToRead, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    string? lineData;
                    while ((lineData = await streamReader.ReadLineAsync()) != null) { }
                }
            }
        }

        /// <summary>
        /// Gets the file name and reads the file using BufferedStream.
        /// </summary>
        /// <param name="fileToRead"></param>
        /// <returns></returns>
        public async Task ReadFileUsingBufferedStreamAsync(string fileToRead)
        {
            using (FileStream fileStream = new FileStream(fileToRead, FileMode.Open, FileAccess.Read))
            {
                using (BufferedStream bufferedStream = new BufferedStream(fileStream))
                {
                    using (StreamReader streamReader = new StreamReader(bufferedStream))
                    {
                        string? lineData;
                        while ((lineData = await streamReader.ReadLineAsync()) != null) { }
                    }
                }
            }
        }
    }
}

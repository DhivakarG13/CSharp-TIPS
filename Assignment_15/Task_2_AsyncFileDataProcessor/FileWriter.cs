using System.Text;

namespace FileDataProcessor
{
    public class FileWriter
    {
        /// <summary>
        /// Gets the file name and creates a text file of size 1GB asynchronously.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task CreateOrWriteFileAsync(string fileName)
        {
            using (StreamWriter streamWriter = new StreamWriter(fileName))
            {
                for (int iterationIndex = 0; iterationIndex < 128 * 1024 * 1024; iterationIndex++)
                {
                    await streamWriter.WriteLineAsync("Laptops");
                }
            }
        }

        /// <summary>
        /// Gets the new file and old file name copies the data of old file to new file using MemoryStream asynchronously.
        /// </summary>
        /// <param name="oldFileName"></param>
        /// <param name="newFileName"></param>
        /// <returns></returns>
        public async Task ProcessFileDataAsync(string oldFileName, string newFileName)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (FileStream fileStream = new FileStream(oldFileName, FileMode.OpenOrCreate, FileAccess.Read))
                {
                    using (StreamReader streamReader = new StreamReader(fileStream))
                    {
                        string? lineData;
                        while ((lineData = streamReader.ReadLine()) != null)
                        {
                            byte[] lineBytes = Encoding.UTF8.GetBytes(lineData.ToUpper() + Environment.NewLine);
                            await memoryStream.WriteAsync(lineBytes, 0, lineBytes.Length);
                        }
                    }
                }

                memoryStream.Position = 0;

                using (FileStream fileStream = new FileStream(newFileName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    memoryStream.WriteTo(fileStream);
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldFileName"></param>
        /// <param name="newFileName"></param>
        /// <returns></returns>
        public async Task ProcessFileDataAsyncAlternate(string oldFileName, string newFileName)
        {
            using (FileStream fileStream1 = new FileStream(oldFileName, FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (FileStream fileStream2 = new FileStream(newFileName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (StreamReader streamReader = new StreamReader(fileStream1, bufferSize: 4096))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(fileStream2, bufferSize: 4096))
                        {
                            string? lineData;
                            while ((lineData = await streamReader.ReadLineAsync()) != null)
                            {
                                await streamWriter.WriteLineAsync(lineData.ToUpper());
                            }

                        }
                    }
                }
            }
        }

    }
}

using System.Text;

namespace FileDataProcessor
{
    public class FileWriter
    {
        public async Task CreateOrWriteFileAsync(string fileName)
        {
            using (StreamWriter streamWriter = new StreamWriter(fileName))
            {
                for (int iterationIndex = 0; iterationIndex < 128 * 1024; iterationIndex++)
                {
                    await streamWriter.WriteLineAsync("Laptops");
                }
            }
        }

        public async Task ProcessFileDataAsync(string oldFileName, string newFileName)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {

                using (FileStream fileStream = new FileStream(oldFileName, FileMode.Open, FileAccess.Read))
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
                using (FileStream fs = new FileStream(newFileName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    memoryStream.WriteTo(fs);
                }
            }

        }

        public async Task ProcessFileDataAsyncAlternate(string oldFileName, string newFileName)
        {
            using (FileStream fileStream1 = new FileStream(oldFileName, FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (FileStream fileStream2 = new FileStream(newFileName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (StreamReader streamReader = new StreamReader(fileStream1))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(fileStream2))
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

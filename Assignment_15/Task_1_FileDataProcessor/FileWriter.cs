using System.Text;

namespace FileDataProcessor
{
    public class FileWriter
    {
        /// <summary>
        /// Gets the file name and creates a text file of size 1GB.
        /// </summary>
        /// <param name="fileName"></param>
        public void CreateOrWriteFile(string fileName)
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    for (int iterationIndex = 0; iterationIndex < 128 * 1024 * 1024; iterationIndex++)
                    {
                        streamWriter.WriteLine("Laptops");
                    }
                }
            }
        }

        /// <summary>
        /// Gets the new file and old file name copies the data of old file to new file using MemoryStream.
        /// </summary>
        /// <param name="oldFileName"></param>
        /// <param name="newFileName"></param>
        public void ProcessFileData(string oldFileName, string newFileName)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (FileStream readFileStream = new FileStream(oldFileName, FileMode.OpenOrCreate, FileAccess.Read))
                {
                    using (StreamReader streamReader = new StreamReader(readFileStream))
                    {
                        string? line;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            byte[] lineBytes = Encoding.UTF8.GetBytes(line.ToUpper() + Environment.NewLine);
                            memoryStream.Write(lineBytes, 0, lineBytes.Length);
                        }
                    }
                }

                memoryStream.Position = 0;

                using (FileStream writeFileStream = new FileStream(newFileName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    memoryStream.WriteTo(writeFileStream);
                }
            }
        }
    }
}
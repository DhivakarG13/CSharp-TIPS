using System.Text;

namespace FileDataProcessor
{
    public class FileWriter
    {
        public void CreateOrWriteFile(string fileName)
        {
            using (StreamWriter streamWriter = new StreamWriter(fileName))
            {
                for (int iterationIndex = 0; iterationIndex < 128 * 1024 * 1024; iterationIndex++)
                {
                    streamWriter.WriteLine("Laptops");
                }
            }
        }

        public void ProcessFileData(string oldFileName, string newFileName)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (FileStream readFileStream = new FileStream(oldFileName, FileMode.Open, FileAccess.Read))
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
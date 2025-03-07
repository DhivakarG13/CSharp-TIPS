using System.Net;

namespace Assignment_18
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            WebDataFetchUtility webDataFetchUtility = new WebDataFetchUtility();
            try
            {
                string DataFromWeb = await webDataFetchUtility.FetchDataFromLink("https://en.wikipedia.org/wiki/C_Sharp_(programming_language)");
                Console.WriteLine(DataFromWeb);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine("Resource not found.");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An UnExpected error occurred: {ex.Message}");
            }
            Console.WriteLine("Press Any Key To Close");
            Console.ReadKey();
        }
    }
}
using System.Threading.Channels;

namespace MultiLayered_Async_Await
{
    public class Program
    {
        static void Main(string[] args)
        {
            Task<int> t1 = Task.Run(() => JsonParser());
            while (true)
            {
                Console.WriteLine
                    (
                    $"[1]CalculateSquare\n" +
                    $"[2]Print the count of K-V pairs \n" +
                    $"[3]Exit"
                    );
                Console.Write("\nEnter Your Choice : ");
                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter a Number:");
                        string? input = Console.ReadLine();
                        int n;
                        if (int.TryParse(input, out n) && !String.IsNullOrEmpty(input))
                        {
                            Console.WriteLine($"{n * n}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input");
                        }
                        break;

                    case "2":
                        if (t1.IsCompleted)
                        {
                            Console.WriteLine(t1.Result);
                        }
                        else
                        {
                            Console.WriteLine("Task is still running.");
                        }
                        break;

                    case "3":
                        return;

                    default:
                        break;
                }
                Console.WriteLine("\n");
            }

        }

        public static async Task<(int, int)> CalculateTriangularNumber()
        {
            return await Task.Run(() =>
            {
                int[] triangularNumbers = new int[100000];
                for (int i = 1; i <= triangularNumbers.Length; i++)
                {
                    int triangularNumber = 0;
                    for (int j = 1; j <= i; j++)
                    {
                        triangularNumber += j;
                    }
                    triangularNumbers[i - 1] = triangularNumber;
                }
                return (10, 5);
            });
        }

        public static async Task<string> FetchDataFromLink()
        {
            (int, int) location = await CalculateTriangularNumber();
            string apiKey = "df8957ef440390db71da759941d9c59e";
            string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?lat={location.Item1}&lon={location.Item2}&appid={apiKey}";
            string jsonString = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    jsonString = responseBody;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request error: {e.Message}");
                }
            }
            return jsonString;
        }

        public static async Task<int> JsonParser()
        {
            string dataInLink = await FetchDataFromLink();
            int count = 0;
            foreach (char character in dataInLink)
            {
                if (character == ':')
                {
                    count++;
                }
            }
            return count;
        }
    }
}
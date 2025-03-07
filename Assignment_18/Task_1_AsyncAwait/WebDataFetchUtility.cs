namespace Assignment_18
{
    public class WebDataFetchUtility
    {
        public async Task<string> FetchDataFromLink(string url)
        {
            string content = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    content= await response.Content.ReadAsStringAsync();
            }
            return content;
        }
    }
}
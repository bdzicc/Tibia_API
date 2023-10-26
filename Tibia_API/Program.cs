namespace Tibia_API
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var requestURL = @"https://www.tibia.com/community/?name=sunrise";
            HttpClient client = new HttpClient();

            HttpResponseMessage reqResp = await client.GetAsync(requestURL);

            if (reqResp.IsSuccessStatusCode)
            {
                HttpContent content = reqResp.Content;
                var result = await content.ReadAsStringAsync();
            }



        }
    }
}
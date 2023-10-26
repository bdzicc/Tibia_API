using System.Net.Http.Headers;

namespace Tibia_API
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var requestURL = @"https://www.tibia.com/community/?name=sunrise";
            HttpClient client = new HttpClient();

            //Set request headers TODO: clean up unnecessary headers, copied all from fiddler for now to avoid 403
            client.DefaultRequestHeaders.Add("Host", "www.tibia.com");
            client.DefaultRequestHeaders.Add("Connection", "keep-alive");
            client.DefaultRequestHeaders.Add("Cache-Control", "max-age=0");
            client.DefaultRequestHeaders.Add("sec-ch-ua", @"""Chromium""; v = ""118"", ""Google Chrome""; v = ""118"", ""Not=A?Brand""; v = ""99""");
            client.DefaultRequestHeaders.Add("sec-ch-ua-mobile", "?0");
            client.DefaultRequestHeaders.Add("sec-ch-ua-platform", "Windows");
            client.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
            client.DefaultRequestHeaders.Add("User-Agent", @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/118.0.0.0 Safari/537.36");
            client.DefaultRequestHeaders.Add("Accept", @"text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
            client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "none");
            client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "navigate");
            client.DefaultRequestHeaders.Add("Sec-Fetch-User", "?1");
            client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "document");
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
            client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.9");

            HttpResponseMessage reqResp = await client.GetAsync(requestURL);

            if (reqResp.IsSuccessStatusCode)
            {
                HttpContent content = reqResp.Content;
                var result = await content.ReadAsStringAsync();
            }
        }
    }
}
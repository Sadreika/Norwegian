using System;
using System.Net;
using System.Net.Http;

namespace Norwegian
{
    public class Crawler
    {
        private string url = "https://www.norwegian.com/uk/";
        private HttpClient client = new HttpClient();

        public async System.Threading.Tasks.Task crawlingAsync()
        {
            client.DefaultRequestHeaders.Add("Host", "www.norwegian.com");
            client.DefaultRequestHeaders.Add("UserAgent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:81.0) Gecko/20100101 Firefox/81.0");
            client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            client.DefaultRequestHeaders.Add("Accept-Language", "lt,en-US;q=0.8,en;q=0.6,ru;q=0.4,pl;q=0.2");
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
            client.DefaultRequestHeaders.Add("DNT", "1");
            client.DefaultRequestHeaders.Add("Connection", "keep-alive");
            client.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");

            string content = await client.GetStringAsync(url);   
            Console.WriteLine(content);
        
        }
    }
}

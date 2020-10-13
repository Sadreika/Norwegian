using RestSharp;
using System;
using System.Net;

namespace Norwegian
{
    public class Crawler
    {
        private string url = "https://www.norwegian.com";
        private RestClient client = new RestClient();
        public void GETMethodCrawl(RestClient client, string query)
        {
            RestRequest request = new RestRequest(query, Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.StatusCode);
        }

        public void crawling()
        {
            client.BaseUrl = new Uri(url, UriKind.Absolute);
            //client.Proxy = new WebProxy("1.0.183.218", 8080);

            client.BaseHost = "www.norwegian.com";
            client.ConnectionGroupName = "keep-alive";
            client.AddDefaultHeader("sec-ch-ua", "\"Chromium\";v=\"86\", \"\\\"Not\\\\A;Brand\";v=\"99\", \"Google Chrome\";v=\"86\"");
            client.AddDefaultHeader("sec-ch-ua-mobile", "?0");
            client.AddDefaultHeader("Upgrade-Insecure-Requests", "1");
            client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.75 Safari/537.36";
            client.AddDefaultHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            client.AddDefaultHeader("Sec-Fetch-Site", "cross-site");
            client.AddDefaultHeader("Sec-Fetch-Mode", "navigate");
            client.AddDefaultHeader("Sec-Fetch-User", "?1");
            client.AddDefaultHeader("Sec-Fetch-Dest", "document");

            client.AddDefaultHeader("Accept-Encoding", "gzip, deflate, br");
            client.AddDefaultHeader("Accept-Language", "en-US,en;q=0.9");

            GETMethodCrawl(client, "/uk/");
        }
    }
}
